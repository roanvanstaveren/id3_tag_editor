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
    /// Interaction logic for TextInformation.xaml
    /// </summary>
    public partial class TextInformation : Window
    {
        TagLib.File file;
        public TextInformation(string filepath)
        {
            InitializeComponent();
            file = TagLib.File.Create(filepath); // Get file from filepath

            // filling textboxes
            tbTitle.Text = file.Tag.Title;
            tbTitleSortOrder.Text = file.Tag.TitleSort;
            // subtitle doesn't exist in taglib
            tbAlbum.Text = file.Tag.Album;
            tbAlbumSortOrder.Text = file.Tag.AlbumSort;
            tbInterpret.Text = file.Tag.FirstPerformer;
            // language
            // mood
            cbGenre.SelectedItem = file.Tag.FirstGenre;
            tbContentDescription.Text = file.Tag.Comment;
            // initial key
            tbTrackNumber.Text = file.Tag.Track.ToString();
            // playlist delay
            // part of set
            // set subtitle
            tbBPM.Text = file.Tag.BeatsPerMinute.ToString();

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

        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitle.Text != "")
                file.Tag.Title = tbTitle.Text;
            if (tbTitleSortOrder.Text != "")
                file.Tag.TitleSort = tbTitleSortOrder.Text;
            // subtitle
            if (tbAlbum.Text != "")
                file.Tag.Album = tbAlbum.Text;
            if (tbAlbumSortOrder.Text != "")
                file.Tag.AlbumSort = tbAlbumSortOrder.Text;
            if (tbInterpret.Text != "")
            {
                file.Tag.Performers = null;
                file.Tag.Performers = new[] { tbInterpret.Text };
            }
            // language
            // mood
            // genre
            if (tbContentDescription.Text != "")
                file.Tag.Comment = tbContentDescription.Text;
            // initial key
            if (tbTrackNumber.Text != "")
                file.Tag.Track = Convert.ToUInt32(tbTrackNumber.Text);
            // playlist delay
            // part of set
            // set subtitle
            if (tbBPM.Text != "")
                file.Tag.BeatsPerMinute = Convert.ToUInt32(tbBPM.Text);
            file.Save();
            MessageBox.Show("File saved successfully.");
        }
    }
}
