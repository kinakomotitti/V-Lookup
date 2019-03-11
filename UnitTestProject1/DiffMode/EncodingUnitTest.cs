namespace UnitTestProject1.DiffModeUnitTest
{
    #region using
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using vlookup;
    #endregion

    [TestClass]
    public class EncodingTest
    {
        [TestMethod]
        public void UTF_8TestMethod()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/file1.csv",
                DiffMode = new DiffMode()
                {
                    TargetFilePath = "./../../../../SampleData/file2.csv",
                    PrimaryKeyCols = "1".Split(","),
                    ConpareTargetCols = "2".Split(",")
                },
                NormalMode = null
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            var actual = settings.ResultSummry;
            Assert.AreEqual("2件の違いが検出されました。", actual);
        }

        [TestMethod]
        public void Shift_JisMethod()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/typeA-1.csv",
                DiffMode = new DiffMode()
                {
                    TargetFilePath = "./../../../../SampleData/typeA-2.csv",
                    PrimaryKeyCols = "3".Split(","),
                    ConpareTargetCols = "4".Split(",")
                },
                NormalMode = null,
                Encoding = System.Text.Encoding.ASCII
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            var actual = settings.ResultSummry;
            Assert.AreEqual("2件の違いが検出されました。", actual);
        }
    }
}
