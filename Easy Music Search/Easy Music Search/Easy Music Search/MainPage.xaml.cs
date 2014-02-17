using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Easy_Music_Search.Resources;
using Nokia.Music.Tasks;
using Microsoft.Phone.Tasks;

namespace Easy_Music_Search
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void searchMusic_tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_SearchMusic.Text != string.Empty)
            {
                MusicSearchTask task = new MusicSearchTask();
                task.SearchTerms = txt_SearchMusic.Text;
                task.Show();
            }
            else
            {
                MessageBox.Show("Enter the Music name.", "Easy Music Search", MessageBoxButton.OK);
            }
        }

        private void searchArtists_tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_SearchArtists.Text != string.Empty)
            {
                ShowArtistTask task = new ShowArtistTask();
                task.ArtistName = txt_SearchArtists.Text;
                task.Show();
            }
            else
            {
                MessageBox.Show("Enter the Artist name.", "Easy Music Search", MessageBoxButton.OK);
            }
        }

        private void showMixes_tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShowMixesTask task = new ShowMixesTask();
            task.Show();
        }

        private void showGigs_tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShowGigsTask task = new ShowGigsTask();
            task.Show();
        }

        private void RateThisApp(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask oRateTask = new MarketplaceReviewTask();
            oRateTask.Show();
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