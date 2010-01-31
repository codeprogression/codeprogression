using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LibFlashcard.WikiText
{
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
}
