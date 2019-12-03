﻿using ID3;
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
        private ID3Info _id3;
        public frmGeneral(ID3Info Data)
        {
            InitializeComponent();
            _id3 = Data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // id3 is null
            tbTrack.Text = _id3.FileName;
        }
    }
}
