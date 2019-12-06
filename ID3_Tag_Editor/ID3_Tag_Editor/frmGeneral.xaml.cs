using ID3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ID3_Tag_Editor
{
    /// <summary>
    /// Interaction logic for frmGeneral.xaml
    /// </summary>
    public partial class frmGeneral : Window
    {
        TagLib.File file;
        public frmGeneral(string filepath)
        {
            InitializeComponent();

            file = TagLib.File.Create(filepath); // Get file from filepath
            lbPath.Content = file.Name;

            // ID3v1
            tbTrack.Text = file.Tag.Track.ToString();
            tbTitle.Text = file.Tag.Title;
            tbArtist.Text = file.Tag.FirstPerformer;
            tbAlbum.Text = file.Tag.Album;
            cbGenre.SelectedItem = file.Tag.FirstGenre;
            tbYear.Text = file.Tag.Year.ToString();
            tbComment.Text = file.Tag.Comment;

            // ID3v2
            tbTrack2.Text = file.Tag.Track.ToString();
            tbTitle2.Text = file.Tag.Title;
            tbArtist2.Text = file.Tag.FirstPerformer;
            tbAlbum2.Text = file.Tag.Album;
            cbGenre2.SelectedItem = file.Tag.FirstGenre;

            // Combobox items
            cbGenre.Items.Add("Blues");
            cbGenre.Items.Add("Classic Rock");
            cbGenre.Items.Add("Country");
            cbGenre.Items.Add("Dance");
            cbGenre.Items.Add("Disco");
            cbGenre.Items.Add("Funk");
            cbGenre.Items.Add("Hip-Hop");
            cbGenre.Items.Add("Jazz");
            cbGenre.Items.Add("Metal");

            cbGenre2.Items.Add("Blues");
            cbGenre2.Items.Add("Classic Rock");
            cbGenre2.Items.Add("Country");
            cbGenre2.Items.Add("Dance");
            cbGenre2.Items.Add("Disco");
            cbGenre2.Items.Add("Funk");
            cbGenre2.Items.Add("Hip-Hop");
            cbGenre2.Items.Add("Jazz");
            cbGenre2.Items.Add("Metal");
        }

        private void btCopyFrom2_Click(object sender, RoutedEventArgs e)
        {
            tbTrack.Text = tbTrack2.Text;
            tbTitle.Text = tbTitle2.Text;
            tbArtist.Text = tbArtist2.Text;
            tbAlbum.Text = tbAlbum2.Text;
            cbGenre.Text = cbGenre2.Text;
        }

        private void btCopyFrom1_Click(object sender, RoutedEventArgs e)
        {
            tbTrack2.Text = tbTrack.Text;
            tbTitle2.Text = tbTitle.Text;
            tbArtist2.Text = tbArtist.Text;
            tbAlbum2.Text = tbAlbum.Text;
            cbGenre2.Text = cbGenre.Text;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            file.Tag.Title = tbTitle2.Text;
            file.Tag.Performers[0] = tbArtist2.Text;
            file.Tag.Album = tbAlbum2.Text;

            // Setting Performers to null because file.Tag.FirstPerformer is read-only
            file.Tag.Performers = null; // clearing out performers
            file.Tag.Performers = new[] { tbArtist2.Text }; 

            // Same for Genres
            file.Tag.Genres = null; // clearing out genres
            file.Tag.Genres = new[] { cbGenre2.SelectedItem.ToString()};

            file.Save();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btTextInformation_Click(object sender, RoutedEventArgs e)
        {
            TextInformation tf = new TextInformation(file.Name);
            tf.Show();
        }
    }
}
