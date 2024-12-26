using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status
{
    public class Status
    {
        public static List<string> status(string name)
        {
            List<string> active = new List<string>();
            active.Add(name);
            return active;
        }

        public static void Main(string[] args)
        {
        }
    }
}
