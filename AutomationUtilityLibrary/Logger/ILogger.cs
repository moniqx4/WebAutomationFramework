using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUtilityLibrary.Logger
{
    public interface ILogger
    {
        void Log(string message);

        void Log(string message, params object[] param);
    }
}
