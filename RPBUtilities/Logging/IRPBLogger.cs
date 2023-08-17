using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RPBUtilities.Logging
{
    public interface IRPBLogger
    {
        void Log(string message,LogLevel level);
    }

}
