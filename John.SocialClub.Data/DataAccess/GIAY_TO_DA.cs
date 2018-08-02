using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using John.SocialClub.Data.DataModel;

namespace John.SocialClub.Data.DataAccess
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
                    if (!reader.IsDBNull(reader.GetOrdinal("MaGT"))) { obj.MAGT = reader.GetInt32(reader.GetOrdinal("MaGT")); } else { obj.MAGT = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoHoSo"))) { obj.SOHOSO = reader.GetString(reader.GetOrdinal("SoHoSo")); } else { obj.SOHOSO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TenGT"))) { obj.TEN_NLX = reader.GetString(reader.GetOrdinal("TenGT")); } else { obj.TEN_NLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TrangThai"))) { obj.TRANGTHAI = reader.GetBoolean(reader.GetOrdinal("TrangThai")); } else { obj.TRANGTHAI = false; }
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
    }
}
