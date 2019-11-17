using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace ID3_Editor
{
    public static class M3U
    {
        public static string[] Load(string FilePath)
        {
            StreamReader FS = new StreamReader(FilePath);
            if(FS.ReadLine() != "#EXTM3U")
                return null;

            string Temp;
            ArrayList Strings = new ArrayList();
            while (!FS.EndOfStream)
            {
                Temp = FS.ReadLine();
                if (Temp.StartsWith("#EXTINF"))
                    continue;

                Strings.Add(Temp);
            }

            return (string[])Strings.ToArray(typeof(string));
        }

        public static void Save(string FilePath, string[] Addresses)
        {
            StreamWriter SW = new StreamWriter(FilePath);
            SW.WriteLine("#EXTM3U");
            foreach (string st in Addresses)
            {
                SW.WriteLine(st);
            }
            SW.Close();
        }
    }
}
