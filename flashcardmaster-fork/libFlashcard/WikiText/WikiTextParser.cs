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
 *  Original FileName :  WikiTextParser.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;

namespace FlashCardMaster.WikiText
{
    public enum TextStyle { Regular, Italic, Bold, BoldItalic, Underline, Monospace, Strikethru, Super, Sub, LineBreak };

    public enum TextAlignment { Top, Bottom, Center };

    public class TextParameters : IComparable<TextParameters>
    {
	   public TextParameters(TextStyle style, int blockStart, int textStart, int textEnd, int blockEnd) {
		  this.Style = style;
		  this.BlockStart = blockStart;
		  this.TextStart = textStart;
		  this.TextEnd = textEnd;
		  this.BlockEnd = blockEnd;
	   }

	   public TextStyle Style;
	   public int BlockStart;
	   public int TextStart;
	   public int TextEnd;
	   public int BlockEnd;


	   public override string ToString() {
		  return string.Format("{0}-{1}", BlockStart, BlockEnd); ;
	   }

	   #region IComparable<TextParameters> Members

	   public int CompareTo(TextParameters other) {
		  return this.BlockStart.CompareTo(other.BlockStart);
	   }

	   #endregion
    }

    public class TextElement
    {
	   TextStyle style;
	   string text;
	   Size size;

	   public TextElement(TextStyle style, string text) {
		  this.style = style;
		  this.text = text;
	   }

	   public TextAlignment Alignment {
		  get {
			 return TextAlignment.Bottom;
		  }
	   }

	   public Size Size {
		  get { return size; }
		  set { size = value; }
	   }

	   public TextStyle Style {
		  get { return this.style; }
		  set { this.style = value; }
	   }

	   public string Text {
		  get { return this.text; }
		  set { this.text = value; }
	   }

	   public override string ToString() {
		  return string.Format("{0}: {1}", this.style, this.text);
	   }
    }


    class WikiTextParser
    {

	   static WikiTextParser() {
		  /*
		  italicPattern = string.Format(patternBase, "'", "''", "italic");
		  boldPattern = string.Format(patternBase, "'", "'''", "italic");
		  boldItalicPattern = string.Format(patternBase, "'", "'''''", "bolditalic");
		  underlinePattern = string.Format(patternBase, "_", "__", "underline");
		  monospacePattern = string.Format(patternBase, "`", "``", "mono");
		  strikethruPattern = string.Format(patternBase, "~", "~~", "strike");
		  superscriptPattern = string.Format(patternBase, "\\^", "\\^\\^", "super");
		  subscriptPattern = string.Format(patternBase, ",", ",,", "sub");
		   */
	   }

	   // 0 = Base character
	   // 1 = Base pattern
	   // 2 = Name
	   const string patternBase = @"(?<!{0})(?<{2}>{1}([^{0}\\]*(\\.[^{0}\\]*)*){1})(?!{0})";

	   public static void Test() {
		  string italic = string.Format(patternBase, "'", "''", "italic");
		  string bold = string.Format(patternBase, "'", "'''", "bold");
		  string bolditalic = string.Format(patternBase, "'", "'''''", "bolditalic");
		  string underline = string.Format(patternBase, "_", "__", "underline");
		  string monospace = string.Format(patternBase, "`", "`", "monospace");
		  string strikethru = string.Format(patternBase, "~", "~~", "strikethru");
		  string super = string.Format(patternBase, "\\^", "\\^", "super");
		  string sub = string.Format(patternBase, ",", ",,", "sub");

	   }

	   const string italicPattern = @"(?<!')(?<italic>''([^'\\]*(\\.[^'\\]*)*)'')(?!')";
	   const string boldPattern = @"(?<!')(?<bold>'''([^'\\]*(\\.[^'\\]*)*)''')(?!')";
	   const string boldItalicPattern = @"(?<!')(?<bolditalic>'''''([^'\\]*(\\.[^'\\]*)*)''''')(?!')";
	   const string underlinePattern = @"(?<!_)(?<underline>__([^_\\]*(\\.[^_\\]*)*)__)(?!_)";
	   const string monospacePattern = @"(?<!`)(?<monospace>`([^`\\]*(\\.[^`\\]*)*)`)(?!`)";
	   const string strikethruPattern = @"(?<!~)(?<strikethru>~~([^~\\]*(\\.[^~\\]*)*)~~)(?!~)";
	   const string superscriptPattern = @"(?<!\^)(?<super>\^([^\^\\]*(\\.[^\^\\]*)*)\^)(?!\^)";
	   const string subscriptPattern = @"(?<!,)(?<sub>,,([^,\\]*(\\.[^,\\]*)*),,)(?!,)";


