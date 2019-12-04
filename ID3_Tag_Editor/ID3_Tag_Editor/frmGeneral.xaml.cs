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
        public frmGeneral(string filepath)
        {
            InitializeComponent();

            var file = TagLib.File.Create(filepath); // Get file from filepath
            
            //// Save Changes:
            //file.Save();

            // ID3v1
            tbTrack.Text = file.Tag.Track.ToString();
            tbTitle.Text = file.Tag.Title;
            tbArtist.Text = file.Tag.FirstPerformer;
            tbAlbum.Text = file.Tag.Album;
            tbGenre.Text = file.Tag.FirstGenre;
            tbYear.Text = file.Tag.Year.ToString();
            tbComment.Text = file.Tag.Comment;

            // ID3v2
            tbTrack2.Text = file.Tag.Track.ToString();
            tbTitle2.Text = file.Tag.Title;
            tbArtist2.Text = file.Tag.FirstPerformer;
            tbAlbum2.Text = file.Tag.Album;
            tbGenre.Text = file.Tag.FirstGenre;
        }

        private void btCopyFrom2_Click(object sender, RoutedEventArgs e)
        {
            tbTrack.Text = tbTrack2.Text;
            tbTitle.Text = tbTitle2.Text;
            tbArtist.Text = tbArtist2.Text;
            tbAlbum.Text = tbAlbum2.Text;
            tbGenre.Text = tbGenre2.Text;
        }

        private void btCopyFrom1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
