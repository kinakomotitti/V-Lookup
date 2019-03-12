using System;
using System.Collections.Generic;
using System.Text;

namespace vlookup.Output
{
    class ConsoleOutput : BaseOutput
    {
        public ConsoleOutput(Settings settings) : base(settings) { }

        public override string OutputExecute()
        {
            Console.WriteLine($"{settings.ResultString}");
            return "";
        }
    }
}
