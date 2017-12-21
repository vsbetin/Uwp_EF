using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.ViewModels.CustomerViewModels.CustomerOrders;
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

namespace TermWorkDatabases.Views.CustomerView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerDuringOrdersPage : Page
    {
        public CustomerDuringOrdersPage()
        {
            this.InitializeComponent();
            SizeChanged += CustomerDuringOrdersPage_SizeChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DuringOrdersViewModel ViewModel = new DuringOrdersViewModel(e.Parameter as Customer);
            DataContext = ViewModel;
        }

        private void CustomerDuringOrdersPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DuringOrdersList.Width = e.NewSize.Width - 60;
            DuringOrdersList.Height = e.NewSize.Height - 60;
        }
    }
}
