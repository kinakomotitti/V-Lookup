using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using vlookup;

namespace UnitTestProject1.NormalModeUnitTest
{
    [TestClass]
    public class PatternTest
    {
        [TestMethod]
        public void test003が1列目に存在する()
        {
            //一行目にtest003がある行を出力。
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
        public void aが2列目に存在する()
        {
            //一行目にtest003がある行を出力。
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/file1.csv",
                DiffMode = null,
                NormalMode = new NormalMode()
                {
                    SearchString = "a",
                    TargetColNumber = "2"
                }
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            var actual = settings.ResultSummry;
            Assert.AreEqual("5件のデータが検出されました。", actual);
        }

        [TestMethod]
        public void test003が1から2行目の1列目に存在しない()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/file1.csv",
                DiffMode = null,
                NormalMode = new NormalMode()
                {
                    SearchString = "test003",
                    TargetColNumber = "1",
                    TargetRowNumber="1:2"

                }
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            var actual = settings.ResultSummry;
            Assert.AreEqual("0件のデータが検出されました。", actual);
        }

        [TestMethod]
        public void test003が４から１０行目の1列目に存在しない()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/file1.csv",
                DiffMode = null,
                NormalMode = new NormalMode()
                {
                    SearchString = "test003",
                    TargetColNumber = "1",
                    TargetRowNumber = "4:10"

                }
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            var actual = settings.ResultSummry;
            Assert.AreEqual("0件のデータが検出されました。", actual);
        }

        [TestMethod]
        public void test003が１０から１０行目の1列目に存在しない()
        {
            Settings settings = new Settings()
            {
                TargetFilePath = "./../../../../SampleData/file1.csv",
                DiffMode = null,
                NormalMode = new NormalMode()
                {
                    SearchString = "test003",
                    TargetColNumber = "1",
                    TargetRowNumber = "10:10"

                }
            };
            ProcessManager.CreateProcessExecutor(settings).Execute();
            var actual = settings.ResultSummry;
            Assert.AreEqual("0件のデータが検出されました。", actual);
        }
    }
}

