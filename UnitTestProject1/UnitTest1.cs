namespace UnitTestProject1
{
    #region using
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using vlookup;
    #endregion

    [TestClass]
    public class SampleUnitTest
    {
        [TestMethod]
        public void TemplateMethod()
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
            Assert.AreEqual("", "");
        }
    }
}
