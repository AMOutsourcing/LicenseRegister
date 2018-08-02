using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using John.SocialClub.Data.DataModel;

namespace John.SocialClub.Data.DataAccess
{
    public class NGUOI_LX_DA
    {
        public static List<NGUOI_LX> getData(DateTime start,DateTime end,String trangthai, string cmnd)
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

            if(start != null)
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
                command.Parameters.AddWithValue("@EndDate", end);
            }
            if (trangthai != null && trangthai.Trim().Length > 0)
            {
                command.Parameters.AddWithValue("@status", trangthai);
            }

            if (cmnd != null && cmnd.Trim().Length > 0)
            {
                command.Parameters.AddWithValue("@cmnd", "%"+cmnd.Trim()+"%");
            }

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                NGUOI_LX obj = null;
                while (reader.Read())
                {
                    obj = new NGUOI_LX();
                    if (!reader.IsDBNull(reader.GetOrdinal("MaDK"))) { obj.MADK = reader.GetString(reader.GetOrdinal("MaDK")); } else { obj.MADK = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DonViNhanHSo"))) { obj.DV_NHAN_HS = reader.GetString(reader.GetOrdinal("DonViNhanHSo")); } else { obj.DV_NHAN_HS = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HoDemNLX"))) { obj.HO_DEM_NLX = reader.GetString(reader.GetOrdinal("HoDemNLX")); } else { obj.HO_DEM_NLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TenNLX"))) { obj.TEN_NLX = reader.GetString(reader.GetOrdinal("TenNLX")); } else { obj.TEN_NLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HoVaTen"))) { obj.HO_VA_TEN = reader.GetString(reader.GetOrdinal("HoVaTen")); } else { obj.HO_VA_TEN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaQuocTich"))) { obj.MA_QUOC_TICH = reader.GetString(reader.GetOrdinal("MaQuocTich")); } else { obj.MA_QUOC_TICH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgaySinh"))) { obj.NGAY_SINH = reader.GetString(reader.GetOrdinal("NgaySinh")); } else { obj.NGAY_SINH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiTT"))) { obj.NOI_TT = reader.GetString(reader.GetOrdinal("NoiTT")); } else { obj.NOI_TT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiTT_MaDVHC"))) { obj.NOI_TT_MA_DVHC = reader.GetString(reader.GetOrdinal("NoiTT_MaDVHC")); } else { obj.NOI_TT_MA_DVHC = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiTT_MaDVQL"))) { obj.NOI_TT_MA_DVQL = reader.GetString(reader.GetOrdinal("NoiTT_MaDVQL")); } else { obj.NOI_TT_MA_DVQL = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCT"))) { obj.NOI_CT = reader.GetString(reader.GetOrdinal("NoiCT")); } else { obj.NOI_CT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCT_MaDVHC"))) { obj.NOI_CT_MA_DVHC = reader.GetString(reader.GetOrdinal("NoiCT_MaDVHC")); } else { obj.NOI_CT_MA_DVHC = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCT_MaDVQL"))) { obj.NOI_CT_MA_DVQL = reader.GetString(reader.GetOrdinal("NoiCT_MaDVQL")); } else { obj.NOI_CT_MA_DVQL = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoCMT"))) { obj.SO_CMT = reader.GetString(reader.GetOrdinal("SoCMT")); } else { obj.SO_CMT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayCapCMT"))) { obj.NGAY_CAP_CMT = reader.GetDateTime(reader.GetOrdinal("NgayCapCMT")); } else { obj.NGAY_CAP_CMT = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCapCMT"))) { obj.NOI_CAP_CMT = reader.GetString(reader.GetOrdinal("NoiCapCMT")); } else { obj.NOI_CAP_CMT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GhiChu"))) { obj.GHI_CHU = reader.GetString(reader.GetOrdinal("GhiChu")); } else { obj.GHI_CHU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TrangThai"))) { obj.TRANG_THAI = reader.GetBoolean(reader.GetOrdinal("TrangThai")); } else { obj.TRANG_THAI = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiTao"))) { obj.NGUOI_TAO = reader.GetString(reader.GetOrdinal("NguoiTao")); } else { obj.NGUOI_TAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiSua"))) { obj.NGUOI_SUA = reader.GetString(reader.GetOrdinal("NguoiSua")); } else { obj.NGUOI_SUA = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayTao"))) { obj.NGAY_TAO = reader.GetDateTime(reader.GetOrdinal("NgayTao")); } else { obj.NGAY_TAO = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgaySua"))) { obj.NGAY_SUA = reader.GetDateTime(reader.GetOrdinal("NgaySua")); } else { obj.NGAY_SUA = DateTime.Now; }
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
    }
}
