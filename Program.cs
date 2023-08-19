using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


class Program{
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);
    public static void Main(string[] args){
        RegistryKey FixTaskmgr = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
        FixTaskmgr.DeleteValue("DisableTaskMgr");
        FixTaskmgr.Close();       
        MessageBox((IntPtr)0, "Fix Task Manager", "succeeded", 0);        
        Process.Start("C:\\Windows\\System32\\Taskmgr.exe");
    }
}