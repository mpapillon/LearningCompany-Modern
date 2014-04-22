using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément du menu volant des paramètres, consultez la page http://go.microsoft.com/fwlink/?LinkId=273769

namespace LearningCompany_WinRT
{
    public sealed partial class MainSettingsFlyout : SettingsFlyout
    {
        private ApplicationDataContainer localSettings;
        private bool urlHasChanged = false;

        public MainSettingsFlyout()
        {
            this.InitializeComponent();
            this.localSettings = ApplicationData.Current.LocalSettings;

            if (this.localSettings.Values.ContainsKey("apiUrl"))
                this.ServiceUrl.Text = localSettings.Values["apiUrl"] as string;
        }

        private void ServiceUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx = sender as TextBox;
            this.urlHasChanged = true;
            this.localSettings.Values["apiUrl"] = tbx.Text;
        }
    }
}
