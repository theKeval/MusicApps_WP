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
    public partial class SearchMusic : PhoneApplicationPage
    {
        public SearchMusic()
        {
            InitializeComponent();
        }

        private void btn_SearchMusic_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txt_Music.Text != string.Empty)
            {
                MusicSearchTask task = new MusicSearchTask();
                task.SearchTerms = txt_Music.Text;
                task.Show();
            }
            else
            {
                MessageBox.Show("Enter the Music name first.", "Music of your choice", MessageBoxButton.OK);
            }
        }
    }
}