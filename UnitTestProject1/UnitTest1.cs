using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using vlookup;

namespace UnitTestProject1
{
    [TestClass]
    public class SampleUnitTest
    {
        [TestMethod]
        public void SampleTestMethod()
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
            Assert.AreEqual("", "");
        }
    }
}
