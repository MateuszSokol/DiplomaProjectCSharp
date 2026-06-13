using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjects.writeReadData
{
    internal class MyFile
    {
        public string filePath { get; set; }

        public void writeToFile()
        {
            // Compose a string that consists of three lines.
            string lines = "First line.\r\nSecond line.\r\nThird line.";

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
            file.WriteLine(lines);

            file.Close();
        }

        public string readFromFile()
        {
            // Source - https://stackoverflow.com/a/7387108
            // Posted by marc_s, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-06-10, License - CC BY-SA 4.0

            return File.ReadAllText(filePath);


        }
    }
}
