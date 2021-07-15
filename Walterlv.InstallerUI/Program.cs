using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace Walterlv.InstallerUI
{
    public class Program : BootstrapperApplication
    {
        [STAThread]
        public static int Main(string[] args)
        {
            // 这里的代码仅为调试使用，在最终的项目中无任何用途。
            var app = new App();
            return app.Run();
        }

        protected override void Run()
        {
            Engine.Log(LogLevel.Standard, "Running the Walterlv.InstallerUI.");
            try
            {
                LaunchUI();
                Engine.Log(LogLevel.Standard, "Exiting the Walterlv.InstallerUI.");
                Engine.Quit(0);
            }
            catch (Exception ex)
            {
                Engine.Log(LogLevel.Error, $"The Walterlv.InstallerUI is failed: {ex}");
                Engine.Quit(-1);
            }
            finally
            {
                Engine.Log(LogLevel.Standard, "The Walterlv.InstallerUI has exited.");
            }
        }

        private int LaunchUI()
        {
            // 设置 WPF Application 的资源程序集，避免 WPF 自己找不到。
            Application.ResourceAssembly = Assembly.GetExecutingAssembly();

            // 正常启动 WPF Application。
            var app = new App();
            return app.Run();
        }
    }
}
