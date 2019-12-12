using ID3_Editor;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ID3;
using System.Text;
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
using System.ComponentModel;
using System.Collections;

namespace ID3_Tag_Editor
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        private ID3Info _Data;
        public ObservableCollection<ID3Info> collection = new ObservableCollection<ID3Info>();
        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        // Load List 1
        private void Load_List_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog List = new OpenFileDialog();
            List.Multiselect = false;
            List.Filter = "M3U Files (*.m3u)|*.m3u";
            List.Title = "List File";
            List.ValidateNames = true;
            if (List.ShowDialog() == true)
            {
                string[] list = List.FileNames;
                LoadM3u(list);
            }
        }

        // Load List 2
        public void LoadM3u(string[] FilePaths)
        {
            if (Path.GetExtension(FilePaths[0]).ToLower() != ".m3u")
                return;

            //ClearList();
            string[] L = M3U.Load(FilePaths[0]);
            AddNewFiles(L);
        }


        // Adding new file(s) to datagrid
        public void AddNewFiles(string[] FilePaths)
        {
            ID3Info ID3File;
            int i = 0;

            try
            {
                foreach (string path in FilePaths)
                {
                    var file = TagLib.File.Create(FilePaths[i]);
                    var fileInfo = new FileInfo(FilePaths[i]);
                    ID3File = new ID3Info(FilePaths[i], true);
                    ID3File.FileSize = fileInfo.Length / 1000;
                    ////ID3File.ID3Size = file.
                    //collection.Add(ID3File); // Filepath is set correctly, Columns are being added at the end
                    //_Data = ID3File;
                    //dataGrid.ItemsSource = collection;
                    // FileInfo(path).Length
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(FilePaths[i] + "\nCan't load file. " + ex.Message, "Loading File");
                return;
            }
        }

        // Adding new file to datagrid
        public void AddNewFile(string filePath)
        {
            ID3Info ID3File;

            try
            {
                var file = TagLib.File.Create(filePath);
                var fileInfo = new FileInfo(filePath);
                ID3File = new ID3Info(filePath, true);
                ID3File.FileSize = fileInfo.Length / 1000;
                ////ID3File.ID3Size = file.
                collection.Add(ID3File); // Filepath is set correctly, Columns are being added at the end
                _Data = ID3File;
                dataGrid.ItemsSource = collection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(filePath + "\nCan't load file. " + ex.Message, "Loading File");
                return;
            }
        }

        // Row Click 1
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            int index = 0;
            var selectedFile = dataGrid.SelectedItem as ID3Info;
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].FilePath == selectedFile.FilePath)
                {
                    index = i;
                    break;
                }
            }
            frmGeneral g = new frmGeneral(selectedFile.FilePath, collection, index);
            g.Show();
        }

        // File Add 1 
        private void File_Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog List = new OpenFileDialog();
            List.Multiselect = true;
            List.Filter = "MP3 Files (*.mp3)|*.mp3";
            List.ValidateNames = true;
            if (List.ShowDialog() == true)
            {
                if (List.FileNames.Length > 1)
                {
                    LoadMultipleMP3(List.FileNames);
                }
                LoadMP3(List.FileName);
            }


        }

        // File Add 2
        public void LoadMP3(string path)
        {
            var file = TagLib.File.Create(path); // Get file from filepath

            if (Path.GetExtension(file.Name).ToLower() != ".mp3")
            {
                MessageBox.Show("File is not MP3.");
                return;
            }

            AddNewFile(path);
        }

        public void LoadMultipleMP3(string[] filePaths)
        {
            var file = TagLib.File.Create(path); // Get file from filepath

            foreach (string item in filePaths)
            {
                if (Path.GetExtension(item.Name).ToLower() != ".mp3")
                {
                    MessageBox.Show("File is not MP3.");
                    return; 
                }
            }
            AddNewFiles(filePaths);
        }

        private void Save_List_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }

        // Save list as .m3u 
        public void SaveList()
        {
            SaveFileDialog FileDialog = new SaveFileDialog();
            FileDialog.Filter = "M3U files(*.m3u)|*.m3u";
            FileDialog.Title = "Save files list";
            if (FileDialog.ShowDialog() == true)
            {
                FileInfo SF = new FileInfo(FileDialog.FileName);
                ArrayList A = new ArrayList();
                foreach (var st in collection)
                {
                    FileInfo F = new FileInfo(st.FilePath);
                    A.Add(F.FullName);
                }
                M3U.Save(FileDialog.FileName, (string[])A.ToArray(typeof(string)));
                MessageBox.Show("List saved successfully.");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;

            var selected = dataGrid.SelectedItem as ID3Info;

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].FilePath == selected.FilePath)
                {
                    dataGrid.SelectedItem = collection[i--];
                    break;
                }
            }
        }

        private void btDown_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;

            var selected = dataGrid.SelectedItem as ID3Info;

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].FilePath == selected.FilePath)
                {
                    dataGrid.SelectedItem = collection[i++];
                    DataContext = collection;
                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGrid.SelectedItem = collection[_selectedIndex];
        }
    }
}

