using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util_MY云笔记
{
    public class AppConfig
    {
        public static string GetConfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch { return null; }
        }
        public static string SaveConfig(string key, string value)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (ConfigurationManager.AppSettings[key] == null)
                {
                    conf.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    conf.AppSettings.Settings[key].Value = value;
                }

                conf.Save();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string SaveConfig(Dictionary<string, string> dic)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (KeyValuePair<string, string> k in dic)
                {
                    if (ConfigurationManager.AppSettings[k.Key] == null)
                    {
                        conf.AppSettings.Settings.Add(k.Key, k.Value);
                    }
                    else
                    {
                        conf.AppSettings.Settings[k.Key].Value = k.Value;
                    }
                }
                conf.Save();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
