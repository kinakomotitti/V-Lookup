namespace vlookup
{
    #region using

    using System.Text;

    #endregion

    /// <summary>
    /// Setting
    /// </summary>
    public class Settings
    {
        #region CommonSettings

        /// <summary>
        /// Encoding
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public string TargetFilePath { get; set; }

        public string OutputMethod { get; set; } = "Console";

        public string ResultString { get; set; }

        public string ResultSummry { get; set; }

        #endregion

        public NormalMode NormalMode { get; set; } = null;

        public DiffMode DiffMode { get; set; } = null;

        
    }

    public class NormalMode
    {
        public string SearchString { get; set; }
        public string TargetColNumber { get; set; }
        public string TargetRowNumber { get; set; } 
    }

    public class DiffMode
    {
        public string TargetFilePath { get; set; }
        public string[] PrimaryKeyCols { get; set; }
        public string[] ConpareTargetCols { get; set; }
        public string separator { get; set; } = ",";
    }

}