	   static Regex italicRegex = new Regex(italicPattern);
	   static Regex boldRegex = new Regex(boldPattern);
	   static Regex boldItalicRegex = new Regex(boldItalicPattern);
	   static Regex underlineRegex = new Regex(underlinePattern);
	   static Regex monospaceRegex = new Regex(monospacePattern);
	   static Regex strikethruRegex = new Regex(strikethruPattern);
	   static Regex superscriptRegex = new Regex(superscriptPattern);
	   static Regex subscriptRegex = new Regex(subscriptPattern);

	   public static string RemoveMarkup(string text) {
		  return RemoveMarkup(text, false);
	   }

	   public static string RemoveMarkup(string text, bool includeLinebreaks) {
		  TextElement[] elements = Parse(text);
		  StringBuilder sb = new StringBuilder(text.Length);
		  for (int i = 0; i < elements.Length; i++) {
			 if (elements[i].Style == TextStyle.LineBreak) {
				if (includeLinebreaks) {
				    sb.Append(Environment.NewLine);
				} else {
				    sb.Append(" ");
				}
			 } else {
				sb.Append(elements[i].Text);
			 }
		  }
		  return sb.ToString();
	   }

	   public static string WikiTextToHtml(string text) {
		  TextElement[] elements = Parse(text);
		  StringBuilder sb = new StringBuilder(text.Length);
		  string format = "<Style type=\"{0}\"><![CDATA[{1}]]></Style>";
		  for (int i = 0; i < elements.Length; i++) {
			 string style;
			 switch (elements[i].Style) {
				case TextStyle.Regular:
				    style = "regular";
				    break;
				case TextStyle.Italic:
				    style = "italic";
				    break;
				case TextStyle.Bold:
				    style = "bold";
				    break;
				case TextStyle.BoldItalic:
				    style = "bolditalic";
				    break;
				case TextStyle.Underline:
				    style = "underline";
				    break;
				case TextStyle.Monospace:
				    style = "monospace";
				    break;
				case TextStyle.Strikethru:
				    style = "strikethru";
				    break;
				case TextStyle.Super:
				    style = "super";
				    break;
				case TextStyle.Sub:
				    style = "sub";
				    break;
				case TextStyle.LineBreak:
				    style = "linebreak";
				    break;
				default:
				    style = "regular";
				    break;
			 }
			 sb.AppendFormat(format, style, elements[i].Text);
		  }
		  return sb.ToString();
	   }

	   private static TextElement[] SplitWords(TextElement[] elements) {
		  List<TextElement> result = new List<TextElement>();
		  for (int i = 0; i < elements.Length; i++) {
			 int index = -1;
			 result.Add(elements[i]);
			 while ((index = result[result.Count - 1].Text.IndexOf(" ")) >= 0) {
				// The last item has a space.
				TextElement last = result[result.Count - 1];

				TextElement ending = new TextElement(last.Style, last.Text.Substring(index + 1, last.Text.Length - (index + 1)));
//				if (ending.Text != string.Empty) {
				    result.Add(ending); // this could be problematic, because space is never stripped
//				}
				// alter the existing element's text
				last.Text = last.Text.Substring(0, index + 1);
				if (last.Text == string.Empty) {
				    result.Remove(last);
				}
			 }
		  }
		  return result.ToArray();
	   }

