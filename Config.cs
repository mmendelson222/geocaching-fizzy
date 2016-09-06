using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy
{
    internal static class Config
    {
        private static string filepath;
        internal static string FilePath
        {
            get
            {
                if (filepath == null)
                    GetEnv();
                return filepath;
            }

            set
            {
                filepath = value;
                SaveEnv();
            }
        }


        const string ENV_SETTING = "gc-fizzy";
        private static void GetEnv()
        {
            string s = System.Environment.GetEnvironmentVariable(ENV_SETTING, EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(s)) return;
            filepath = s;
        }
        private static void SaveEnv()
        {
            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                string value = filepath;
                System.Environment.SetEnvironmentVariable(ENV_SETTING, value, EnvironmentVariableTarget.User);
            }).Start();
        }
    }
}
