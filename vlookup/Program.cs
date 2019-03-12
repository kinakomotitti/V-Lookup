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
        ///
        /// filepath 必須。操作対象のファイルパス。
        /// 
        /// オプションコマンド。実行には、1つのオプションの選択が必要。
        /// -n --normal 検索値,列番号[,範囲]
        /// ノーマルモード。指定された値が含まれる行を検索し、出力する。
        ///     検索値・・・必須。検索対象の文字列。
        ///     列番号・・・必須。検索対象の列番号。セミコロン区切りで複数指定可能。
        ///     [範囲]・・・省略可。指定範囲の行数で検索。規定は、０～最終行。
        /// 
        /// -d --diff 主キー列,列番号,比較対象のfilePath
        /// ファイル比較モード。
        ///     主キー列・・・・・・・・必須。比較対象の行を特定するためのキー列。カンマ区切りで複数指定可能。
        ///     列番号・・・・・・・・・必須。比較対象の列。セミコロン区切りで複数指定可能。
        ///     比較対象のfilePath・・・必須。比較対象のファイルパス。
        ///     
        /// -e --encoding 
        ///     指定可能エンコーディング方式：utf-8(default)、Shift-JIS
        ///                
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                CoreProgram.Main(args);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.Write(ex.ToString());
#endif
                CoreProgram.ShowHelp();
            }
        }
    }
}
