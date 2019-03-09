using System;

namespace vlookup
{
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
        /// -n --normal 検索値,範囲,列番号[,検索方法]
        /// ノーマルモード。指定された値が含まれる行を検索し、出力する。
        ///     検索値・・・必須。検索対象の文字列。
        ///     列番号・・・必須。検索対象の列番号。カンマ区切りで複数指定可能。
        ///     [範囲]・・・省略可。指定範囲の行数で検索。規定は、０～最終行。
        /// 
        /// -d --diff 列番号,比較対象のfilePath[,区切り文字列]
        /// ファイル比較モード。
        ///     主キー列・・・・・・・・必須。比較対象の行を特定するためのキー列。カンマ区切りで複数指定可能。
        ///     列番号・・・・・・・・・必須。比較対象の列。カンマ区切りで複数指定可能。
        ///     比較対象のfilePath・・・必須。比較対象のファイルパス。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //TODO 設定読み取り処理を別クラスに分割。
            Settings settings = new Settings()
            {
                TargetFilePath= "./../../../../SampleData/file1.csv",
                DiffMode = new DiffMode()
                {
                    TargetFilePath = "./../../../../SampleData/file2.csv",
                    PrimaryKeyCols="1".Split(","),
                    ConpareTargetCols="2".Split(",")
                } ,
                NormalMode=null
            };

            var result = ProcessManager.CreateProcessExecutor(settings).Execute();
            Console.Write(result);
        }
    }
}
