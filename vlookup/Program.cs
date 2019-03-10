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
        /// -n --normal 検索値,範囲,列番号[,検索方法]
        /// ノーマルモード。指定された値が含まれる行を検索し、出力する。
        ///     検索値・・・必須。検索対象の文字列。
        ///     列番号・・・必須。検索対象の列番号。セミコロン区切りで複数指定可能。
        ///     [範囲]・・・省略可。指定範囲の行数で検索。規定は、０～最終行。
        /// 
        /// -d --diff 列番号,比較対象のfilePath[,区切り文字列]
        /// ファイル比較モード。
        ///     主キー列・・・・・・・・必須。比較対象の行を特定するためのキー列。カンマ区切りで複数指定可能。
        ///     列番号・・・・・・・・・必須。比較対象の列。セミコロン区切りで複数指定可能。
        ///     比較対象のfilePath・・・必須。比較対象のファイルパス。
        ///     
        /// -e --encoding 
        ///     デフォルト：utf-8
        ///     Shift-JIS
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                new Program().MainCore(args);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
 

        void MainCore(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var settings = this.CreateSettings(args);
            if (settings == null)
            {
                this.ShowHelp();
                return;
            }

            ProcessManager.CreateProcessExecutor(settings).Execute();

            OutputManager.CreateOutputExecutor(settings).Output();
            
        }

        Settings CreateSettings(string[] args)
        {
            var settings = new Settings();
            if (File.Exists(args[0]) == false) return null;
            settings.TargetFilePath = args[0];

            for (int i = 1; i < args.Length; i = i + 2)
            {
                switch (args[i])
                {
                    case "-d":
                    case "--diff":
                        this.DiffParam(settings, args[i + 1]);
                        break;

                    case "-n":
                    case "-normal":
                        throw new NotImplementedException();
                    //break;

                    case "-e":
                    case "--encoding":
                        settings.Encoding = Encoding.GetEncoding(args[i + 1]);
                        break;

                    case "-o":
                    case "--output":
                        settings.OutputMethod = args[i + 1];
                        break;

                    default:
                        settings = null;
                        break;
                }
            }

            return settings;
        }

        void DiffParam(Settings settings, string param)
        {
            var paramList = param.Split(",");
            if (paramList.Length != 3) return;

            settings.DiffMode = new DiffMode()
            {
                PrimaryKeyCols = paramList[0].Split(";"),
                ConpareTargetCols = paramList[1].Split(";"),
                TargetFilePath = paramList[2],
                //todo いずれオプションにする
                separator = ","
            };
        }

        void ShowHelp()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("いずれHelp情報書きます。");
            builder.AppendLine("-d --diff 列番号,比較対象のfilePath[,区切り文字列]");
            Console.Write(builder.ToString());
        }
    }
}
