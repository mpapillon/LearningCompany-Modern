using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LearningCompany_WinRT.Models;
using LearningCompany_WinRT.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace LearningCompany_WinRT.ViewModel
{
    public class FormateurViewModel : ViewModelBase
    {
        private bool _isBusy;
        private IEnumerable<Formateur> _items;
        private Formateur _selectedItem;

        public IFormateurService FormateurService { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(() => IsBusy, ref _isBusy, value); }
        }

        public Formateur SelectedItem
        {
            get { return _selectedItem; }
            set { Set(() => SelectedItem, ref _selectedItem, value); }
        }

        public IEnumerable<Formateur> Items
        {
            get { return _items; }
            set { Set(() => Items, ref _items, value); }
        }

        #region Commands

        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand<SelectionChangedEventArgs> SelectionChangedCommand { get; set; }

        #endregion

        public FormateurViewModel()
        {
            CreateCommands();
            FormateurService = new FormateurService();
        }

        public void CreateCommands()
        {
            this.RefreshCommand = new RelayCommand(RefreshHandler);
            this.SelectionChangedCommand = new RelayCommand<SelectionChangedEventArgs>(OnSelectionChanged);
        }

        private void RefreshHandler()
        {
            RefreshData();
        }

        public void Load()
        {
            RefreshData();
        }

        public async void RefreshData()
        {
            IsBusy = true;
            Windows.UI.Popups.MessageDialog msg = null;

            try
            {
                Items = await FormateurService.GetAll();
            }
            catch
            {
                msg = new Windows.UI.Popups.MessageDialog("Impossible de se connecter au serveur", "Oups !");
            }

            if (msg != null)
                await msg.ShowAsync();
            
            IsBusy = false;
        }

        private void OnSelectionChanged(SelectionChangedEventArgs arg)
        {
            if (this.SelectedItem == null)
                return;

            Messenger.Default.Send<Formateur>(this.SelectedItem);
            SelectedItem = null;
        }
    }
}
