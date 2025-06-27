using System.Text;

namespace CleverenceTestTask.Задание_3
{
    public class LogParser
    {
        private static Dictionary<string, string> _logLevelMap = new Dictionary<string, string>()
        {
            { "INFORMATION", "INFO" },
            { "INFO", "INFO" },
            { "WARNING", "WARN" },
            { "WARN", "WARN" },
            { "ERROR", "ERROR" },
            { "DEBUG", "DEBUG" },
        };
        private sealed class LogRow
        {
            private string _date;
            private string _time;
            private string _level;
            private string _method;
            private string _message;

            public string Date
            {
                get => _date;
            }
            public string Time
            {
                get => _time;
            }
            public string Level
            {
                get => _level;
            }
            public string Method
            {
                get => _method;
            }
            public string Message
            {
                get => _message;
            }
            public LogRow(string date, string time, string level, string message, string method = "DEFAULT")
            {
                _date = _dateCovertor(date.Trim());
                _time = time.Trim();
                _level = _correctingLogLeval(level.Trim());
                _method = method.Trim();
                _message = message.Trim();
            }
            private string _dateCovertor(string date)
            {
                var formats = new[] { "dd.MM.yyyy", "yyyy-MM-dd" };
                var dt = DateTime.ParseExact(date, formats, null, System.Globalization.DateTimeStyles.None);
                return dt.ToString("dd-MM-yyyy");
            }
            private string _correctingLogLeval(string str)
                => _logLevelMap.TryGetValue(str.Trim().ToUpper(), out var result) ? result : "UNKNOWN";
            public override string ToString()
                => $"{_date}\t{_time}\t{_level}\t{_method}\t{_message}";
        }

        private const string  problemFileName = "problems.txt";
        public void ParsingLogFile(string path, string pathOut = "",string pathProblems = "")
        {
            var inputDirectory = Path.GetDirectoryName(path) ?? ".";

            string logOutputPath = string.IsNullOrEmpty(pathOut) 
                ? Path.Combine(inputDirectory, $"Log_{DateTime.Now:yyyy_MM_dd}.txt") : pathOut;
            string problemOutputPath = string.IsNullOrEmpty(pathProblems) 
                ? Path.Combine(inputDirectory, problemFileName) 
                : Path.Combine(Path.GetDirectoryName(pathProblems), problemFileName) ;

            using var inputFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var inputStreamReader = new StreamReader(inputFileStream, Encoding.UTF8);

            using var outputFileStream = new FileStream(logOutputPath, FileMode.Append, FileAccess.Write);
            using var outputStreamWriter = new StreamWriter(outputFileStream, Encoding.UTF8);

            using var problemsFileStream = new FileStream(problemOutputPath, FileMode.Append, FileAccess.Write);
            using var problemsStreamWriter = new StreamWriter(problemsFileStream, Encoding.UTF8);

            Console.WriteLine($"Начало парсинга файла по адресу: {path}");
            string line = string.Empty;
            ulong count = 0;
            while ((line = inputStreamReader.ReadLine()) != null)
            {
                count++;
                try
                {
                    string temp = ParsingString(line) + "\n";
                    outputStreamWriter.WriteLine(temp);
                }
                catch
                {
                    problemsStreamWriter.WriteLine(line);
                }
            }
            Console.WriteLine($"Парсинг окончен\nОбработано строк: {count}");
            Console.WriteLine($"Результат сохранен по пути: {Path.GetFullPath(logOutputPath)}\n" +
                $"Строки, которые не удалось расправсить, сохранены по пути: {Path.GetFullPath(problemOutputPath)}");
        }
        public string ParsingString(string line)
        {
            LogRow log;

            if (line.Contains('|'))
            {
                var data = line.Split('|');

                if (data.Length < 5) throw new FormatException("Некорректный формат 2");
                var dateTime = data[0].Split(' ');
                if (dateTime.Length != 2) throw new FormatException("Некорректный формат даты и времени");
                log = new LogRow(dateTime[0], dateTime[1], data[1], data[4], data[3]);
            }
            else
            {
                var data = line.Split(' ', 4);
                if (data.Length != 4) throw new FormatException("Некорректный формат 1");
                log = new LogRow(data[0], data[1], data[2], data[3]);
            }
            if(log.Level == "UNKNOWN") throw new FormatException("Не корректный уровень лога");
            return log.ToString();
        }
    }
}
