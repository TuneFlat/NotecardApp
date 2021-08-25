using NotecardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotecardApp.Services
{
    public interface IDeckService
    {
        List<Deck> SearchDecks(int? id = null, string name = null);

        void AddDeck(Deck deck);

        void AddDecks(List<Deck> decks);

        void UpdateDeck(Deck deck);

        void UpdateDecks(List<Deck> decks);

        void DeleteDeck(Deck deck);


        void DeleteDecks(List<Deck> decks);


    }
}
