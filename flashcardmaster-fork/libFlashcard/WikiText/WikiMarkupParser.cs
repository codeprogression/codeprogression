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
 *  Original FileName :  WikiMarkupParser.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace LibFlashcard.WikiText
{
    public class WikiMarkupParser
    {
        // Must be pre-sorted
        // Warning: The contextLookupTable depend on the order
        static WikiContext[] DEFAULT_CONTEXTS = new WikiContext[] { 
			 new WikiContext(TextStyle.BoldItalic, @"'''''"),
			 new WikiContext(TextStyle.Bold, @"'''"),
			 new WikiContext(TextStyle.Monospace, @"{{{", "}}}"),
			 new WikiContext(TextStyle.Italic, @"''"),
			 new WikiContext(TextStyle.Underline, @"__"),
			 new WikiContext(TextStyle.Strikethru, @"~~"),
			 new WikiContext(TextStyle.Sub, @",,"),
			 new WikiContext(TextStyle.Monospace, @"`"),
			 new WikiContext(TextStyle.Super, @"^"),
			 new WikiContext(TextStyle.Bold, @"*")
		  };

        static Dictionary<TextStyle, WikiContext> contextLookupTable;

        static WikiMarkupParser() {
            // Warning: The indices depend on DEFAULT_CONTEXTS
            // Also, dupes are not allowed, so we pick the preferred one
            contextLookupTable = new Dictionary<TextStyle, WikiContext>();
            contextLookupTable.Add(TextStyle.BoldItalic, DEFAULT_CONTEXTS[0]);
            contextLookupTable.Add(TextStyle.Bold, DEFAULT_CONTEXTS[1]);
            contextLookupTable.Add(TextStyle.Italic, DEFAULT_CONTEXTS[3]);
            contextLookupTable.Add(TextStyle.Underline, DEFAULT_CONTEXTS[4]);
            contextLookupTable.Add(TextStyle.Strikethru, DEFAULT_CONTEXTS[5]);
            contextLookupTable.Add(TextStyle.Sub, DEFAULT_CONTEXTS[6]);
            contextLookupTable.Add(TextStyle.Monospace, DEFAULT_CONTEXTS[7]);
            contextLookupTable.Add(TextStyle.Super, DEFAULT_CONTEXTS[8]);
        }

        public static string GetStartDelimiter(TextStyle style) {
            return contextLookupTable[style].StartDelimiter;
        }

        public static string GetEndDelimiter(TextStyle style) {
            return contextLookupTable[style].EndDelimiter;
        }

        public static string WrapText(TextStyle style, string text) {
            if (style == TextStyle.LineBreak) {
                throw new ArgumentException("This TextStyle cannot be wrapped.", "style");
            }
            return GetStartDelimiter(style) + text + GetStartDelimiter(style);
        }

        /// <summary>
        /// Strips all markup information from a wiki formatted string.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <returns>A string with no markup information.</returns>
        public static string RemoveMarkup(string text) {
            return RemoveMarkup(text, false);
        }

        /// <summary>
        /// Strips all markup information from a wiki formatted string.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <param name="includeLinebreaks">If true, line breaks will be added, otherwise likebreaks will be replaced by a space.</param>
        /// <returns>A string with no markup information.</returns>
        public static string RemoveMarkup(string text, bool includeLinebreaks) {
            TextElement[] elements = Parse(text);
            StringBuilder sb = new StringBuilder(text.Length);
            for (int i = 0; i < elements.Length; i++) {
                if (elements[i].Style == TextStyle.LineBreak) {
                    if (includeLinebreaks) { sb.Append(Environment.NewLine); } else { sb.Append(" "); }
                } else { sb.Append(elements[i].Text); }
            }
            return sb.ToString();
        }

        public static void WikiTextToXml(string text, XmlWriter writer) {
            TextElement[] elements = Parse(text);
            for (int i = 0; i < elements.Length; i++) {
                if (elements[i].Style == TextStyle.LineBreak) {
                    writer.WriteElementString(LibFlashcard.Drivers.XmlDriver.XmlKeywords.Br, string.Empty);
                } else if (elements[i].Style == TextStyle.Regular) {
                    writer.WriteString(elements[i].Text);
                } else {
                    writer.WriteStartElement(LibFlashcard.Drivers.XmlDriver.XmlKeywords.Style);
                    writer.WriteAttributeString(LibFlashcard.Drivers.XmlDriver.XmlKeywords.Style_type, TextStyleToString(elements[i].Style));
                    writer.WriteString(elements[i].Text);
                    writer.WriteEndElement();
                }
            }
        }

        public static string WikiTextToPangoMarkup(string text) {
            TextElement[] elements = Parse(text);
            StringBuilder sb = new StringBuilder(text.Length);
            for (int i = 0; i < elements.Length; i++) {
                switch (elements[i].Style) {
                    case TextStyle.Regular:
                        sb.Append(elements[i].Text);
                        break;
                    case TextStyle.Italic:
                        sb.AppendFormat("<i>{0}</i>", elements[i].Text);
                        break;
                    case TextStyle.Bold:
                        sb.AppendFormat("<b>{0}</b>", elements[i].Text);
                        break;
                    case TextStyle.BoldItalic:
                        // This is not BoldItalic. There is another way, but it's too much work. Screw it.
                        sb.AppendFormat("<b><i>{0}</i></b>", elements[i].Text);
                        break;
                    case TextStyle.Underline:
                        sb.AppendFormat("<u>{0}</u>", elements[i].Text);
                        break;
                    case TextStyle.Monospace:
                        sb.AppendFormat("<tt>{0}</tt>", elements[i].Text);
                        break;
                    case TextStyle.Strikethru:
                        sb.AppendFormat("<s>{0}</s>", elements[i].Text);
                        break;
                    case TextStyle.Super:
                        sb.AppendFormat("<sup>{0}</sup>", elements[i].Text);
                        break;
                    case TextStyle.Sub:
                        sb.AppendFormat("<sub>{0}</sub>", elements[i].Text);
                        break;
                    case TextStyle.LineBreak:
                        sb.Append(@"\n");
                        break;
                    default:
                        sb.Append(elements[i].Text);
                        break;
                }
            }
            return sb.ToString();
        }


        public static string TextStyleToString(TextStyle style) {
            string name = "regular";
            switch (style) {
                case TextStyle.Regular:
                    name = "regular";
                    break;
                case TextStyle.Italic:
                    name = "italic";
                    break;
                case TextStyle.Bold:
                    name = "bold";
                    break;
                case TextStyle.BoldItalic:
                    name = "bolditalic";
                    break;
                case TextStyle.Underline:
                    name = "underline";
                    break;
                case TextStyle.Monospace:
                    name = "monospace";
                    break;
                case TextStyle.Strikethru:
                    name = "strikethru";
                    break;
                case TextStyle.Super:
                    name = "super";
                    break;
                case TextStyle.Sub:
                    name = "sub";
                    break;
                case TextStyle.LineBreak:
                    name = "linebreak";
                    break;
                default:
                    name = "regular";
                    break;
            }
            return name;
        }

        public static TextStyle StringToTextStyle(string name) {
            TextStyle style = TextStyle.Regular;
            switch (name) {
                case "regular":
                    style = TextStyle.Regular;
                    break;
                case "italic":
                    style = TextStyle.Italic;
                    break;
                case "bold":
                    style = TextStyle.Bold;
                    break;
                case "bolditalic":
                    style = TextStyle.BoldItalic;
                    break;
                case "underline":
                    style = TextStyle.Underline;
                    break;
                case "monospace":
                    style = TextStyle.Monospace;
                    break;
                case "strikethru":
                    style = TextStyle.Strikethru;
                    break;
                case "super":
                    style = TextStyle.Super;
                    break;
                case "sub":
                    style = TextStyle.Sub;
                    break;
                case "linebreak":
                    style = TextStyle.LineBreak;
                    break;
                default:
                    style = TextStyle.Regular;
                    break;
            }
            return style;
        }

        /// <summary>
        /// Converts a wiki formatted string to a LaTeX string. 
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <returns>A LaTeX formatted string.</returns>
        public static string WikiTextToLateX(string text) {
            TextElement[] elements = Parse(text);
            StringBuilder sb = new StringBuilder(text.Length);
            for (int i = 0; i < elements.Length; i++) {
                string escapedText = EscapeLaTeXString(elements[i].Text);
                switch (elements[i].Style) {
                    case TextStyle.Regular:
                        sb.Append(escapedText);
                        break;
                    case TextStyle.Italic:
                        sb.AppendFormat(@"\textit{{{0}}}", escapedText);
                        break;
                    case TextStyle.Bold:
                        sb.AppendFormat(@"\textbf{{{0}}}", escapedText);
                        break;
                    case TextStyle.BoldItalic:
                        // This is not BoldItalic. There is another way, but it's too much work. Screw it.
                        sb.AppendFormat(@"\textbf{{{0}}}", escapedText);
                        break;
                    case TextStyle.Underline:
                        sb.AppendFormat(@"\underline{{{0}}}", escapedText);
                        break;
                    case TextStyle.Monospace:
                        sb.AppendFormat(@"\texttt{{{0}}}", escapedText);
                        break;
                    case TextStyle.Strikethru:
                        sb.AppendFormat(@"\sout{{{0}}}", escapedText);
                        break;
                    case TextStyle.Super:
                        sb.AppendFormat(@"$^{{\mbox{{{0}}}}}$", escapedText);
                        break;
                    case TextStyle.Sub:
                        sb.AppendFormat(@"$_{{\mbox{{{0}}}}}$", escapedText);
                        break;
                    case TextStyle.LineBreak:
                        sb.Append(@"\newline ");
                        break;
                    default:
                        sb.Append(escapedText);
                        break;
                }
            }
            return sb.ToString();
        }

        private static string EscapeLaTeXString(string value) {
            return value.Replace("&", @"\&");
        }

        /// <summary>
        /// Parses a wiki formatted string into a structured list.
        /// </summary>
        /// <param name="text">The text to process.</param>
        /// <returns>A array containing parsed tokens.</returns>
        public static TextElement[] Parse(string text) {
            return Parse(text, false);
        }

        /// <summary>
        /// Parses a wiki formatted string into a structured list.
        /// </summary>
        /// <param name="text">The text to process.</param>
        /// <param name="splitWords">If true, each word in the string will be split into tokens.</param>
        /// <returns>A array containing parsed tokens.</returns>
        public static TextElement[] Parse(string text, bool splitWords) {
            WikiMarkupParser parser = new WikiMarkupParser(text, DEFAULT_CONTEXTS);
            parser.BreakWords = splitWords;
            return parser.Tokenize();
        }

        /// <summary>
        /// Specifies the context for the WikiMarkupParser
        /// </summary>
        internal class WikiContext
        {
            string startDelimiter = string.Empty;
            string endDelimiter = string.Empty;
            TextStyle type = TextStyle.Regular;

            public WikiContext(TextStyle type, string startDelimiter, string endDelimiter) {
                this.type = type;
                this.startDelimiter = startDelimiter;
                this.endDelimiter = endDelimiter;
            }

            public WikiContext(TextStyle type, string delimiter) {
                this.type = type;
                this.startDelimiter = delimiter;
                this.endDelimiter = delimiter;
            }

            /// <summary>
            /// Gets the string that denotes the beginning of this context.
            /// </summary>
            public string StartDelimiter {
                get { return this.startDelimiter; }
            }

            /// <summary>
            /// Gets the string that denotes the ending of this context.
            /// </summary>
            public string EndDelimiter {
                get { return this.endDelimiter; }
            }

            /// <summary>
            /// Gets the type represented by this instance of WikiContext.
            /// </summary>
            public LibFlashcard.WikiText.TextStyle Type {
                get { return this.type; }
            }
        }

        internal class WordBuilder
        {
            StringBuilder sb;
            TextStyle type;
            List<TextElement> elements;
            bool breakWords = false;

            public WordBuilder(TextStyle type, ref List<TextElement> elements)
                : this(type, ref elements, false) { }

            public WordBuilder(TextStyle type, ref List<TextElement> elements, bool breakWords) {
                sb = new StringBuilder();
                this.elements = elements;
                this.type = type;
                this.breakWords = breakWords;
            }

            /// <summary>
            /// Adds a character to the buffer
            /// </summary>
            /// <param name="c">The character to add</param>
            public void Append(char c) {
                sb.Append(c);
                if (breakWords) {
                    // Split words
                    if (c == ' ') {
                        Pop();
                    }
                }
            }

            /// <summary>
            /// Adds a linebreak to the list.
            /// </summary>
            public void PutLineBreak() {
                elements.Add(new TextElement(TextStyle.LineBreak, string.Empty));
            }

            /// <summary>
            /// Add the contents of the buffer to the list and clears the buffer.
            /// </summary>
            public void Pop() {
                if (sb.Length > 0) {
                    elements.Add(new TextElement(type, sb.ToString()));
                    sb.Length = 0;
                }
            }
        }

        string wikiText;
        WikiContext[] contexts;
        int tokenIndex = -1;
        char current;
        bool breakWords = false;
        bool throwOnSyntaxError = false;

        /// <summary>
        /// If true, an exception will be thrown when syntax error is occured. Default is false.
        /// </summary>
        public bool ThrowOnSyntaxError {
            get { return throwOnSyntaxError; }
            set { throwOnSyntaxError = value; }
        }

        /// <summary>
        /// If true, words are broken into seperate tokens.
        /// </summary>
        public bool BreakWords {
            get { return breakWords; }
            set { breakWords = value; }
        }

        /// <summary>
        /// The current character.
        /// </summary>
        private char Current {
            get { return current; }
        }

        /// <summary>
        /// The markedup text.
        /// </summary>
        public string WikiText {
            get { return wikiText; }
        }

        /// <summary>
        /// Creates a new instance of WikiMarkupParser.
        /// </summary>
        /// <param name="wikiText">The text to parse.</param>
        /// <param name="contexts">The context to use when parsing.</param>
        internal WikiMarkupParser(string wikiText, WikiContext[] contexts) {
            this.wikiText = wikiText;
            this.contexts = contexts;
        }

        /// <summary>
        /// Reads a wiki markup string and converts it into TextElements based on specified contexts.
        /// </summary>
        /// <returns>The tokens extracted from the wiki markup string.</returns>
        public TextElement[] Tokenize() {
            List<TextElement> elements = new List<TextElement>();
            WordBuilder sb = new WordBuilder(TextStyle.Regular, ref elements, this.breakWords);
            while (Step()) {
                WikiContext context;
                if (Current == '\\') { // Escape
                    Step(); // Read over \
                    sb.Append(Current); // Save the escaped char so that the parser won't misinterpret it
                } else if (IsNewLine()) {
                    // TODO: Lines breaks inside contexts need to be parsed.
                    //	    This should be moved into WordBuilder class(?)
                    sb.Pop();
                    sb.PutLineBreak();
                } else if (FindContext(out context)) {
                    sb.Pop();
                    Step(context.StartDelimiter.Length - 1); // Skip over delimiter - 1
                    ReadUntil(context.EndDelimiter, context.Type, ref elements);
                } else {
                    // Regular Text
                    sb.Append(Current);
                }
            }

            // Save the last regular text
            sb.Pop();

            return elements.ToArray();
        }

        /// <summary>
        /// Checks if the current position is  a newline. A new line is '\r\n' or '\r' or '\n'
        /// </summary>
        /// <remarks>
        /// If the newline is '\r\n' the reader is made to step over the \n.
        /// </remarks>
        /// <returns>True, if the current position is a newline, otherwise false.</returns>
        private bool IsNewLine() {
            if ((ReadFwd(2) == "\r\n")) {
                Step(); // Read over the \n
                return true;
            } else if ((Current == '\n') || (Current == '\r')) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Looks for a context at the current position.
        /// </summary>
        /// <remarks>
        /// <code>WikiMarkupParser.contexts</code> must be sorted by StartDelimiter.Length, with the longest one first.
        /// </remarks>
        /// <param name="currentContext">The context that was found, if any.</param>
        /// <returns>True, if a context was found, otherwise false.</returns>
        private bool FindContext(out WikiContext currentContext) {
            foreach (WikiContext context in contexts) {
                if (ReadFwd(context.StartDelimiter.Length) == context.StartDelimiter) {
                    currentContext = context;
                    return true;
                }
            }
            currentContext = null;
            return false;
        }

        /// <summary>
        /// Read a number of characters starting with Current.
        /// </summary>
        /// <param name="count">The number of characters to read.</param>
        /// <returns>A string containing the result. Is read range is out of bounds an empty string is returned.</returns>
        private string ReadFwd(int count) {
            if (tokenIndex + count > wikiText.Length) { return string.Empty; }
            char[] result = new char[count];
            int index = 0;
            for (int i = tokenIndex; i < tokenIndex + count; i++) {
                result[index] = wikiText[i];
                index++;
            }
            return new string(result);
        }

        /// <summary>
        /// Advances the reader by a specified amount.
        /// </summary>
        /// <param name="count">The number of steps to take.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        private bool Step(int count) {
            for (int i = 0; i < count; i++) {
                if (!Step()) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Advances the reader by one position.
        /// </summary>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        private bool Step() {
            if (tokenIndex < wikiText.Length - 1) {
                tokenIndex++;
                current = wikiText[tokenIndex];
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Resets the reader.
        /// </summary>
        private void Reset() {
            this.tokenIndex = -1;
            this.current = '\0';
        }

        /// <summary>
        /// Read a string until 'end' is found. 
        /// </summary>
        /// <remarks>
        /// When this method returns, the reader will be at the last character of end.
        /// </remarks>
        /// <param name="end">The end characters to look for.</param>
        /// <returns>The strings until 'end', but not including end.</returns>
        private void ReadUntil(string end, TextStyle style, ref List<TextElement> elements) {
            WordBuilder sb = new WordBuilder(style, ref elements, this.breakWords);
            bool contextClosed = false;

            while (Step()) {
                if (IsNewLine()) {
                    sb.Pop();
                    sb.PutLineBreak();
                } else if (Current == '\\') { // Escape
                    Step();
                    sb.Append(Current);
                } else {
                    if (ReadFwd(end.Length) == end) {
                        Step(end.Length - 1);
                        contextClosed = true;
                        break;
                    } else {
                        sb.Append(Current);
                    }
                }
            }

            if (!contextClosed && throwOnSyntaxError) {
                throw new SyntaxErrorException(string.Format("An error occured at position {0}. The section was not properly closed.", this.tokenIndex));
            }

            sb.Pop();
        }

        /// <summary>
        /// Read a string until 'end' is found. 
        /// </summary>
        /// <remarks>
        /// When this method returns, the reader will be at the last character of end.
        /// </remarks>
        /// <param name="end">The end characters to look for.</param>
        /// <returns>The strings until 'end', but not including end.</returns>
        [Obsolete]
        private string ReadUntil(string end) {
            StringBuilder sb = new StringBuilder(80);

            while (Step()) {
                if (Current == '\\') { // Escape
                    Step();
                    sb.Append(Current);
                } else {
                    if (ReadFwd(end.Length) == end) {
                        Step(end.Length - 1);
                        break;
                    } else {
                        sb.Append(Current);
                    }
                }
            }



            return sb.ToString();
        }
    }
}
