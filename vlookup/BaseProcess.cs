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
    public abstract class BaseProcess
    {
        /// <summary>
        /// Settings
        /// </summary>
        public Settings settings { get; set; } = new Settings();


        public abstract void Execute();
    }
}