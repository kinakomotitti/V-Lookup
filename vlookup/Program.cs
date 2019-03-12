namespace vlookup
{
    #region using
    using System;
    using System.IO;
    using System.Text;
    #endregion

    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// usage: vlookup filePath [-n 検索値,列番号[,範囲]] [-d 列番号,比較対象のfilePath]
        /// -n --normal 検索値,列番号[,範囲]
        /// -d --diff 主キー列,列番号,比較対象のfilePath
        /// -e --encoding 指定可能エンコーディング方式：utf-8(default)、Shift-JIS
        /// 
        /// 
        /// 参考URL）http://www.excel-list.com/vlookup.html
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                ProgramCore.MainCore(args);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.Write(ex.ToString());
#endif
                ProgramCore.ShowHelp();
            }
        }
    }
}
