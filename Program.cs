using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWork3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Если текущая операционная система является Windows Vista (версия 6) или более поздней версии,
            // вызывается функция поддержки масштабирования DPI
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        // Импорт функции из динамической библиотеки "user32.dll"
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        // Объявление функции, сообщающей операционной системе о том, что приложение поддерживает масштабирование DPI 
        private static extern bool SetProcessDPIAware();
    }
}
