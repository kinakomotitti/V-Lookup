namespace vlookup.Mode
{
    #region using
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    #endregion

    /// <summary>
    /// MainProcess
    /// </summary>
    public abstract class BaseProcess
    {
        /// <summary>
        /// Settings
        /// </summary>
        public Settings settings { get; set; } = new Settings();


        public abstract void Execute();

        protected List<List<string>> ConvertInputDataToObject(string inputDataPath)
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
    }
}