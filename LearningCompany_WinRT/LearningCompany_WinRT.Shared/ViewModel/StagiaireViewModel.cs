using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LearningCompany_WinRT.Models;
using LearningCompany_WinRT.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace LearningCompany_WinRT.ViewModel
{
    public class StagiaireViewModel : ViewModelBase
    {
        private bool _isBusy;
        private bool _isDataLoaded = false;

        private IEnumerable<Stagiaire> _stagiaires;
        private Stagiaire _selectedItem;

        public StagiaireService WebService { get; set; }

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

        public Stagiaire SelectedItem
        {
            get { return _selectedItem; }
            set { Set(() => SelectedItem, ref _selectedItem, value); }
        }

        public IEnumerable<Stagiaire> Stagiaires
        {
            get { return _stagiaires; }
            set { Set(() => Stagiaires, ref _stagiaires, value); }
        }

        #region Commands

        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand<SelectionChangedEventArgs> ShowFormateurCommand { get; set; }

        #endregion

        public StagiaireViewModel()
        {
            // Si la vue est dans le designer XAML, on charge des données d'exemples.
            if(ViewModelBase.IsInDesignModeStatic)
            {
                //this.Stagiaires = SampleData.FormateurSample.Items;
            }

            // Si l'utilisateur a renseigné une url pour l'api dans les paramètres, on l'utilise.
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("apiUrl"))
                this.WebService = new StagiaireService(ApplicationData.Current.LocalSettings.Values["apiUrl"] as string);
            else
                this.WebService = new StagiaireService();

            //this.CheckFromCache();
            this.CreateCommands();
        }

        private void CreateCommands()
        {
            this.LoadDataCommand = new RelayCommand(Load);
            this.RefreshCommand = new RelayCommand(RefreshHandler);
        }

        private void RefreshHandler()
        {
            RefreshData();
        }

        public void Load()
        {
            this.RefreshData();
        }

        public async void RefreshData()
        {
            IsBusy = true;
            Windows.UI.Popups.MessageDialog msg = null;

#if WINDOWS_PHONE_APP
            // Si c'est une application Windows Phone, on affiche un message d'attente
            // dans la barre des status.
            var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.ProgressIndicator.Text = "Chargement des stagiaires...";
            await statusBar.ProgressIndicator.ShowAsync();
#endif

            // On vérifie si l'utilisateur n'a pas changé l'adresse de l'api entre temps
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("apiUrl"))
            {
                var url = ApplicationData.Current.LocalSettings.Values["apiUrl"] as string;
                if (url != this.WebService._serviceUrl)
                    this.WebService = new StagiaireService(url);
            }

            try
            {
                //await System.Threading.Tasks.Task.Delay(3000);

                IEnumerable<Stagiaire> staTemp = await WebService.GetAll();
                this.Stagiaires = staTemp.OrderBy(f => f.Nom).ToArray();

                this.IsDataLoaded = true;
            }
            catch
            {
                string message = "Assurez-vous d'être connecté à internet (via Wi-Fi ou Cellulaire). Si le problème persiste, vérifiez l'adresse du service web dans les paramètres.";
                msg = new Windows.UI.Popups.MessageDialog(message, "Problème de connexion");
            }

#if WINDOWS_PHONE_APP
            await statusBar.ProgressIndicator.HideAsync();
#endif

            if (msg != null)
                await msg.ShowAsync();

            IsBusy = false;
        }

    }
}
