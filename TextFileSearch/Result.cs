using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace TextFileSearch
{
    public struct Result
    {
        public int Number { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long LineMumber { get; set; }
        public string LineText { get; set; }

        public Result(int number, string filePpath, int lineNumber, string lineText)
            : this()
        {
            Number = number;
            FilePath = filePpath;
            FileName = Path.GetFileName(FilePath);
            LineMumber = lineNumber;
            LineText = lineText;
        }
    }

    public class ResultList : BindingList<Result>
    {
        public void Add(string filePpath, int lineNumber, string lineText)
        {
            this.Add(new Result(this.Count, filePpath, lineNumber , lineText));
        }
    }
}


