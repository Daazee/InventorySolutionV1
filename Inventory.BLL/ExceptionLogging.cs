using System;
using System.IO;
namespace Inventory.BLL
{
    public static class ExceptionLogging
    {

        private static string ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation, HostAdd, StackTrace;

        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;

            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            ErrorLocation = ex.Message.ToString();
            StackTrace = ex.StackTrace;

            try
            {
                string filepath = Path.GetFullPath(@"E:\CSharpMVCProject\MVCApps\laundry1.0\LaundrySoln\Laundry.Job\log\");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                string filename = DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "_log.txt";
                //string path = Path.GetFullPath();
                string fullpath = filepath + filename;
                if (!File.Exists(fullpath))
                {
                    File.Create(fullpath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(fullpath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + StackTrace + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line;
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();

                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }

    }
}