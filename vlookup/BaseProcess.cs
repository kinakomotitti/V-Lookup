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
    internal abstract class BaseProcess
    {
        /// <summary>
        /// Settings
        /// </summary>
        internal Settings settings { get; set; } = new Settings();


        internal abstract string Execute();
    }
}