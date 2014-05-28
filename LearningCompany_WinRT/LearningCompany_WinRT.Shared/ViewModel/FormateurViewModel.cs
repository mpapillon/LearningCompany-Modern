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
    public class FormateurViewModel : ViewModelBase
    {
        private bool _isBusy;
        private bool _isDataLoaded = false;
        private bool _isDataCached;

        //private readonly string _cacheName = "Formateurs_Cache.xml";
        //private StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        private IEnumerable<Formateur> _formateurs;
        private IEnumerable<Formateur> _formateursExternes;
        private IEnumerable<Formateur> _formateursInternes;
        private Formateur _selectedItem;

        public FormateurService WebService { get; set; }

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

        public bool IsDataCached
        {
            get { return _isDataCached; }
            set { Set(() => IsDataCached, ref _isDataCached, value); }
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
            // Si la vue est dans le designer XAML, on charge des données d'exemples.
            if(ViewModelBase.IsInDesignModeStatic)
            {
                this.Formateurs = SampleData.FormateurSample.Items;
                this.FormateursExternes = SampleData.FormateurSample.Items.Where(f => f.IntervenantExterieur).ToArray();
                this.FormateursInternes = SampleData.FormateurSample.Items.Where(f => !f.IntervenantExterieur).ToArray();
            }

            // Si l'utilisateur a renseigné une url pour l'api dans les paramètres, on l'utilise.
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("apiUrl"))
                this.WebService = new FormateurService(ApplicationData.Current.LocalSettings.Values["apiUrl"] as string);
            else
                this.WebService = new FormateurService();

            //this.CheckFromCache();
            this.CreateCommands();
        }

        private void CreateCommands()
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
            //if (!this.IsDataLoaded && !this.IsDataCached)
                this.RefreshData();
            //else if (!this.IsDataLoaded && this.IsDataCached)
            //    this.LoadFromCache();
        }

        public async void RefreshData()
        {
            IsBusy = true;
            Windows.UI.Popups.MessageDialog msg = null;

#if WINDOWS_PHONE_APP
            // Si c'est une application Windows Phone, on affiche un message d'attente
            // dans la barre des status.
            var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.ProgressIndicator.Text = "Chargement des formateurs...";
            await statusBar.ProgressIndicator.ShowAsync();
#endif

            // On vérifie si l'utilisateur n'a pas changé l'adresse de l'api entre temps
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("apiUrl"))
            {
                var url = ApplicationData.Current.LocalSettings.Values["apiUrl"] as string;
                if (url != this.WebService._serviceUrl)
                    this.WebService = new FormateurService(url);
            }

            try
            {
                //await System.Threading.Tasks.Task.Delay(3000);

                IEnumerable<Formateur> formateursTemp = await WebService.GetAll();

                // Ajout de l'adresse complète pour les photos
                foreach(var aFormateur in formateursTemp)
                {
                    aFormateur.UrlPhoto = WebService.GetBaseUrl() + aFormateur.UrlPhoto;           
                }

                this.Formateurs = formateursTemp.OrderBy(f => f.Nom).ToArray();
                this.FormateursExternes = Formateurs.Where(f => f.IntervenantExterieur).OrderBy(f => f.Nom).ToArray();
                this.FormateursInternes = Formateurs.Where(f => !f.IntervenantExterieur).OrderBy(f => f.Nom).ToArray();

                //this.SaveInCache();

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

        //public async void LoadFromCache()
        //{
        //    var cacheFolder = await this._localFolder.GetFolderAsync("LocalCache");

        //    XmlSerializer serializer = new XmlSerializer(typeof(Formateur[]));
        //    StorageFile sampleFile = await cacheFolder.GetFileAsync(this._cacheName);
        //    this.Formateurs = serializer.Deserialize(await sampleFile.OpenStreamForReadAsync()) as Formateur[];

        //    this.FormateursExternes = Formateurs.Where(f => f.IntervenantExterieur).OrderBy(f => f.Nom).ToArray();
        //    this.FormateursInternes = Formateurs.Where(f => !f.IntervenantExterieur).OrderBy(f => f.Nom).ToArray();

        //    this.IsDataLoaded = true;
        //}

        //public async void SaveInCache()
        //{
        //    var cacheFolder = await this._localFolder.GetFolderAsync("LocalCache");

        //    XmlSerializer serializer = new XmlSerializer(typeof(Formateur[]));
        //    StorageFile sampleFile = await cacheFolder.CreateFileAsync(this._cacheName, CreationCollisionOption.ReplaceExisting);
        //    var stream = await sampleFile.OpenStreamForWriteAsync();
        //    serializer.Serialize(stream, this.Formateurs);
        //    this.IsDataCached = true;

        //    stream.Dispose();
        //}

        //private async void CheckFromCache()
        //{
        //    // vérification du dossier de cache, si n'existe ps il sera crée.
        //    StorageFolder cacheFolder;

        //    try { cacheFolder = await this._localFolder.GetFolderAsync("LocalCache"); }
        //    catch { cacheFolder = null; }

        //    if (cacheFolder == null)
        //        await this._localFolder.CreateFolderAsync("LocalCache");

        //    // vérification de l'existence du fichier de cache
        //    try 
        //    {
        //        await cacheFolder.GetFileAsync(this._cacheName);
        //        this.IsDataCached = true;
        //    } 
        //    catch 
        //    {
        //        this.IsDataCached = false;
        //    }
        //}

        private void OnShowFormateur(SelectionChangedEventArgs arg)
        {
            if (this.SelectedItem == null)
                return;

            Messenger.Default.Send<Formateur>(this.SelectedItem);
            SelectedItem = null;
        }
    }
}
