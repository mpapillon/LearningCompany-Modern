using LearningCompany_WinRT.Common;
using LearningCompany_WinRT.Models;
using LearningCompany_WinRT.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page de base, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556

namespace LearningCompany_WinRT.Views.Formateurs
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class FormateursView : Page
    {
        private NavigationHelper navigationHelper;
        private FormateursViewModel defaultViewModel = new FormateursViewModel();

        public FormateursView()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.DataContext = this.defaultViewModel;
        }

        /// <summary>
        /// Obtient le <see cref="NavigationHelper"/> associé à ce <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Obtient le modèle d'affichage pour ce <see cref="Page"/>.
        /// Cela peut être remplacé par un modèle d'affichage fortement typé.
        /// </summary>
        public FormateursViewModel DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Remplit la page à l'aide du contenu passé lors de la navigation. Tout état enregistré est également
        /// fourni lorsqu'une page est recréée à partir d'une session antérieure.
        /// </summary>
        /// <param name="sender">
        /// La source de l'événement ; en général <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Données d'événement qui fournissent le paramètre de navigation transmis à
        /// <see cref="Frame.Navigate(Type, Object)"/> lors de la requête initiale de cette page et
        /// un dictionnaire d'état conservé par cette page durant une session
        /// antérieure.  L'état n'aura pas la valeur Null lors de la première visite de la page.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// Conserve l'état associé à cette page en cas de suspension de l'application ou de
        /// suppression de la page du cache de navigation.  Les valeurs doivent être conformes aux
        /// exigences en matière de sérialisation de <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">La source de l'événement ; en général <see cref="NavigationHelper"/></param>
        /// <param name="e">Données d'événement qui fournissent un dictionnaire vide à remplir à l'aide de l'
        /// état sérialisable.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        private async void LoadData(bool force = false)
        {
            if (!this.defaultViewModel.IsDataLoaded || force)
            {
                StatusBar statusBar = StatusBar.GetForCurrentView();
                try
                {
                    statusBar.ProgressIndicator.Text = "Chargement des formateurs...";
                    await statusBar.ProgressIndicator.ShowAsync();

                    await this.defaultViewModel.LoadData(force);
                }
                catch
                {
                    string Title = "Impossible de charger les données";
                    string Content = "Assurez vous d'être connecté à internet (Wi-Fi ou Cellulaire). Si le problème persiste, vérifiez l'adresse du service web dans les paramètres.";
                    var msg = new MessageDialog(Content, Title);
                    msg.ShowAsync();
                }

                await statusBar.ProgressIndicator.HideAsync();
            }
        }

        #region Inscription de NavigationHelper

        /// <summary>
        /// Les méthodes fournies dans cette section sont utilisées simplement pour permettre
        /// NavigationHelper pour répondre aux méthodes de navigation de la page.
        /// <para>
        /// La logique spécifique à la page doit être placée dans les gestionnaires d'événements pour  
        /// <see cref="NavigationHelper.LoadState"/>
        /// et <see cref="NavigationHelper.SaveState"/>.
        /// Le paramètre de navigation est disponible dans la méthode LoadState 
        /// en plus de l'état de page conservé durant une session antérieure.
        /// </para>
        /// </summary>
        /// <param name="e">Fournit des données pour les méthodes de navigation et
        /// les gestionnaires d'événements qui ne peuvent pas annuler la requête de navigation.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Formateurs_Externes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Formateurs_Externes.SelectedItem != null)
            {
                ViewFormateursDetails(Formateurs_Externes.SelectedItem as Formateur);
                Formateurs_Externes.SelectedItem = null;
            }
        }

        private void Formateurs_Internes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Formateurs_Internes.SelectedItem != null)
            {
                ViewFormateursDetails(Formateurs_Internes.SelectedItem as Formateur);
                Formateurs_Internes.SelectedItem = null;
            }
        }

        private void ViewFormateursDetails(Formateur aFormateur)
        {
            this.Frame.Navigate(typeof(FormateurDetailsView), aFormateur);
        }

        private void Refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            this.LoadData(true);
        }
    }
}
