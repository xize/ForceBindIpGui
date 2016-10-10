using Microsoft.Win32;
using src.ForceBindIPGui.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.ForceBindIPGui
{
    class Installation
    {

        private static Installation inst;

        private Installation() {}

        public void install()
        {
            if(Environment.Is64BitOperatingSystem)
            {
                File.WriteAllBytes(@"C:\Windows\system32\BindIP.dll", Resources.BindIP);
                File.WriteAllBytes(@"C:\Windows\syswow64\BindIP.dll", Resources.BindIP);
                File.WriteAllBytes(@"C:\Windows\syswow64\BindIP64.dll", Resources.BindIP64);
                File.WriteAllBytes(@"C:\Windows\system32\ForceBindIP.exe", Resources.ForceBindIP);
                File.WriteAllBytes(@"C:\Windows\syswow64\ForceBindIP64.exe", Resources.ForceBindIP64);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\ForceBindIPGui");
                File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ForceBindIPGui\ForceBindIPGui.exe");
                RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("run", true);
                basekey.SetValue("ForceBindIPGui", @"%appdata%\ForceBindIPGui\ForceBindIPGui.exe -minimized");
                basekey.Close();
            } else
            {
                File.WriteAllBytes(@"C:\Windows\system32\BindIP.dll", Resources.BindIP);
                File.WriteAllBytes(@"C:\Windows\system32\ForceBindIP.exe", Resources.ForceBindIP);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ForceBindIPGui");
                File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ForceBindIPGui\ForceBindIPGui.exe");
                RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("run", true);
                basekey.SetValue("ForceBindIPGui", @"%appdata%\ForceBindIPGui\ForceBindIPGui.exe -minimized");
                basekey.Close();
            }
        }

        public void uninstall()
        {
            if(isInstalled())
            {
                if(Environment.Is64BitOperatingSystem)
                {
                    RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey("exefile").OpenSubKey("shell", true);
                    try
                    {
                        basekey.DeleteSubKeyTree("Run Program Without VPN (ForcedBindIP 64 bit)");
                        basekey.DeleteSubKeyTree("Run Program Without VPN (ForcedBindIP 32 bit)");
                        basekey.Close();
                    } catch(ArgumentNullException) { } catch(ArgumentException) { }
                    File.Delete(@"C:\Windows\System32\BindIP.dll");
                    File.Delete(@"C:\Windows\System32\ForceBindIP.exe");
                    File.Delete(@"C:\Windows\syswow64\BindIP.dll");
                    File.Delete(@"C:\Windows\syswow64\BindIP64.dll");
                    File.Delete(@"C:\Windows\syswow64\ForceBindIP64.exe");

                    Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ForceBindIPGui", true);
                    RegistryKey basekey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("run", true);
                    basekey2.DeleteValue("ForceBindIPGui");
                    basekey2.Close();
                } else
                {
                    RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey("exefile").OpenSubKey("shell", true);
                    try
                    {
                        basekey.DeleteSubKey("Run Program Without VPN (ForcedBindIP 32 bit)");
                        basekey.Close();
                    } catch (ArgumentNullException) { } catch (ArgumentException) { }
                    File.Delete(@"C:\Windows\System32\BindIP.dll");
                    File.Delete(@"C:\Windows\System32\ForceBindIP.exe");

                    Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ForceBindIPGui", true);
                    RegistryKey basekey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("run", true);
                    basekey2.DeleteValue("ForceBindIPGui");
                    basekey2.Close();
                }
            }
        }

        public bool isInstalled()
        {
            if(Environment.Is64BitOperatingSystem)
            {
                if(File.Exists(@"C:\Windows\System32\BindIP.dll") && File.Exists(@"C:\Windows\System32\ForceBindIP.exe") && File.Exists(@"C:\Windows\syswow64\BindIP.dll") && File.Exists(@"C:\Windows\syswow64\BindIP64.dll") && File.Exists(@"C:\Windows\syswow64\ForceBindIP64.exe"))
                {
                    return true;
                }
            } else
            {
                if (File.Exists(@"C:\Windows\System32\BindIP.dll") && File.Exists(@"C:\Windows\System32\ForceBindIP.exe"))
                {
                    return true;
                }
            }
            return false;
        }

        public static Installation getInstallation()
        {
            if(inst == null)
            {
                inst = new Installation();
            }
            return inst;
        }

    }
}
