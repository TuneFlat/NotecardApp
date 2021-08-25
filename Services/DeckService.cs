using NotecardApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotecardApp.Services
{
    public class DeckService : IDeckService
    {
        private DeckRepository _deckRepository;

        #region Constructor

        public DeckService()
        {
            _deckRepository = new DeckRepository(new DeckModel());
        }

        #endregion


        #region Search

        public List<Deck> SearchDecks(int? id = null, string name = null)
        {
            var query = _deckRepository.GetDecks();
            if (id.HasValue)
                query = query.Where(x => x.Id == id);
            if (name != null)
                query = query.Where(x => x.Name == name);

            return query.ToList();
        }

        #endregion


        #region Add

        public void AddDeck(Deck deck)
        {
            _deckRepository.InsertDeck(deck);
        }

        public void AddDecks(List<Deck> decks)
        {
            _deckRepository.InsertDecks(decks);
        }

        #endregion


        #region Update

        public void UpdateDeck(Deck deck)
        {
            _deckRepository.UpdateDeck(deck);
        }

        public void UpdateDecks(List<Deck> decks)
        {
            _deckRepository.UpdateDecks(decks);
        }

        #endregion


        #region Delete

        public void DeleteDeck(Deck deck)
        {
            _deckRepository.DeleteDeck(deck);
        }

        public void DeleteDecks(List<Deck> decks)
        {
            _deckRepository.DeleteDecks(decks);
        }

        #endregion
    }
}
