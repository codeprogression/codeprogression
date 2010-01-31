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
 *  Original FileName :  XmlDriver.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.IO;
using System.Text;
using System.Xml;
using LibFlashcard.Model;
using LibFlashcard.Utilities;
using LibFlashcard.WikiText;

namespace LibFlashcard.Drivers
{
    /// <summary>
    /// Read and Writes CardDeck using XML file format
    /// </summary>
    public class XmlDriver: AbstractDriver
    {
        public XmlDriver(string path)
            : base(path) { }

        /// <summary>
        /// Constant string that are used in XML.
        /// </summary>
        internal sealed class XmlKeywords
        {
            private XmlKeywords() { }

            public const string CardML = "CardML";

            public const string CardDeck = "CardDeck";
            public const string Fields = "Fields";
            public const string Field = "Field";
            public const string Field_Name = "name";
            public const string Field_Index = "index";
            public const string Field_Type = "type";
            public const string Field_Side = "side";
            public const string Field_Position = "position";
            public const string Field_ForeColor = "forecolor";
            public const string Field_BackColor = "backcolor";

            public const string Cards = "Cards";
            public const string Card = "Card";
            public const string Card_Learned = "learned";
            public const string Card_Field = "CardField";
            public const string Card_Field_Name = "name";
            public const string Style = "Style";
            public const string Style_type = "type";

            public const string Br = "br";
        }

        XmlTextStyleProcessing styleProc = XmlTextStyleProcessing.ConvertToXml;
        bool useRgbColor = false;


        /// <summary>
        /// Set the method to handle wikistyle in text.
        /// Default is ConvertToXml
        /// </summary>
        public XmlTextStyleProcessing StyleProcessing {
            get { return styleProc; }
            set { styleProc = value; }
        }

        /// <summary>
        /// If true, System.Color value are serialized as rgb(r,g,b) instead of argb(a,r,g,b).
        /// </summary>
        public bool UseRgbColor {
            get { return useRgbColor; }
            set { useRgbColor = value; }
        }

        public override CardDeck DeSerialize(Stream stream) {
            CardDeckBuilder builder = new CardDeckBuilder();
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader schemaReader = XmlTextReader.Create(new StringReader(GetSchema()));
            settings.Schemas.Add(null, schemaReader);
            settings.ProhibitDtd = false;
            settings.ValidationType = ValidationType.Schema;
            settings.XmlResolver = null;
            XmlReader reader = XmlTextReader.Create(stream, settings);

            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element: {
                            switch (reader.Name) {
                                case XmlKeywords.Field:
                                    builder.AddStyle(ReadElementStyle(reader));
                                    break;
                                case XmlKeywords.Card:
                                    ReadCard(reader.ReadSubtree(), builder);
                                    break;
                            }
                        }
                        break;
                }
            }

