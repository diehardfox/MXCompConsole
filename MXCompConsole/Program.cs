using MITSUBISHI.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXCompConsole
{
    class Program
    {
        private static DotUtlType control;
        static void Main(string[] args)
        {
            control = new DotUtlType();
            control.ActLogicalStationNumber = 1;

            if( control.Open() == 0 )
            {
                Console.WriteLine("Connection opened successfully");
            }
            else
            {
                Console.WriteLine("Unable to open connection. Closing the program");
                return;
            }

            var label = new string[] { "D100" };
            var value = new int[label.Length];
            var returnCode = control.ReadDeviceRandom(ref label, 1, ref value);
            
            if( returnCode == 0 )
            {
                Console.WriteLine("Able to read values");
                Console.WriteLine("{0} => {1}", label, value);
            }
            else
            {
                Console.WriteLine("Unable to read the values from the PLC. {0}", returnCode);
            }

            var label1 = "D100";
            var value1 = new short[label.Length];
            returnCode = control.ReadDeviceRandom2(ref label1, 1, ref value1);

            if (returnCode == 0)
            {
                Console.WriteLine("Able to read values");
                Console.WriteLine("{0} => {1}", label, value);
            }
            else
            {
                Console.WriteLine("Unable to read the values from the PLC. {0}", returnCode);
            }

            control.Close();
        }
    }
}
