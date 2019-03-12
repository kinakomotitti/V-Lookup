using System.Text;

namespace vlookup.Output
{
    public abstract class BaseOutput
    {
        public Settings settings { get; set; }
        public BaseOutput(Settings settings)
        {
            this.settings = settings;
        }
        public abstract string OutputExecute();
    }
}
