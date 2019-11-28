using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TextFileSearch
{
    public static class TextSearcher
    {
        public static FileResult SearchTextInFile(string file, string searchText, bool matchCase, bool matchWholeWord)
        {
            string pattern = null;
            if(!matchWholeWord) pattern = string.Format(".*{0}.*", Regex.Escape(searchText));
            else pattern = string.Format(@".*([^\d\w_]|^){0}([^\d\w_]|$).*", Regex.Escape(searchText));
            Regex regex = null;
            if (matchCase) regex = new Regex(pattern);
            else regex = new Regex(pattern, RegexOptions.IgnoreCase);

            FileResult fileResult = new FileResult(file);
            StreamReader sr = new StreamReader(File.Open(file, FileMode.Open, FileAccess.Read));

            string line;
            int lineNum = 0;
            while ((line = sr.ReadLine()) != null)
            {
                ++lineNum;
                if (regex.IsMatch(line))
                {
                    fileResult.LineResults.Add(new LineResult(lineNum, line));
                }
            }

            sr.Close();

            return fileResult.LineResults.Count > 0 ? fileResult : null;
        }

        public static List<FileResult> SearchTextInFolder(string folder, string searchText, string[] fileTypes, bool matchCase, bool matchWholeWord)
        {
            List<FileResult> fileResults = new List<FileResult>();
            string[] files =
                Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                .Where(s => fileTypes.Where( ft => s.EndsWith(ft)).Count() > 0)
                .ToArray();

            foreach (string file in files)
            {
                FileResult fileResults_tmp = SearchTextInFile(file, searchText, matchCase, matchWholeWord);
                if (fileResults_tmp != null)
                    fileResults.Add(fileResults_tmp);
            }

            return fileResults;
        }
    }

    public class LineResult
    {
        public int LineNum { get; set; }
        public string Line { get; set; }

        public LineResult(int lineNum, string line)
        {
            LineNum = lineNum;
            Line = line;
        }
    }

    public class FileResult
    {
        public string File { get; set; }
        public List<LineResult> LineResults { get; set; }

        public FileResult(string file)
        {
            LineResults = new List<LineResult>();
            File = file;
        }
    }
}
