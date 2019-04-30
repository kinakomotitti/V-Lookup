namespace UnitTestProject1.OutputManager
{
    #region using
    using vlookup;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using vlookup.Output;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    #endregion

    [TestClass]
    public class OutputManagerTest
    {
        #region 正常系

        [TestMethod]
        public void コンソール出力用のインスタンスが生成される()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "",
                DiffMode = null,
                NormalMode = null,
                OutputMethod = "",
                Encoding = Encoding.UTF8,
                ResultString = "ああああ"
            };

            var actualInstance = OutputManager.CreateOutputExecutor(settings);

            Assert.AreEqual(typeof(ConsoleOutput), actualInstance.GetType());
        }

        [TestMethod]
        public void ファイル出力用のインスタンスが生成される()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "",
                DiffMode = null,
                NormalMode = null,
                OutputMethod = "file",
                Encoding = Encoding.UTF8,
                ResultString = "ああああ"
            };

            var actualInstance = OutputManager.CreateOutputExecutor(settings);

            Assert.AreEqual(typeof(FileOutput), actualInstance.GetType());
        }

        #endregion


        #region 入力値が異常な場合の正常系

        [TestMethod]
        public void 出力モードの設定値が不正な場合はコンソール出力用のインスタンスが生成される()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "",
                DiffMode = null,
                NormalMode = null,
                OutputMethod = "ふぁいる",
                Encoding = Encoding.UTF8,
                ResultString = "ああああ"
            };

            var actualInstance = OutputManager.CreateOutputExecutor(settings);

            Assert.AreEqual(typeof(ConsoleOutput), actualInstance.GetType());
        }

        #endregion
    }
}
