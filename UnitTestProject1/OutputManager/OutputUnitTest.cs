namespace UnitTestProject1.OutputManager
{
    #region using
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using vlookup;
    #endregion

    [TestClass]
    public class OutputUnitTest
    {
        [TestMethod]
        public void SampleTestMethod()
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

            var test = OutputManager.CreateOutputExecutor(settings);


        }
    }
}
