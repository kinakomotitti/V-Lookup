﻿namespace vlookup
{
    #region using
    using System;
    using System.IO;
    #endregion

    class OutputManager
    {
        private Settings settings { get; set; }

        public static OutputManager CreateOutputExecutor(Settings settings)
        {
            return new OutputManager(settings);
        }

        private OutputManager(Settings settings)
        {
            this.settings = settings;
        }

        #region 出力処理

        public void Output()
        {
            Console.WriteLine($"{this.settings.ResultSummry}");
            
            switch (this.settings.OutputMethod.ToLower())
            {
                case "file":
                    File.WriteAllText($"{DateTime.Now.ToString("yyyyMMddhhmmss")}_output.csv",this.settings.ResultString,this.settings.Encoding);
                    break;

                case "console":
                default:
                    Console.WriteLine($"{this.settings.ResultString}");
                    break;
            }
        }

        #endregion
    }
}
