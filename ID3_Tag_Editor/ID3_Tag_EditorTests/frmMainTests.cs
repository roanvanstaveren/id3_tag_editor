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
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            try
            {
                string[] strArr = {  path + "\\test.mp3",
                path + "\\test2.mp3" };
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
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            try
            {
                string[] strArr = { path + "\\test.mp3",
                path + "\\test2.mp3" };
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
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            try
            {
                form.AddNewFile(path + "\\test.mp3");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void LoadMP3Test()
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            try
            {
                form.LoadMP3(path + "\\test.mp3");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void LoadMultipleMP3Test()
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            try
            {
                string[] strArr = { path + "\\test.mp3",
                path + "\\test2.mp3" };
                form.LoadMultipleMP3(strArr);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}