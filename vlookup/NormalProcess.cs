using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace vlookup
{
    class NormalProcess : BaseProcess
    {

        #region コンストラクタ

        public NormalProcess(Settings settings)
        {
            base.settings = settings;
        }

        #endregion


        public override void Execute()
        {
            var inputData = this.ConvertInputDataToObject(this.settings.TargetFilePath);

            //検索範囲設定
            var startIndex = 0;
            var endIndex = inputData.Count;
            var counter = 0;
            if (this.settings.NormalMode.TargetRowNumber != null)
            {
                var param = int.Parse(this.settings.NormalMode.TargetRowNumber.Split(":")[0]) - 1;
                startIndex = param > endIndex ? endIndex : param;

                param = int.Parse(this.settings.NormalMode.TargetRowNumber.Split(":")[1]) - 1;
                endIndex = param > endIndex ? endIndex : param;
            }

            if (int.Parse(this.settings.NormalMode.TargetColNumber) > inputData[0].Count)
            {
                return;
            }

            //検索実行
            var builder = new StringBuilder();
            for (int i = startIndex; i < endIndex; i++)
            {
                if (inputData[i][int.Parse(this.settings.NormalMode.TargetColNumber) - 1] == this.settings.NormalMode.SearchString)
                {
                    builder.AppendLine(string.Join(",", inputData[i]));
                    counter++;
                }

            }

            this.settings.ResultString = builder.ToString();
            this.settings.ResultSummry = $"{counter}件のデータが検出されました。";
        }
    }
}
