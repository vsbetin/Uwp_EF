using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TermWorkDatabases.Models.Enteties;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TermWorkDatabases.Views.ProducerView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProducerMain : Page
    {
        public ProducerMain()
        {
            this.InitializeComponent();
        }

        Company _company;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _company = e.Parameter as Company;
            ProducerContentFrame.Navigate(typeof(ProducerHomePage), _company);
        }

        private void HanburgerButton_PointerPressed(object sender, RoutedEventArgs e)
        {
            ProducerMainSplitView.IsPaneOpen = !ProducerMainSplitView.IsPaneOpen;
        }

        private void ExitProducerMain_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), _company);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void HomeButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ProducerContentFrame.Navigate(typeof(ProducerHomePage), _company);
        }

        private void NewButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ProducerContentFrame.Navigate(typeof(ProducerNewOrdersPage), _company);
        }

        private void DuringButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ProducerContentFrame.Navigate(typeof(ProducerDuringOrdersPage), _company);
        }

        private void CompletedButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ProducerContentFrame.Navigate(typeof(ProducerCompletedOrdersPage), _company);
        }

        private void ProductsButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ProducerContentFrame.Navigate(typeof(ProducerProductsPage), _company);
        }

        private void PlantsButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ProducerContentFrame.Navigate(typeof(ProducerPlantsPage), _company);
        }
    }
}
