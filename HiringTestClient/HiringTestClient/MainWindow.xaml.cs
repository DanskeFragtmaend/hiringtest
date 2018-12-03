using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using HiringTestApi.Model;

namespace HiringTestClient
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private const string apiUri = "http://localhost:43536/api/truck";
        private Truck selectedTruck;

        public ObservableCollection<Truck> Trucks { get; set; } = new ObservableCollection<Truck>();
        public Truck SelectedTruck { get => this.selectedTruck; set { this.selectedTruck = value; OnPropertyChanged(); } }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void bRefreshTruckList_Click(object sender, RoutedEventArgs e)
        {
            Trucks.Clear();
            var client = new HttpClient();
            var res = await client.GetAsync(apiUri);
            if (!res.IsSuccessStatusCode)
                MessageBox.Show(this, res.ReasonPhrase, "Error gettings data", MessageBoxButton.OK, MessageBoxImage.Error);
            var trucks = await res.Content.ReadAsAsync<IEnumerable<Truck>>();
            foreach (var truck in trucks)
                Trucks.Add(truck);
        }
        private async void bSaveTruck_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var res = await client.PutAsJsonAsync(apiUri, this.selectedTruck);
            if (!res.IsSuccessStatusCode)
                MessageBox.Show(this, $"Call to the backend failed, maybe the endpoint wasn't found. Error: {res.ReasonPhrase}", "Error saving data", MessageBoxButton.OK, MessageBoxImage.Error);
            SelectedTruck = null;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }
}