	   private static TextElement[] SplitLines(List<TextElement> elements) {
		  List<TextElement> result = new List<TextElement>();
		  for (int i = 0; i < elements.Count; i++) {
			 int index = -1;
			 result.Add(elements[i]);
			 while ((index = result[result.Count - 1].Text.IndexOf("\n")) >= 0) {
				// The last item has a linebreak.
				TextElement last = result[result.Count - 1];

				// add linebreak
				result.Add(new TextElement(TextStyle.LineBreak, ""));
				// insert text after the line break. (this item is now the last and will be split further, if necessary)
				TextElement ending = new TextElement(last.Style, last.Text.Substring(index + 1, last.Text.Length - index - 1));
				if (ending.Text != string.Empty) {
				    result.Add(ending);
				}
				// alter the existing element's text
				last.Text = last.Text.Substring(0, index);
				if (last.Text == string.Empty) {
				    result.Remove(last);
				}
			 }
		  }
		  return result.ToArray();
	   }


	   public static TextElement[] Parse(string text, bool splitwords) {
		  // This is really bad
		  TextElement[] elements = Parse(text);
		  return SplitWords(elements);
	   }

	   public static TextElement[] Parse(string text) {

		  // This is costly!
		  string wikitext = text.Replace("\r\n", "\n");
		  wikitext = wikitext.Replace("\r", "\n");

		  List<TextParameters> tparams = new List<TextParameters>();

		  // Bug: Same text can sometimes be parsed twice
		  Extract(tparams, italicRegex.Matches(wikitext), "italic", TextStyle.Italic, 2);
		  Extract(tparams, boldRegex.Matches(wikitext), "bold", TextStyle.Bold, 3);
		  Extract(tparams, boldItalicRegex.Matches(wikitext), "bolditalic", TextStyle.BoldItalic, 5);
		  Extract(tparams, underlineRegex.Matches(wikitext), "underline", TextStyle.Underline, 2);
		  Extract(tparams, monospaceRegex.Matches(wikitext), "monospace", TextStyle.Monospace, 1);
		  Extract(tparams, strikethruRegex.Matches(wikitext), "strikethru", TextStyle.Strikethru, 2);
		  Extract(tparams, superscriptRegex.Matches(wikitext), "super", TextStyle.Super, 1);
		  Extract(tparams, subscriptRegex.Matches(wikitext), "sub", TextStyle.Sub, 2);

		  tparams.Sort();
		  
		  // extract regular text; this could be optimized
		  List<TextParameters> regular = new List<TextParameters>();
		  int begin = 0;
		  int max = wikitext.Length;
		  for (int i = 0; i < tparams.Count; i++) {
			 if (tparams[i].BlockStart != 0) {
				if (tparams[i].BlockStart - begin > 0) {
				    regular.Add(new TextParameters(TextStyle.Regular, begin, begin, tparams[i].BlockStart, tparams[i].BlockStart));
				}
			 }
			 begin = tparams[i].BlockEnd;
		  }
		  if (begin != wikitext.Length) {
			 // grab the last block
			 regular.Add(new TextParameters(TextStyle.Regular, begin, begin, wikitext.Length, wikitext.Length));
		  }

		  tparams.AddRange(regular);
		  tparams.Sort();

		  // convert TextParameters to TextElement
		  List<TextElement> elements = new List<TextElement>(tparams.Count);
		  for (int i = 0; i < tparams.Count; i++) {
			 elements.Add(new TextElement(tparams[i].Style, wikitext.Substring(tparams[i].TextStart, tparams[i].TextEnd - tparams[i].TextStart)));
///			 Console.WriteLine("{0}: {1}", tparams[i].Style, text.Substring(tparams[i].TextStart, tparams[i].TextEnd - tparams[i].TextStart).Replace(" ", "<space>"));
		  }

		  // Finally, split lines
		  return SplitLines(elements);
	   }

	   private static void Extract(List<TextParameters> tparams, MatchCollection matches, string group, TextStyle style, int trim) {
		  foreach (Match match in matches) {
			 Group grp = match.Groups[group];
			 if (!string.IsNullOrEmpty(grp.Value)) {
				TextParameters param = new TextParameters(style, grp.Index, grp.Index + trim, grp.Index + grp.Length - trim, grp.Index + grp.Length);
				tparams.Add(param);
			 }
		  }
	   }
    }
}
