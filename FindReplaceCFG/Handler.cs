using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindReplaceCFG
{
    public class Handler
    {
        private string searchPath = @"C:\ProgramData\vizrt\viz3\"; // @"C:\Temp\Test";
        private string searchPhrase = "MapServerServerIp =";
        private string replacePhrase = "MapServerServerIp = vizmaps11";
        public void CopyOrig()
        {
            string hostName = GetHostName();
            string targetNamePart = "VIZ-" + hostName + "-";
            string targetName = "";

            for (int i = 0; i <= 4; i++)
            {
                targetName = targetNamePart + $"{i}-0.cfg";
                targetName = Path.Combine(searchPath, targetName);
                if (File.Exists(targetName))
                {
                    File.Copy(targetName, targetName + ".bck", true);
                    var result = ReplaceInFile(targetName);
                    SaveFile(targetName, result);
                }
            }
        }

        public string ReplaceInFile(string fileName)
        {
            var text = File.ReadAllText(fileName, Encoding.GetEncoding(1252)); //28591 ISO-8859-1 //28605 ISO-8859-15
            var lines = text.Split('\n');
            int indexer = 0;

            foreach (var line in lines)
            {
                if (line.Contains(searchPhrase))
                {
                    lines.SetValue(replacePhrase, indexer);
                }
                indexer++;
            }
            var resultFile = String.Join("\n", lines);
            return resultFile;
        }

        public void SaveFile(string targetName, string lines)
        {
            File.WriteAllText(targetName, lines, Encoding.GetEncoding(1252)); //Encoding.UTF8
        }



        private string GetHostName()
        {
            string result = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            return result;
        }



    }
}
