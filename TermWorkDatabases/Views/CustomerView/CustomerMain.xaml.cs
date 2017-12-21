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

namespace TermWorkDatabases.Views.CustomerView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerMain : Page
    {
        public CustomerMain()
        {
            this.InitializeComponent();            
        }

        Customer _customer;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _customer = e.Parameter as Customer;
            CustomerContentFrame.Navigate(typeof(CustomerHomePage), _customer);
        }

        private void HanburgerButton_PointerPressed(object sender, RoutedEventArgs e)
        {
            CustomerMainSplitView.IsPaneOpen = !CustomerMainSplitView.IsPaneOpen;
        }

        private void ExitCustomerMain_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void HomeButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            CustomerContentFrame.Navigate(typeof(CustomerHomePage), _customer);
        }

        private void NewButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            CustomerContentFrame.Navigate(typeof(CustomerNewOrdersPage), _customer);
        }

        private void DuringButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            CustomerContentFrame.Navigate(typeof(CustomerDuringOrdersPage), _customer);
        }

        private void CompletedButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            CustomerContentFrame.Navigate(typeof(CustomerCompletedOrdersPage), _customer);            
        }

        private void ProductsButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            CustomerContentFrame.Navigate(typeof(CustomerProductsPage), _customer);
        }
    }
}
