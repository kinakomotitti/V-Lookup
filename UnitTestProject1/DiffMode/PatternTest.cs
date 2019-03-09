using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using vlookup;

namespace UnitTestProject1.DiffModeUnitTest
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
                DiffMode = new DiffMode()
                {
                    TargetFilePath = "./../../../../SampleData/file2.csv",
                    PrimaryKeyCols = "1".Split(","),
                    ConpareTargetCols = "2".Split(",")
                },
                NormalMode = null
            };
            var actual = ProcessManager.CreateProcessExecutor(settings).Execute();
            Assert.AreEqual("", actual);
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
            var actual = ProcessManager.CreateProcessExecutor(settings).Execute();
            Assert.AreEqual("", actual);
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
            var actual = ProcessManager.CreateProcessExecutor(settings).Execute();
            Assert.AreEqual("", actual);
        }

    }
}

