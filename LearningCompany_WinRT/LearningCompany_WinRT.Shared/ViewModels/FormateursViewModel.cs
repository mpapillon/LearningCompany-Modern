using LearningCompany_WinRT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using System.Xml.Serialization;
using System.IO;

namespace LearningCompany_WinRT.ViewModels
{
    public class FormateursViewModel : INotifyPropertyChanged
    {
        #region Notifs de changements

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        private bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null)
        {
            if (object.Equals(variable, valeur)) return false;

            variable = valeur;
            NotifyPropertyChanged(nomPropriete);
            return true;
        }

        #endregion

        public bool IsDataLoaded { get; private set; }

        private Services.LearningCompanyApi _webService;
        private StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        private List<Formateur> _formateursInternes;
        public List<Formateur> FormateursInternes
        {
            get { return _formateursInternes; }
            set { NotifyPropertyChanged(ref _formateursInternes, value); }
        }

        private List<Formateur> _formateursExternes;
        public List<Formateur> FormateursExternes
        {
            get { return _formateursExternes; }
            set { NotifyPropertyChanged(ref _formateursExternes, value); }
        }

        public FormateursViewModel()
        {
            this.IsDataLoaded = false;

            if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey("apiUrl"))
                this._webService = new Services.LearningCompanyApi(Windows.Storage.ApplicationData.Current.LocalSettings.Values["apiUrl"] as string);
            else
                this._webService = new Services.LearningCompanyApi();
        }

        public async Task<bool> LoadData(bool reload = false)
        {
            if(!this.IsDataLoaded || reload)
            {
                List<Formateur> formateurs = await this.LoadDataFromWeb();

                this.FormateursExternes = formateurs.Where(f => f.IntervenantExterieur == true).ToList();
                this.FormateursInternes = formateurs.Where(f => f.IntervenantExterieur == false).ToList();

                return true;
            }

            return false;
        }

        private async Task<List<Formateur>> LoadDataFromCache()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Formateur>));
            StorageFile sampleFile = await _localFolder.GetFileAsync("formateurs.xml");
            return serializer.Deserialize(await sampleFile.OpenStreamForReadAsync()) as List<Formateur>;
        }

        private async Task<List<Formateur>> LoadDataFromWeb()
        {
            var formateurs = await this._webService.GetFormateurs();
            IsDataLoaded = true;

            return formateurs;
        }
    }
}
