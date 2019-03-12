namespace vlookup
{
    #region using
    using System;
    using System.IO;
    using System.Text;
    #endregion

    class ProgramCore
    {
        #region Main

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="args"></param>
        public static void MainCore(string[] args)
        {
            new ProgramCore().MainPrivate(args);
        }

        void MainPrivate(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var settings = this.CreateSettings(args);
            if (settings == null)
            {
                ProgramCore.ShowHelp();
                return;
            }

            ProcessManager.CreateProcessExecutor(settings).Execute();

            OutputManager.CreateOutputExecutor(settings).Output();
        }

        #endregion

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
                        this.NormalParam(settings, args[i + 1]);
                        break;

                    case "-e":
                    case "--encoding":
                        settings.Encoding = Encoding.GetEncoding(args[i + 1]);
                        break;

                    case "-o":
                    case "--output":
                        settings.OutputMethod = args[i + 1];
                        break;

                    case "-f":
                    case "--filter":
                        //TODO 特定の列のみ出力するための指定ができるようにする
                        throw new NotImplementedException();

                    default:
                        settings = null;
                        break;
                }
            }

            return settings;
        }

        /// <summary>
        /// NormalMode用のSettingインスタンスの作成処理
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="param"></param>
        void NormalParam(Settings settings, string param)
        {
            var paramList = param.Split(",");
            if (paramList.Length < 2) return;
            settings.DiffMode = null;
            settings.NormalMode = new NormalMode()
            {
                SearchString = paramList[0],
                TargetColNumber = paramList[1],
                TargetRowNumber = (paramList.Length == 3) ? paramList[2] : null
            };
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
                //TODO いずれオプションにする
                separator = ","
            };
        }

        /// <summary>
        /// 利用方法表示
        /// </summary>
        public static void ShowHelp()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("usage: dotnet vlookup.dll TargetFilePath [--help]");
            builder.AppendLine("\t  [--normal 検索値,列番号[,範囲]");
            builder.AppendLine("\t  [--diff 列番号,比較対象のfilePath[,区切り文字列]]");
            builder.AppendLine("\t  [--encoding エンコーディング方式]");
            builder.AppendLine("\t  [--output 出力先]");
            builder.AppendLine("");
            builder.AppendLine("--help, ヘルプ情報を表示します。");
            builder.AppendLine("");
            builder.AppendLine("--normal -n, 検索値,列番号[,範囲]");
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
