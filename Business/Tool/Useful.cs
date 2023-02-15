using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Tool
{
    public static class Useful
    {
        #region Gets

        public static string GetApplicationDirectory()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory.Replace("WebAppUnitTests\\bin\\Debug", "WebApp\\");
        }

        public static string GetAppSettings(string keyWebConfig)
        {
            return ConfigurationManager.AppSettings[keyWebConfig];
        }

        public static string GetPngToBase64String(string path)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            return String.Format("data:image/png;base64,{0}", base64String);
        }

        public static int GetPageSizeMaximun()
        {
            int pageSixeMaximun = Convert.ToInt32(Useful.GetAppSettings("PageSizeMaximun"));
            return pageSixeMaximun;
        }

        public static string GetRutCheckDigit(int rut)
        {
            int count = 2;
            int accumulator = 0;

            while (rut != 0)
            {
                int multiple = (rut % 10) * count;
                accumulator = accumulator + multiple;
                rut = rut / 10;
                count = count + 1;
                if (count == 8)
                {
                    count = 2;
                }
            }

            int digit = 11 - (accumulator % 11);
            string rutDigit = digit.ToString().Trim();
            if (digit == 10)
            {
                rutDigit = "K";
            }
            if (digit == 11)
            {
                rutDigit = "0";
            }

            return rutDigit;
        }

        public static string GetFormatRut(string rut)
        {
            int count = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(" ", "");
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    count++;
                    if (count == 3 && i != 0)
                    {
                        format = "." + format;
                        count = 0;
                    }
                }
                return format;
            }
        }

        public static string SOAPCSharpKey()
        {
            return GetAppSettings("KeyHeader");
        }

        #endregion

        #region Validate

        public static bool ValidateRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expression = new Regex(GetAppSettings("IsRut"));
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expression.IsMatch(rut))
            {
                return false;
            }
            char[] charCut = { '-' };
            string[] arrayRut = rut.Split(charCut);
            if (dv != GetRutCheckDigit(Convert.ToInt32(arrayRut[0])))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            if (dateTimeOffset == DateTimeOffset.MinValue)
                return false;
            else
                return true;
        }

        public static bool ValidateBase64String(string base64String)
        {
            return (base64String.Trim().Length % 4 == 0) && Regex.IsMatch(base64String.Trim(), @GetAppSettings("IsBase64String"), RegexOptions.None);
        }

        public static bool ValidateIsImageBase64String(string base64String)
        {
            if (!base64String.Contains("data:image/bmp;base64") && !base64String.Contains("data:image/emf;base64") && !base64String.Contains("data:image/exif;base64") && !base64String.Contains("data:image/gif;base64")
                && !base64String.Contains("data:image/icon;base64") && !base64String.Contains("data:image/jpeg;base64") && !base64String.Contains("data:image/jpg;base64") && !base64String.Contains("data:image/png;base64")
                && !base64String.Contains("data:image/tiff;base64") && !base64String.Contains("data:image/wmf;base64"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Replace
        public static string ReplaceConventionImageFromBase64String(string base64String)
        {
            base64String = base64String.Replace("data:image/bmp;base64,", "");
            base64String = base64String.Replace("data:image/emf;base64,", "");
            base64String = base64String.Replace("data:image/exif;base64,", "");
            base64String = base64String.Replace("data:image/gif;base64,", "");
            base64String = base64String.Replace("data:image/icon;base64,", "");
            base64String = base64String.Replace("data:image/jpeg;base64,", "");
            base64String = base64String.Replace("data:image/jpg;base64,", "");
            base64String = base64String.Replace("data:image/png;base64,", "");
            base64String = base64String.Replace("data:image/tiff;base64,", "");
            base64String = base64String.Replace("data:image/wmf;base64,", "");
            return base64String;
        }
        #endregion
    }
}
