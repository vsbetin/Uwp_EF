using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.ViewModels.ProducerViewModels.ProducerPlants;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TermWorkDatabases.Views.ProducerView.ProducerPlants
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProducerAddNewPlant : Page
    {
        public ProducerAddNewPlant()
        {
            this.InitializeComponent();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProducerPlantsPage));
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AddPlantViewModel ViewModel = new AddPlantViewModel(e.Parameter as Company);
            DataContext = ViewModel;
        }
    }
}
