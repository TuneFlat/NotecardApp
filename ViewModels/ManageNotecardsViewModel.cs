using NotecardApp.Base;
using NotecardApp.Models;
using NotecardApp.Services;
using NotecardApp.Shared;
using NotecardApp.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotecardApp.ViewModels
{
    public class ManageNotecardsViewModel : BaseViewModel
    {
        #region Fields

        private readonly IDeckService _deckService;
        private readonly INotecardService _notecardService;

        #endregion

        #region Constructor

        public ManageNotecardsViewModel()
        {
            _deckService = new DeckService();
            _notecardService = new NotecardService();
            Decks = new ObservableRangeCollection<Deck>();
            SelectedDeckId = null;
            Notecards = new ObservableRangeCollection<Notecard>();
            SelectedNotecardId = null;

            AddNotecardCommand = new DelegateCommand<object>(AddNotecard);
            UpdateNotecardCommand = new DelegateCommand<object>(UpdateNotecard);
            DeleteNotecardCommand = new DelegateCommand<object>(DeleteNotecard);
            DeleteDeckCommand = new DelegateCommand<object>(DeleteDeck);
            DeckSelectionCommand = new DelegateCommand<object>(DeckSelection);
            UpdateDeckCommand = new DelegateCommand<object>(UpdateDeck);
            AddDeckCommand = new DelegateCommand<object>(AddDeck);

            PopulateDecks();
        }

        #endregion

        #region Bindings

        private ObservableRangeCollection<Deck> _decks;

        public ObservableRangeCollection<Deck> Decks
        {
            get => _decks;
            set => SetField(ref _decks, value);
        }

        private ObservableRangeCollection<Notecard> _notecards;

        public ObservableRangeCollection<Notecard> Notecards
        {
            get => _notecards;
            set => SetField(ref _notecards, value);
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

        #endregion

        #region Commands

        public DelegateCommand<object> AddDeckCommand { get; set; }
        public DelegateCommand<object> DeleteDeckCommand { get; set; }
        public DelegateCommand<object> UpdateDeckCommand { get; set; }
        public DelegateCommand<object> UpdateNotecardCommand { get; set; }
        public DelegateCommand<object> AddNotecardCommand { get; set; }
        public DelegateCommand<object> DeleteNotecardCommand { get; set; }
        public DelegateCommand<object> DeckSelectionCommand { get; set; }

        #endregion

        #region Command Methods

        private void AddDeck(object param)
        {
            var editPopup = new PopupEditWindow(new Deck(), this);
            editPopup.Show();
        }
        private void UpdateDeck(object param)
        {
            Deck selectedDeck = Decks.FirstOrDefault(x => x.Id == SelectedDeckId);
            var editWindow = new PopupEditWindow(selectedDeck, this);
            editWindow.Show();
        }

        private void DeleteDeck(object param)
        {
            if (SelectedDeckId.HasValue)
            {
                Deck deckToDelete = Decks?.FirstOrDefault(x => x.Id == SelectedDeckId);
                List<Notecard> notecards = deckToDelete?.Notecards.ToList();
                _notecardService.DeleteNotecards(notecards);
                _deckService.DeleteDeck(deckToDelete);
            }
        }

        private void UpdateNotecard(object param)
        {
            Notecard selectedNotecard = Notecards.FirstOrDefault(x => x.Id == SelectedNotecardId);
            var editWindow = new PopupEditWindow(selectedNotecard, this);
            editWindow.Show();

        }
        private void AddNotecard(object param)
        {
            var editPopup = new PopupEditWindow(new Notecard(), this);
            editPopup.Show();
        }

        private void DeleteNotecard(object param)
        {
            if (SelectedNotecardId.HasValue && SelectedDeckId.HasValue)
            {
                Notecard notecardToDelete = Decks?.FirstOrDefault(x => x.Id == SelectedDeckId)?.Notecards?.FirstOrDefault(x => x.Id == SelectedNotecardId);
                _notecardService.DeleteNotecard(notecardToDelete);
            }
        }

        private void DeckSelection(object param)
        {
            if (SelectedDeckId != null) PopulateNotecards();
            SelectedNotecardId = null;
        }

        #endregion

        #region Methods

        public void PopulateDecks()
        {
            var decks = _deckService.SearchDecks();
            Decks.ReplaceRange(decks);
        }

        public void PopulateNotecards()
        {
            Deck deck = Decks.FirstOrDefault(x => x.Id == SelectedDeckId);
            if (deck != null)
            {
                var notecards = deck?.Notecards;
                Notecards.ReplaceRange(notecards);
            }
        }

        public void FinishUpdate()
        {
            PopulateDecks();
            PopulateNotecards();
        }

        #endregion
    }
}
