using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Nokia.Music.Tasks;

namespace My_Music_Finder
{
    public partial class SearchArtists : PhoneApplicationPage
    {
        public SearchArtists()
        {
            InitializeComponent();
        }

        private void btn_SearchArtists_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_Artists.Text != string.Empty)
            {
                ShowArtistTask task = new ShowArtistTask();
                task.ArtistName = txt_Artists.Text;
                task.Show();
            }
            else
            {
                MessageBox.Show("Enter the Artist name first.", "Music of your choice", MessageBoxButton.OK);
            }
        }
    }
}