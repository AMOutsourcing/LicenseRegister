using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using John.SocialClub.Data.DataModel;

namespace John.SocialClub.Data.DataAccess
{
    public class NGUOILX_HOSO_DA
    {
        public static List<NGUOILX_HOSO> getData(List<NGUOI_LX> listData)
        {
            List<NGUOILX_HOSO> rtn = new List<NGUOILX_HOSO>();

            if(listData == null || listData.Count <= 0)
            {
                return rtn;
            }

            List<List<NGUOI_LX>> listTmp = Ultils.splitList(listData,300).ToList();
            for (int i = 0; i < listTmp.Count; i++)
            {
                rtn.AddRange(getNguoiLX(listTmp[i]));
            }
            
            return rtn;
        }

        private static List<NGUOILX_HOSO> getNguoiLX(List<NGUOI_LX> listData)
        {
            List<NGUOILX_HOSO> rtn = new List<NGUOILX_HOSO>();

            if (listData == null || listData.Count <= 0)
            {
                return rtn;
            }

            //Tao SQL
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *  FROM  [dbo].[NguoiLX_HoSo] WHERE MADK IN (");
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
                NGUOILX_HOSO obj = null;
                while (reader.Read())
                {
                    obj = new NGUOILX_HOSO();
                    if (!reader.IsDBNull(reader.GetOrdinal("MaDK"))) { obj.MADK = reader.GetString(reader.GetOrdinal("MaDK")); } else { obj.MADK = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoHoSo"))) { obj.SOHOSO = reader.GetString(reader.GetOrdinal("SoHoSo")); } else { obj.SOHOSO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MACSDT"))) { obj.MACSDT = reader.GetString(reader.GetOrdinal("MACSDT")); } else { obj.MACSDT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaSoGTVT"))) { obj.MASOGTVT = reader.GetString(reader.GetOrdinal("MaSoGTVT")); } else { obj.MASOGTVT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaDVNhanHSo"))) { obj.MADVNHANHSO = reader.GetString(reader.GetOrdinal("MaDVNhanHSo")); } else { obj.MADVNHANHSO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayNhanHSo"))) { obj.NGAYNHANHSO = reader.GetDateTime(reader.GetOrdinal("NgayNhanHSo")); } else { obj.NGAYNHANHSO = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiNhanHSo"))) { obj.NGUOINHANHSO = reader.GetString(reader.GetOrdinal("NguoiNhanHSo")); } else { obj.NGUOINHANHSO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayHenTra"))) { obj.NGAYHENTRA = reader.GetDateTime(reader.GetOrdinal("NgayHenTra")); } else { obj.NGAYHENTRA = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaLoaiHs"))) { obj.MALOAIHS = reader.GetInt32(reader.GetOrdinal("MaLoaiHs")); } else { obj.MALOAIHS = 0; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TT_XuLy"))) { obj.TT_XULY = reader.GetString(reader.GetOrdinal("TT_XuLy")); } else { obj.TT_XULY = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DuongDanAnh"))) { obj.DUONGDANANH = reader.GetString(reader.GetOrdinal("DuongDanAnh")); } else { obj.DUONGDANANH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("ChatLuongAnh"))) { obj.CHATLUONGANH = reader.GetInt32(reader.GetOrdinal("ChatLuongAnh")); } else { obj.CHATLUONGANH = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayThuNhanAnh"))) { obj.NGAYTHUNHANANH = reader.GetDateTime(reader.GetOrdinal("NgayThuNhanAnh")); } else { obj.NGAYTHUNHANANH = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiThuNhanAnh"))) { obj.NGUOITHUNHANANH = reader.GetString(reader.GetOrdinal("NguoiThuNhanAnh")); } else { obj.NGUOITHUNHANANH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoGPLXDaCo"))) { obj.SOGPLXDACO = reader.GetString(reader.GetOrdinal("SoGPLXDaCo")); } else { obj.SOGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HangGPLXDaCo"))) { obj.HANGGPLXDACO = reader.GetString(reader.GetOrdinal("HangGPLXDaCo")); } else { obj.HANGGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DonViCapGPLXDaCo"))) { obj.DONVICAPGPLXDACO = reader.GetString(reader.GetOrdinal("DonViCapGPLXDaCo")); } else { obj.DONVICAPGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCapGPLXDaCo"))) { obj.NOICAPGPLXDACO = reader.GetString(reader.GetOrdinal("NoiCapGPLXDaCo")); } else { obj.NOICAPGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayCapGPLXDaCo"))) { obj.NGAYCAPGPLXDACO = reader.GetString(reader.GetOrdinal("NgayCapGPLXDaCo")); } else { obj.NGAYCAPGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayHHGPLXDaCo"))) { obj.NGAYHHGPLXDACO = reader.GetString(reader.GetOrdinal("NgayHHGPLXDaCo")); } else { obj.NGAYHHGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayTTGPLXDaCo"))) { obj.NGAYTTGPLXDACO = reader.GetString(reader.GetOrdinal("NgayTTGPLXDaCo")); } else { obj.NGAYTTGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DonViHocLX"))) { obj.DONVIHOCLX = reader.GetString(reader.GetOrdinal("DonViHocLX")); } else { obj.DONVIHOCLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NamHocLX"))) { obj.NAMHOCLX = reader.GetInt32(reader.GetOrdinal("NamHocLX")); } else { obj.NAMHOCLX = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HangGPLX"))) { obj.HANGGPLX = reader.GetString(reader.GetOrdinal("HangGPLX")); } else { obj.HANGGPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoNamLX"))) { obj.SONAMLX = reader.GetInt32(reader.GetOrdinal("SoNamLX")); } else { obj.SONAMLX = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoKmLXAnToan"))) { obj.SOKMLXANTOAN = reader.GetInt32(reader.GetOrdinal("SoKmLXAnToan")); } else { obj.SOKMLXANTOAN = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GiayCNSK"))) { obj.GIAYCNSK = reader.GetBoolean(reader.GetOrdinal("GiayCNSK")); } else { obj.GIAYCNSK = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("LyDoCapDoi"))) { obj.LYDOCAPDOI = reader.GetString(reader.GetOrdinal("LyDoCapDoi")); } else { obj.LYDOCAPDOI = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MucDichCapDoi"))) { obj.MUCDICHCAPDOI = reader.GetString(reader.GetOrdinal("MucDichCapDoi")); } else { obj.MUCDICHCAPDOI = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDungSH"))) { obj.NOIDUNGSH = reader.GetInt32(reader.GetOrdinal("NoiDungSH")); } else { obj.NOIDUNGSH = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaKhoaHoc"))) { obj.MAKHOAHOC = reader.GetString(reader.GetOrdinal("MaKhoaHoc")); } else { obj.MAKHOAHOC = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HangDaoTao"))) { obj.HANGDAOTAO = reader.GetString(reader.GetOrdinal("HangDaoTao")); } else { obj.HANGDAOTAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoGiayCNTN"))) { obj.SOGIAYCNTN = reader.GetString(reader.GetOrdinal("SoGiayCNTN")); } else { obj.SOGIAYCNTN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoCCN"))) { obj.SoCCN = reader.GetString(reader.GetOrdinal("SoCCN")); } else { obj.SoCCN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaBC1"))) { obj.MABC1 = reader.GetString(reader.GetOrdinal("MaBC1")); } else { obj.MABC1 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("BC1_TuoiTS"))) { obj.BC1_TUOITS = reader.GetBoolean(reader.GetOrdinal("BC1_TuoiTS")); } else { obj.BC1_TUOITS = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("BC1_ThamNien"))) { obj.BC1_THAMNIEN = reader.GetBoolean(reader.GetOrdinal("BC1_ThamNien")); } else { obj.BC1_THAMNIEN = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaBC2"))) { obj.MABC2 = reader.GetString(reader.GetOrdinal("MaBC2")); } else { obj.MABC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQuaBC2"))) { obj.KETQUABC2 = reader.GetBoolean(reader.GetOrdinal("KetQuaBC2")); } else { obj.KETQUABC2 = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaLyDoTCBC2"))) { obj.MALYDOTCBC2 = reader.GetInt32(reader.GetOrdinal("MaLyDoTCBC2")); } else { obj.MALYDOTCBC2 = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaKySH"))) { obj.MAKYSH = reader.GetString(reader.GetOrdinal("MaKySH")); } else { obj.MAKYSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoBD"))) { obj.SOBD = reader.GetString(reader.GetOrdinal("SoBD")); } else { obj.SOBD = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("LanSH"))) { obj.LANSH = reader.GetInt32(reader.GetOrdinal("LanSH")); } else { obj.LANSH = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoQDSH"))) { obj.SOQDSH = reader.GetString(reader.GetOrdinal("SoQDSH")); } else { obj.SOQDSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayQDSH"))) { obj.NGAYQDSH = reader.GetDateTime(reader.GetOrdinal("NgayQDSH")); } else { obj.NGAYQDSH = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQua_LyThuyet"))) { obj.KETQUA_LYTHUYET = reader.GetString(reader.GetOrdinal("KetQua_LyThuyet")); } else { obj.KETQUA_LYTHUYET = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NhanXet_LyThuyet"))) { obj.NHANXET_LYTHUYET = reader.GetString(reader.GetOrdinal("NhanXet_LyThuyet")); } else { obj.NHANXET_LYTHUYET = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQua_Hinh"))) { obj.KETQUA_HINH = reader.GetInt32(reader.GetOrdinal("KetQua_Hinh")); } else { obj.KETQUA_HINH = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NhanXet_Hinh"))) { obj.NHANXET_HINH = reader.GetString(reader.GetOrdinal("NhanXet_Hinh")); } else { obj.NHANXET_HINH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQua_Duong"))) { obj.KETQUA_DUONG = reader.GetInt32(reader.GetOrdinal("KetQua_Duong")); } else { obj.KETQUA_DUONG = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NhanXet_Duong"))) { obj.NHANXET_DUONG = reader.GetString(reader.GetOrdinal("NhanXet_Duong")); } else { obj.NHANXET_DUONG = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQuaSH"))) { obj.KETQUASH = reader.GetString(reader.GetOrdinal("KetQuaSH")); } else { obj.KETQUASH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoQDTT"))) { obj.SOQDTT = reader.GetString(reader.GetOrdinal("SoQDTT")); } else { obj.SOQDTT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayQDTT"))) { obj.NGAYQDTT = reader.GetDateTime(reader.GetOrdinal("NgayQDTT")); } else { obj.NGAYQDTT = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiKy"))) { obj.NGUOIKY = reader.GetString(reader.GetOrdinal("NguoiKy")); } else { obj.NGUOIKY = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GhiChu"))) { obj.GHICHU = reader.GetString(reader.GetOrdinal("GhiChu")); } else { obj.GHICHU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiTao"))) { obj.NGUOITAO = reader.GetString(reader.GetOrdinal("NguoiTao")); } else { obj.NGUOITAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiSua"))) { obj.NGUOISUA = reader.GetString(reader.GetOrdinal("NguoiSua")); } else { obj.NGUOISUA = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayTao"))) { obj.NGAYTAO = reader.GetDateTime(reader.GetOrdinal("NgayTao")); } else { obj.NGAYTAO = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgaySua"))) { obj.NGAYSUA = reader.GetDateTime(reader.GetOrdinal("NgaySua")); } else { obj.NGAYSUA = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoGPLXTmp"))) { obj.SOGPLXTMP = reader.GetString(reader.GetOrdinal("SoGPLXTmp")); } else { obj.SOGPLXTMP = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayKTBC1"))) { obj.NGAYKTBC1 = reader.GetDateTime(reader.GetOrdinal("NgayKTBC1")); } else { obj.NGAYKTBC1 = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiKTBC1"))) { obj.NGUOIKTBC1 = reader.GetString(reader.GetOrdinal("NguoiKTBC1")); } else { obj.NGUOIKTBC1 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayKTBC2"))) { obj.NGAYKTBC2 = reader.GetDateTime(reader.GetOrdinal("NgayKTBC2")); } else { obj.NGAYKTBC2 = DateTime.Now; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiKTBC2"))) { obj.NGUOIKTBC2 = reader.GetString(reader.GetOrdinal("NguoiKTBC2")); } else { obj.NGUOIKTBC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaIn"))) { obj.MAIN = reader.GetString(reader.GetOrdinal("MaIn")); } else { obj.MAIN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQuaDoiSanhTW"))) { obj.KETQUADOISANHTW = reader.GetBoolean(reader.GetOrdinal("KetQuaDoiSanhTW")); } else { obj.KETQUADOISANHTW = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GhiChuKQDSTW"))) { obj.GHICHUKQDSTW = reader.GetString(reader.GetOrdinal("GhiChuKQDSTW")); } else { obj.GHICHUKQDSTW = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("ChuKy"))) { obj.CHUKY = reader.GetString(reader.GetOrdinal("ChuKy")); } else { obj.CHUKY = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TrangThai"))) { obj.TRANGTHAI = reader.GetBoolean(reader.GetOrdinal("TrangThai")); } else { obj.TRANGTHAI = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaHTCap"))) { obj.MAHTCAP = reader.GetString(reader.GetOrdinal("MaHTCap")); } else { obj.MAHTCAP = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("IDs"))) { obj.IDS = reader.GetInt64(reader.GetOrdinal("IDs")); } else { obj.IDS = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TT_XuLy_Old"))) { obj.TT_XULY_OLD = reader.GetString(reader.GetOrdinal("TT_XuLy_Old")); } else { obj.TT_XULY_OLD = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KQ_BC1"))) { obj.KQ_BC1 = reader.GetBoolean(reader.GetOrdinal("KQ_BC1")); } else { obj.KQ_BC1 = false; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KQ_BC1_GhiChu"))) { obj.KQ_BC1_GHICHU = reader.GetString(reader.GetOrdinal("KQ_BC1_GhiChu")); } else { obj.KQ_BC1_GHICHU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("Transfer_flag"))) { obj.TRANSFER_FLAG = reader.GetInt32(reader.GetOrdinal("Transfer_flag")); } else { obj.TRANSFER_FLAG = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NamcapLandau"))) { obj.NAMCAPLANDAU = reader.GetString(reader.GetOrdinal("NamcapLandau")); } else { obj.NAMCAPLANDAU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaTrichNgang"))) { obj.MATRICHNGANG = reader.GetString(reader.GetOrdinal("MaTrichNgang")); } else { obj.MATRICHNGANG = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DiaChiTrenGplx"))) { obj.DIACHITRENGPLX = reader.GetString(reader.GetOrdinal("DiaChiTrenGplx")); } else { obj.DIACHITRENGPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("CoQuanQuanLyGplx"))) { obj.COQUANQUANLYGPLX = reader.GetString(reader.GetOrdinal("CoQuanQuanLyGplx")); } else { obj.COQUANQUANLYGPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DiaChiTrenGplx_ChiTiet"))) { obj.DIACHITRENGPLX_CHITIET = reader.GetString(reader.GetOrdinal("DiaChiTrenGplx_ChiTiet")); } else { obj.DIACHITRENGPLX_CHITIET = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("IN_GPLX"))) { obj.IN_GPLX = reader.GetInt32(reader.GetOrdinal("IN_GPLX")); } else { obj.IN_GPLX = -1; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SOSERI_GPLX_DACO"))) { obj.SOSERI_GPLX_DACO = reader.GetString(reader.GetOrdinal("SOSERI_GPLX_DACO")); } else { obj.SOSERI_GPLX_DACO = ""; }
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
