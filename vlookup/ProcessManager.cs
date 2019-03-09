using System;
using System.Collections.Generic;
using System.Text;

namespace vlookup
{
    internal static class ProcessManager
    {
        internal static BaseProcess CreateProcessExecutor(Settings settings)
        {
            BaseProcess process;

            if (settings.DiffMode != null)
            {
                process = new DiffModeProcess(settings);
            }
            else
            {
                process = null;
                throw new NotImplementedException();
            }
            
            return process;
        }
    }
}
