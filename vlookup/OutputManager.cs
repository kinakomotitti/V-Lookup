namespace vlookup
{
    #region using
    using System;
    using System.IO;
    using vlookup.Output;
    #endregion

    public class OutputManager
    {
        private Settings settings { get; set; }

        private OutputManager(Settings settings)
        {
            this.settings = settings;
        }

        public static BaseOutput CreateOutputExecutor(Settings settings)
        {
            BaseOutput output = null;
            switch (settings.OutputMethod.ToLower())
            {
                case "file":
                    output = new FileOutput(settings);
                    break;

                case "console":
                default:
                    output = new ConsoleOutput(settings);
                    break;
            }

            return output;
        }
    }
}
