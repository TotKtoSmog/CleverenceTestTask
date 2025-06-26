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
    }
}
