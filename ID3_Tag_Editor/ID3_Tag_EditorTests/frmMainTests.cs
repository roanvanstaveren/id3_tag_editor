using Microsoft.VisualStudio.TestTools.UnitTesting;
using ID3_Tag_Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3_Tag_Editor.Tests
{
    [TestClass()]
    public class frmMainTests
    {
        frmMain form = new frmMain();
        [TestMethod()]
        public void LoadM3uTest()
        {
            try
            {
                string[] strArr = { "C:\\Users\\roan1\\Music\\trap\\Alan Walker - Sing Me To Sleep (marshmello Remix).mp3",
                "C:\\Users\\roan1\\Music\\trap\\Black Coast - TRNDSTTR (Lucian Remix).mp3"};
                form.LoadM3u(strArr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void AddNewFilesTest()
        {
            try
            {
                string[] strArr = { "C:\\Users\\roan1\\Music\\trap\\Alan Walker - Sing Me To Sleep (marshmello Remix).mp3",
                "C:\\Users\\roan1\\Music\\trap\\Black Coast - TRNDSTTR (Lucian Remix).mp3"};
                form.AddNewFiles(strArr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void AddNewFileTest()
        {
            try
            {
                form.AddNewFile("C:\\Users\\roan1\\Music\\trap\\Alan Walker - Sing Me To Sleep (marshmello Remix).mp3");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void LoadMP3Test()
        {
            try
            {
                form.LoadMP3("C:\\Users\\roan1\\Music\\trap\\Alan Walker - Sing Me To Sleep (marshmello Remix).mp3");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void LoadMultipleMP3Test()
        {
            try
            {
                string[] strArr = { "C:\\Users\\roan1\\Music\\trap\\Alan Walker - Sing Me To Sleep (marshmello Remix).mp3",
                "C:\\Users\\roan1\\Music\\trap\\Black Coast - TRNDSTTR (Lucian Remix).mp3"};
                form.LoadMultipleMP3(strArr);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}