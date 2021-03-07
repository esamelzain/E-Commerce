using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace E_CommerceApi.Handlers
{
    public class BusinessLogicLayer
    {
        #region Declarations
        DataAccessLayer DAL = new DataAccessLayer();
        string SqlQuery;
        string[] paramName, paramValue;
        #endregion
        public static int VATPercantage = 5;
        /// </summary>
        public static Guid StringToGUID(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data);
        }
        public static string RemoveStyle(string html, string style)
        {
            Regex regex = new Regex(style + "\\s*:.*?;?");
            return regex.Replace(html, string.Empty);
        }
        /// <summary>
        /// Detect Mobile Device
        /// </summary>
        /// <returns></returns>
        public static bool isMobileBrowser()
        {
            //GETS THE CURRENT USER CONTEXT
            HttpContext context = HttpContext.Current;

            //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                return true;
            }
            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                return true;
            }
            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
                context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                return true;
            }
            //AND FINALLY CHECK THE HTTP_USER_AGENT 
            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                string[] mobiles = new[]
                {
                    "midp", "j2me", "avant", "docomo",
                    "novarra", "palmos", "palmsource",
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/",
                    "blackberry", "mib/", "symbian",
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio",
                    "SIE-", "SEC-", "samsung", "HTC",
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx",
                    "NEC", "philips", "mmm", "xx",
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java",
                    "pt", "pg", "vox", "amoi",
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo",
                    "sgh", "gradi", "jb", "dddi",
                    "moto", "iphone"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// constructs the  seo friendly url
        /// </summary>
        /// <param name="RestuarntName"></param>
        public static string GetUrlcompatibleString(string param)
        {
            param = param.Trim();
            if (param.Contains("-"))
                param = param.Replace("-", "+");            
            param = Regex.Replace(param, @"\s", "-");
            param = param.Replace("+", "-").Replace("/", "-").Replace("&", "and").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(",", "").Replace(".", "").Replace("--", "-").Replace("--", "-").Replace("?", "-");
            param = param.Replace("”", "-").Replace("\"", "-").Replace("!", "-").Replace("--", "-").Replace("%", "").Trim('-');
            return param.ToLower();
        }
        /// <summary>
        /// constructs the  seo friendly url
        /// </summary>
        /// <param name="RestuarntName"></param>
        public static string GetProductUrlString(string param)
        {
            param = param.Trim();
            param = param.Replace("/", "!");
            return param.ToLower();
        }
        public string GetSHA1HashData(string data)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("X2"));
            }
            return returnValue.ToString();
        }

         
        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        public void SaveLogTrack(string UserID, string Action)
        {
            SqlQuery = "Sp_SaveLogTrack";
            paramName = new string[2] { "@UserID", "@Action" };
            paramValue = new string[2];
            paramValue[0] = UserID;
            paramValue[1] = Action;
            DAL.ExecuteNonQueryWithParameters(SqlQuery, paramName, paramValue, "sp");
        }
        public bool SendSMS(string MobileNumber, string Message)
        {
            try
            {
                string userName = "JACKYSTRANS", password = "Pt0nLK9H", source = "JACKYSBSHOP";
                int type = 0, dlr = 0;

                if (MobileNumber.StartsWith("+971"))
                    MobileNumber = MobileNumber.Replace("+971", "971");
                else if (MobileNumber.StartsWith("00971"))
                    MobileNumber = MobileNumber.Replace("00971", "971");
                else if (MobileNumber.StartsWith("5"))
                    MobileNumber = "971" + MobileNumber;
                else if (MobileNumber.StartsWith("05"))
                    MobileNumber = "971" + MobileNumber.Substring(1);
                string uri = "http://sms.rmlconnect.net/bulksms2346/sbulksms?username=" + userName + "&password=" + password + "&type=" + type + "&dlr=" + dlr + "&destination=" + MobileNumber + "&source=" + source + "&message=" + Message;

                WebClient wc = new WebClient();
                var result = wc.DownloadData(uri);
                var response = System.Text.Encoding.Default.GetString(result);
            }
            catch (Exception)
            {
            }
            return true;
        }
    }
}