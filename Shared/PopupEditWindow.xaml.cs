using NotecardApp.Models;
using NotecardApp.Services;
using NotecardApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotecardApp.Shared
{
    public partial class PopupEditWindow : Window
    {
        private readonly IDeckService _deckService;
        private readonly INotecardService _notecardService;

        public PopupEditWindow(Notecard notecard, Object obj)
        {
            InitializeComponent();
            _deckService = new DeckService();
            _notecardService = new NotecardService();
            NotecardFields.Visibility = Visibility.Visible;
            notecardInfo = notecard;
            vm = obj as ManageNotecardsViewModel;
        }

        public PopupEditWindow(Deck deck, Object obj)
        {
            InitializeComponent();
            _deckService = new DeckService();
            _notecardService = new NotecardService();
            deckInfo = deck;
            DeckFields.Visibility = Visibility.Visible;
            DeckName.Text = deckInfo?.Name ?? string.Empty;
            
            DeckNotecards.ItemsSource = deckInfo?.Notecards.ToList();
            vm = obj as ManageNotecardsViewModel;
        }

        public ManageNotecardsViewModel vm;
        public Deck deckInfo;
        public Notecard notecardInfo;

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            vm.FinishUpdate();          
        }

        private void CancelCommand(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveCommand(object sender, RoutedEventArgs e)
        {
            if (deckInfo != null)
            {
                _deckService.UpdateDeck(deckInfo);   
            }
            if (notecardInfo != null)
            {
                _notecardService.UpdateNotecard(notecardInfo);
            }

            Close();
        }
    }
}
// TODO: Look to see if passing data like this violates MVVM. It works though it's messy.