using System;
using System.Windows.Forms;
using StudentManagementWinForms;

namespace StudentManagementWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new Form1());
        }
    }
}