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

            //string[] values = s.Split(new char[] { '|' });
            //try
            //{
            //    Application = string.IsNullOrEmpty(values[0]) ? null : values[0];
            //    DeploymentGroup = string.IsNullOrEmpty(values[1]) ? null : values[1];
            //    DeploymentID = string.IsNullOrEmpty(values[2]) ? null : values[2];
            //    DeploymentListLimit = string.IsNullOrEmpty(values[3]) ? 10 : int.Parse(values[3]);
            //}
            //catch { }
        }
        private static void SaveEnv()
        {
            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                //string value = string.Format("{0}|{1}|{2}|{3}", Application, DeploymentGroup, DeploymentID, DeploymentListLimit);
                string value = filepath;
                System.Environment.SetEnvironmentVariable(ENV_SETTING, value, EnvironmentVariableTarget.User);
            }).Start();
        }
    }
}
