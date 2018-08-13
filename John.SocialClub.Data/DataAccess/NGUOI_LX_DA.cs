using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using John.SocialClub.Data.DataModel;

namespace John.SocialClub.Data.DataAccess
{
    public class NGUOI_LX_DA
    {
        public static List<NGUOI_LX> getData(DateTime start, DateTime end, String trangthai, string cmnd)
        {
            List<NGUOI_LX> rtn = new List<NGUOI_LX>();

            string queryString = "";
            if (trangthai != null && trangthai.Trim().Length > 0)
            {
                queryString = "SELECT n.* FROM [dbo].[NguoiLX] n LEFT JOIN [dbo].[NguoiLX_HoSo] h ON n.MaDK = h.MaDK WHERE 1 = 1 ";
            }
            else
            {
                queryString = "SELECT n.* FROM [dbo].[NguoiLX] n WHERE 1 = 1 ";
            }

            if (start != null)
            {
                queryString += " AND n.NgayTao>=@StartDate ";
            }
            if (end != null)
            {
                queryString += " AND n.NgayTao<=@EndDate ";
            }

            if (trangthai != null && trangthai.Trim().Length > 0)
            {
                queryString += " AND h.TT_XULY=@status ";
            }

            if (cmnd != null && cmnd.Trim().Length > 0)
            {
                queryString += " AND n.SoCMT like @cmnd ";
            }
            SqlConnection connection = Ultils.GetDBConnection();
            SqlCommand command = new SqlCommand(queryString, connection);
            if (start != null)
            {
                command.Parameters.AddWithValue("@StartDate", start);
            }
            if (end != null)
            {
                end = end.AddDays(1);
                command.Parameters.AddWithValue("@EndDate", end);
            }
            if (trangthai != null && trangthai.Trim().Length > 0)
            {
                command.Parameters.AddWithValue("@status", trangthai);
            }

            if (cmnd != null && cmnd.Trim().Length > 0)
            {
                command.Parameters.AddWithValue("@cmnd", "%" + cmnd.Trim() + "%");
            }

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                NGUOI_LX obj = null;
                int i = 1;
                while (reader.Read())
                {
                    obj = new NGUOI_LX();
                    obj.STT = i++;
                    if (!reader.IsDBNull(reader.GetOrdinal("MaDK"))) { obj.MADK = reader.GetString(reader.GetOrdinal("MaDK")); } else { obj.MADK = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DonViNhanHSo"))) { obj.DV_NHAN_HS = reader.GetString(reader.GetOrdinal("DonViNhanHSo")); } else { obj.DV_NHAN_HS = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HoDemNLX"))) { obj.HO_DEM_NLX = reader.GetString(reader.GetOrdinal("HoDemNLX")); } else { obj.HO_DEM_NLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TenNLX"))) { obj.TEN_NLX = reader.GetString(reader.GetOrdinal("TenNLX")); } else { obj.TEN_NLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HoVaTen"))) { obj.HO_VA_TEN = reader.GetString(reader.GetOrdinal("HoVaTen")); } else { obj.HO_VA_TEN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaQuocTich"))) { obj.MA_QUOC_TICH = reader.GetString(reader.GetOrdinal("MaQuocTich")); } else { obj.MA_QUOC_TICH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgaySinh"))) { obj.NGAY_SINH = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("NgaySinh")),"yyyyMMdd", CultureInfo.InvariantCulture).ToString(Ultils.FORMAT_DATE); } else { obj.NGAY_SINH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiTT"))) { obj.NOI_TT = reader.GetString(reader.GetOrdinal("NoiTT")); } else { obj.NOI_TT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiTT_MaDVHC"))) { obj.NOI_TT_MA_DVHC = reader.GetString(reader.GetOrdinal("NoiTT_MaDVHC")); } else { obj.NOI_TT_MA_DVHC = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiTT_MaDVQL"))) { obj.NOI_TT_MA_DVQL = reader.GetString(reader.GetOrdinal("NoiTT_MaDVQL")); } else { obj.NOI_TT_MA_DVQL = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCT"))) { obj.NOI_CT = reader.GetString(reader.GetOrdinal("NoiCT")); } else { obj.NOI_CT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCT_MaDVHC"))) { obj.NOI_CT_MA_DVHC = reader.GetString(reader.GetOrdinal("NoiCT_MaDVHC")); } else { obj.NOI_CT_MA_DVHC = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCT_MaDVQL"))) { obj.NOI_CT_MA_DVQL = reader.GetString(reader.GetOrdinal("NoiCT_MaDVQL")); } else { obj.NOI_CT_MA_DVQL = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoCMT"))) { obj.SO_CMT = reader.GetString(reader.GetOrdinal("SoCMT")); } else { obj.SO_CMT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayCapCMT"))) { obj.NGAY_CAP_CMT = reader.GetDateTime(reader.GetOrdinal("NgayCapCMT")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAY_CAP_CMT = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCapCMT"))) { obj.NOI_CAP_CMT = reader.GetString(reader.GetOrdinal("NoiCapCMT")); } else { obj.NOI_CAP_CMT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GhiChu"))) { obj.GHI_CHU = reader.GetString(reader.GetOrdinal("GhiChu")); } else { obj.GHI_CHU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TrangThai"))) { obj.TRANG_THAI = Convert.ToInt32(reader.GetBoolean(reader.GetOrdinal("TrangThai"))); } else { obj.TRANG_THAI = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiTao"))) { obj.NGUOI_TAO = reader.GetString(reader.GetOrdinal("NguoiTao")); } else { obj.NGUOI_TAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiSua"))) { obj.NGUOI_SUA = reader.GetString(reader.GetOrdinal("NguoiSua")); } else { obj.NGUOI_SUA = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayTao"))) { obj.NGAY_TAO = reader.GetDateTime(reader.GetOrdinal("NgayTao")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAY_TAO = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgaySua"))) { obj.NGAY_SUA = reader.GetDateTime(reader.GetOrdinal("NgaySua")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAY_SUA = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GioiTinh"))) { obj.GIOI_TINH = reader.GetString(reader.GetOrdinal("GioiTinh")); } else { obj.GIOI_TINH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HoVaTenIn"))) { obj.HO_VA_TEN_IN = reader.GetString(reader.GetOrdinal("HoVaTenIn")); } else { obj.HO_VA_TEN_IN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SO_CMND_CU"))) { obj.SO_CMND_CU = reader.GetString(reader.GetOrdinal("SO_CMND_CU")); } else { obj.SO_CMND_CU = ""; }
                    rtn.Add(obj);
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            Console.WriteLine("getData: " + rtn.Count);
            return rtn;
        }

        public static int insertData(List<NGUOI_LX> listData)
        {
            return 1;
        }
        public static int insertData(NGUOI_LX obj)
        {
            int rtn = 0;

            string queryString = "INSERT INTO [dbo].[NguoiLX] (MaDK, DonViNhanHSo, HoDemNLX, TenNLX, HoVaTen, MaQuocTich, NgaySinh, NoiTT, NoiTT_MaDVHC, NoiTT_MaDVQL, NoiCT, NoiCT_MaDVHC, NoiCT_MaDVQL, SoCMT, NgayCapCMT, NoiCapCMT, GhiChu, TrangThai, NguoiTao, NguoiSua, NgayTao, NgaySua, GioiTinh, HoVaTenIn, SO_CMND_CU) " +
                "VALUES (@MaDK, @DonViNhanHSo, @HoDemNLX, @TenNLX, @HoVaTen, @MaQuocTich, @NgaySinh, @NoiTT, @NoiTT_MaDVHC, @NoiTT_MaDVQL, @NoiCT, @NoiCT_MaDVHC, @NoiCT_MaDVQL, @SoCMT, @NgayCapCMT, @NoiCapCMT, @GhiChu, @TrangThai, @NguoiTao, @NguoiSua, @NgayTao, @NgaySua, @GioiTinh, @HoVaTenIn, @SO_CMND_CU)";
            SqlConnection connection = Ultils.GetDBConnectionImport();
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MaDK", obj.MADK);
            command.Parameters.AddWithValue("@DonViNhanHSo", obj.DV_NHAN_HS);
            command.Parameters.AddWithValue("@HoDemNLX", obj.HO_DEM_NLX);
            command.Parameters.AddWithValue("@TenNLX", obj.TEN_NLX);
            command.Parameters.AddWithValue("@HoVaTen", obj.HO_VA_TEN);
            command.Parameters.AddWithValue("@MaQuocTich", obj.MA_QUOC_TICH);
            command.Parameters.AddWithValue("@NgaySinh", obj.NGAY_SINH);
            command.Parameters.AddWithValue("@NoiTT", obj.NOI_TT);
            command.Parameters.AddWithValue("@NoiTT_MaDVHC", obj.NOI_TT_MA_DVHC);
            command.Parameters.AddWithValue("@NoiTT_MaDVQL", obj.NOI_TT_MA_DVQL);
            command.Parameters.AddWithValue("@NoiCT", obj.NOI_CT);
            command.Parameters.AddWithValue("@NoiCT_MaDVHC", obj.NOI_CT_MA_DVHC);
            command.Parameters.AddWithValue("@NoiCT_MaDVQL", obj.NOI_CT_MA_DVQL);
            command.Parameters.AddWithValue("@SoCMT", obj.SO_CMT);
            command.Parameters.AddWithValue("@NgayCapCMT", obj.NGAY_CAP_CMT);
            command.Parameters.AddWithValue("@NoiCapCMT", obj.NOI_CAP_CMT);
            command.Parameters.AddWithValue("@GhiChu", obj.GHI_CHU);
            command.Parameters.AddWithValue("@TrangThai", obj.TRANG_THAI);
            command.Parameters.AddWithValue("@NguoiTao", obj.NGUOI_TAO);
            command.Parameters.AddWithValue("@NguoiSua", obj.NGUOI_SUA);
            command.Parameters.AddWithValue("@NgayTao", obj.NGAY_TAO);
            command.Parameters.AddWithValue("@NgaySua", obj.NGAY_SUA);
            command.Parameters.AddWithValue("@GioiTinh", obj.GIOI_TINH);
            command.Parameters.AddWithValue("@HoVaTenIn", obj.HO_VA_TEN_IN);
            command.Parameters.AddWithValue("@SO_CMND_CU", obj.SO_CMND_CU);
            connection.Open();
            int recordsAffected = command.ExecuteNonQuery();
            return rtn;
        }


        public static int insertDataString(SqlConnection connection, SqlTransaction transaction, NGUOI_LX obj)
        {
            int rtn = 0;
            try
            {

                string queryString = "INSERT INTO [dbo].[NguoiLX] (MaDK, DonViNhanHSo, HoDemNLX, TenNLX, HoVaTen, MaQuocTich, NgaySinh, NoiTT, NoiTT_MaDVHC, NoiTT_MaDVQL, NoiCT, NoiCT_MaDVHC, NoiCT_MaDVQL, SoCMT, NgayCapCMT, NoiCapCMT, GhiChu, TrangThai, NguoiTao, NguoiSua, NgayTao, NgaySua, GioiTinh, HoVaTenIn, SO_CMND_CU) " +
                    "VALUES (@MaDK, @DonViNhanHSo, @HoDemNLX, @TenNLX, @HoVaTen, @MaQuocTich, @NgaySinh, @NoiTT, @NoiTT_MaDVHC, @NoiTT_MaDVQL, @NoiCT, @NoiCT_MaDVHC, @NoiCT_MaDVQL, @SoCMT, @NgayCapCMT, @NoiCapCMT, @GhiChu, @TrangThai, @NguoiTao, @NguoiSua, @NgayTao, @NgaySua, @GioiTinh, @HoVaTenIn, @SO_CMND_CU)";

                SqlCommand command = new SqlCommand(queryString, connection);
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.AddWithValue("@MaDK", obj.MADK);
                if (obj.DV_NHAN_HS == null || obj.DV_NHAN_HS.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DonViNhanHSo", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DonViNhanHSo", obj.DV_NHAN_HS);
                }
                if (obj.HO_DEM_NLX == null || obj.HO_DEM_NLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HoDemNLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HoDemNLX", obj.HO_DEM_NLX);
                }
                if (obj.TEN_NLX == null || obj.TEN_NLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TenNLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TenNLX", obj.TEN_NLX);
                }
                if (obj.HO_VA_TEN == null || obj.HO_VA_TEN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HoVaTen", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HoVaTen", obj.HO_VA_TEN);
                }
                if (obj.MA_QUOC_TICH == null || obj.MA_QUOC_TICH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MaQuocTich", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MaQuocTich", obj.MA_QUOC_TICH);
                }
                if (obj.NGAY_SINH == null || obj.NGAY_SINH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NgaySinh", DateTime.ParseExact(obj.NGAY_SINH, Ultils.FORMAT_DATE, CultureInfo.InvariantCulture).ToString("yyyyMMdd"));
                }
                if (obj.NOI_TT == null || obj.NOI_TT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiTT", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiTT", obj.NOI_TT);
                }
                if (obj.NOI_TT_MA_DVHC == null || obj.NOI_TT_MA_DVHC.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiTT_MaDVHC", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiTT_MaDVHC", obj.NOI_TT_MA_DVHC);
                }
                if (obj.NOI_TT_MA_DVQL == null || obj.NOI_TT_MA_DVQL.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiTT_MaDVQL", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiTT_MaDVQL", obj.NOI_TT_MA_DVQL);
                }
                if (obj.NOI_CT == null || obj.NOI_CT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiCT", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiCT", obj.NOI_CT);
                }
                if (obj.NOI_CT_MA_DVHC == null || obj.NOI_CT_MA_DVHC.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiCT_MaDVHC", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiCT_MaDVHC", obj.NOI_CT_MA_DVHC);
                }
                if (obj.NOI_CT_MA_DVQL == null || obj.NOI_CT_MA_DVQL.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiCT_MaDVQL", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiCT_MaDVQL", obj.NOI_CT_MA_DVQL);
                }

                if (obj.SO_CMT == null || obj.SO_CMT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SoCMT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SoCMT", obj.SO_CMT);
                }
                if (obj.NGAY_CAP_CMT == null || obj.NGAY_CAP_CMT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NgayCapCMT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NgayCapCMT", DateTime.Parse(obj.NGAY_CAP_CMT));
                }

                if (obj.NOI_CAP_CMT == null || obj.NOI_CAP_CMT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NoiCapCMT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NoiCapCMT", obj.NOI_CAP_CMT);
                }
                if (obj.GHI_CHU == null || obj.GHI_CHU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GhiChu", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GhiChu", obj.GHI_CHU);
                }
                if (obj.TRANG_THAI == null)
                {
                    command.Parameters.AddWithValue("@TrangThai", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TrangThai", obj.TRANG_THAI);
                }
                if (obj.NGUOI_TAO == null || obj.NGUOI_TAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NguoiTao", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NguoiTao", obj.NGUOI_TAO);
                }
                if (obj.NGUOI_SUA == null || obj.NGUOI_SUA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NguoiSua", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NguoiSua", obj.NGUOI_SUA);
                }
                if (obj.NGAY_TAO == null || obj.NGAY_TAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NgayTao", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NgayTao", DateTime.Parse(obj.NGAY_TAO));
                }

                if (obj.NGAY_SUA == null || obj.NGAY_SUA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NgaySua", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NgaySua", DateTime.Parse(obj.NGAY_SUA));
                }

                if (obj.GIOI_TINH == null || obj.GIOI_TINH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GioiTinh", obj.GIOI_TINH);
                }

                if (obj.HO_VA_TEN_IN == null || obj.HO_VA_TEN_IN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HoVaTenIn", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HoVaTenIn", obj.HO_VA_TEN_IN);
                }
                if (obj.SO_CMND_CU == null || obj.SO_CMND_CU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SO_CMND_CU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SO_CMND_CU", obj.SO_CMND_CU);
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
    }
}
