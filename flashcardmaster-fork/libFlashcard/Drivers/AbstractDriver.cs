/*************************************************************************
 *  Flash Card Master
 *  Copyleft (C) 2006 Nithin Philips
 *
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU General Public License
 *  as published by the Free Software Foundation; either version 2
 *  of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation,Inc.,59 Temple Place - Suite 330,Boston,MA 02111-1307, USA.
 *
 *  Author            :  Nithin Philips <spikiermonkey@users.sourceforge.net>
 *  Original FileName :  AbstractDriver.cs
 *  Created           :  Thu Oct 05 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LibFlashcard.Model;
using Mono.Unix;

namespace LibFlashcard.Drivers
{
    /// <summary>
    /// Provides the base for Drivers that can read or write CardDeck objects to files or other medium.
    /// Use Create() static method to initialize a concrete instance.
    /// </summary>
    public abstract class AbstractDriver
    {
        //TODO: Although written like a pluggable architecture, we currently do not search for plugins.

        protected AbstractDriver(string path) {
            this.path = path;
        }

        protected bool canSerialize = false;
        protected bool canDeSerialize = false;
        protected bool canFullDeserialize = false;
        private string path;

        protected string Path {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// Specifies whether or not the driver can serialize card decks.
        /// </summary>
        public virtual bool CanSerialize {
            get { return canSerialize; }
        }

        /// <summary>
        /// Specifies whether or not the driver can deserialize card decks.
        /// </summary>
        public virtual bool CanDeSerialize {
            get { return canDeSerialize; }
        }

        /// <summary>
        /// Specifies whether or not the driver can fully deserialize card decks.
        /// A <code>true</code> value indicated loss of information during serializion.
        /// </summary>
        public virtual bool CanFullDeserialize {
            get { return canFullDeserialize; }
        }

        /// <summary>
        /// Deserializes the file specified by the <code>Path</code> property.
        /// </summary>
        /// <returns>The <code>CardDeck</code> object that was deserialized.</returns>
        public CardDeck DeSerialize() {
            return DeSerialize(this.path);
        }

        public CardDeck DeSerialize(string path) {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None)) {
                return DeSerialize(stream);
            }
        }

        public abstract CardDeck DeSerialize(Stream stream);

        public void Serialize(CardDeck deck) {
            Serialize(this.path, deck);
        }

        public void Serialize(string path, CardDeck deck) {
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)) {
                Serialize(stream, deck);
            }
        }

        public abstract void Serialize(Stream stream, CardDeck deck);

        /// <summary>
        /// Creates an appropriate Driver for the specified file, based on its extension as returned by Path.GetExtension() method.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A concrete Driver that can handle the given filetype.</returns>
        /// <exception cref="System.NotSupportedException">Thrown when no known Drivers are implemented for the gived filetype.</exception>
        public static AbstractDriver Create(string path) {
            Init();
            string ext = System.IO.Path.GetExtension(path);
            StringComparer comparer = StringComparer.CurrentCultureIgnoreCase;

            DriverAttributes current = null;
            for (int i = 0; i < drivers.Count; i++) {
                if (comparer.Compare(drivers[i].SupportedExtensions.Key, ext) == 0) {
                    current = drivers[i];
                    break;
                }
            }
            if (current == null) {
                throw new NotSupportedException(string.Format(Catalog.GetString("No handlers are implemented for type {0}.\nUnable to create handler for '{1}'"), ext, path));
            } else {
                return current.Create(path);
            }
        }

        public static bool SupportsFullSerialization(string ext) {
            Init();
            StringComparer comparer = StringComparer.CurrentCultureIgnoreCase;
            for (int i = 0; i < drivers.Count; i++) {
                if (comparer.Compare(drivers[i].SupportedExtensions.Key, ext) == 0) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Creates a list of all extensions supported by all registered drivers. This can be used as a Filter in Open/SaveFileDialogs.
        /// </summary>
        /// <param name="count">Indicates the number of supported file types.</param>
        /// <returns></returns>
        public static string GetReadersFilter(out int count) {
            Init();
            StringBuilder sb = new StringBuilder();
            string allExt = string.Empty;
            count = drivers.Count;
            for (int i = 0; i < drivers.Count; i++) {
                if (drivers[i].CanDeserialize) {
                    sb.AppendFormat("{1} (*{0})|*{0}|", drivers[i].SupportedExtensions.Key, drivers[i].SupportedExtensions.Value);
                    allExt += string.Format("*{0}", drivers[i].SupportedExtensions.Key);
                    if (i < drivers.Count - 1) { allExt += ";"; }
                }
            }
            //TODO: Localize.
            sb.AppendFormat(Catalog.GetString("All Supported formats") + "{0}", allExt);
            return sb.ToString();
        }

        public static string GetWritersFilter() {
            Init();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < drivers.Count; i++) {
                if (drivers[i].CanSerialize) {
                    sb.AppendFormat("{1} (*{0})|*{0}|", drivers[i].SupportedExtensions.Key, drivers[i].SupportedExtensions.Value);
                }
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static bool CanRead(string ext) {
            DriverAttributes dat = GetDriverAttributes(ext);
            if (dat != null) {
                return dat.CanDeserialize;
            } else {
                return false;
            }
        }

        public static bool CanWrite(string ext) {
            DriverAttributes dat = GetDriverAttributes(ext);
            if (dat != null) {
                return dat.CanSerialize;
            } else {
                return false;
            }
        }

        public static bool IsPartialSupport(string ext) {
            DriverAttributes dat = GetDriverAttributes(ext);
            if (dat != null) {
                return dat.PartialDeserialize;
            } else {
                return false;
            }
        }

        public static bool NeedKeyAnswer(string ext) {
            DriverAttributes dat = GetDriverAttributes(ext);
            if (dat != null) {
                return dat.NeedKeyAnswer;
            } else {
                return false;
            }
        }

        public static DriverAttributes GetDriverAttributes(string ext) {
            Init();
            for (int i = 0; i < drivers.Count; i++) {
                if (StringComparer.CurrentCultureIgnoreCase.Compare(drivers[i].SupportedExtensions.Key, ext) == 0) {
                    return drivers[i];
                }
            }
            return null;
        }

        static List<DriverAttributes> drivers;
        static void Init() {
            if (drivers != null) { return; }
            drivers = new List<DriverAttributes>();
            drivers.Add(new DriverAttributes(typeof(XmlDriver), new KeyValuePair<string, string>(".cml", Catalog.GetString("Card XML file")), true, true, false, false));
            drivers.Add(new DriverAttributes(typeof(CardDriver), new KeyValuePair<string, string>(".card", Catalog.GetString("Card file")), true, true, false, false));
            drivers.Add(new DriverAttributes(typeof(CsvDriver), new KeyValuePair<string, string>(".csv", Catalog.GetString("Comma seperated value file")), true, true, true, false));
            drivers.Add(new DriverAttributes(typeof(XhtmlDriver), new KeyValuePair<string, string>(".html", Catalog.GetString("XHTML file")), true, false, false, false));
            drivers.Add(new DriverAttributes(typeof(LaTeXDriver), new KeyValuePair<string, string>(".tex", Catalog.GetString("LaTeX file")), true, false, false, true));
            drivers.Add(new DriverAttributes(typeof(XfsDriver), new KeyValuePair<string, string>(".xfs", Catalog.GetString("Flash Card Pro file")), true, true, true, true));
        }

        /// <summary>
        /// Describes a driver class.
        /// </summary>
        public class DriverAttributes
        {

            public DriverAttributes(Type type, KeyValuePair<string, string> supportedExtensions, bool canSerialize, bool canDeserialize, bool partialDeserialize, bool needKeyAnswer) {
                this.type = type;
                this.supportedExtensions = supportedExtensions;
                this.canSerialize = canSerialize;
                this.canDeserialize = canDeserialize;
                this.partialDeserialize = partialDeserialize;
                this.needKeyAnswer = needKeyAnswer;
            }

            public AbstractDriver Create(string path) {
                return Activator.CreateInstance(type, path) as AbstractDriver;
            }

            Type type;
            KeyValuePair<string, string> supportedExtensions;
            bool canSerialize;
            bool canDeserialize;
            bool partialDeserialize;
            bool needKeyAnswer;

            public bool NeedKeyAnswer {
                get { return needKeyAnswer; }
            }

            public System.Collections.Generic.KeyValuePair<string, string> SupportedExtensions {
                get { return this.supportedExtensions; }
            }

            public bool CanSerialize {
                get { return this.canSerialize; }
            }

            public bool CanDeserialize {
                get { return this.canDeserialize; }
            }

            public bool PartialDeserialize {
                get { return this.partialDeserialize; }
            }
        }

    }
}
