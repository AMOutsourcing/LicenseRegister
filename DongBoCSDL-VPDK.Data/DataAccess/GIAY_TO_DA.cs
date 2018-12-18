using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GPLX.Data.DataModel;

namespace GPLX.Data.DataAccess
{
    public class GIAY_TO_DA
    {
        public static List<GIAY_TO> getData(List<NGUOI_LX> listData)
        {
            List<GIAY_TO> rtn = new List<GIAY_TO>();

            if (listData == null || listData.Count <= 0)
            {
                return rtn;
            }

            List<List<NGUOI_LX>> listTmp = Ultils.splitList(listData, 300).ToList();
            for (int i = 0; i < listTmp.Count; i++)
            {
                rtn.AddRange(getGiayTo(listTmp[i]));
            }

            return rtn;
        }

        public static List<GIAY_TO> getGiayTo(List<NGUOI_LX> listData)
        {
            List<GIAY_TO> rtn = new List<GIAY_TO>();
            if (listData == null || listData.Count <= 0)
            {
                return rtn;
            }
            //Tao SQL
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *  FROM  [dbo].[NguoiLXHS_GiayTo] WHERE MADK IN (");
            int i = 1;

            foreach (NGUOI_LX user in listData)
            {
                // IN clause
                sb.Append("@MADK" + i.ToString() + ",");

                i++;
            }
            sb.Length--;
            sb.Append(")");

            //set SqlCommand
            SqlConnection connection = Ultils.GetDBConnection();
            SqlCommand command = new SqlCommand(sb.ToString(), connection);

            //Set param
            i = 1;
            foreach (NGUOI_LX user in listData)
            {
                // parameter
                command.Parameters.AddWithValue("@MADK" + i.ToString(), user.MADK);
                i++;
            }

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                GIAY_TO obj = null;
                while (reader.Read())
                {
                    obj = new GIAY_TO();
                    if (!reader.IsDBNull(reader.GetOrdinal("MaDK"))) { obj.MADK = reader.GetString(reader.GetOrdinal("MaDK")); } else { obj.MADK = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaGT"))) { obj.MAGT = reader.GetInt32(reader.GetOrdinal("MaGT")).ToString(); } else { obj.MAGT = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoHoSo"))) { obj.SOHOSO = reader.GetString(reader.GetOrdinal("SoHoSo")); } else { obj.SOHOSO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TenGT"))) { obj.TEN_NLX = reader.GetString(reader.GetOrdinal("TenGT")); } else { obj.TEN_NLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TrangThai"))) { obj.TRANGTHAI = reader.GetBoolean(reader.GetOrdinal("TrangThai")).ToString(); } else { obj.TRANGTHAI = null; }
                    rtn.Add(obj);
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            return rtn;
        }

        public static int insertData(SqlConnection connection, SqlTransaction transaction, GIAY_TO obj)
        {
            int rtn = 0;

            try
            {
                string queryString = "INSERT INTO [dbo].[NguoiLXHS_GiayTo] (MaDK, MaGT, SoHoSo, TenGT, TrangThai) " +
                    "VALUES (@MADK, @MAGT, @SOHOSO, @TEN_NLX, @TRANGTHAI)";

                SqlCommand command = new SqlCommand(queryString, connection);
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.AddWithValue("@MaDK", obj.MADK);
                if (obj.MAGT != null)
                {
                    command.Parameters.AddWithValue("@MaGT", Int32.Parse(obj.MAGT));
                }
                else
                {
                    command.Parameters.AddWithValue("@MaGT", DBNull.Value);
                }

                if (obj.SOHOSO == null || obj.SOHOSO.Length <= 0)
                {
                    command.Parameters.AddWithValue("@SoHoSo", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SoHoSo", obj.SOHOSO);

                }
                if (obj.TEN_NLX == null || obj.TEN_NLX.Length <= 0)
                {
                    command.Parameters.AddWithValue("@TEN_NLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TEN_NLX", obj.TEN_NLX);

                }
                if (obj.TRANGTHAI == null)
                {
                    command.Parameters.AddWithValue("@TrangThai", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TrangThai", obj.TRANGTHAI);

                }
                rtn = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rtn = -1;
                throw ex;
            }
            finally
            {
            }
            return rtn;
        }


        public static int insertData(GIAY_TO obj)
        {
            int rtn = 0;

            SqlConnection connection = Ultils.GetDBConnection();
            try
            {
                string queryString = "INSERT INTO [dbo].[NguoiLXHS_GiayTo] (MaDK, MaGT, SoHoSo, TenGT, TrangThai) " +
                    "VALUES (@MADK, @MAGT, @SOHOSO, @TEN_NLX, @TRANGTHAI)";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@MaDK", obj.MADK);
                if (obj.MAGT != null)
                {
                    command.Parameters.AddWithValue("@MaGT", Int32.Parse(obj.MAGT));
                }
                else
                {
                    command.Parameters.AddWithValue("@MaGT", DBNull.Value);
                }

                if (obj.SOHOSO == null || obj.SOHOSO.Length <= 0)
                {
                    command.Parameters.AddWithValue("@SoHoSo", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SoHoSo", obj.SOHOSO);

                }
                if (obj.TEN_NLX == null || obj.TEN_NLX.Length <= 0)
                {
                    command.Parameters.AddWithValue("@TEN_NLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TEN_NLX", obj.TEN_NLX);

                }
                if (obj.TRANGTHAI == null)
                {
                    command.Parameters.AddWithValue("@TrangThai", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TrangThai", obj.TRANGTHAI);

                }
                rtn = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rtn = -1;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }
    }
}
