using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;

namespace CommonUtilities
{
    public class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
    }


    public static class FileHelper
    {

        public static string Extension(this string @this)
        {
            try { return @this.Substring(@this.LastIndexOf(".") + 1); }
            catch { return ""; }
        }

        public static bool ExistsIn(this string @this, List<string> extensions)
        {
            return extensions.Contains(@this);
        }

        public static string Clean(this string @this)
        {
            return Regex.Replace(@this, @"[\\/:*?""<>|]+", "");
        }

        public static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            var searcher = new ManagementObjectSearcher(@"SELECT Caption, DeviceID FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            foreach (var device in searcher.Get())
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("Caption"),
                (string)device.GetPropertyValue("Caption")
                ));
            }

            return devices;
        }

        public static List<string> UsbDrives()
        {

            int i = 0;
            List<string> lista;

            Console.WriteLine("fetching logical disks...");

            try
            {

                ManagementObjectCollection drives = new ManagementObjectSearcher("SELECT Caption, DeviceID FROM Win32_DiskDrive WHERE InterfaceType='USB'").Get();

                lista = new List<string>();
                // browse all USB WMI physical disks
                foreach (ManagementObject drive in drives)
                {
                    // browse all USB WMI physical disks
                    foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"] + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        // browse all USB WMI physical disks
                        foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {
                            if (disk["CAPTION"].ToString() != null)
                            {
                                lista.Add(disk["CAPTION"].ToString());
                                //i++;
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.ToString());
                return null;
            }
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it’s new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
