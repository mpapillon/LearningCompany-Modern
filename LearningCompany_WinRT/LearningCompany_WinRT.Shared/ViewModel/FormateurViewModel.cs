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
using System.Linq;

namespace LearningCompany_WinRT.ViewModel
{
    public class FormateurViewModel : ViewModelBase
    {
        private bool _isBusy;
        private bool _isDataLoaded = false;

        private IEnumerable<Formateur> _formateurs;
        private IEnumerable<Formateur> _formateursExternes;
        private IEnumerable<Formateur> _formateursInternes;
        private Formateur _selectedItem;

        public IFormateurService FormateurService { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(() => IsBusy, ref _isBusy, value); }
        }

        public bool IsDataLoaded
        {
            get { return _isDataLoaded; }
            set { Set(() => IsDataLoaded, ref _isDataLoaded, value); }
        }

        public Formateur SelectedItem
        {
            get { return _selectedItem; }
            set { Set(() => SelectedItem, ref _selectedItem, value); }
        }

        public IEnumerable<Formateur> Formateurs
        {
            get { return _formateurs; }
            set { Set(() => Formateurs, ref _formateurs, value); }
        }

        public IEnumerable<Formateur> FormateursExternes
        {
            get { return _formateursExternes; }
            set { Set(() => FormateursExternes, ref _formateursExternes, value); }
        }

        public IEnumerable<Formateur> FormateursInternes
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return SampleData.FormateurSample.Items.Where(f => !f.IntervenantExterieur).ToArray();
                else
                    return _formateursInternes;
            }
            set { Set(() => FormateursInternes, ref _formateursInternes, value); }
        }

        #region Commands

        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand<SelectionChangedEventArgs> ShowFormateurCommand { get; set; }

        #endregion

        public FormateurViewModel()
        {
            if(ViewModelBase.IsInDesignModeStatic)
            {
                this.Formateurs = SampleData.FormateurSample.Items;
                this.FormateursExternes = SampleData.FormateurSample.Items.Where(f => f.IntervenantExterieur).ToArray();
                this.FormateursInternes = SampleData.FormateurSample.Items.Where(f => !f.IntervenantExterieur).ToArray();
            }

            CreateCommands();
            FormateurService = new FormateurService();
        }

        public void CreateCommands()
        {
            this.LoadDataCommand = new RelayCommand(Load);
            this.RefreshCommand = new RelayCommand(RefreshHandler);
            this.ShowFormateurCommand = new RelayCommand<SelectionChangedEventArgs>(OnShowFormateur);
        }

        private void RefreshHandler()
        {
            RefreshData();
        }

        public void Load()
        {
            if(!IsDataLoaded)
                RefreshData();
        }

        public async void RefreshData()
        {
            IsBusy = true;
            Windows.UI.Popups.MessageDialog msg = null;

            try
            {
                await System.Threading.Tasks.Task.Delay(3000);

                this.Formateurs = await FormateurService.GetAll();
                this.FormateursExternes = Formateurs.Where(f => f.IntervenantExterieur).ToArray();
                this.FormateursInternes = Formateurs.Where(f => !f.IntervenantExterieur).ToArray();

                this.IsDataLoaded = true;
            }
            catch
            {
                msg = new Windows.UI.Popups.MessageDialog("Impossible de se connecter au serveur", "Oups !");
            }

            if (msg != null)
                await msg.ShowAsync();
            
            IsBusy = false;
        }

        private void OnShowFormateur(SelectionChangedEventArgs arg)
        {
            if (this.SelectedItem == null)
                return;

            Messenger.Default.Send<Formateur>(this.SelectedItem);
            SelectedItem = null;
        }
    }
}
