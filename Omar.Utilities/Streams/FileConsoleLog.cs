using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Omar.Utilities.Streams
{
    public class FileConsoleLog
    {
        private readonly string LogDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Outputs");

        private static FileConsoleLog _outputSingleton;
        private static FileConsoleLog OutputSingleton
        {
            get
            {
                if (_outputSingleton == null)
                    _outputSingleton = new FileConsoleLog();

                return _outputSingleton;
            }
        }

        private static bool IsStreamWriterOn = true;

        public StreamWriter StreamWriter { get; set; }

        public FileConsoleLog()
        {
            EnsureDirectoryExists();
            InstantiateStreamWriter();
        }

        ~FileConsoleLog()
        {
            if (StreamWriter != null)
            {
                try
                {
                    StreamWriter.Dispose();
                }
                catch (ObjectDisposedException) { }
            }
        }

        public static void WriteLine(string str)
        {
            Console.WriteLine(str);

            if (IsStreamWriterOn)
                OutputSingleton.StreamWriter.WriteLine(str);
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(LogDirPath))
            {
                try
                {
                    Directory.CreateDirectory(LogDirPath);
                }
                catch (UnauthorizedAccessException ex)
                {
                    IsStreamWriterOn = false;
                    throw new ApplicationException(string.Format("Access denied. Could not create log directory using path: {0}. Logging errors to an external file disabled.", LogDirPath), ex);
                }
            }
        }

        private void InstantiateStreamWriter()
        {
            string filePath = Path.Combine(LogDirPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt");

            try
            {
                StreamWriter = new StreamWriter(filePath)
                {
                    AutoFlush = true
                };
            }
            catch (UnauthorizedAccessException)
            {
                IsStreamWriterOn = false;
                throw new ApplicationException(String.Format("Access denied. Could not instantiate StreamWriter using path: {0}. Logging errors to an external file disabled.", filePath));
            }

        }
    }
}
