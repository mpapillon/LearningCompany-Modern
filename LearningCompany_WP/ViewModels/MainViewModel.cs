using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LearningCompany_WP.Resources;
using LearningCompany_WP.AccesCommerciaux;
using System.Data.Services.Client;
using System.Linq;

namespace LearningCompany_WP.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // This is the URI of the public, read-only Northwind data service. 
        // To make updates and save changes, replace this URI 
        // with your own Northwind service implementation.
        private static readonly Uri _rootUri =
            new Uri("http://192.168.1.10:24609/Services/AccesCommerciaux.svc/");

        // Define the typed DataServiceContext.
        private LearningCompanyContext _context;

        // Define the binding collection for Customers.
        private DataServiceCollection<Formateur> _formateurs;

        // Gets and sets the collection of Customer objects from the feed.
        // This collection is used to bind to the UI (View).
        public DataServiceCollection<Formateur> Formateurs
        {
            get { return _formateurs; }

            private set
            {
                // Set the Titles collection.
                _formateurs = value;

                // Register a handler for the LoadCompleted callback.
                _formateurs.LoadCompleted += OnFormateursLoaded;

                // Raise the PropertyChanged events.
                NotifyPropertyChanged("Formateurs");
            }
        }


        private DataServiceCollection<Client> _clients;
        public DataServiceCollection<Client> Clients
        {
            get { return _clients; }
            private set 
            {
                // Set the Titles collection.
                _clients = value;

                // Register a handler for the LoadCompleted callback.
                _clients.LoadCompleted += OnClientsLoaded;

                // Raise the PropertyChanged events.
                NotifyPropertyChanged("Clients");
            }
        }


        private DataServiceCollection<Stagiaire> _stagiaires;
        public DataServiceCollection<Stagiaire> Stagiaires
        {
            get { return _stagiaires; }
            private set 
            {
                // Set the Titles collection.
                _stagiaires = value;

                // Register a handler for the LoadCompleted callback.
                _stagiaires.LoadCompleted += OnStagiairesLoaded;

                // Raise the PropertyChanged events.
                NotifyPropertyChanged("Stagiaires");
            }
        }



        // Used to determine whether the data is loaded.
        public bool IsDataLoaded { get; private set; }

        // Loads data when the application is initialized.
        public void LoadData()
        {
            // Instantiate the context and binding collection.
            _context = new LearningCompanyContext(_rootUri);
            Formateurs = new DataServiceCollection<Formateur>(_context);
            Clients = new DataServiceCollection<Client>(_context);
            Stagiaires = new DataServiceCollection<Stagiaire>(_context);

            // Specify an OData query that returns all customers.
            var formateursQuery = from formt in _context.Formateurs
                        orderby formt.Nom
                        select formt;

            var clientsQuery = from cli in _context.Clients
                               orderby cli.Reference
                               select cli;

            var stagiairesQuery = from sta in _context.Stagiaires
                                  orderby sta.Nom
                                  select sta;

            // Load the customer data.
            Formateurs.LoadAsync(formateursQuery);
            Clients.LoadAsync(clientsQuery);
            Stagiaires.LoadAsync(stagiairesQuery);
        }

        // Displays data from the stored data context and binding collection 
        public void LoadData(LearningCompanyContext context,
            DataServiceCollection<Formateur> _formateurs, DataServiceCollection<Client> _clients, DataServiceCollection<Stagiaire> _stagiaires)
        {
            _context = context;
            Formateurs = _formateurs;
            Clients = _clients;
            Stagiaires = _stagiaires;

            IsDataLoaded = true;
        }

        // Handles the DataServiceCollection<T>.LoadCompleted event.
        private void OnFormateursLoaded(object sender, LoadCompletedEventArgs e)
        {
            // Make sure that we load all pages of the Customers feed.
            if (Formateurs.Continuation != null)
            {
                Formateurs.LoadNextPartialSetAsync();
            }
            IsDataLoaded = true;
        }

        private void OnClientsLoaded(object sender, LoadCompletedEventArgs e)
        {
            // Make sure that we load all pages of the Customers feed.
            if (Clients.Continuation != null)
            {
                Clients.LoadNextPartialSetAsync();
            }
            IsDataLoaded = true;
        }

        private void OnStagiairesLoaded(object sender, LoadCompletedEventArgs e)
        {
            // Make sure that we load all pages of the Customers feed.
            if (Stagiaires.Continuation != null)
            {
                Stagiaires.LoadNextPartialSetAsync();
            }
            IsDataLoaded = true;
        }

        // Declare a PropertyChanged for the UI to register 
        // to get updates from the ViewModel.
        public event PropertyChangedEventHandler PropertyChanged;

        // Notifies the binding about a changed property value.
        private void NotifyPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                // Raise the PropertyChanged event.
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}