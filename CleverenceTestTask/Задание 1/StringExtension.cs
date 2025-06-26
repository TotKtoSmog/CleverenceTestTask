namespace CleverenceTestTask.Задание_1
{
    public static class StringExtension
    {
        public static string Compression(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            int count = 0;
            char lastChar = str[0];
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            foreach (char c in str)
            {
                if (lastChar != c)
                {
                    stringBuilder.Append(count > 1 ? $"{lastChar}{count}" : $"{lastChar}");
                    count = 1;
                    lastChar = c;
                }
                else
                    count++;
            }
            stringBuilder.Append(count > 1 ? $"{lastChar}{count}" : $"{lastChar}");
            return stringBuilder.ToString();
        }

        public static string Decompression(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            char lastChar = str[0];
            System.Text.StringBuilder stringBuilderDigit = new System.Text.StringBuilder();
            for(int i = 1; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    stringBuilder.Append(decompressionString(stringBuilderDigit, lastChar));
                    stringBuilderDigit.Clear();
                    lastChar = str[i];
                }
                else
                {
                    stringBuilderDigit.Append(str[i]);
                }
            }
            stringBuilder.Append(decompressionString(stringBuilderDigit, lastChar));
            return stringBuilder.ToString();
        }
        private static string decompressionString(System.Text.StringBuilder stringBuilderDigit, char lastChar)
            => stringBuilderDigit.Length > 0 ? 
            new string(lastChar, Convert.ToInt32(stringBuilderDigit.ToString())) 
            : new string(lastChar, 1);
    }
}
