﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Happy_Music.Resources;
using Nokia.Music.Tasks;

namespace Happy_Music
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

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            ShowGigsTask task = new ShowGigsTask();
            task.Show();
        }

        private void ApplicationBarMenuItem_Click_Mixes(object sender, EventArgs e)
        {
            ShowMixesTask task = new ShowMixesTask();
            task.Show();
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_MusicSearch.Text != string.Empty)
            {
                MusicSearchTask task = new MusicSearchTask();
                task.SearchTerms = txt_MusicSearch.Text;
                task.Show();
            }
            else
            {
                MessageBox.Show("Ente the Music name.", "Happy Music", MessageBoxButton.OK);
            }
        }

        private void Button_Tap_Artist(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_ArtistsSearch.Text != string.Empty)
            {
                ShowArtistTask task = new ShowArtistTask();
                task.ArtistName = txt_ArtistsSearch.Text;
                task.Show();
            }
            else
            {
                MessageBox.Show("Ente the Artist name.", "Happy Music", MessageBoxButton.OK);
            }
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