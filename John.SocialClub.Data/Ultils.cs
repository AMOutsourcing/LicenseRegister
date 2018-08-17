using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using John.SocialClub.Data.DataAccess;
using John.SocialClub.Data.DataModel;
using John.SocialClub.Data.Ultis;
using CSJ2K;
using System.Drawing;
using CSJ2K.Util;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Windows.Forms;

namespace John.SocialClub.Data
{
    public static class Ultils
    {
        public static String FORMAT_DATE = "dd/MM/yyyy";
        public static String FORMAT_DATE_FOLDER = "yyyyMMdd";
        public static String FORMAT_DATETIME = "yyyy-MM-dd HH:mm:ss";
        public static String FILE_NAME = "TestFile.txt";
        public static Dictionary<string, string> configuration = null;
        public static void readFileConfig(String fileName)
        {
            if (configuration == null)
            {
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader("../../config/" + fileName))
                    {
                        configuration = new Dictionary<string, string>();
                        String s = "";
                        String[] tmp = null;
                        while (sr.Peek() >= 0)
                        {
                            s = sr.ReadLine();
                            tmp = s.Split('=');
                            configuration.Add(tmp[0].Trim(), tmp[1].Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static String getConfig(String config)
        {
            return System.Configuration.ConfigurationSettings.AppSettings[config];

            //if (configuration == null)
            //{
            //    readFileConfig(FILE_NAME);
            //}
            //if (configuration.ContainsKey(config))
            //    return configuration[config];
            //else
            //    throw new Exception(String.Format("Key {0} was not found", config));
        }

        //--------------------------SQL
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static SqlConnection GetDBConnection()
        {
            readFileConfig(FILE_NAME);
            //string datasource = @"tran-vmware\SQLEXPRESS";
            string datasource = getConfig("datasource");
            string database = getConfig("database");
            string username = getConfig("username");
            string password = getConfig("password");

            return GetDBConnection(datasource, database, username, password);
        }

        public static SqlConnection GetDBConnectionImport()
        {
            readFileConfig(FILE_NAME);
            string datasource = getConfig("datasourceImport");
            string database = getConfig("databaseImport");
            string username = getConfig("usernameImport");
            string password = getConfig("passwordImport");

            return GetDBConnection(datasource, database, username, password);
        }

        public static String GetDBConnectionStringImport()
        {
            readFileConfig(FILE_NAME);
            string datasource = getConfig("datasourceImport");
            string database = getConfig("databaseImport");
            string username = getConfig("usernameImport");
            string password = getConfig("passwordImport");

            return @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
        }

        public static bool IsServerConnected(SqlConnection connection)
        {
            try
            {
                Console.WriteLine("Connecting to: {0}", getConfig("datasource"));
                var query = "select 1";
                Console.WriteLine("Executing: {0}", query);

                var command = new SqlCommand(query, connection);

                connection.Open();
                Console.WriteLine("SQL Connection successful.");

                command.ExecuteScalar();
                Console.WriteLine("SQL Query execution successful.");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure: {0}", ex.Message);
                return false;
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static void testExport<T>(IList<T> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter writer = new StreamWriter("test.xml"))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static void testExportHead(HEADER data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HEADER));
            using (TextWriter writer = new StreamWriter("test.xml"))
            {
                serializer.Serialize(writer, data);
            }
        }

        //public static IList<IList<T>> Split<T>(IList<T> source)
        //{
        //    return source
        //        .Select((x, i) => new { Index = i, Value = x })
        //        .GroupBy(x => x.Index / 3)
        //        .Select(x => x.Select(v => v.Value).ToList())
        //        .ToList();
        //}

        public static List<List<float[]>> splitList(List<float[]> locations, int nSize = 30)
        {
            var list = new List<List<float[]>>();

            for (int i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }

            return list;
        }

        public static IEnumerable<List<T>> splitList<T>(List<T> locations, int nSize = 300)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }


        public static void exportXml(String fileName, List<NGUOI_LX> lstNLX, List<NGUOILX_HOSO> lstHoso, List<GIAY_TO> lstGiayTo)
        {
            //Remove null 
            var sb = new StringBuilder();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            //settings.NewLineOnAttributes = true;


            XmlSerializer s = new XmlSerializer(typeof(NGUOI_LX), "");

            using (var writerSb = new StringWriter(sb))
            using (XmlWriter writer = XmlWriter.Create(writerSb, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("HEADER");
                writer.WriteElementString("MA_GIAO_DICH", "");
                writer.WriteElementString("MA_DV_GUI", "");
                writer.WriteElementString("TEN_DV_GUI", "");
                writer.WriteElementString("NGAY_GUI", DateTime.Now.ToShortDateString());
                writer.WriteElementString("NGUOI_GUI", "");
                writer.WriteElementString("TONG_SO_BAN_GHI", lstNLX.Count.ToString());


                //BODY
                writer.WriteStartElement("BODY");

                s = new XmlSerializer(typeof(NGUOI_LX), "");
                foreach (NGUOI_LX obj in lstNLX)
                {
                    s.Serialize(new XmlWriterEE(writer), obj, ns);
                }

                s = new XmlSerializer(typeof(NGUOILX_HOSO), "");
                foreach (NGUOILX_HOSO obj in lstHoso)
                {
                    s.Serialize(new XmlWriterEE(writer), obj, ns);
                }

                s = new XmlSerializer(typeof(GIAY_TO), "");
                foreach (GIAY_TO obj in lstGiayTo)
                {
                    s.Serialize(new XmlWriterEE(writer), obj, ns);
                }


                //foreach (NGUOI_LX obj in lstNLX)
                //{
                //    obj.writerXml(writer);
                //}

                //foreach (NGUOILX_HOSO obj in lstHoso)
                //{
                //    obj.writerXml(writer);
                //}

                //foreach (GIAY_TO obj in lstGiayTo)
                //{
                //    obj.writerXml(writer);
                //}

                writer.WriteEndElement();   //End BODY

                writer.WriteEndElement();   //End HEADER

                writer.WriteEndDocument();
            }


            //Remove
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                sb = sb.Replace(" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                sb = sb.Replace("xmlns:p4=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                sb = sb.Replace(" p4:nil=\"true\" ", "");
                stream.Write(sb);
            }
        }


        public static HEADER Deserialize(String filePath)
        {
            HEADER rtn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(HEADER));
            StreamReader reader = new StreamReader(filePath);
            rtn = (HEADER)serializer.Deserialize(reader);
            reader.Close();
            return rtn;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void testImport<T>(List<T> listData, string tableName)
        {
            var objBulk = new BulkUploadToSql<T>()
            {
                InternalStore = listData,
                TableName = tableName,
                CommitBatchSize = 1000,
                ConnectionString = GetDBConnectionStringImport()
            };
            objBulk.Commit();
        }
        
        public static String importHosoJp2(List<NGUOILX_HOSO> ListNguoiLxHs)
        {
            string filepath = getConfigInDB("IMG_PATH_VPDK_SOGTVT");

            String pathAnh = "";
            foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
            {
                try
                {
                    if (obj.DUONGDANANH != null && obj.DUONGDANANH.Trim().Length > 0)
                    {
                        if (obj.NGAYTHUNHANANH != "")
                        {
                            pathAnh = filepath + "\\" + DateTime.Parse(obj.NGAYTHUNHANANH).ToString(Ultils.FORMAT_DATE_FOLDER);
                            //Tao thu muc
                            System.IO.Directory.CreateDirectory(pathAnh);

                            obj.DUONGDANANH = decodeJp2(pathAnh, obj.MADK + ".jp2", obj.DUONGDANANH);
                        }
                        else
                        {
                            pathAnh = filepath + "\\" + DateTime.Now.ToString(FORMAT_DATE_FOLDER);
                            //Tao thu muc
                            System.IO.Directory.CreateDirectory(filepath);

                            obj.DUONGDANANH = decodeJp2(pathAnh, obj.MADK + ".jp2", obj.DUONGDANANH);
                        }
                    }

                }
                catch (Exception ex)
                {

                }

            }
            return "";
        }

        public static void renameAnhHosoJp2(List<NGUOILX_HOSO> ListNguoiLxHs)
        {
            string filepath = getConfigInDB("IMG_PATH_VPDK_SOGTVT");
            
            foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
            {
                try
                {
                    if (obj.DUONGDANANH != null && obj.DUONGDANANH.Trim().Length > 0)
                    {
                        // get the file attributes for file or directory
                        FileAttributes attr = File.GetAttributes(obj.DUONGDANANH);
                        
                        //detect whether its a directory or file
                        if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                        {
                            string oldFile = Path.GetFileName(obj.DUONGDANANH);
                            string newFile = obj.DUONGDANANH.Replace(oldFile, obj.MADK + ".jp2");

                            System.IO.File.Copy(obj.DUONGDANANH, newFile, false);
                            obj.DUONGDANANH = newFile;
                        }
                        
                    }

                }
                catch (Exception ex)
                {

                }

            }
        }

        public static String importDbWithCommit(List<NGUOI_LX> ListNguoiLx, List<NGUOILX_HOSO> ListNguoiLxHs, List<GIAY_TO> ListGiayTo)
        {
            SqlConnection connection = Ultils.GetDBConnectionImport();


            // Start a local transaction.
            SqlTransaction transaction = null;

            try
            {

                connection.Open();
                transaction = connection.BeginTransaction("importDbWithCommit");
                foreach (NGUOI_LX obj in ListNguoiLx)
                {
                    NGUOI_LX_DA.insertDataString(connection, transaction, obj);
                }
                //Ultils.testImport(bODY.ListNguoiLx, "NguoiLX");
                Console.WriteLine("-------------- IMPORT NGUOI_LX DONE: ");

                int i = 1;
                foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
                {
                    Console.WriteLine("-------------- NGUOILX_HOSO DUONGDANANH " + i++ + ": " + obj.DUONGDANANH.ToString());
                    Console.WriteLine("-------------- insert NGUOILX_HOSO: " + NGUOILX_HOSO_DA.insertData(connection, transaction, obj));
                }

                //Ultils.testImport(bODY.ListNguoiLxHs, "NguoiLX_HoSo");
                Console.WriteLine("-------------- IMPORT ListNguoiLxHs DONE: ");

                foreach (GIAY_TO obj in ListGiayTo)
                {
                    Console.WriteLine("-------------- GIAY_TO MADK " + i++ + ": " + obj.MADK.ToString());
                    Console.WriteLine("-------------- insert GIAY_TO: " + GIAY_TO_DA.insertData(connection, transaction, obj));
                }

                // Attempt to commit the transaction.
                transaction.Commit();
                return "";
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        public static String NullValue(String value)
        {
            if (value == null || value.Trim().Length <= 0)
            {
                return null;
            }
            return value;
        }

        public static DateTime? NullValueDate(String value)
        {
            if (value == null || value.Trim().Length <= 0)
            {
                return null;
            }
            return DateTime.Parse(value);
        }
        public static Int32? NullValueInt(String value)
        {
            if (value == null || value.Trim().Length <= 0)
            {
                return null;
            }
            return Int32.Parse(value);
        }
        public static Boolean? NullValueBool(String value)
        {
            if (value == null || value.Trim().Length <= 0)
            {
                return null;
            }
            return Boolean.Parse(value);
        }

        //https://www.nuget.org/packages/CSJ2K/
        public static string encodeJp2(String path)
        {
            try
            {
                BitmapImageCreator.Register();
                Bitmap image = J2kImage.FromFile(path).As<Bitmap>();
                return ImageToBase64(image, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("encodeJp2 '" + path + "' error: " + ex.Message);
                return "";
            }
        }

        public static string decodeJp2(String filepath, String filename, String base64)
        {
            BitmapImageCreator.Register();
            filepath = filepath + "\\" + filename;
            var enc = Convert.FromBase64String(base64);
            File.WriteAllBytes(filepath, enc);
            return filepath;
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                return Convert.ToBase64String(imageBytes);
            }
        }

        public static string ImageToBase64(byte[] imageBytes)
        {
            // Convert byte[] to base 64 string
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public static string OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
                return "";
            }
            else
            {
                return string.Format("{0} Directory does not exist!", folderPath);
            }
        }

        public static String getConfigInDB(String configName)
        {
            string queryString = "SELECT [GiaTriTS] FROM [dbo].[QTHT_ThamSoHT] WHERE TenTS=@configName";
            SqlConnection connection = Ultils.GetDBConnectionImport();
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@configName", configName.Trim());
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("GiaTriTS")))
                    {
                        return reader.GetString(reader.GetOrdinal("GiaTriTS"));
                    }
                    else
                    {
                        return getConfig("pathImport");
                    }
                }
                return getConfig("pathImport");
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }


        public static String importNguoiLxeWithCommit(NGUOI_LX NguoiLx, List<NGUOILX_HOSO> ListNguoiLxHs, List<GIAY_TO> ListGiayTo)
        {
            SqlConnection connection = Ultils.GetDBConnectionImport();


            // Start a local transaction.
            SqlTransaction transaction = null;

            try
            {

                connection.Open();
                transaction = connection.BeginTransaction("importDbWithCommit");

                NGUOI_LX_DA.insertDataString(connection, transaction, NguoiLx);

                //Ultils.testImport(bODY.ListNguoiLx, "NguoiLX");
                Console.WriteLine("-------------- IMPORT NGUOI_LX DONE: ");

                int i = 1;
                foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
                {
                    Console.WriteLine("-------------- NGUOILX_HOSO DUONGDANANH " + i++ + ": " + obj.DUONGDANANH.ToString());
                    Console.WriteLine("-------------- insert NGUOILX_HOSO: " + NGUOILX_HOSO_DA.insertData(connection, transaction, obj));
                }

                //Ultils.testImport(bODY.ListNguoiLxHs, "NguoiLX_HoSo");
                Console.WriteLine("-------------- IMPORT ListNguoiLxHs DONE: ");

                foreach (GIAY_TO obj in ListGiayTo)
                {
                    Console.WriteLine("-------------- GIAY_TO MADK " + i++ + ": " + obj.MADK.ToString());
                    Console.WriteLine("-------------- insert GIAY_TO: " + GIAY_TO_DA.insertData(connection, transaction, obj));
                }

                // Attempt to commit the transaction.
                transaction.Commit();
                return "";
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            TextBox textBox2 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            //textBox.Text = value;
            textBox.Text = value.Substring(0, value.Length - 6);
            textBox2.Text = value.Substring(value.Length - 6);

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 270, 20);
            textBox2.SetBounds(200, 36, 90, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            //textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;


            //textBox
            textBox.ReadOnly = true;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox2 ,textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            textBox2.Focus();
            value = textBox.Text + textBox2.Text;
            return dialogResult;
        }


    }
}
