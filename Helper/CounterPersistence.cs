using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Medical.Helper
{
    public static class CounterPersistence
    {
        private static readonly string _filePath = "counter.txt";
        private static readonly object _lock = new object();

        public static int ReadCounter()
        {
            lock (_lock)
            {
                try
                {
                    if (File.Exists(_filePath))
                    {
                        string content = File.ReadAllText(_filePath);
                        if (int.TryParse(content, out int counter))
                        {
                            return counter;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[CounterPersistence] Read error: {ex.Message}");
                }
                return 0;
            }
        }

        public static void WriteCounter(int counter)
        {
            lock (_lock)
            {
                try
                {
                    File.WriteAllText(_filePath, counter.ToString());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[CounterPersistence] Write error: {ex.Message}");
                }
            }
        }
    }
}
