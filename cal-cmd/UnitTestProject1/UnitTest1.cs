using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cal_cmd;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestArgs1()
        {
            string[] args = { "-g", "100", "problem.txt", "0" };
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(0, control.GetError());
        }
        [TestMethod]
        public void TestArgs2()
        {
            string[] args = { "-g", "100.1", "problem.txt", "0" };
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(1, control.GetError());
        }
        [TestMethod]
        public void TestArgs3()
        {
            string[] args = { "-g", "100", "problem.txt", "3" };
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(3, control.GetError());
        }
        [TestMethod]
        public void TestArgs4()
        {
            string[] args = { "-g", "-100", "problem.txt", "1" };
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(1, control.GetError());
        }
        [TestMethod]
        public void TestArgs5()
        {
            string[] args = { "-g", "100", "problem.txt", "1.1" };
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(3, control.GetError());
        }
        [TestMethod]
        public void TestArgs6()
        {
            string[] args = { "-g", "-100", "problem.txt"};
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(4, control.GetError());
        }
        [TestMethod]
        public void TestArgs7()
        {
            string[] args = {};
            Control control = new Control();
            control.ControlCore(args);
            Assert.AreEqual(4, control.GetError());
        }
        [TestMethod]
        public void TestCal1()
        {
            Solve solve = new Solve();
            solve.CalCore("(20+3)*3**2");
            Assert.AreEqual("207", solve.GetRes());
        }
        [TestMethod]
        public void TestCal2()
        {
            Solve solve = new Solve();
            solve.CalCore("( 20 + 3) * 4 ** 2");
            Assert.AreEqual("368", solve.GetRes());
        }
        [TestMethod]
        public void TestCal3()
        {
            Solve solve = new Solve();
            solve.CalCore("3/2 + 5");
            Assert.AreEqual("13/2", solve.GetRes());
        }
        [TestMethod]
        public void TestCal4()
        {
            Solve solve = new Solve();
            solve.CalCore("4/2 + 5");
            Assert.AreEqual("7", solve.GetRes());
        }
        [TestMethod]
        public void TestCal5()
        {
            Solve solve = new Solve();
            solve.CalCore("4 / 3 + 1/4");
            Assert.AreEqual("19/12", solve.GetRes());
        }
        [TestMethod]
        public void TestMyPow1()
        {
            Solve solve = new Solve();
            Assert.AreEqual(16, solve.MyPow(2, 4));
        }
        [TestMethod]
        public void TestGCD1()
        {
            Solve solve = new Solve();
            Assert.AreEqual(3, solve.gcd(15,6));
        }
        [TestMethod]
        public void TestGCD2()
        {
            Solve solve = new Solve();
            Assert.AreEqual(1, solve.gcd(15, 7));
        }
        [TestMethod]
        public void TestGCD3()
        {
            Solve solve = new Solve();
            Assert.AreEqual(15, solve.gcd(15, 0));
        }
    }
}
