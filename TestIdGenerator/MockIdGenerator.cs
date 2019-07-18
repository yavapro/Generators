using System.Threading;

namespace TestIdGenerator
{
    using System;
    
    public class MockGenerator
    {
        private static int counter = 0;
        
        public static long GenerateInt64()
        {
            long keyPart1_54bit = DateTime.UtcNow.Ticks << (64 - 54);
            long keyPart2_10bit = GetCount();
            
            long id = keyPart1_54bit | keyPart2_10bit;

            return id;
        }
        
        public static int GenerateInt32()
        {
            return (int)GenerateInt64();
        }
        
        public static string GenerateString()
        {
            return GenerateInt64().ToString();
        }

        private static int GetCount()
        {
            Interlocked.CompareExchange(ref counter, 1, 1024);
            var i = Interlocked.Increment(ref counter);

            return i++;
        }
    }
}