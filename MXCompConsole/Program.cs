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

            var label = "D100";
            var value = new int[2];
            var returnCode = control.ReadDeviceBlock(ref label, 2, ref value);
            
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
            var value1 = new int[1];
            returnCode = control.ReadDeviceBlock(ref label1, 1, ref value1);

            if (returnCode == 0)
            {
                Console.WriteLine("Able to read values");
                Console.WriteLine("{0} => {1}", label1, value1);
            }
            else
            {
                Console.WriteLine("Unable to read the values from the PLC. {0}", returnCode);
            }

            var label2 = "D100";
            var value2 = 0;
            returnCode = control.GetDevice(ref label2, ref value2);

            if (returnCode == 0)
            {
                Console.WriteLine("Able to read values");
                Console.WriteLine("{0} => {1}", label2, value2);
            }
            else
            {
                Console.WriteLine("Unable to read the values from the PLC. {0}", returnCode);
            }

            control.Close();
        }
    }
}
