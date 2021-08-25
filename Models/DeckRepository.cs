using NotecardApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace NotecardApp.Models
{
    public class DeckRepository
    {
        private DeckModel _deckModel;
        private bool _disposed = false;

        public DeckRepository(DeckModel _deckModel)
        {
            this._deckModel = _deckModel;
        }

        public void DeleteDeck(Deck deck)
        {
            _deckModel.Decks.Remove(deck);
        }

        public void DeleteDecks(List<Deck> decks)
        {
            _deckModel.Decks.RemoveRange(decks);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _deckModel.Dispose();
                }
            }
            _disposed = true;
        }

        public Deck GetDeckById(int deckId)
        {
            return _deckModel.Decks.Find(deckId);
        }

        public IEnumerable<Deck> GetDecks()
        {
            return _deckModel.Decks.ToList();
        }

        public void InsertDeck(Deck deck)
        {
            _deckModel.Decks.Add(deck);
        }

        public void InsertDecks(List<Deck> decks)
        {
            _deckModel.Decks.AddRange(decks);
        }

        public void Save()
        {
            _deckModel.SaveChanges();
        }

        public void UpdateDeck(Deck deck)
        {
            _deckModel.Entry(deck).State = EntityState.Modified;
        }

        public void UpdateDecks(List<Deck> decks)
        {
            _deckModel.Entry(decks).State = EntityState.Modified;
        }




    }
}
