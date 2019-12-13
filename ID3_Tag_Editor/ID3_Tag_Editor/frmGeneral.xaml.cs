using ID3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private ObservableCollection<ID3Info> _collection = new ObservableCollection<ID3Info>();
        private int _index;
        string _filepath;
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        TagLib.File file;
        public frmGeneral(string filepath, ObservableCollection<ID3Info> collection, int index)
        {
            InitializeComponent();

            file = TagLib.File.Create(filepath); // Get file from filepath
            lbPath.Content = file.Name;
            _collection = collection;
            _index = index;
            _filepath = filepath;

            SetValues();

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
            CopyFrom2();
        }

        private void btCopyFrom1_Click(object sender, RoutedEventArgs e)
        {
            CopyFrom1();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitle2.Text != "")
                file.Tag.Title = tbTitle2.Text;

            if (tbArtist2.Text != "")
                file.Tag.Performers[0] = tbArtist2.Text;

            if (tbAlbum2.Text != "")
                file.Tag.Album = tbAlbum2.Text;

            if (tbTrack2.Text != "")
            {
                try { file.Tag.Track = Convert.ToUInt32(tbTrack2.Text); }
                catch (Exception) { throw; }
            }

            // set is nowhere to be found

            // Setting Performers to null because file.Tag.FirstPerformer is read-only
            if (tbArtist2.Text != "")
            {
                file.Tag.Performers = null;
                file.Tag.Performers = new[] { tbArtist2.Text };
            }

            // Same for Genres
            if (cbGenre2.SelectedItem != null)
            {
                file.Tag.Genres = null;
                file.Tag.Genres = new[] { cbGenre2.SelectedItem.ToString() };
            }

            file.Save();
            MessageBox.Show("File saved successfully.");
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btTextInformation_Click(object sender, RoutedEventArgs e)
        {
            TextInformation tf = new TextInformation(_filepath, _collection, _index);
            tf.Show();
        }

        public void SetValues()
        {
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
        }

        private void btPrevious_Click(object sender, RoutedEventArgs e)
        {
            _index--;
            if (0 > _index)
            {
                MessageBox.Show("There is no further file to be edited.");
                _index++;
            }
            file = TagLib.File.Create(_collection[_index].FilePath);
            SetValues();
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            _index++;
            if (_collection.Count <= _index)
            {
                MessageBox.Show("There is no further file to be edited.");
                _index--;
            }
            file = TagLib.File.Create(_collection[_index].FilePath);
            SetValues();
        }

        public void CopyFrom1()
        {
            tbTrack2.Text = tbTrack.Text;
            tbTitle2.Text = tbTitle.Text;
            tbArtist2.Text = tbArtist.Text;
            tbAlbum2.Text = tbAlbum.Text;
            cbGenre2.Text = cbGenre.Text;
        }

        public void CopyFrom2()
        {
            tbTrack.Text = tbTrack2.Text;
            tbTitle.Text = tbTitle2.Text;
            tbArtist.Text = tbArtist2.Text;
            tbAlbum.Text = tbAlbum2.Text;
            cbGenre.Text = cbGenre2.Text;
        }
    }
}
