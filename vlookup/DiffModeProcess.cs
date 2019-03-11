﻿namespace vlookup
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    #endregion


    /// <summary>
    /// DiffModeProcess
    /// </summary>
    public class DiffModeProcess : BaseProcess
    {
        #region コンストラクタ

        public DiffModeProcess(Settings settings)
        {
            base.settings = settings;
        }

        #endregion

        #region Main Method (DiffFiles)

        /// <summary>
        /// 差分検出処理実行
        /// </summary>
        /// <param name="file1Path"></param>
        /// <param name="file2Path"></param>
        /// <returns></returns>
        public override void Execute()
        {
            //read files
            var file1Data = this.ConvertInputDataToObject(this.settings.TargetFilePath);
            var file2Data = this.ConvertInputDataToObject(this.settings.DiffMode.TargetFilePath);

            //copare data and return result.
            (this.settings.ResultString, this.settings.ResultSummry) = this.ConpareList(file1Data, file2Data);
        }

        #endregion

        #region privateMethod

        private (string, string) ConpareList(List<List<string>> file1Data, List<List<string>> file2Data)
        {
            StringBuilder builder = new StringBuilder();

            int targetCol = int.Parse(this.settings.DiffMode.PrimaryKeyCols.First());
            int collisionCount = 0;
            file1Data.ForEach(file1Item =>
            {
                bool iscollision = false;
                file2Data.ForEach(file2Item =>
                {
                    //比較する行の検索
                    if (this.CheckCols(file1Item, file2Item, this.settings.DiffMode.PrimaryKeyCols))
                    {
                        //比較実行
                        if (this.CheckCols(file1Item, file2Item, this.settings.DiffMode.ConpareTargetCols) == false)
                        {
                            //指定した値と一致しないときは☆をつけて表示する
                            builder.AppendLine($"★{string.Join(this.settings.DiffMode.separator, file2Item)}");
                            builder.AppendLine($"☆{string.Join(this.settings.DiffMode.separator, file1Item)}");
                            collisionCount++;
                            iscollision = true;
                        }
                    }
                });
                if (iscollision == false)
                    builder.AppendLine($"{string.Join(this.settings.DiffMode.separator, file1Item)}");
            });


            return (builder.ToString(), $"解析が完了しました。\r\n {collisionCount}件の違いが検出されました。");
        }

        private bool CheckCols(List<string> file1, List<string> file2, string[] patterns)
        {
            bool result = false;
            foreach (var colStr in patterns)
            {
                int col = int.Parse(colStr) - 1;
                result = file1[col] == file2[col];
                if (result == false) break;
            }
            return result;
        }

        #endregion
    }
}