namespace vlookup.Output
{
    #region using
    using System;
    using System.IO;
    #endregion

    public class FileOutput : BaseOutput
    {
        public FileOutput(Settings settings) : base(settings) { }
        

        public override string OutputExecute()
        {
            File.WriteAllText($"{DateTime.Now.ToString("yyyyMMddhhmmss")}_output.csv",
                  this.settings.ResultString,
                  this.settings.Encoding);

            return "";
        }
    }
}