            return builder.Build();
        }

        private static void ReadCard(XmlReader reader, CardDeckBuilder builder) {
            CardLearningStaus learnStatus = CardLearningStaus.NotLearned;

            if (!reader.Read()) { return; } // move into the Card element
            
            for (int i = 0; i < reader.AttributeCount; i++) {
                reader.MoveToAttribute(i);
                switch (reader.Name) {
                    case XmlKeywords.Card_Learned:
                        learnStatus = (CardLearningStaus)Enum.Parse(typeof(CardLearningStaus), reader.Value);
                        break;
                }
            }

            builder.BeginCard(learnStatus);

            while (reader.Read()) {
                if (reader.Name == XmlKeywords.Card_Field) { // in CardField
                    string name = string.Empty, value = string.Empty;
                    // read attributes
                    for (int i = 0; i < reader.AttributeCount; i++) {
                        reader.MoveToAttribute(i);
                        switch (reader.Name) {
                            case XmlKeywords.Card_Field_Name:
                                name = reader.Value;
                                break;
                        }
                    }
                    reader.MoveToContent();
                    XmlReader fieldValueReader = reader.ReadSubtree();
                    value = ReadCardValue(fieldValueReader);

                    builder.AddCardField(name, value);
                }
            }

            builder.EndCard();
        }

        /// <summary>
        /// Parse a CardField element
        /// </summary>
        private static string ReadCardValue(XmlReader reader) {
            StringBuilder result = new StringBuilder();
            while (reader.Read()) {
                // Whitespace is preserved!
                if ((reader.NodeType == XmlNodeType.Text) || (reader.NodeType == XmlNodeType.Whitespace)) {
                    result.Append(reader.Value);
                } else if (reader.NodeType == XmlNodeType.Element) {
                    switch (reader.Name) {
                        case XmlKeywords.Br:
                            result.Append(Environment.NewLine);
                            break;
                        case XmlKeywords.Style:
                            string type = string.Empty;
                            for (int i = 0; i < reader.AttributeCount; i++) {
                                reader.MoveToAttribute(i);
                                switch (reader.Name) {
                                    case XmlKeywords.Style_type:
                                        type = reader.Value;
                                        break;
                                }
                            }

                            TextStyle style = WikiMarkupParser.StringToTextStyle(type);
                            if (reader.Read() && (reader.NodeType == XmlNodeType.Text)) {
                                if (style == TextStyle.Regular) {
                                    result.Append(reader.Value);
                                } else if (style == TextStyle.LineBreak) {
                                    result.Append(Environment.NewLine);
                                } else {
                                    result.Append(WikiMarkupParser.WrapText(style, reader.Value));
                                }
                            }
                            break;
                    }
                }
            }
            return result.ToString();
        }

        private static CardElementStyle ReadElementStyle(XmlReader reader) {
            CardElementStyle style = new CardElementStyle(0, string.Empty);
            for (int i = 0; i < reader.AttributeCount; i++) {
                reader.MoveToAttribute(i);
                switch (reader.Name) {
                    case XmlKeywords.Field_Index:
                        style.Index = int.Parse(reader.Value);
                        break;
                    case XmlKeywords.Field_Name:
                        style.Name = reader.Value;
                        break;
                    case XmlKeywords.Field_Position:
                        style.Position = (CardElementPositions)Enum.Parse(typeof(CardElementPositions), reader.Value);
                        break;
                    case XmlKeywords.Field_Side:
                        style.Side = (CardElementSides)Enum.Parse(typeof(CardElementSides), reader.Value);
                        break;
                    case XmlKeywords.Field_Type:
                        style.Type = (CardElementType)Enum.Parse(typeof(CardElementType), reader.Value);
                        break;
                    case XmlKeywords.Field_ForeColor:
                        style.ForeColor = Utilities.Utility.DeserializeColor(reader.Value);
                        break;
                    case XmlKeywords.Field_BackColor:
                        style.BackColor = Utilities.Utility.DeserializeColor(reader.Value);
                        break;
                    default:
                        break;
                }
            }
            return style;
        }

        public override void Serialize(Stream stream, CardDeck deck) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            XmlWriter writer = XmlWriter.Create(stream, settings);
            Serialize(writer, deck);
            writer.Close();
        }

        public void Serialize(XmlWriter writer, CardDeck deck) {
            writer.WriteStartDocument(false);
            writer.WriteStartElement(XmlKeywords.CardDeck, "http://flashcardmaster.sourceforge.net/cardml/1.0/schema");
            writer.WriteAttributeString("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "http://flashcardmaster.sourceforge.net/cardml/1.0/schema http://flashcardmaster.sourceforge.net/cardml/1.0/schema");
            writer.WriteStartElement(XmlKeywords.Fields);
            foreach (CardElementStyle style in deck.Styles) {
                writer.WriteStartElement(XmlKeywords.Field);
                writer.WriteAttributeString(XmlKeywords.Field_Index, style.Index.ToString());
                writer.WriteAttributeString(XmlKeywords.Field_Name, WikiMarkupParser.RemoveMarkup(style.Name));
                writer.WriteAttributeString(XmlKeywords.Field_Type, style.Type.ToString());
                writer.WriteAttributeString(XmlKeywords.Field_Side, style.Side.ToString());
                writer.WriteAttributeString(XmlKeywords.Field_Position, style.Position.ToString());
                if (useRgbColor) {
                    writer.WriteAttributeString(XmlKeywords.Field_ForeColor, Utilities.Utility.ColorToRgb(style.ForeColor));
                    writer.WriteAttributeString(XmlKeywords.Field_BackColor, Utilities.Utility.ColorToRgb(style.BackColor));
                } else {
                    writer.WriteAttributeString(XmlKeywords.Field_ForeColor, Utilities.Utility.ColorToArgb(style.ForeColor));
                    writer.WriteAttributeString(XmlKeywords.Field_BackColor, Utilities.Utility.ColorToArgb(style.BackColor));
                }
                writer.WriteEndElement(); // Field
            }
            writer.WriteEndElement(); // Fields

            writer.WriteStartElement(XmlKeywords.Cards);
            foreach (Card card in deck.Cards) {
                writer.WriteStartElement(XmlKeywords.Card);
                writer.WriteAttributeString(XmlKeywords.Card_Learned, card.LearnStatus.ToString());

                foreach (CardElement element in card.Elements) {
                    writer.WriteStartElement(XmlKeywords.Card_Field);
                    writer.WriteAttributeString(XmlKeywords.Card_Field_Name, WikiMarkupParser.RemoveMarkup(element.Style.Name));

                    // This is necessary since CardField tag preserves whitespace
                    writer.WriteString(string.Empty); // Enter mixed content mode (ie. no indentation)
                    switch (styleProc) {
                        case XmlTextStyleProcessing.Remove:
                            writer.WriteString(WikiMarkupParser.RemoveMarkup(element.Text, true));
                            break;
                        case XmlTextStyleProcessing.ConvertToXml:
                            WikiMarkupParser.WikiTextToXml(element.Text, writer);
                            break;
                        default:
                            writer.WriteString(element.Text);
                            break;
                    }
                    writer.WriteEndElement(); // Field
                }
                writer.WriteEndElement(); // Card
            }
            writer.WriteEndElement(); // Cards
            writer.WriteEndElement(); // CardDeck
            writer.WriteEndDocument();
            writer.Flush();
        }


        private static string GetSchema() {
            /* DO NOT Edit this string directly. 
             * To prepare this string:
             *  1. Open Resources/cml.xsd
             *  2. To replace quotes enter '%s/"/\\"/g'
             *  3. To wrap lines in quotes see http://www.vim.org/tips/tip.php?tip_id=194
             */
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
"<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\" targetNamespace=\"http://flashcardmaster.sourceforge.net/cardml/1.0/schema\" xmlns=\"http://flashcardmaster.sourceforge.net/cardml/1.0/schema\">" +
" <xs:element name=\"CardDeck\">" +
"   <xs:annotation>" +
"     <xs:documentation>A card deck.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:complexType>" +
"     <xs:sequence>" +
"       <xs:element ref=\"Fields\"/>" +
"       <xs:element ref=\"Cards\"/>" +
"     </xs:sequence>" +
"   </xs:complexType>" +
" </xs:element>" +
" <!--  Elements............................................................................ -->" +
" <xs:element name=\"Fields\">" +
"   <xs:annotation>" +
"     <xs:documentation>A collection of fields.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:complexType>" +
"     <xs:sequence>" +
"       <xs:element maxOccurs=\"unbounded\" ref=\"Field\"/>" +
"     </xs:sequence>" +
"   </xs:complexType>" +
" </xs:element>" +
" <xs:element name=\"Field\">" +
"   <xs:annotation>" +
"     <xs:documentation>Defines the appearance of a card field.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:complexType>" +
"     <xs:attributeGroup ref=\"att.Field.index\"/>" +
"     <xs:attributeGroup ref=\"att.Field.name\"/>" +
"     <xs:attributeGroup ref=\"att.Field.type\"/>" +
"     <xs:attributeGroup ref=\"att.Field.side\"/>" +
"     <xs:attributeGroup ref=\"att.Field.position\"/>" +
"     <xs:attribute name=\"forecolor\">" +
"       <xs:annotation>" +
"         <xs:documentation>Foreground color of the field. Format: [a]rgb([0-255],[0-255],[0-255],[0-255]).</xs:documentation>" +
"       </xs:annotation>" +
"     </xs:attribute>" +
"     <xs:attribute name=\"backcolor\">" +
"       <xs:annotation>" +
"         <xs:documentation>Background color of the field. Format: [a]rgb([0-255],[0-255],[0-255],[0-255]).</xs:documentation>" +
"       </xs:annotation>" +
"     </xs:attribute>" +
"   </xs:complexType>" +
" </xs:element>" +
" <xs:element name=\"Cards\">" +
"   <xs:annotation>" +
"     <xs:documentation>A collection of cards.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:complexType>" +
"     <xs:sequence>" +
"       <xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" ref=\"Card\"/>" +
"     </xs:sequence>" +
"   </xs:complexType>" +
" </xs:element>" +
" <xs:element name=\"Card\">" +
"   <xs:annotation>" +
"     <xs:documentation>A card.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:complexType>" +
"     <xs:sequence>" +
"       <xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" ref=\"CardField\"/>" +
"     </xs:sequence>" +
"     <xs:attributeGroup ref=\"att.Card.name\"/>" +
"   </xs:complexType>" +
" </xs:element>" +
" <xs:element name=\"CardField\">" +
"   <xs:annotation>" +
"     <xs:documentation>A card field.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:complexType mixed=\"true\">" +
"     <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">" +
"       <xs:element ref=\"Style\"/>" +
"       <xs:element ref=\"br\"/>" +
"     </xs:choice>" +
"     <xs:attributeGroup ref=\"att.CardField.name\"/>" +
"   </xs:complexType>" +
" </xs:element>" +
" <!-- ..................................................................................... -->" +
" <!--  Field Attributes.................................................................... -->" +
" <xs:attributeGroup name=\"att.Field.index\">" +
"   <xs:attribute name=\"index\" use=\"required\" type=\"xs:integer\">" +
"     <xs:annotation>" +
"       <xs:documentation>An integer, 0 or greater, representing the ID of the field. Must be unique and increment by one.</xs:documentation>" +
"     </xs:annotation>" +
"   </xs:attribute>" +
" </xs:attributeGroup>" +
" <xs:attributeGroup name=\"att.Field.name\">" +
"   <xs:attribute name=\"name\" use=\"required\" type=\"xs:ID\">" +
"     <xs:annotation>" +
"       <xs:documentation>Name of a field, must be unique.</xs:documentation>" +
"     </xs:annotation>" +
"   </xs:attribute>" +
" </xs:attributeGroup>" +
" <xs:attributeGroup name=\"att.Field.type\">" +
"   <xs:attribute name=\"type\" use=\"required\">" +
"     <xs:annotation>" +
"       <xs:documentation>Type of a field.</xs:documentation>" +
"     </xs:annotation>" +
"     <xs:simpleType>" +
"       <xs:restriction base=\"xs:token\">" +
"         <xs:enumeration value=\"Key\"/>" +
"         <xs:enumeration value=\"Answer\"/>" +
"         <xs:enumeration value=\"Other\"/>" +
"       </xs:restriction>" +
"     </xs:simpleType>" +
"   </xs:attribute>" +
" </xs:attributeGroup>" +
" <xs:attributeGroup name=\"att.Field.side\">" +
"   <xs:attribute name=\"side\" use=\"required\">" +
"     <xs:annotation>" +
"       <xs:documentation>The side on which the field is shown.</xs:documentation>" +
"     </xs:annotation>" +
"     <xs:simpleType>" +
"       <xs:restriction base=\"xs:token\">" +
"         <xs:enumeration value=\"Front\"/>" +
"         <xs:enumeration value=\"Back\"/>" +
"         <xs:enumeration value=\"Both\"/>" +
"       </xs:restriction>" +
"     </xs:simpleType>" +
"   </xs:attribute>" +
" </xs:attributeGroup>" +
" <xs:attributeGroup name=\"att.Field.position\">" +
"   <xs:attribute name=\"position\" use=\"required\">" +
"     <xs:annotation>" +
"       <xs:documentation>The relative position of the field on the card.</xs:documentation>" +
"     </xs:annotation>" +
"     <xs:simpleType>" +
"       <xs:restriction base=\"xs:token\">" +
"         <xs:enumeration value=\"None\"/>" +
"         <xs:enumeration value=\"Top, Left\"/>" +
"         <xs:enumeration value=\"Top, HorizontalCenter\"/>" +
"         <xs:enumeration value=\"Top, Right\"/>" +
"         <xs:enumeration value=\"Left, VerticalCenter\"/>" +
"         <xs:enumeration value=\"Center\"/>" +
"         <xs:enumeration value=\"Right, VerticalCenter\"/>" +
"         <xs:enumeration value=\"Bottom, Left\"/>" +
"         <xs:enumeration value=\"Bottom, HorizontalCenter\"/>" +
"         <xs:enumeration value=\"Bottom, Right\"/>" +
"       </xs:restriction>" +
"     </xs:simpleType>" +
"   </xs:attribute>" +
" </xs:attributeGroup>" +
" <!-- ..................................................................................... -->" +
" <!--  Card Attributes..................................................................... -->" +
" <xs:attributeGroup name=\"att.Card.name\">" +
"   <xs:attribute name=\"learned\" use=\"required\">" +
"     <xs:annotation>" +
"       <xs:documentation>The learned status of the card.</xs:documentation>" +
"     </xs:annotation>" +
"     <xs:simpleType>" +
"       <xs:restriction base=\"xs:token\">" +
"         <xs:enumeration value=\"Learned\"/>" +
"         <xs:enumeration value=\"NotLearned\"/>" +
"         <xs:enumeration value=\"MaybeLearned\"/>" +
"       </xs:restriction>" +
"     </xs:simpleType>" +
"   </xs:attribute>" +
" </xs:attributeGroup>" +
" <!-- ..................................................................................... -->" +
" <!--  CardField Attributes................................................................ -->" +
" <xs:attributeGroup name=\"att.CardField.name\">" +
"   <xs:annotation>" +
"     <xs:documentation>The field associated with this card field.</xs:documentation>" +
"   </xs:annotation>" +
"   <xs:attribute name=\"name\" use=\"required\" type=\"xs:IDREF\"/>" +
" </xs:attributeGroup>" +
" <!-- ..................................................................................... -->" +
" <!--  Text Styles......................................................................... -->" +
" <xs:element name=\"Style\">" +
"   <xs:complexType mixed=\"true\">" +
"     <xs:attribute name=\"type\" use=\"required\">" +
"       <xs:simpleType>" +
"         <xs:restriction base=\"xs:token\">" +
"           <xs:enumeration value=\"regular\"/>" +
"           <xs:enumeration value=\"italic\"/>" +
"           <xs:enumeration value=\"bold\"/>" +
"           <xs:enumeration value=\"bolditalic\"/>" +
"           <xs:enumeration value=\"underline\"/>" +
"           <xs:enumeration value=\"monospace\"/>" +
"           <xs:enumeration value=\"strikethru\"/>" +
"           <xs:enumeration value=\"super\"/>" +
"           <xs:enumeration value=\"sub\"/>" +
"           <xs:enumeration value=\"linebreak\"/>" +
"         </xs:restriction>" +
"       </xs:simpleType>" +
"     </xs:attribute>" +
"   </xs:complexType>" +
" </xs:element>" +
" <xs:element name=\"br\">" +
"   <xs:complexType/>" +
" </xs:element>" +
" <!-- ..................................................................................... -->" +
"</xs:schema>";
        }

    }


    /// <summary>
    /// Determines how to process wikitext markup in text
    /// </summary>
    public enum XmlTextStyleProcessing
    {
        /// <summary>
        /// Keeps the markup as is.
        /// </summary>
        None,
        /// <summary>
        /// Strips all styles.
        /// </summary>
        Remove,
        /// <summary>
        /// Converts wiki styles to &lt;Style&gt elements.
        /// </summary>
        ConvertToXml
    }
}
