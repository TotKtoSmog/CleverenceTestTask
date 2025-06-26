using CleverenceTestTask.Задание_2;

namespace CleverenceTestTask.Test
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void GetCount_0_0returned()
        {
            Server.Clear();
            int expected = 0;

            int actual = Server.GetCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToCount_100_100returned()
        {
            Server.Clear();
            int count = 100;
            int expected = 100;

            Server.AddToCount(count);

            int actual = Server.GetCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToCount_100_20_120returned()
        {
            Server.Clear();
            int count1 = 100;
            int count2 = 20;
            int expected = 120;

            Server.AddToCount(count1);
            Server.AddToCount(count2);

            int actual = Server.GetCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCountParallel_0_0returned()
        {
            Server.Clear();
            int r1 = 0, r2 = 0;
            Parallel.Invoke(
                () => r1 = Server.GetCount(),
                () => r2 = Server.GetCount()
            );

            Assert.AreEqual(r1, r2);
        }
    }
}
