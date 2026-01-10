using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Helper
{
    public static class FakturaNumerGenerator
    {
        private static int _counter;
        private static readonly object _lock = new object();

        #region Konstruktor
        static FakturaNumerGenerator()
        {
            _counter = CounterPersistence.ReadCounter();
            System.Diagnostics.Debug.WriteLine($"[FakturaNumerGenerator] Wartosc: {_counter}");
        }
        #endregion
        public static string GenerateNumber()
        {
            lock (_lock)
            {
                DateTime now = DateTime.Now;
                int nextNumber = _counter + 1;
                return $"FV/{now.Year:D4}/{now.Month:D2}/{nextNumber}";
            }
        }

        public static void Increment()
        {
            lock (_lock)
            {
                _counter++;
                CounterPersistence.WriteCounter(_counter);
                System.Diagnostics.Debug.WriteLine($"[FakturaNumerGenerator] Wartosc pod dodaniu: {_counter}");
            }
        }
    }
}
