using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Balabolin.Crestron.Gate.Plugins
{
    public class Plugin
    {
        private DateTime _AssemblyDateTime;
        private IPlugin _plugin;
        public string Name => _plugin.Name;
        public string Version => _plugin.Version;
        public Bitmap Logo => _plugin.Logo;

        public DateTime AssemblyDateTime
        {
            get
            {
                return _AssemblyDateTime;
            }
        }

        public string AssemblyFileName { get; }
        public int PID { get; set; }
        public Plugin(string assemblyFileName)
        {
            AssemblyFileName = assemblyFileName;
        }
        public void LoadPlugin()
        {
            Assembly pluginAss = Assembly.LoadFrom(AssemblyFileName);
            if (pluginAss != null)
            {
                foreach (var type in pluginAss.GetTypes())
                {
                    var i = type.GetInterface("IPlugin");
                    if (i != null)
                    {
                        _plugin = (IPlugin)pluginAss.CreateInstance(type.FullName);
                        _AssemblyDateTime = File.GetLastWriteTime(AssemblyFileName);
                    }
                }
            }
        }
    }

    public class PluginManager
    {
        public string PluginDir { get; }

        public List<Plugin> Plugins;
        public void Rescan()
        {
            string[] pluginFiles = Directory.GetFiles(PluginDir, "*.dll");

            foreach (string pluginFile in pluginFiles)
            {
                Plugin plugin = new Plugin(pluginFile);
                plugin.LoadPlugin();
                Plugins.Add(plugin);
            }
        }

        public PluginManager(string pluginDir)
        {
            PluginDir = pluginDir;
            Plugins = new List<Plugin>();
        }
    }
}
