using CleverenceTestTask.Задание_1;

namespace CleverenceTestTask.Test
{
    [TestClass]
    public class StringExtension
    {
        [TestMethod]
        public void Compression_a_areturned()
        {
            string str = "a";
            string expected = "a";

            string actual = str.Compression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Compression_aaabbbcf_a3b3cfreturned()
        {
            string str = "aaabbbcf";
            string expected = "a3b3cf";

            string actual = str.Compression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Compression_abcf_abcfreturned()
        {
            string str = "abcf";
            string expected = "abcf";

            string actual = str.Compression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Compression_acaaafff_aca3f3returned()
        {
            string str = "acaaafff";
            string expected = "aca3f3";

            string actual = str.Compression();
            Assert.AreEqual(expected, actual);
        }
    }
}