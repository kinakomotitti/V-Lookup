namespace vlookup
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    #endregion

    /// <summary>
    /// MainProcess
    /// </summary>
    internal class MainProcess
    {
        /// <summary>
        /// Settings
        /// </summary>
        internal Settings settings { get; set; } = new Settings();

        #region コンストラクタ

        /// <summary>
        /// start with custom settings.
        /// </summary>
        /// <param name="settings"></param>
        internal MainProcess(Settings settings)
        {
            this.settings = settings;
        }

        #endregion

        #region Main Method (DiffFiles)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file1Path"></param>
        /// <param name="file2Path"></param>
        /// <returns></returns>
        internal string DiffFiles()
        {
            //read files
            var file1Data = this.ConvertInputDataToObject(this.settings.TargetFilePath);
            var file2Data = this.ConvertInputDataToObject(this.settings.DiffMode.TargetFilePath);

            //copare data and return result.
            return this.ConpareList(file1Data, file2Data);
        }

        #endregion

        #region privateMethod

        private List<List<string>> ConvertInputDataToObject(string inputDataPath)
        {
            var data = new List<List<string>>();
            File.ReadAllLines(inputDataPath, this.settings.Encoding)
               .ToList<string>()
               .ForEach(item =>
               {
                   var row = new List<string>();
                   item.Split(',').ToList().ForEach(param => row.Add(param));
                   data.Add(row);
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
                         if (file1Item[1] != file2Item[1])
                         {
                             builder.AppendLine($"★{string.Join(',', file2Item)}");
                         }
                     }
                 });
                 builder.AppendLine($"{string.Join(',', file1Item)}");
             });

            return builder.ToString();
        }

        #endregion
    }
}