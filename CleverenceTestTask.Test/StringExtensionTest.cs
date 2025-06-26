using CleverenceTestTask.Задание_1;

namespace CleverenceTestTask.Test
{
    [TestClass]
    public class StringExtensionTest
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

        [TestMethod]
        public void Compression_aaabbcccdde_a3b2c3d2ereturned()
        {
            string str = "aaabbcccdde";
            string expected = "a3b2c3d2e";

            string actual = str.Compression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decompression_a_areturned()
        {
            string str = "a";
            string expected = "a";

            string actual = str.Decompression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decompression_ab2_abbreturned()
        {
            string str = "ab2";
            string expected = "abb";

            string actual = str.Decompression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decompression_ab2a4c2_abbaaaaccreturned()
        {
            string str = "ab2a4c2";
            string expected = "abbaaaacc";

            string actual = str.Decompression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decompression_a11_aaaaaaaaaaareturned()
        {
            string str = "a11";
            string expected = "aaaaaaaaaaa";

            string actual = str.Decompression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decompression_a10b5c3_aaaaaaaaaabbbbbcccreturned()
        {
            string str = "a10b5c3";
            string expected = "aaaaaaaaaabbbbbccc";

            string actual = str.Decompression();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decompression_a3b2c3d2e_aaabbcccddereturned()
        {
            string str = "a3b2c3d2e";
            string expected = "aaabbcccdde";

            string actual = str.Decompression();
            Assert.AreEqual(expected, actual);
        }
    }
}