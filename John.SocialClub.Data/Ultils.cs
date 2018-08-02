using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using John.SocialClub.Data.DataModel;

namespace John.SocialClub.Data
{
    public class Ultils
    {
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
            if (configuration == null)
            {
                readFileConfig(FILE_NAME);
            }
            if (configuration.ContainsKey(config))
                return configuration[config];
            else
                throw new Exception(String.Format("Key {0} was not found", config));
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

        public static bool IsServerConnected()
        {
            SqlConnection connection = GetDBConnection();
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
    }
}
