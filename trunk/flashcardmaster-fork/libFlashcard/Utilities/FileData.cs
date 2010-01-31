using System;
using System.IO;
using LibFlashcard.Drivers;
using LibFlashcard.Model;

namespace LibFlashcard.Utilities
{
    public class FileData
    {
        string fileName = "";
        CardDeck deck = null;
        bool modified = false;

        public event EventHandler DataModified;

        private bool suppressEvents = false;

        public bool SuppressEvents {
            get { return suppressEvents; }
            set { suppressEvents = value; }
        }

        protected void OnDataModified() {
            if (suppressEvents) { return; }
            if (DataModified != null) {
                DataModified(this, new EventArgs());
            }
        }

        public bool Modified {
            get { return modified; }
            set { modified = value; OnDataModified(); }
        }

        public string FileName {
            get { return fileName; }
            set { fileName = value; }
        }

        public CardDeck Deck {
            get { return deck; }
            set { deck = value; }
        }

        public FileData() {
            this.fileName = "";
            this.deck = new CardDeck();
        }

        public FileData(CardDeck deck) {
            this.deck = deck;
        }

        public FileData(string fileName) {
            this.fileName = fileName;
            Load();
        }

        public bool CanFullSerialize {
            get { return AbstractDriver.SupportsFullSerialization(Path.GetExtension(this.FileName)); }
        }

        public void Save() {
            Save(AbstractDriver.Create(this.fileName));
            this.Modified = false;
        }

        public void Save(string fileName) {
            Save(AbstractDriver.Create(fileName));
        }

        public void Save(AbstractDriver driver) {
            driver.Serialize(this.deck);
        }

        public void Load() {
            this.deck = Load(AbstractDriver.Create(this.fileName));
        }

        public CardDeck Load(string fileName) {
            return Load(AbstractDriver.Create(fileName));
        }

        public CardDeck Load(AbstractDriver driver) {
            CardDeck deck = driver.DeSerialize();
            deck.ReIndexCards();
            return deck;
        }

        public void Merge(string fileName) {
            Merge(Load(fileName));
        }

        public void Merge(CardDeck newDeck) {
            if (newDeck.Cards.Count > 0) {
                if (newDeck.Styles.Count != this.deck.Styles.Count) { throw new MissingFieldException("Fields do not match"); }
                this.deck.AddCards(newDeck.Cards.ToArray(), true);
            }
        }
    }
}
