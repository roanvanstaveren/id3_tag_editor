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
            tbAlbum.Text = file.Tag.Album;
            tbInterpret.Text = file.Tag.FirstPerformer;
            tbAlbumSortOrder.Text = file.Tag.AlbumSort;
            tbContentDescription.Text = file.Tag.Comment;
            tbTrackNumber.Text = file.Tag.Track.ToString();
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
    }
}
