using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.ViewModels.ProducerViewModels.ProducerOrders;
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

namespace TermWorkDatabases.Views.ProducerView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProducerCompletedOrdersPage : Page
    {
        public ProducerCompletedOrdersPage()
        {
            this.InitializeComponent();
            SizeChanged += ProducerCompletedOrdersPage_SizeChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CompletedOrdersViewModel ViewModel = new CompletedOrdersViewModel(e.Parameter as Company);
            DataContext = ViewModel;
        }

        private void ProducerCompletedOrdersPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CompletedOrders.Width = e.NewSize.Width - 60;
            CompletedOrders.Height = e.NewSize.Height - 60;
        }
    }
}
