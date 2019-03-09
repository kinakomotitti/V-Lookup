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
        /// <summary>
        /// Encoding
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public string TargetFilePath { get; set; }

        public NormalMode NormalMode { get; set; } = null;

        public DiffMode DiffMode { get; set; } = null;

    }

    public class NormalMode
    {

    }

    public class DiffMode
    {
        public string TargetFilePath { get; set; }
        public string[] PrimaryKeyCols { get; set; }
        public string[] ConpareTargetCols { get; set; }
    }

}