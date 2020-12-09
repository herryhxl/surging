using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace EFRepository.Extend
{
    public static class Extend
    {
        public static string MapPath(this string path)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, path);
        }
        public static bool IsDataSetData(this DataSet DataSet)
        {
            if (DataSet == null || DataSet.Tables.Count == 0 || DataSet.Tables[0].Rows.Count == 0) return true;
            return false;
        }

        public static string ToBeginEndDateString(this DateTime BeginTime, DateTime EndTime)
        {
            var DateText = "";
            var BeginDays = (new DateTime(BeginTime.Year, BeginTime.Month, BeginTime.Day) - DateTime.Today).TotalDays;
            var EndDays = (new DateTime(EndTime.Year, EndTime.Month, EndTime.Day) - DateTime.Today).TotalDays;
            if (BeginDays == -1)
                DateText = "昨天," + BeginTime.ToString("HH:mm");
            else if (BeginDays == 0)
                DateText = "今天," + BeginTime.ToString("HH:mm");
            else if (BeginDays == 1)
                DateText = "明天," + BeginTime.ToString("HH:mm");
            else
            {
                if (DateTime.Now.Year == BeginTime.Year)
                {
                    if (EndTime.Day == BeginTime.Day && EndTime.Month == BeginTime.Month)
                        DateText = string.Format("{0},{1}", BeginTime.ToString("MM-dd"), BeginTime.ToString("HH:mm"));
                    else if (EndTime.Month == BeginTime.Month)
                        DateText = string.Format("{0},{1}", BeginTime.ToString("MM月"), BeginTime.ToString("dd日 HH:mm"));
                    else
                        DateText = "," + BeginTime.ToString("MM-dd HH:mm");
                }
                else
                    DateText = "," + BeginTime.ToString("yyyy-MM-dd HH:mm");
            }
            //处理结束时间
            if (EndDays == -1)
            {
                if (BeginDays == -1)
                    DateText += ",," + EndTime.ToString("HH:mm");
                else DateText += ",昨天," + EndTime.ToString("HH:mm");
            }
            else if (EndDays == 0)
            {
                if (BeginDays == 0)
                    DateText += ",," + EndTime.ToString("HH:mm");
                else DateText += ",今天," + EndTime.ToString("HH:mm");
            }
            else if (EndDays == 1)
            {
                if (BeginDays == 1)
                    DateText += ",," + EndTime.ToString("HH:mm");
                else DateText += ",明天," + EndTime.ToString("HH:mm");
            }
            else
            {
                if (DateTime.Now.Year == EndTime.Year)
                {
                    if (EndTime.Day == BeginTime.Day && EndTime.Month == BeginTime.Month)
                        DateText += ",," + EndTime.ToString("HH:mm");
                    else if (EndTime.Month == BeginTime.Month)
                        DateText += ",," + EndTime.ToString("dd日 HH:mm");
                    else DateText += ",," + EndTime.ToString("MM-dd HH:mm");
                }
                else
                    DateText += ",," + EndTime.ToString("yyyy-MM-dd HH:mm");
            }
            return DateText;
        }
        public static DateTime Begin(this DateTime Begin)
        {
            return new DateTime(Begin.Year, Begin.Month, Begin.Day, 0, 0, 0);
        }
        public static long TimeStampMillisecond(this DateTime Time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var intResult = (Time - startTime).TotalMilliseconds;
            return (long)intResult;
        }
        public static long TimeStamp(this DateTime Time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var intResult = (Time - startTime).TotalSeconds;
            return (long)intResult;
        }
        public static string ToWeekString(this DateTime Time)
        {
            var Week = Time.DayOfWeek;
            string WeekString = "";
            switch (Week)
            {
                case DayOfWeek.Monday:
                    WeekString = "周一"; break;
                case DayOfWeek.Tuesday:
                    WeekString = "周二"; break;
                case DayOfWeek.Wednesday:
                    WeekString = "周三"; break;
                case DayOfWeek.Thursday:
                    WeekString = "周四"; break;
                case DayOfWeek.Friday:
                    WeekString = "周五"; break;
                case DayOfWeek.Saturday:
                    WeekString = "周六"; break;
                case DayOfWeek.Sunday:
                    WeekString = "周日"; break;
            }
            return string.Format(WeekString + " {0}", Time.ToDateString());
        }

        public static DateTime Begin(this DateTime? Begin)
        {
            if (Begin == null) throw new ValidateException("开始时间不能为空");
            DateTime be = (DateTime)Begin;
            return be.Begin();
        }
        public static string ToUserID(this string Account)
        {
            if (Account.IsNull()) throw new ValidateException("账号不能为空");
            return string.Format("sip:+{0}@ims.ge.chinamobile.com", Account.ToAccount());
        }

        public static string UserIDToAccount(this string UserID)
        {
            if (UserID.IsNull()) throw new ValidateException("账号不能为空");
            var p = UserID.IndexOf("@");
            if (p != -1)
            {
                //-22-5
                return UserID.Substring(7, p - 7);
            }
            else throw new ValidateException(string.Format("UserID:{0}格式错误。", UserID));
        }
        public static string ToAccount(this string Account)
        {
            if (Account.IsNull()) throw new ValidateException("账号不能为空");
            var Flag = -1;
            for (int i = 0; i < Account.Length; i++)
            {
                var item = Account[i];
                if (item == '0') Flag = i;
                else break;
            }
            if (Flag != -1)
                Account = Account.Substring(Flag + 1);
            return string.Format("86{0}", Account);
        }


        public static bool IsChange<T>(this T OldValue, T Value)
        {
            if (OldValue == null)
            {
                if (Value == null)
                    return false;
                return true;
            }
            return !OldValue.Equals(Value);
        }

        public static string HmacSha1(this string encryptText, string encryptKey)
        {
            HMACSHA1 myHMACSHA1 = new HMACSHA1(Encoding.Default.GetBytes(encryptKey));
            byte[] RstRes = myHMACSHA1.ComputeHash(Encoding.Default.GetBytes(encryptText));

            StringBuilder EnText = new StringBuilder();
            foreach (byte Byte in RstRes)
            {
                EnText.AppendFormat("{0:x2}", Byte);
            }
            return EnText.ToString();
        }

        public static string CodeStart(this string Code)
        {
            StringBuilder Str = new StringBuilder();
            for (int i = 1; i <= Code.ToArray().Count(); i++)
            {
                if (i % 2 == 0)
                {
                    var p = Code.Substring(i - 2, 2);
                    if (p != "00")
                        Str.Append(p);
                }
            }
            return Str.ToString();
        }

        public static List<string> CodeList(this string Code)
        {
            var Result = new List<string>();
            if (Code.IndexOf('-') != -1)
            {
                StringBuilder str = new StringBuilder();
                Code.ToCharArray().ToList().ForEach(item =>
                {
                    if (item != '-')
                        Result.Add(str.ToString());
                    str.Append(item);
                });
            }
            else//530101{530000,530100,530101}
            {
                for (int i = 1; i <= Code.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        var MyCode = Code.Substring(0, i);
                        for (int p = i; p < Code.Length; p++)
                        {
                            MyCode += "0";
                        }
                        Result.Add(MyCode);
                    }
                }
            }
            return Result.Distinct().ToList();
        }

        public static DateTime End(this DateTime End)
        {
            return new DateTime(End.Year, End.Month, End.Day, 23, 59, 59);
        }
        public static DateTime End(this DateTime? End)
        {
            if (End == null) throw new ValidateException("结束时间不能为空");
            DateTime be = (DateTime)End;
            return be.End();
        }


        public static string UTF8ToBase64(this string Text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Text));
        }
        public static string Base64ToUTF8(this string Text)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(Text));
        }

        public static string Base64ToImageUrl(this string Base64ImageData, string Path)
        {
            string dymicName = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            byte[] arr = Convert.FromBase64String(Base64ImageData);//将纯净资源Base64转换成等效的8位无符号整形数组
            var ms = new MemoryStream(arr);//转换成无法调整大小的MemoryStream对象
            var bitmap = new System.Drawing.Bitmap(ms);//将MemoryStream对象转换成Bitmap对象
            var fileName = $@"/{dymicName}.jpg";
            string ImageUrl = Path + fileName; //转换成绝对路径 
            bitmap.Save(ImageUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
            //保存到服务器路径
            //bitmap.Save(filePath + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            //bitmap.Save(filePath + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
            //bitmap.Save(filePath + ".png", System.Drawing.Imaging.ImageFormat.Png);
            ms.Close();//关闭当前流，并释放所有与之关联的资源
            bitmap.Dispose();
            return fileName;
        }

        public static List<int> ToIntList(this string Text)
        {
            var Result = new List<int>();
            Text.Split(',').ToList().ForEach(item =>
            {
                Result.Add(Convert.ToInt32(item));
            });
            if (Result.Count == 0) throw new ValidateException("未包含任何元素");
            return Result;
        }

        public static DateTime getValueDateTime(this string Text)
        {
            return Convert.ToDateTime(Text);
        }
        public static Guid getValueGuid(this string Text)
        {
            return Guid.Parse(Text);
        }
        public static decimal getValuedecimal(this string Text)
        {
            return Convert.ToDecimal(Text.Trim());
        }
        public static float getValuefloat(this string Text)
        {
            return Convert.ToSingle(Text.Trim());
        }
        public static long getValuelong(this string Text)
        {
            return Convert.ToInt64(Text.Trim());
        }
        public static int getValueint(this string Text)
        {
            return Convert.ToInt32(Text.Trim());
        }
        public static bool getValuebool(this string Text)
        {
            return Convert.ToBoolean(Text);
        }
        public static bool IsAllChineseWord(this string str_word)
        {
            return Regex.IsMatch(str_word, @"^[\u4e00-\u9fa5]+$");
        }

        public static bool IsContainsChineseWord(this string str_word)
        {
            return Regex.IsMatch(str_word, @"[\u4e00-\u9fa5]");
        }

        public static bool IsNull(this string Text)
        {
            return string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text);
        }

        public static string ReplaseX(this string Text)
        {
            if (Text.IsNull())
                return Text;
            if (Text.IsPhone())
                return ReplaseXStart(Text, 3, 10);
            else if (Text.IsValidEmail())
                return ReplaseXStart(Text, 3, Text.IndexOf("@"));
            else if (Text.IsIDCard())
                return ReplaseXStart(Text, 3, Text.Length - 1);
            else if (Text.Length <= 10)
                return ReplaseXStart(Text, 1, Text.Length);
            else if (Text.Length > 100)
                return Text.Substring(0, 50) + "……";
            else
                return ReplaseXStart(Text, 1, Text.Length - 2);
        }
        public static string ReplaseXStart(this string Text, int Start, int End)
        {
            var Str = new StringBuilder();
            if (!Text.IsNull())
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if (i < Start || i > End) Str.Append(Text[i]);
                    else Str.Append("*");
                }
            }
            return Str.ToString();
        }
        /// <summary>
        /// 是否为电话号
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static bool IsPhone(this string Phone)
        {
            return Regex.IsMatch(Phone, @"^1[3-9]\d{9}$");
        }

        public static bool IsEduYunNo(this string Input)
        {
            return Regex.IsMatch(Input, @"^\d{5,9}$");
        }
        /// <summary>
        /// 邮政编码验证
        /// </summary>
        /// <param name="PostCode"></param>
        /// <returns></returns>
        public static bool IsPostCode(this string PostCode)
        {
            return Regex.IsMatch(PostCode, @"^\d{6}$");
        }
        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainsNumber(this string text)
        {
            return Regex.IsMatch(text, @"^(?=.*[0-9])");
        }
        /// <summary>
        /// 是否包含字母
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainsLetters(this string text)
        {
            return Regex.IsMatch(text, @"^(?=.*[a-zA-Z])");
        }

        public static int GetPassWordType(this string password)
        {
            int type = 0;
            if (IsContainsCapital(password)) type = type + 1;
            if (IsContainsSpecial(password)) type = type + 1;
            return type;
        }
        /// <summary>
        /// 包含特殊字符
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainsSpecial(this string text)
        {
            return Regex.IsMatch(text, @"^(?=([\x21-\x7e]+)[^a-zA-Z0-9])");
        }
        /// <summary>
        /// 是否包含小写字母
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainsLowercase(this string text)
        {
            return Regex.IsMatch(text, @"^(?=.*[a-z])");
        }
        /// <summary>
        /// 是否包含大写字母
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainsCapital(this string text)
        {
            return Regex.IsMatch(text, @"^(?=.*[A-Z])");
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            email = email.Trim();
            var result = Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
            return result;
        }
        public static bool IsIDCard(this string IDCard)
        {
            return Regex.IsMatch(IDCard, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$");
        }
        public static DateTime? BirthdayFromCard(this string IDCard)
        {
            if (!IDCard.IsNull())
            {
                if (!IDCard.IsIDCard()) throw new ValidateException("身份证号码格式不正确。");
                var date = "";
                if (IDCard.Length == 15)
                    date = "19" + IDCard.Substring(6, 6);
                else if (IDCard.Length == 18)
                    date = IDCard.Substring(6, 8);
                return DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            }
            else return null;
        }
        public static int SexFromCard(this string IDCard)
        {
            string SexNumber = "1";
            if (!IDCard.IsNull())
            {
                if (!IDCard.IsIDCard()) throw new ValidateException("身份证号码格式不正确。");
                if (IDCard.Length == 15)
                    SexNumber = IDCard.Substring(IDCard.Length - 1);
                else if (IDCard.Length == 18)
                    SexNumber = IDCard.Substring(IDCard.Length - 2, 1);
            }
            int p = 1;
            int.TryParse(SexNumber, out p);
            return p % 2;
        }
        public static string ToDateString(this DateTime? Date, bool IsTime = false)
        {
            string format = "yyyy-MM-dd";
            if (IsTime) format = "yyyy-MM-dd HH:mm:ss";
            if (Date == null) return "";
            else return ((DateTime)Date).ToString(format);
        }
        public static string ToDateString(this DateTime Date, bool IsTime = false)
        {
            string format = "yyyy-MM-dd";
            if (IsTime) format = "yyyy-MM-dd HH:mm:ss";
            return Date.ToString(format);
        }
        public static string MD5(this string code)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(code);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static PageList<T> ToPage<T>(this IEnumerable<T> query, BaseCondition condition, int? TotalCount = null)
        {
            int? TotalPage = null;
            if (condition.Page.HasValue && condition.PageCount.HasValue && condition.Page.Value > 0 && condition.PageCount.Value > 0)
            {
                if (condition.Page == 1)
                {
                    if (TotalCount == null)
                        TotalCount = query.Count();
                    int p = TotalCount.Value / condition.PageCount.Value;
                    TotalPage = TotalCount.Value % condition.PageCount.Value == 0 ? p : p + 1;
                }
                query = query.Skip((condition.Page.Value - 1) * condition.PageCount.Value).Take(condition.PageCount.Value);
            }
            return new PageList<T>
            {
                Records = query.ToList(),
                TotalCount = TotalCount,
                TotalPage = TotalPage
            };
        }

        public static async Task<PageList<T>> ToPage<T>(this IQueryable<T> query, BaseCondition condition, int? TotalCount = null)
        {
            int? TotalPage = null;
            if (!condition.Page.HasValue || condition.Page <= 0)
                condition.Page = 1;
            if (!condition.PageCount.HasValue || condition.PageCount <= 0 || condition.PageCount > 500)
                condition.PageCount = 500;

            if (condition.Page == 1)
            {
                if (TotalCount == null)
                    TotalCount = query.Count();
                int p = TotalCount.Value / condition.PageCount.Value;
                TotalPage = TotalCount.Value % condition.PageCount.Value == 0 ? p : p + 1;
            }
            query = query.Skip((condition.Page.Value - 1) * condition.PageCount.Value).Take(condition.PageCount.Value);
            return new PageList<T>
            {
                Records = await query.ToListAsync(),
                TotalCount = TotalCount,
                TotalPage = TotalPage
            };
        }
        //public static string ToExcel(this DataTable dataTable, string Directory)
        //{
        //    var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
        //    var sheet = workbook.CreateSheet("sheet");
        //    var Row = sheet.CreateRow(0);
        //    for (int k = 0; k < dataTable.Columns.Count; k++)
        //    {
        //        var Col = dataTable.Columns[k];
        //        Row.CreateCell(k).SetCellValue(Col.ColumnName);
        //    }
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        var rows = sheet.CreateRow(i + 1);
        //        for (int j = 0; j < dataTable.Columns.Count; j++)
        //        {
        //            rows.CreateCell(j).SetCellValue(dataTable.Rows[i][j].ToString());
        //        }
        //    }
        //    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";
        //    var UploadPath = Directory.MapPath();
        //    var FilePath = UploadPath + "/" + fileName;
        //    using (var fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
        //    {
        //        workbook.Write(fs);
        //    }
        //    return fileName;
        //}

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="text">加密字符</param>
        /// <param name="key">加密的Key</param>
        /// <param name="iv">密钥</param>
        /// <returns></returns>
        public static string AESEncrypt(this string text, string key, string iv = "1234523589356780")
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] ivArray = Encoding.UTF8.GetBytes(iv);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(text);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.IV = ivArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text">待加密数据</param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AESDecrypt(this string text, string key, string iv = "1234523589356780")
        {
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iv);
            var toEncryptArray = Convert.FromBase64String(text);
            var rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = keyArray;
            rijndaelManaged.IV = ivArray;
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.PKCS7;
            var cTransform = rijndaelManaged.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
        /// <summary>
        /// 微信AES解密
        /// </summary>
        /// <param name="EncryptData">加密数据</param>
        /// <param name="Key">加密Key</param>
        /// <param name="Iv">加密偏移量</param>
        /// <returns></returns>
        public static string AESWxDecrypt(this string EncryptData, string Key, string Iv)
        {
            var encryptedData = Convert.FromBase64String(EncryptData);
            var rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Key = Convert.FromBase64String(Key);
            rijndaelCipher.IV = Convert.FromBase64String(Iv);
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            var transform = rijndaelCipher.CreateDecryptor();
            var plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }
    }
}
