using Microsoft.Office.Interop.Outlook;
using System;
using System.IO;
using System.Text;

namespace TimeTracking
{
    public static class ExceptionManager
    {
        public static void LogEvent(System.Exception ex, string msg, bool sendToDev)
        {
            string message = string.Empty;
            try
            {
                using (StreamWriter sw = File.Exists(Constants.exceptionsFilePath) ? File.AppendText(Constants.exceptionsFilePath) : File.CreateText(Constants.exceptionsFilePath))
                {
                    byte[] dateAsByteArr = Encoding.Default.GetBytes(ex.ToString());
                    sw.WriteLine(ex.ToString());
                    sw.WriteLine();
                }
            }
            catch
            {
                message = "An error has occured, unable to log exception to log file" + Environment.NewLine + ex.ToString();
            }

            if (sendToDev)
            {
                Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.Application();
                MailItem mail = outlook.CreateItem(OlItemType.olMailItem);
                mail.To = Constants.developer;
                mail.Subject = "Time tracking error";
                mail.BodyFormat = OlBodyFormat.olFormatPlain;
                mail.Body = string.Format("{0}{1}{2}{3}{4}", msg, Environment.NewLine, ex.ToString(), Environment.NewLine, ex.InnerException);
                mail.Display();
            }
            else
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = string.Format("An error has occured - see log {0}", Constants.exceptionsFilePath);
                }
            }
        }
    }
}