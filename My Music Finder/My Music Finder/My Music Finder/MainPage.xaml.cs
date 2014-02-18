using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using My_Music_Finder.Resources;
using My_Music_Finder.ViewModels;
using System.Collections.ObjectModel;
using Nokia.Music.Tasks;

namespace My_Music_Finder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            //DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public ObservableCollection<MyData> data = new ObservableCollection<MyData>();



        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (data.Count == 0)
            {
                data.Add(new MyData
                {
                    Header = "Search Music",
                    SubHeader = "Are you in search of your favourite music track..?"
                });

                data.Add(new MyData
                {
                    Header = "Search Artists",
                    SubHeader = "Are you in search of your favourite Artist..?"
                });

                data.Add(new MyData
                {
                    Header = "Search Gigs",
                    SubHeader = "Here are few Gigs around you."
                });

                data.Add(new MyData
                {
                    Header = "Search Mixes",
                    SubHeader = "Not sure what to listen..? Here are few Mixes for you."
                });
            }

            llselector.ItemsSource = data;


            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        private void llselector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOption = (MyData)llselector.SelectedItem;

            switch(selectedOption.Header)
            {
                case "Search Music":
                    NavigationService.Navigate(new Uri("/SearchMusic.xaml", UriKind.Relative));
                    break;

                case "Search Artists":
                    NavigationService.Navigate(new Uri("/SearchArtists.xaml", UriKind.Relative));
                    break;

                case "Search Gigs":
                    ShowGigsTask task = new ShowGigsTask();
                    task.Show();
                    break;

                case "Search Mixes":
                    ShowMixesTask Mixestask = new ShowMixesTask();
                    Mixestask.Show();
                    break;

            }
        }

        private void BtnInApp_tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchasePage.xaml", UriKind.Relative));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}