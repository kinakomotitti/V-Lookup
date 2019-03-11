using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using vlookup;

namespace UnitTestProject1.NormalModeUnitTest
{
    [TestClass]
    public class PatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/file1.csv",
                DiffMode=null,
                NormalMode = new NormalMode()
                {
                    SearchString= "test003",
                    TargetColNumber="1"
                }
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();

            var actual = settings.ResultSummry;
            Assert.AreEqual("1件のデータが検出されました。", actual);
        }

        [TestMethod]
        public void TestMethod2()
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
            Assert.AreEqual("", "");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/typeB-1.csv",
                DiffMode = new DiffMode()
                {
                    TargetFilePath = "./../../../../SampleData/typeB-2.csv",
                    PrimaryKeyCols = "3".Split(","),
                    ConpareTargetCols = "4".Split(",")
                },
                NormalMode = null,
                Encoding = System.Text.Encoding.GetEncoding(932)
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            Assert.AreEqual("", "");
        }

    }
}

