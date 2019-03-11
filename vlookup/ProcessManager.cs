using System;
using System.Collections.Generic;
using System.Text;

namespace vlookup
{
    public static class ProcessManager
    {
        public static BaseProcess CreateProcessExecutor(Settings settings)
        {
            BaseProcess process;

            if (settings.DiffMode != null)
            {
                process = new DiffModeProcess(settings);
            }
            else
            {
                process = new NormalProcess(settings);
            }
            
            return process;
        }
    }
}
