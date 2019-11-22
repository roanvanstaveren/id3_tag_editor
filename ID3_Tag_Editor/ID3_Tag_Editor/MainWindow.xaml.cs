﻿using ID3_Editor;
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
using System.Collections.ObjectModel;

namespace ID3_Tag_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ID3v2> collection = new ObservableCollection<ID3v2>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void File_Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog List = new OpenFileDialog();
            List.Multiselect = false;
            List.Filter = "M3U Files (*.m3u)|*.m3u";
            List.Title = "List File";
            List.ValidateNames = true;
            if (List.ShowDialog() == true)
            {
                LoadM3u(List.FileName);
            }
        }

        public void LoadM3u(string FilePath)
        {
            if (Path.GetExtension(FilePath).ToLower() != ".m3u")
                return;

            //ClearList();
            string[] L = M3U.Load(FilePath);
            foreach (string st in L)
                AddNewFile(st);
        }

        public void AddNewFile(string FilePath)
        {
            ID3v2 ID3File;

            try
            {
                ID3File = new ID3v2(FilePath, true);
                collection.Add(ID3File);
            }
            catch (Exception ex)
            {
                MessageBox.Show(FilePath + "\nCan't load file. " + ex.Message, "Loading File");
                return;
            }

            //dataGrid.ItemsSource = collection;
            //_Tags.Remove(FilePath); // remove previous file if was in list
            //_Tags.Add(FilePath, ID3File);

            //_ErrorDialog.AddErrors(ID3File);
            //ID3File.ID3v2Info.Errors.Clear();
        }
        /// <summary>
        /// Open OpenFileDialog to choose file for opening
        /// </summary>
        public void AddNewFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                foreach (string File in openFileDialog.FileNames)
                    AddNewFile(File);
        }
    }
}
