using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace vlookup
{
    internal class MainProcess
    {

        internal string DiffFiles(string file1Path, string file2Path)
        {
            var file1Data = this.ConvertInputDataToObject(file1Path);
            var file2Data = this.ConvertInputDataToObject(file2Path);

            return this.ConpareList(file1Data, file2Data);
        }

        private List<List<string>> ConvertInputDataToObject(string inputDataPath)
        {
            var data = new List<List<string>>();
            File.ReadAllLines(inputDataPath)
               .ToList<string>()
               .ForEach(item =>
               {
                   var row = new List<string>();
                   item.Split(',').ToList().ForEach(param => row.Add(item));
                   data.Add(new List<string>());
               });
            return data;
        }


        private string ConpareList(List<List<string>> file1Data, List<List<string>> file2Data)
        {
            StringBuilder builder = new StringBuilder();
            file1Data.ForEach(file1Item =>
             {
                 file2Data.ForEach(file2Item =>
                 {
                     if (file1Item[0] == file2Item[0])
                     {
                         if (file1Item[1] == file2Item[1])
                         {
                             builder.Append($"☆{string.Join(',', file1Data)}");
                             builder.Append($"★{string.Join(',', file2Data)}");
                         }
                     }
                 });
                 builder.Append($"{string.Join(',', file1Data)}");
             });

            return builder.ToString();
        }
    }
}
