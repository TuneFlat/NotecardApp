using NotecardApp.Base;
using NotecardApp.Models;
using NotecardApp.Services;
using NotecardApp.Shared;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotecardApp.ViewModels
{
    public class EditDecksAndNotecardsViewModel : BaseViewModel
    {
        #region Fields

        private readonly IDeckService _deckService;
        private readonly INotecardService _notecardService;

        #endregion


        #region Constructor
        public EditDecksAndNotecardsViewModel()
        {
            _deckService = new DeckService();
            _notecardService = new NotecardService();

            Decks = new ObservableRangeCollection<Deck>();
            Notecards = new ObservableRangeCollection<Notecard>();
            SelectedDeckId = null;
            SelectedNotecardId = null;
            NotecardAnswer = null;
            NotecardQuestion = null;
            NotecardHint = null;
            EditDeckVisibility = Visibility.Hidden;
            EditNotecardVisibility = Visibility.Hidden;


            SaveCommand = new DelegateCommand<object>(Save);
            CancelCommand = new DelegateCommand<object>(Cancel);

            // TODO: Change these populate methods once context for creating this page is figured out.
            PopulateDecks();
            PopulateNotecards();
        }

        #endregion


        #region Bindings

        private ObservableRangeCollection<Notecard> _notecards;

        public ObservableRangeCollection<Notecard> Notecards
        {
            get => _notecards;
            set => SetField(ref _notecards, value);
        }

        private ObservableRangeCollection<Deck> _decks;

        public ObservableRangeCollection<Deck> Decks
        {
            get => _decks;
            set => SetField(ref _decks, value);
        }

        private int? _selectedDeckId;
        public int? SelectedDeckId
        {
            get => _selectedDeckId;
            set => SetField(ref _selectedDeckId, value);
        }

        private int? _selectedNotecardId;
        public int? SelectedNotecardId
        {
            get => _selectedNotecardId;
            set => SetField(ref _selectedNotecardId, value);
        }

        private string _notecardQuestion;
        public string NotecardQuestion
        {
            get => _notecardQuestion;
            set => SetField(ref _notecardQuestion, value);
        }

        private string _notecardAnswer;
        public string NotecardAnswer
        {
            get => _notecardAnswer;
            set => SetField(ref _notecardAnswer, value);
        }

        private string _notecardHint;
        public string NotecardHint
        {
            get => _notecardHint;
            set => SetField(ref _notecardHint, value);
        }

        private Visibility _editNotecardVisibility;
        public Visibility EditNotecardVisibility
        {
            get => _editNotecardVisibility;
            set => SetField(ref _editNotecardVisibility, value);
        }

        private Visibility _editDeckVisibility;
        public Visibility EditDeckVisibility
        {
            get => _editDeckVisibility;
            set => SetField(ref _editDeckVisibility, value);
        }

        #endregion


        #region Commands

        public DelegateCommand<object> SaveCommand;
        public DelegateCommand<object> CancelCommand;

        #endregion


        #region Command Methods

        public void Save(object param)
        {
            throw new NotImplementedException();
        }

        public void Cancel(object param)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region ViewModel Methods

        public void PopulateDecks()
        {
            var decks = _deckService.SearchDecks();
            Decks.ReplaceRange(decks);
        }

        public void PopulateNotecards()
        {
            var deck = _deckService.SearchDecks().First();//Decks.FirstOrDefault(x => x.Id == SelectedDeckId);
            if (deck is not null)
            {
                var notecards = deck?.Notecards;
                Notecards.ReplaceRange(notecards);
            }
        }

        #endregion
    }
}
