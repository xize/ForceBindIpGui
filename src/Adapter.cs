using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace src.ForceBindIPGui
{
    class Adapter
    {

        private static Adapter adpt;

        private Window window;

        private Adapter(Window window)
        {
            this.window = window;
        }

        public void setAdapterContext()
        {
            window.progress.Value = 0;

            if (!isValidIP(window.adapter.Text))
            {
                MessageBox.Show("Invalid ip address filled in, it needs to be in compliance with RF1918");
                return;
            }

            RegistryKey basekey;
            if (Environment.Is64BitOperatingSystem)
            {
                basekey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey("exefile").OpenSubKey("shell", true);
                RegistryKey key1 = basekey.CreateSubKey("Run Program Without VPN (ForcedBindIP 32 bit)");
                key1.SetValue("", "Run Program Without VPN (ForcedBindIP 32 bit)");
                RegistryKey command1 = key1.CreateSubKey("command");
                command1.SetValue("", "c:\\windows\\system32\\ForceBindIP "+window.adapter.Text+" \"%l\"");
                command1.Close();
                key1.Close();
                
                RegistryKey key2 = basekey.CreateSubKey("Run Program Without VPN (ForcedBindIP 64 bit)");
                key2.SetValue("", "Run Program Without VPN (ForcedBindIP 64 bit)");
                RegistryKey command2 = key2.CreateSubKey("command");
                command2.SetValue("", "c:\\windows\\syswow64\\ForceBindIP64 "+ window.adapter.Text + " \"%l\"");
                command2.Close();
                key2.Close();
                basekey.Close();
            }
            else
            {
                basekey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey("exefile").OpenSubKey("shell", true);
                RegistryKey key1 = basekey.CreateSubKey("Run Program Without VPN (ForcedBindIP 32 bit)");
                key1.SetValue("", "Run Program Without VPN (ForcedBindIP 32 bit)");
                RegistryKey command1 = key1.CreateSubKey("command");
                command1.SetValue("", "c:\\windows\\system32\\ForceBindIP "+ window.adapter.Text + " \"%l\"");
                command1.Close();
                key1.Close();
                basekey.Close();
            }

            window.progress.Value = 100;

        }

        public bool isAdapterSet()
        {
            if(Environment.Is64BitOperatingSystem)
            {
                RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey("exefile").OpenSubKey("shell", true);
                try
                {
                    RegistryKey key1 = basekey.OpenSubKey("Run Program Without VPN (ForcedBindIP 32 bit)");
                    RegistryKey key2 = basekey.OpenSubKey("Run Program Without VPN (ForcedBindIP 64 bit)");
                    if(key1 != null && key2 != null)
                    {
                        return true;
                    }
                    return false;
                } catch(Exception)
                {
                    return false;
                }
            } else
            {
                RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey("exefile").OpenSubKey("shell", true);
                try
                {
                    RegistryKey key = basekey.OpenSubKey("Run Program Without VPN (ForcedBindIP 32 bit)");
                    if(key != null)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool isValidIP(string ip)
        {
            try
            {
                IPAddress.Parse(ip);
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public static Adapter getAdapterFactory(Window window)
        {
            if(adpt == null)
            {
                adpt = new Adapter(window);
            }
            return adpt;
        } 
    }
}
