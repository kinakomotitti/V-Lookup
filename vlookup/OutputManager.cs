﻿namespace vlookup
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
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

        public void Output()
        {
            switch (this.settings.OutputMethod.ToLower())
            {
                case "file":
                    File.WriteAllText($"{DateTime.Now.ToString("yyyyMMddhhmmss")}_output.csv",this.settings.ResultString,this.settings.Encoding);
                    break;

                case "console":
                default:
                    break;
            }
        }
    }
}
