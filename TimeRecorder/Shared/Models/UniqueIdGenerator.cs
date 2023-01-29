using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeRecorder.Shared.Models
{

    public class UniqueIdGenerator
    {
        private static TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        private static Random random = new Random();
        private static int currentId = 0;
        private static readonly object lockObject = new object();

        public static Int64 GenerateId()
        {
            lock (lockObject)
            {
                return Int64.Parse("" + t.Seconds + random.Next(512) + ++currentId);
            }
        }
    }

}
