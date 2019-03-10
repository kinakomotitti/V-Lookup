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
                new Program().MainCore(args);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="args"></param>
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

        /// <summary>
        /// 引数チェック＋Settingインスタンスの作成
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
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

        /// <summary>
        /// DiffMode用のSettingインスタンスの作成処理
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="param"></param>
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

        /// <summary>
        /// 利用方法表示
        /// </summary>
        void ShowHelp()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("usage: dotnet vlookup.dll TargetFilePath [--help]");
            builder.AppendLine("\t  [--normal 検索値,範囲,列番号[,検索方法]]");
            builder.AppendLine("\t  [--diff 列番号,比較対象のfilePath[,区切り文字列]]");
            builder.AppendLine("\t  [--encoding エンコーディング方式]");
            builder.AppendLine("\t  [--output 出力先]");
            builder.AppendLine("");
            builder.AppendLine("--help, ヘルプ情報を表示します。");
            builder.AppendLine("");
            builder.AppendLine("--normal -n, 検索値,列番号[,範囲]]");
            builder.AppendLine("\t 検索値 \t 検索対象の文字列を指定します");
            builder.AppendLine("\t 列番号 \t 検索値を検索する範囲（列）を指定します");
            builder.AppendLine("\t 範囲 　\t 省略可。検索値を検索する範囲（行）を指定します");
            builder.AppendLine("\t【例】");
            builder.AppendLine("\t -n Sample,1　　　・・・指定されたファイルに含まれるすべての行の中で、1列目にSampleがある行を抽出します。");
            builder.AppendLine("\t -n Sample,1,1;5　・・・指定されたファイルの1行目～5行目の中、1列目にSampleがある行を抽出します。");
            builder.AppendLine("");
            builder.AppendLine("--diff -d, 主キー列,列番号,比較対象のfilePath");
            builder.AppendLine("\t 主キー列 \t 行を特定することができる特徴のある列を指定します。");
            builder.AppendLine("\t 列番号　 \t 主キー列で特定した行のうち、どの列の値を比較するかを選択します。デフォルトでは、すべての列を比較します。");
            builder.AppendLine("\t 比較対象のfilePath");
            builder.AppendLine("\t【例】");
            builder.AppendLine("\t -d 1,2,Sample.csv　・・・共通引数で指定されたファイルと、Sample.csvのうち、1列目が同じ値の行の2列目の値を比較します。");
            builder.AppendLine("\t -d 1;2;3;4,5;6;7,Sample.csv　・・・共通引数で指定されたファイルと、Sample.csvのうち、1~4列目が同じ値の行の5~7列目の値を比較します。");
            builder.AppendLine("");
            builder.AppendLine("--encoding　-e,  UTF-8 | Shift-JIS");
            builder.AppendLine("");
            builder.AppendLine("--output -o, console | file");

            Console.Write(builder.ToString());
        }
    }
}
