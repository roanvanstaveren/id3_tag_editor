using ID3_Editor;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ID3;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ID3_Tag_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void File_Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filePath = String.Empty;
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            LoadM3u(filePath);
        }

        /// <summary>
        /// Open OpenFileDialog to choose file for opening
        /// </summary>
        public void AddNewFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                foreach (string File in openFileDialog.FileNames)
                    AddNewFile(File);
        }

        /// <summary>
        /// Add Specific file to list
        /// </summary>
        /// <param name="FilePath">FileAddress to add</param>
        public void AddNewFile(string FilePath)
        {
            ID3Info ID3File;

            try
            {
                ID3File = new ID3Info(FilePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(FilePath + "\nCan't load file. " + ex.Message, "Loading File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Tags.ContainsKey(FilePath))
            {
                if (MessageBox.Show("This file is in list. would you like to reload it ?",
                    "reloading", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return; // exit function
            }

            _FileListDialog.AddFile(ID3File);
            _Tags.Remove(FilePath); // remove previous file if was in list
            _Tags.Add(FilePath, ID3File);

            _ErrorDialog.AddErrors(ID3File);
            //ID3File.ID3v2Info.Errors.Clear();
        }

        public void AddFiles()
        {
            string Ext = Path.GetExtension(File);
            if (Ext.ToLower() == ".mp3")
                Program.MainForm.AddNewFile(File);
            if (Ext.ToLower() == ".m3u")
                Program.MainForm.LoadM3u(File);
        }

        public ofdOpenMp3
        public void LoadM3u(string FilePath)
        {
            if (Path.GetExtension(FilePath).ToLower() != ".m3u")
                return;

            string[] L = M3U.Load(FilePath);
        }
    }
}
