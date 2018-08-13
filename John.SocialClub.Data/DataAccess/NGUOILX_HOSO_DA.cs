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
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayNhanHSo"))) { obj.NGAYNHANHSO = reader.GetDateTime(reader.GetOrdinal("NgayNhanHSo")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAYNHANHSO = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiNhanHSo"))) { obj.NGUOINHANHSO = reader.GetString(reader.GetOrdinal("NguoiNhanHSo")); } else { obj.NGUOINHANHSO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayHenTra"))) { obj.NGAYHENTRA = reader.GetDateTime(reader.GetOrdinal("NgayHenTra")).ToString(); } else { obj.NGAYHENTRA = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaLoaiHs"))) { obj.MALOAIHS = reader.GetInt32(reader.GetOrdinal("MaLoaiHs")).ToString(); } else { obj.MALOAIHS = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TT_XuLy"))) { obj.TT_XULY = reader.GetString(reader.GetOrdinal("TT_XuLy")); } else { obj.TT_XULY = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DuongDanAnh"))) { obj.DUONGDANANH = reader.GetString(reader.GetOrdinal("DuongDanAnh")); } else { obj.DUONGDANANH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("ChatLuongAnh"))) { obj.CHATLUONGANH = reader.GetInt32(reader.GetOrdinal("ChatLuongAnh")).ToString(); } else { obj.CHATLUONGANH = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayThuNhanAnh"))) { obj.NGAYTHUNHANANH = reader.GetDateTime(reader.GetOrdinal("NgayThuNhanAnh")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAYTHUNHANANH = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiThuNhanAnh"))) { obj.NGUOITHUNHANANH = reader.GetString(reader.GetOrdinal("NguoiThuNhanAnh")).ToString(); } else { obj.NGUOITHUNHANANH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoGPLXDaCo"))) { obj.SOGPLXDACO = reader.GetString(reader.GetOrdinal("SoGPLXDaCo")); } else { obj.SOGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HangGPLXDaCo"))) { obj.HANGGPLXDACO = reader.GetString(reader.GetOrdinal("HangGPLXDaCo")); } else { obj.HANGGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DonViCapGPLXDaCo"))) { obj.DONVICAPGPLXDACO = reader.GetString(reader.GetOrdinal("DonViCapGPLXDaCo")); } else { obj.DONVICAPGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiCapGPLXDaCo"))) { obj.NOICAPGPLXDACO = reader.GetString(reader.GetOrdinal("NoiCapGPLXDaCo")); } else { obj.NOICAPGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayCapGPLXDaCo"))) { obj.NGAYCAPGPLXDACO = reader.GetString(reader.GetOrdinal("NgayCapGPLXDaCo")); } else { obj.NGAYCAPGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayHHGPLXDaCo"))) { obj.NGAYHHGPLXDACO = reader.GetString(reader.GetOrdinal("NgayHHGPLXDaCo")); } else { obj.NGAYHHGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayTTGPLXDaCo"))) { obj.NGAYTTGPLXDACO = reader.GetString(reader.GetOrdinal("NgayTTGPLXDaCo")); } else { obj.NGAYTTGPLXDACO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DonViHocLX"))) { obj.DONVIHOCLX = reader.GetString(reader.GetOrdinal("DonViHocLX")); } else { obj.DONVIHOCLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NamHocLX"))) { obj.NAMHOCLX = reader.GetInt32(reader.GetOrdinal("NamHocLX")).ToString(); } else { obj.NAMHOCLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HangGPLX"))) { obj.HANGGPLX = reader.GetString(reader.GetOrdinal("HangGPLX")); } else { obj.HANGGPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoNamLX"))) { obj.SONAMLX = reader.GetInt32(reader.GetOrdinal("SoNamLX")).ToString(); } else { obj.SONAMLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoKmLXAnToan"))) { obj.SOKMLXANTOAN = reader.GetInt32(reader.GetOrdinal("SoKmLXAnToan")).ToString(); } else { obj.SOKMLXANTOAN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GiayCNSK"))) { obj.GIAYCNSK = Convert.ToInt32(reader.GetBoolean(reader.GetOrdinal("GiayCNSK"))).ToString(); } else { obj.GIAYCNSK = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("LyDoCapDoi"))) { obj.LYDOCAPDOI = reader.GetString(reader.GetOrdinal("LyDoCapDoi")); } else { obj.LYDOCAPDOI = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MucDichCapDoi"))) { obj.MUCDICHCAPDOI = reader.GetString(reader.GetOrdinal("MucDichCapDoi")); } else { obj.MUCDICHCAPDOI = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDungSH"))) { obj.NOIDUNGSH = reader.GetInt32(reader.GetOrdinal("NoiDungSH")).ToString(); } else { obj.NOIDUNGSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaKhoaHoc"))) { obj.MAKHOAHOC = reader.GetString(reader.GetOrdinal("MaKhoaHoc")); } else { obj.MAKHOAHOC = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("HangDaoTao"))) { obj.HANGDAOTAO = reader.GetString(reader.GetOrdinal("HangDaoTao")); } else { obj.HANGDAOTAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoGiayCNTN"))) { obj.SOGIAYCNTN = reader.GetString(reader.GetOrdinal("SoGiayCNTN")); } else { obj.SOGIAYCNTN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoCCN"))) { obj.SOCCN = reader.GetString(reader.GetOrdinal("SoCCN")); } else { obj.SOCCN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaBC1"))) { obj.MABC1 = reader.GetString(reader.GetOrdinal("MaBC1")); } else { obj.MABC1 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("BC1_TuoiTS"))) { obj.BC1_TUOITS = Convert.ToInt32(reader.GetBoolean(reader.GetOrdinal("BC1_TuoiTS"))).ToString(); } else { obj.BC1_TUOITS = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("BC1_ThamNien"))) { obj.BC1_THAMNIEN = Convert.ToInt32(reader.GetBoolean(reader.GetOrdinal("BC1_ThamNien"))).ToString(); } else { obj.BC1_THAMNIEN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaBC2"))) { obj.MABC2 = reader.GetString(reader.GetOrdinal("MaBC2")); } else { obj.MABC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQuaBC2"))) { obj.KETQUABC2 = Convert.ToInt32(reader.GetBoolean(reader.GetOrdinal("KetQuaBC2"))).ToString(); } else { obj.KETQUABC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaLyDoTCBC2"))) { obj.MALYDOTCBC2 = reader.GetInt32(reader.GetOrdinal("MaLyDoTCBC2")).ToString(); } else { obj.MALYDOTCBC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaKySH"))) { obj.MAKYSH = reader.GetString(reader.GetOrdinal("MaKySH")); } else { obj.MAKYSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoBD"))) { obj.SOBD = reader.GetString(reader.GetOrdinal("SoBD")); } else { obj.SOBD = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("LanSH"))) { obj.LANSH = reader.GetInt32(reader.GetOrdinal("LanSH")).ToString(); } else { obj.LANSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoQDSH"))) { obj.SOQDSH = reader.GetString(reader.GetOrdinal("SoQDSH")); } else { obj.SOQDSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayQDSH"))) { obj.NGAYQDSH = reader.GetDateTime(reader.GetOrdinal("NgayQDSH")).ToString(); } else { obj.NGAYQDSH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQua_LyThuyet"))) { obj.KETQUA_LYTHUYET = reader.GetString(reader.GetOrdinal("KetQua_LyThuyet")); } else { obj.KETQUA_LYTHUYET = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NhanXet_LyThuyet"))) { obj.NHANXET_LYTHUYET = reader.GetString(reader.GetOrdinal("NhanXet_LyThuyet")); } else { obj.NHANXET_LYTHUYET = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQua_Hinh"))) { obj.KETQUA_HINH = reader.GetInt32(reader.GetOrdinal("KetQua_Hinh")).ToString(); } else { obj.KETQUA_HINH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NhanXet_Hinh"))) { obj.NHANXET_HINH = reader.GetString(reader.GetOrdinal("NhanXet_Hinh")); } else { obj.NHANXET_HINH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQua_Duong"))) { obj.KETQUA_DUONG = reader.GetInt32(reader.GetOrdinal("KetQua_Duong")).ToString(); } else { obj.KETQUA_DUONG = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NhanXet_Duong"))) { obj.NHANXET_DUONG = reader.GetString(reader.GetOrdinal("NhanXet_Duong")); } else { obj.NHANXET_DUONG = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQuaSH"))) { obj.KETQUASH = reader.GetString(reader.GetOrdinal("KetQuaSH")); } else { obj.KETQUASH = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoQDTT"))) { obj.SOQDTT = reader.GetString(reader.GetOrdinal("SoQDTT")); } else { obj.SOQDTT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayQDTT"))) { obj.NGAYQDTT = reader.GetDateTime(reader.GetOrdinal("NgayQDTT")).ToString(); } else { obj.NGAYQDTT = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiKy"))) { obj.NGUOIKY = reader.GetString(reader.GetOrdinal("NguoiKy")); } else { obj.NGUOIKY = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GhiChu"))) { obj.GHICHU = reader.GetString(reader.GetOrdinal("GhiChu")); } else { obj.GHICHU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiTao"))) { obj.NGUOITAO = reader.GetString(reader.GetOrdinal("NguoiTao")); } else { obj.NGUOITAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiSua"))) { obj.NGUOISUA = reader.GetString(reader.GetOrdinal("NguoiSua")); } else { obj.NGUOISUA = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayTao"))) { obj.NGAYTAO = reader.GetDateTime(reader.GetOrdinal("NgayTao")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAYTAO = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgaySua"))) { obj.NGAYSUA = reader.GetDateTime(reader.GetOrdinal("NgaySua")).ToString(Ultils.FORMAT_DATETIME); } else { obj.NGAYSUA = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SoGPLXTmp"))) { obj.SOGPLXTMP = reader.GetString(reader.GetOrdinal("SoGPLXTmp")).ToString(); } else { obj.SOGPLXTMP = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayKTBC1"))) { obj.NGAYKTBC1 = reader.GetDateTime(reader.GetOrdinal("NgayKTBC1")).ToString(); } else { obj.NGAYKTBC1 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiKTBC1"))) { obj.NGUOIKTBC1 = reader.GetString(reader.GetOrdinal("NguoiKTBC1")).ToString(); } else { obj.NGUOIKTBC1 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NgayKTBC2"))) { obj.NGAYKTBC2 = reader.GetDateTime(reader.GetOrdinal("NgayKTBC2")).ToString(); } else { obj.NGAYKTBC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NguoiKTBC2"))) { obj.NGUOIKTBC2 = reader.GetString(reader.GetOrdinal("NguoiKTBC2")).ToString(); } else { obj.NGUOIKTBC2 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaIn"))) { obj.MAIN = reader.GetString(reader.GetOrdinal("MaIn")); } else { obj.MAIN = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KetQuaDoiSanhTW"))) { obj.KETQUADOISANHTW = reader.GetBoolean(reader.GetOrdinal("KetQuaDoiSanhTW")).ToString(); } else { obj.KETQUADOISANHTW = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("GhiChuKQDSTW"))) { obj.GHICHUKQDSTW = reader.GetString(reader.GetOrdinal("GhiChuKQDSTW")); } else { obj.GHICHUKQDSTW = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("ChuKy"))) { obj.CHUKY = reader.GetString(reader.GetOrdinal("ChuKy")); } else { obj.CHUKY = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TrangThai"))) { obj.TRANGTHAI = Convert.ToInt32(reader.GetBoolean(reader.GetOrdinal("TrangThai"))).ToString(); } else { obj.TRANGTHAI = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaHTCap"))) { obj.MAHTCAP = reader.GetString(reader.GetOrdinal("MaHTCap")); } else { obj.MAHTCAP = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("IDs"))) { obj.IDS = reader.GetInt64(reader.GetOrdinal("IDs")); } else { obj.IDS = null; }
                    if (!reader.IsDBNull(reader.GetOrdinal("TT_XuLy_Old"))) { obj.TT_XULY_OLD = reader.GetString(reader.GetOrdinal("TT_XuLy_Old")); } else { obj.TT_XULY_OLD = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KQ_BC1"))) { obj.KQ_BC1 = reader.GetBoolean(reader.GetOrdinal("KQ_BC1")).ToString(); } else { obj.KQ_BC1 = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("KQ_BC1_GhiChu"))) { obj.KQ_BC1_GHICHU = reader.GetString(reader.GetOrdinal("KQ_BC1_GhiChu")); } else { obj.KQ_BC1_GHICHU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("Transfer_flag"))) { obj.TRANSFER_FLAG = reader.GetInt32(reader.GetOrdinal("Transfer_flag")).ToString(); } else { obj.TRANSFER_FLAG = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("NamcapLandau"))) { obj.NAMCAPLANDAU = reader.GetString(reader.GetOrdinal("NamcapLandau")); } else { obj.NAMCAPLANDAU = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("MaTrichNgang"))) { obj.MATRICHNGANG = reader.GetString(reader.GetOrdinal("MaTrichNgang")); } else { obj.MATRICHNGANG = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DiaChiTrenGplx"))) { obj.DIACHITRENGPLX = reader.GetString(reader.GetOrdinal("DiaChiTrenGplx")); } else { obj.DIACHITRENGPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("CoQuanQuanLyGplx"))) { obj.COQUANQUANLYGPLX = reader.GetString(reader.GetOrdinal("CoQuanQuanLyGplx")); } else { obj.COQUANQUANLYGPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("DiaChiTrenGplx_ChiTiet"))) { obj.DIACHITRENGPLX_CHITIET = reader.GetString(reader.GetOrdinal("DiaChiTrenGplx_ChiTiet")); } else { obj.DIACHITRENGPLX_CHITIET = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("IN_GPLX"))) { obj.IN_GPLX = reader.GetInt32(reader.GetOrdinal("IN_GPLX")).ToString(); } else { obj.IN_GPLX = ""; }
                    if (!reader.IsDBNull(reader.GetOrdinal("SOSERI_GPLX_DACO"))) { obj.SOSERI_GPLX_DACO = reader.GetString(reader.GetOrdinal("SOSERI_GPLX_DACO")); } else { obj.SOSERI_GPLX_DACO = ""; }

                    obj.encodeImg();
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


        public static int insertData(SqlConnection connection, SqlTransaction transaction, NGUOILX_HOSO obj)
        {
            int rtn = 0;

            try
            {
                string queryString = "INSERT INTO [dbo].[NguoiLX_HoSo](MaDK,SoHoSo,MACSDT,MaSoGTVT,MaDVNhanHSo,NgayNhanHSo,NguoiNhanHSo,NgayHenTra,MaLoaiHs,TT_XuLy,DuongDanAnh,ChatLuongAnh,NgayThuNhanAnh,NguoiThuNhanAnh,SoGPLXDaCo,HangGPLXDaCo,DonViCapGPLXDaCo,NoiCapGPLXDaCo,NgayCapGPLXDaCo,NgayHHGPLXDaCo,NgayTTGPLXDaCo,DonViHocLX,NamHocLX,HangGPLX,SoNamLX,SoKmLXAnToan,GiayCNSK,LyDoCapDoi,MucDichCapDoi,NoiDungSH,MaKhoaHoc,HangDaoTao,SoGiayCNTN,SoCCN,MaBC1,BC1_TuoiTS,BC1_ThamNien,MaBC2,KetQuaBC2,MaLyDoTCBC2,MaKySH,SoBD,LanSH,SoQDSH,NgayQDSH,KetQua_LyThuyet,NhanXet_LyThuyet,KetQua_Hinh,NhanXet_Hinh,KetQua_Duong,NhanXet_Duong,KetQuaSH,SoQDTT,NgayQDTT,NguoiKy,GhiChu,NguoiTao,NguoiSua,NgayTao,NgaySua,SoGPLXTmp,NgayKTBC1,NGUOIKTBC1,NgayKTBC2,NguoiKTBC2,MaIn,KetQuaDoiSanhTW,GhiChuKQDSTW,ChuKy,TrangThai,MaHTCap,TT_XuLy_Old,KQ_BC1,KQ_BC1_GhiChu,Transfer_flag,NamcapLandau,MaTrichNgang,DiaChiTrenGplx,CoQuanQuanLyGplx,DiaChiTrenGplx_ChiTiet,IN_GPLX,SOSERI_GPLX_DACO) " +
                    "VALUES (@MADK,@SOHOSO,@MACSDT,@MASOGTVT,@MADVNHANHSO,@NGAYNHANHSO,@NGUOINHANHSO,@NGAYHENTRA,@MALOAIHS,@TT_XULY,@DUONGDANANH,@CHATLUONGANH,@NGAYTHUNHANANH,@NGUOITHUNHANANH,@SOGPLXDACO,@HANGGPLXDACO,@DONVICAPGPLXDACO,@NOICAPGPLXDACO,@NGAYCAPGPLXDACO,@NGAYHHGPLXDACO,@NGAYTTGPLXDACO,@DONVIHOCLX,@NAMHOCLX,@HANGGPLX,@SONAMLX,@SOKMLXANTOAN,@GIAYCNSK,@LYDOCAPDOI,@MUCDICHCAPDOI,@NOIDUNGSH,@MAKHOAHOC,@HANGDAOTAO,@SOGIAYCNTN,@SoCCN,@MABC1,@BC1_TUOITS,@BC1_THAMNIEN,@MABC2,@KETQUABC2,@MALYDOTCBC2,@MAKYSH,@SOBD,@LANSH,@SOQDSH,@NGAYQDSH,@KETQUA_LYTHUYET,@NHANXET_LYTHUYET,@KETQUA_HINH,@NHANXET_HINH,@KETQUA_DUONG,@NHANXET_DUONG,@KETQUASH,@SOQDTT,@NGAYQDTT,@NGUOIKY,@GHICHU,@NGUOITAO,@NGUOISUA,@NGAYTAO,@NGAYSUA,@SOGPLXTMP,@NGAYKTBC1,@NGUOIKTBC1,@NGAYKTBC2,@NGUOIKTBC2,@MAIN,@KETQUADOISANHTW,@GHICHUKQDSTW,@CHUKY,@TRANGTHAI,@MAHTCAP,@TT_XULY_OLD,@KQ_BC1,@KQ_BC1_GHICHU,@TRANSFER_FLAG,@NAMCAPLANDAU,@MATRICHNGANG,@DIACHITRENGPLX,@COQUANQUANLYGPLX,@DIACHITRENGPLX_CHITIET,@IN_GPLX,@SOSERI_GPLX_DACO)";

                SqlCommand command = new SqlCommand(queryString, connection);
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                
                command.Parameters.AddWithValue("@MADK", obj.MADK);
                if (obj.SOHOSO == null || obj.SOHOSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOHOSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOHOSO", obj.SOHOSO);
                }
                if (obj.MACSDT == null || obj.MACSDT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MACSDT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MACSDT", obj.MACSDT);
                }
                if (obj.MASOGTVT == null || obj.MASOGTVT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MASOGTVT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MASOGTVT", obj.MASOGTVT);
                }
                if (obj.MADVNHANHSO == null || obj.MADVNHANHSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MADVNHANHSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MADVNHANHSO", obj.MADVNHANHSO);
                }
                //command.Parameters.AddWithValue("@NGAYNHANHSO", obj.NGAYNHANHSO);
                if (obj.NGAYNHANHSO == null || obj.NGAYNHANHSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYNHANHSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYNHANHSO", DateTime.Parse(obj.NGAYNHANHSO));
                }
                if (obj.NGUOINHANHSO == null || obj.NGUOINHANHSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOINHANHSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOINHANHSO", obj.NGUOINHANHSO);
                }
                //command.Parameters.AddWithValue("@NGAYHENTRA", obj.NGAYHENTRA);
                if (obj.NGAYHENTRA == null || obj.NGAYHENTRA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYHENTRA", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYHENTRA", DateTime.Parse(obj.NGAYHENTRA));
                }
                //command.Parameters.AddWithValue("@MALOAIHS", obj.MALOAIHS);
                if (obj.MALOAIHS == null || obj.MALOAIHS.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MALOAIHS", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MALOAIHS", Int32.Parse(obj.MALOAIHS));
                }
                if (obj.TT_XULY == null || obj.TT_XULY.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TT_XULY", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TT_XULY", obj.TT_XULY);
                }
                if (obj.DUONGDANANH == null || obj.DUONGDANANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DUONGDANANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DUONGDANANH", obj.DUONGDANANH);
                }
                //command.Parameters.AddWithValue("@CHATLUONGANH" ,obj.CHATLUONGANH);
                if (obj.CHATLUONGANH == null || obj.CHATLUONGANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@CHATLUONGANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@CHATLUONGANH", Int32.Parse(obj.CHATLUONGANH));
                }
                //command.Parameters.AddWithValue("@NGAYTHUNHANANH", obj.NGAYTHUNHANANH);
                if (obj.NGAYTHUNHANANH == null || obj.NGAYTHUNHANANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYTHUNHANANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYTHUNHANANH", DateTime.Parse(obj.NGAYTHUNHANANH));
                }
                if (obj.NGUOITHUNHANANH == null || obj.NGUOITHUNHANANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOITHUNHANANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOITHUNHANANH", obj.NGUOITHUNHANANH);
                }
                if (obj.SOGPLXDACO == null || obj.SOGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOGPLXDACO", obj.SOGPLXDACO);
                }
                if (obj.HANGGPLXDACO == null || obj.HANGGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HANGGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HANGGPLXDACO", obj.HANGGPLXDACO);
                }
                if (obj.DONVICAPGPLXDACO == null || obj.DONVICAPGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DONVICAPGPLXDACO", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@DONVICAPGPLXDACO", obj.DONVICAPGPLXDACO);
                }
                if (obj.NOICAPGPLXDACO == null || obj.NOICAPGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NOICAPGPLXDACO", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@NOICAPGPLXDACO", obj.NOICAPGPLXDACO);
                }
                if (obj.NGAYCAPGPLXDACO == null || obj.NGAYCAPGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYCAPGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYCAPGPLXDACO", obj.NGAYCAPGPLXDACO);
                }
                if (obj.NGAYHHGPLXDACO == null || obj.NGAYHHGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYHHGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYHHGPLXDACO", obj.NGAYHHGPLXDACO);
                }
                if (obj.NGAYTTGPLXDACO == null || obj.NGAYTTGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYTTGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYTTGPLXDACO", obj.NGAYTTGPLXDACO);
                }
                if (obj.DONVIHOCLX == null || obj.DONVIHOCLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DONVIHOCLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DONVIHOCLX", obj.DONVIHOCLX);
                }
                //command.Parameters.AddWithValue("@NAMHOCLX" ,obj.NAMHOCLX);
                if (obj.NAMHOCLX == null || obj.NAMHOCLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NAMHOCLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NAMHOCLX", Int32.Parse(obj.NAMHOCLX));
                }
                if (obj.HANGGPLX == null || obj.HANGGPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HANGGPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HANGGPLX", obj.HANGGPLX);
                }
                //command.Parameters.AddWithValue("@SONAMLX" ,obj.SONAMLX);
                if (obj.SONAMLX == null || obj.SONAMLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SONAMLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SONAMLX", Int32.Parse(obj.SONAMLX));
                }
                //command.Parameters.AddWithValue("@SOKMLXANTOAN", obj.SOKMLXANTOAN);
                if (obj.SOKMLXANTOAN == null || obj.SOKMLXANTOAN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOKMLXANTOAN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOKMLXANTOAN", Int32.Parse(obj.SOKMLXANTOAN));
                }
                //command.Parameters.AddWithValue("@GIAYCNSK" ,obj.GIAYCNSK);
                if (obj.GIAYCNSK == null || obj.GIAYCNSK.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GIAYCNSK", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GIAYCNSK", Int32.Parse(obj.GIAYCNSK) != 0);
                }
                if (obj.LYDOCAPDOI == null || obj.LYDOCAPDOI.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@LYDOCAPDOI", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@LYDOCAPDOI", obj.LYDOCAPDOI);
                }
                if (obj.MUCDICHCAPDOI == null || obj.MUCDICHCAPDOI.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MUCDICHCAPDOI", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@MUCDICHCAPDOI", obj.MUCDICHCAPDOI);
                }
                //command.Parameters.AddWithValue("@NOIDUNGSH" ,obj.NOIDUNGSH);
                if (obj.NOIDUNGSH == null || obj.NOIDUNGSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NOIDUNGSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NOIDUNGSH", Int32.Parse(obj.NOIDUNGSH));
                }
                //command.Parameters.AddWithValue("@MAKHOAHOC", obj.MAKHOAHOC);
                if (obj.MAKHOAHOC == null || obj.MAKHOAHOC.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAKHOAHOC", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAKHOAHOC", obj.MAKHOAHOC);
                }
                if (obj.HANGDAOTAO == null || obj.HANGDAOTAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HANGDAOTAO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HANGDAOTAO", obj.HANGDAOTAO);
                }
                if (obj.SOGIAYCNTN == null || obj.SOGIAYCNTN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOGIAYCNTN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOGIAYCNTN", obj.SOGIAYCNTN);
                }
                if (obj.SOCCN == null || obj.SOCCN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SoCCN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SoCCN", obj.SOCCN);
                }
                if (obj.MABC1 == null || obj.MABC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MABC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MABC1", obj.MABC1);
                }
                //command.Parameters.AddWithValue("@BC1_TUOITS", obj.BC1_TUOITS);
                if (obj.BC1_TUOITS == null || obj.BC1_TUOITS.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@BC1_TUOITS", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@BC1_TUOITS", Boolean.Parse(obj.BC1_TUOITS));
                }
                //command.Parameters.AddWithValue("@BC1_THAMNIEN", obj.BC1_THAMNIEN);
                if (obj.BC1_THAMNIEN == null || obj.BC1_THAMNIEN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@BC1_THAMNIEN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@BC1_THAMNIEN", Boolean.Parse(obj.BC1_THAMNIEN));
                }
                if (obj.MABC2 == null || obj.MABC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MABC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MABC2", obj.MABC2);
                }
                //command.Parameters.AddWithValue("@KETQUABC2", obj.KETQUABC2);
                if (obj.KETQUABC2 == null || obj.KETQUABC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUABC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUABC2", Boolean.Parse(obj.KETQUABC2));
                }
                //command.Parameters.AddWithValue("@MALYDOTCBC2", obj.MALYDOTCBC2);
                if (obj.MALYDOTCBC2 == null || obj.MALYDOTCBC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MALYDOTCBC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MALYDOTCBC2", Int32.Parse(obj.MALYDOTCBC2));
                }
                if (obj.MAKYSH == null || obj.MAKYSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAKYSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAKYSH", obj.MAKYSH);
                }
                if (obj.SOBD == null || obj.SOBD.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOBD", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOBD", obj.SOBD);
                }
                //command.Parameters.AddWithValue("@LANSH", obj.LANSH);
                if (obj.LANSH == null || obj.LANSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@LANSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@LANSH", Int32.Parse(obj.LANSH));
                }
                if (obj.SOQDSH == null || obj.SOQDSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOQDSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOQDSH", obj.SOQDSH);
                }
                //command.Parameters.AddWithValue("@NGAYQDSH", obj.NGAYQDSH);
                if (obj.LANSH == null || obj.NGAYQDSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYQDSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYQDSH", DateTime.Parse(obj.NGAYQDSH));
                }
                if (obj.KETQUA_LYTHUYET == null || obj.KETQUA_LYTHUYET.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUA_LYTHUYET", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUA_LYTHUYET", Int32.Parse(obj.KETQUA_LYTHUYET));
                }
                if (obj.NHANXET_LYTHUYET == null || obj.NHANXET_LYTHUYET.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NHANXET_LYTHUYET", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NHANXET_LYTHUYET", obj.NHANXET_LYTHUYET);
                }
                //command.Parameters.AddWithValue("@KETQUA_HINH" ,obj.KETQUA_HINH);
                if (obj.KETQUA_HINH == null || obj.KETQUA_HINH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUA_HINH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUA_HINH", Int32.Parse(obj.KETQUA_HINH));
                }
                if (obj.NHANXET_HINH == null || obj.NHANXET_HINH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NHANXET_HINH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NHANXET_HINH", obj.NHANXET_HINH);
                }
                //command.Parameters.AddWithValue("@KETQUA_DUONG", obj.KETQUA_DUONG);
                if (obj.KETQUA_DUONG == null || obj.KETQUA_DUONG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUA_DUONG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUA_DUONG", Int32.Parse(obj.KETQUA_DUONG));
                }
                if (obj.NHANXET_DUONG == null || obj.NHANXET_DUONG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NHANXET_DUONG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NHANXET_DUONG", obj.NHANXET_DUONG);
                }
                if (obj.KETQUASH == null || obj.KETQUASH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUASH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUASH", obj.KETQUASH);
                }
                if (obj.SOQDTT == null || obj.SOQDTT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOQDTT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOQDTT", obj.SOQDTT);
                }
                //command.Parameters.AddWithValue("@NGAYQDTT", obj.NGAYQDTT);
                if (obj.NGAYQDTT == null || obj.NGAYQDTT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYQDTT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYQDTT", DateTime.Parse(obj.NGAYQDTT));
                }

                if (obj.NGUOIKY == null || obj.NGUOIKY.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOIKY", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOIKY", obj.NGUOIKY);
                }
                if (obj.GHICHU == null || obj.GHICHU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GHICHU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GHICHU", obj.GHICHU);
                }
                if (obj.NGUOITAO == null || obj.NGUOITAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOITAO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOITAO", obj.NGUOITAO);
                }
                if (obj.NGUOISUA == null || obj.NGUOISUA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOISUA", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOISUA", obj.NGUOISUA);
                }
                //command.Parameters.AddWithValue("@NGAYTAO", obj.NGAYTAO);
                if (obj.NGAYTAO == null || obj.NGAYTAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYTAO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYTAO", DateTime.Parse(obj.NGAYTAO));
                }
                //command.Parameters.AddWithValue("@NGAYSUA", obj.NGAYSUA);
                if (obj.NGAYSUA == null || obj.NGAYSUA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYSUA", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYSUA", DateTime.Parse(obj.NGAYSUA));
                }
                if (obj.SOGPLXTMP == null || obj.SOGPLXTMP.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOGPLXTMP", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOGPLXTMP", obj.SOGPLXTMP);
                }
                //command.Parameters.AddWithValue("@NGAYKTBC1" ,obj.NGAYKTBC1);
                if (obj.NGAYKTBC1 == null || obj.NGAYKTBC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYKTBC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYKTBC1", DateTime.Parse(obj.NGAYKTBC1));
                }

                if (obj.NGUOIKTBC1 == null || obj.NGUOIKTBC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC1", obj.NGUOIKTBC1);
                }
                //command.Parameters.AddWithValue("@NGAYKTBC2", obj.NGAYKTBC2);
                if (obj.NGAYKTBC2 == null || obj.NGAYKTBC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYKTBC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYKTBC2", DateTime.Parse(obj.NGAYKTBC2));
                }
                if (obj.NGUOIKTBC2 == null || obj.NGUOIKTBC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC2", obj.NGUOIKTBC2);
                }
                if (obj.MAIN == null || obj.MAIN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAIN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAIN", obj.MAIN);
                }
                //command.Parameters.AddWithValue("@KETQUADOISANHTW", obj.KETQUADOISANHTW);
                if (obj.KETQUADOISANHTW == null || obj.KETQUADOISANHTW.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUADOISANHTW", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUADOISANHTW", Boolean.Parse(obj.KETQUADOISANHTW));
                }
                if (obj.GHICHUKQDSTW == null || obj.GHICHUKQDSTW.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GHICHUKQDSTW", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GHICHUKQDSTW", obj.GHICHUKQDSTW);
                }
                if (obj.CHUKY == null || obj.CHUKY.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@CHUKY", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@CHUKY", obj.CHUKY);
                }
                //command.Parameters.AddWithValue("@TRANGTHAI", obj.TRANGTHAI);
                if (obj.TRANGTHAI == null || obj.TRANGTHAI.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TRANGTHAI", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TRANGTHAI", Int32.Parse(obj.TRANGTHAI) != 0);
                }
                if (obj.MAHTCAP == null || obj.MAHTCAP.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAHTCAP", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAHTCAP", obj.MAHTCAP);
                }
                //command.Parameters.AddWithValue("@IDS" ,obj.IDS);
                if (obj.TT_XULY_OLD == null || obj.TT_XULY_OLD.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TT_XULY_OLD", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TT_XULY_OLD", obj.TT_XULY_OLD);
                }
                //command.Parameters.AddWithValue("@KQ_BC1", obj.KQ_BC1);
                if (obj.KQ_BC1 == null || obj.KQ_BC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KQ_BC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KQ_BC1", Boolean.Parse(obj.KQ_BC1));
                }
                if (obj.KQ_BC1_GHICHU == null || obj.KQ_BC1_GHICHU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KQ_BC1_GHICHU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KQ_BC1_GHICHU", obj.KQ_BC1_GHICHU);
                }
                //command.Parameters.AddWithValue("@TRANSFER_FLAG", obj.TRANSFER_FLAG);
                if (obj.TRANSFER_FLAG == null || obj.TRANSFER_FLAG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TRANSFER_FLAG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TRANSFER_FLAG", Int32.Parse(obj.TRANSFER_FLAG));
                }
                if (obj.NAMCAPLANDAU == null || obj.NAMCAPLANDAU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NAMCAPLANDAU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NAMCAPLANDAU", obj.NAMCAPLANDAU);
                }
                if (obj.MATRICHNGANG == null || obj.MATRICHNGANG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MATRICHNGANG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MATRICHNGANG", obj.MATRICHNGANG);
                }
                if (obj.DIACHITRENGPLX == null || obj.DIACHITRENGPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX", obj.DIACHITRENGPLX);
                }
                if (obj.COQUANQUANLYGPLX == null || obj.COQUANQUANLYGPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@COQUANQUANLYGPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@COQUANQUANLYGPLX", obj.COQUANQUANLYGPLX);
                }
                if (obj.DIACHITRENGPLX_CHITIET == null || obj.DIACHITRENGPLX_CHITIET.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX_CHITIET", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX_CHITIET", obj.DIACHITRENGPLX_CHITIET);
                }
                //command.Parameters.AddWithValue("@IN_GPLX", obj.IN_GPLX);
                if (obj.IN_GPLX == null || obj.IN_GPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@IN_GPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@IN_GPLX", Int32.Parse(obj.IN_GPLX));
                }
                if (obj.SOSERI_GPLX_DACO == null || obj.SOSERI_GPLX_DACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOSERI_GPLX_DACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOSERI_GPLX_DACO", obj.SOSERI_GPLX_DACO);
                }
                rtn = command.ExecuteNonQuery();

            }catch(Exception ex)
            {
                rtn = -1;
                throw ex;
            }
            finally
            {
            }
            return rtn;
        }

        public static int insertData(NGUOILX_HOSO obj)
        {
            int rtn = 0;

            SqlConnection connection = Ultils.GetDBConnection();

            try
            {
                string queryString = "INSERT INTO [dbo].[NguoiLX_HoSo](MaDK,SoHoSo,MACSDT,MaSoGTVT,MaDVNhanHSo,NgayNhanHSo,NguoiNhanHSo,NgayHenTra,MaLoaiHs,TT_XuLy,DuongDanAnh,ChatLuongAnh,NgayThuNhanAnh,NguoiThuNhanAnh,SoGPLXDaCo,HangGPLXDaCo,DonViCapGPLXDaCo,NoiCapGPLXDaCo,NgayCapGPLXDaCo,NgayHHGPLXDaCo,NgayTTGPLXDaCo,DonViHocLX,NamHocLX,HangGPLX,SoNamLX,SoKmLXAnToan,GiayCNSK,LyDoCapDoi,MucDichCapDoi,NoiDungSH,MaKhoaHoc,HangDaoTao,SoGiayCNTN,SoCCN,MaBC1,BC1_TuoiTS,BC1_ThamNien,MaBC2,KetQuaBC2,MaLyDoTCBC2,MaKySH,SoBD,LanSH,SoQDSH,NgayQDSH,KetQua_LyThuyet,NhanXet_LyThuyet,KetQua_Hinh,NhanXet_Hinh,KetQua_Duong,NhanXet_Duong,KetQuaSH,SoQDTT,NgayQDTT,NguoiKy,GhiChu,NguoiTao,NguoiSua,NgayTao,NgaySua,SoGPLXTmp,NgayKTBC1,NGUOIKTBC1,NgayKTBC2,NguoiKTBC2,MaIn,KetQuaDoiSanhTW,GhiChuKQDSTW,ChuKy,TrangThai,MaHTCap,TT_XuLy_Old,KQ_BC1,KQ_BC1_GhiChu,Transfer_flag,NamcapLandau,MaTrichNgang,DiaChiTrenGplx,CoQuanQuanLyGplx,DiaChiTrenGplx_ChiTiet,IN_GPLX,SOSERI_GPLX_DACO) " +
                    "VALUES (@MADK,@SOHOSO,@MACSDT,@MASOGTVT,@MADVNHANHSO,@NGAYNHANHSO,@NGUOINHANHSO,@NGAYHENTRA,@MALOAIHS,@TT_XULY,@DUONGDANANH,@CHATLUONGANH,@NGAYTHUNHANANH,@NGUOITHUNHANANH,@SOGPLXDACO,@HANGGPLXDACO,@DONVICAPGPLXDACO,@NOICAPGPLXDACO,@NGAYCAPGPLXDACO,@NGAYHHGPLXDACO,@NGAYTTGPLXDACO,@DONVIHOCLX,@NAMHOCLX,@HANGGPLX,@SONAMLX,@SOKMLXANTOAN,@GIAYCNSK,@LYDOCAPDOI,@MUCDICHCAPDOI,@NOIDUNGSH,@MAKHOAHOC,@HANGDAOTAO,@SOGIAYCNTN,@SoCCN,@MABC1,@BC1_TUOITS,@BC1_THAMNIEN,@MABC2,@KETQUABC2,@MALYDOTCBC2,@MAKYSH,@SOBD,@LANSH,@SOQDSH,@NGAYQDSH,@KETQUA_LYTHUYET,@NHANXET_LYTHUYET,@KETQUA_HINH,@NHANXET_HINH,@KETQUA_DUONG,@NHANXET_DUONG,@KETQUASH,@SOQDTT,@NGAYQDTT,@NGUOIKY,@GHICHU,@NGUOITAO,@NGUOISUA,@NGAYTAO,@NGAYSUA,@SOGPLXTMP,@NGAYKTBC1,@NGUOIKTBC1,@NGAYKTBC2,@NGUOIKTBC2,@MAIN,@KETQUADOISANHTW,@GHICHUKQDSTW,@CHUKY,@TRANGTHAI,@MAHTCAP,@TT_XULY_OLD,@KQ_BC1,@KQ_BC1_GHICHU,@TRANSFER_FLAG,@NAMCAPLANDAU,@MATRICHNGANG,@DIACHITRENGPLX,@COQUANQUANLYGPLX,@DIACHITRENGPLX_CHITIET,@IN_GPLX,@SOSERI_GPLX_DACO)";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@MADK", obj.MADK);
                if (obj.SOHOSO == null || obj.SOHOSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOHOSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOHOSO", obj.SOHOSO);
                }
                if (obj.MACSDT == null || obj.MACSDT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MACSDT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MACSDT", obj.MACSDT);
                }
                if (obj.MASOGTVT == null || obj.MASOGTVT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MASOGTVT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MASOGTVT", obj.MASOGTVT);
                }
                if (obj.MADVNHANHSO == null || obj.MADVNHANHSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MADVNHANHSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MADVNHANHSO", obj.MADVNHANHSO);
                }
                //command.Parameters.AddWithValue("@NGAYNHANHSO", obj.NGAYNHANHSO);
                if (obj.NGAYNHANHSO == null || obj.NGAYNHANHSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYNHANHSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYNHANHSO", DateTime.Parse(obj.NGAYNHANHSO));
                }
                if (obj.NGUOINHANHSO == null || obj.NGUOINHANHSO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOINHANHSO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOINHANHSO", obj.NGUOINHANHSO);
                }
                //command.Parameters.AddWithValue("@NGAYHENTRA", obj.NGAYHENTRA);
                if (obj.NGAYHENTRA == null || obj.NGAYHENTRA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYHENTRA", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYHENTRA", DateTime.Parse(obj.NGAYHENTRA));
                }
                //command.Parameters.AddWithValue("@MALOAIHS", obj.MALOAIHS);
                if (obj.MALOAIHS == null || obj.MALOAIHS.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MALOAIHS", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MALOAIHS", Int32.Parse(obj.MALOAIHS));
                }
                if (obj.TT_XULY == null || obj.TT_XULY.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TT_XULY", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TT_XULY", obj.TT_XULY);
                }
                if (obj.DUONGDANANH == null || obj.DUONGDANANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DUONGDANANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DUONGDANANH", obj.DUONGDANANH);
                }
                //command.Parameters.AddWithValue("@CHATLUONGANH" ,obj.CHATLUONGANH);
                if (obj.CHATLUONGANH == null || obj.CHATLUONGANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@CHATLUONGANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@CHATLUONGANH", Int32.Parse(obj.CHATLUONGANH));
                }
                //command.Parameters.AddWithValue("@NGAYTHUNHANANH", obj.NGAYTHUNHANANH);
                if (obj.NGAYTHUNHANANH == null || obj.NGAYTHUNHANANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYTHUNHANANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYTHUNHANANH", DateTime.Parse(obj.NGAYTHUNHANANH));
                }
                if (obj.NGUOITHUNHANANH == null || obj.NGUOITHUNHANANH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOITHUNHANANH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOITHUNHANANH", obj.NGUOITHUNHANANH);
                }
                if (obj.SOGPLXDACO == null || obj.SOGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOGPLXDACO", obj.SOGPLXDACO);
                }
                if (obj.HANGGPLXDACO == null || obj.HANGGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HANGGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HANGGPLXDACO", obj.HANGGPLXDACO);
                }
                if (obj.DONVICAPGPLXDACO == null || obj.DONVICAPGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DONVICAPGPLXDACO", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@DONVICAPGPLXDACO", obj.DONVICAPGPLXDACO);
                }
                if (obj.NOICAPGPLXDACO == null || obj.NOICAPGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NOICAPGPLXDACO", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@NOICAPGPLXDACO", obj.NOICAPGPLXDACO);
                }
                if (obj.NGAYCAPGPLXDACO == null || obj.NGAYCAPGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYCAPGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYCAPGPLXDACO", obj.NGAYCAPGPLXDACO);
                }
                if (obj.NGAYHHGPLXDACO == null || obj.NGAYHHGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYHHGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYHHGPLXDACO", obj.NGAYHHGPLXDACO);
                }
                if (obj.NGAYTTGPLXDACO == null || obj.NGAYTTGPLXDACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYTTGPLXDACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYTTGPLXDACO", obj.NGAYTTGPLXDACO);
                }
                if (obj.DONVIHOCLX == null || obj.DONVIHOCLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DONVIHOCLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DONVIHOCLX", obj.DONVIHOCLX);
                }
                //command.Parameters.AddWithValue("@NAMHOCLX" ,obj.NAMHOCLX);
                if (obj.NAMHOCLX == null || obj.NAMHOCLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NAMHOCLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NAMHOCLX", Int32.Parse(obj.NAMHOCLX));
                }
                if (obj.HANGGPLX == null || obj.HANGGPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HANGGPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HANGGPLX", obj.HANGGPLX);
                }
                //command.Parameters.AddWithValue("@SONAMLX" ,obj.SONAMLX);
                if (obj.SONAMLX == null || obj.SONAMLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SONAMLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SONAMLX", Int32.Parse(obj.SONAMLX));
                }
                //command.Parameters.AddWithValue("@SOKMLXANTOAN", obj.SOKMLXANTOAN);
                if (obj.SOKMLXANTOAN == null || obj.SOKMLXANTOAN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOKMLXANTOAN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOKMLXANTOAN", Int32.Parse(obj.SOKMLXANTOAN));
                }
                //command.Parameters.AddWithValue("@GIAYCNSK" ,obj.GIAYCNSK);
                if (obj.GIAYCNSK == null || obj.GIAYCNSK.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GIAYCNSK", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GIAYCNSK", Int32.Parse(obj.GIAYCNSK) != 0);
                }
                if (obj.LYDOCAPDOI == null || obj.LYDOCAPDOI.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@LYDOCAPDOI", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@LYDOCAPDOI", obj.LYDOCAPDOI);
                }
                if (obj.MUCDICHCAPDOI == null || obj.MUCDICHCAPDOI.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MUCDICHCAPDOI", "");
                }
                else
                {
                    command.Parameters.AddWithValue("@MUCDICHCAPDOI", obj.MUCDICHCAPDOI);
                }
                //command.Parameters.AddWithValue("@NOIDUNGSH" ,obj.NOIDUNGSH);
                if (obj.NOIDUNGSH == null || obj.NOIDUNGSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NOIDUNGSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NOIDUNGSH", Int32.Parse(obj.NOIDUNGSH));
                }
                //command.Parameters.AddWithValue("@MAKHOAHOC", obj.MAKHOAHOC);
                if (obj.MAKHOAHOC == null || obj.MAKHOAHOC.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAKHOAHOC", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAKHOAHOC", obj.MAKHOAHOC);
                }
                if (obj.HANGDAOTAO == null || obj.HANGDAOTAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@HANGDAOTAO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@HANGDAOTAO", obj.HANGDAOTAO);
                }
                if (obj.SOGIAYCNTN == null || obj.SOGIAYCNTN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOGIAYCNTN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOGIAYCNTN", obj.SOGIAYCNTN);
                }
                if (obj.SOCCN == null || obj.SOCCN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SoCCN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SoCCN", obj.SOCCN);
                }
                if (obj.MABC1 == null || obj.MABC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MABC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MABC1", obj.MABC1);
                }
                //command.Parameters.AddWithValue("@BC1_TUOITS", obj.BC1_TUOITS);
                if (obj.BC1_TUOITS == null || obj.BC1_TUOITS.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@BC1_TUOITS", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@BC1_TUOITS", Boolean.Parse(obj.BC1_TUOITS));
                }
                //command.Parameters.AddWithValue("@BC1_THAMNIEN", obj.BC1_THAMNIEN);
                if (obj.BC1_THAMNIEN == null || obj.BC1_THAMNIEN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@BC1_THAMNIEN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@BC1_THAMNIEN", Boolean.Parse(obj.BC1_THAMNIEN));
                }
                if (obj.MABC2 == null || obj.MABC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MABC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MABC2", obj.MABC2);
                }
                //command.Parameters.AddWithValue("@KETQUABC2", obj.KETQUABC2);
                if (obj.KETQUABC2 == null || obj.KETQUABC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUABC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUABC2", Boolean.Parse(obj.KETQUABC2));
                }
                //command.Parameters.AddWithValue("@MALYDOTCBC2", obj.MALYDOTCBC2);
                if (obj.MALYDOTCBC2 == null || obj.MALYDOTCBC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MALYDOTCBC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MALYDOTCBC2", Int32.Parse(obj.MALYDOTCBC2));
                }
                if (obj.MAKYSH == null || obj.MAKYSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAKYSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAKYSH", obj.MAKYSH);
                }
                if (obj.SOBD == null || obj.SOBD.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOBD", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOBD", obj.SOBD);
                }
                //command.Parameters.AddWithValue("@LANSH", obj.LANSH);
                if (obj.LANSH == null || obj.LANSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@LANSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@LANSH", Int32.Parse(obj.LANSH));
                }
                if (obj.SOQDSH == null || obj.SOQDSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOQDSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOQDSH", obj.SOQDSH);
                }
                //command.Parameters.AddWithValue("@NGAYQDSH", obj.NGAYQDSH);
                if (obj.LANSH == null || obj.NGAYQDSH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYQDSH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYQDSH", DateTime.Parse(obj.NGAYQDSH));
                }
                if (obj.KETQUA_LYTHUYET == null || obj.KETQUA_LYTHUYET.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUA_LYTHUYET", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUA_LYTHUYET", Int32.Parse(obj.KETQUA_LYTHUYET));
                }
                if (obj.NHANXET_LYTHUYET == null || obj.NHANXET_LYTHUYET.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NHANXET_LYTHUYET", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NHANXET_LYTHUYET", obj.NHANXET_LYTHUYET);
                }
                //command.Parameters.AddWithValue("@KETQUA_HINH" ,obj.KETQUA_HINH);
                if (obj.KETQUA_HINH == null || obj.KETQUA_HINH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUA_HINH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUA_HINH", Int32.Parse(obj.KETQUA_HINH));
                }
                if (obj.NHANXET_HINH == null || obj.NHANXET_HINH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NHANXET_HINH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NHANXET_HINH", obj.NHANXET_HINH);
                }
                //command.Parameters.AddWithValue("@KETQUA_DUONG", obj.KETQUA_DUONG);
                if (obj.KETQUA_DUONG == null || obj.KETQUA_DUONG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUA_DUONG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUA_DUONG", Int32.Parse(obj.KETQUA_DUONG));
                }
                if (obj.NHANXET_DUONG == null || obj.NHANXET_DUONG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NHANXET_DUONG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NHANXET_DUONG", obj.NHANXET_DUONG);
                }
                if (obj.KETQUASH == null || obj.KETQUASH.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUASH", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUASH", obj.KETQUASH);
                }
                if (obj.SOQDTT == null || obj.SOQDTT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOQDTT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOQDTT", obj.SOQDTT);
                }
                //command.Parameters.AddWithValue("@NGAYQDTT", obj.NGAYQDTT);
                if (obj.NGAYQDTT == null || obj.NGAYQDTT.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYQDTT", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYQDTT", DateTime.Parse(obj.NGAYQDTT));
                }

                if (obj.NGUOIKY == null || obj.NGUOIKY.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOIKY", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOIKY", obj.NGUOIKY);
                }
                if (obj.GHICHU == null || obj.GHICHU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GHICHU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GHICHU", obj.GHICHU);
                }
                if (obj.NGUOITAO == null || obj.NGUOITAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOITAO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOITAO", obj.NGUOITAO);
                }
                if (obj.NGUOISUA == null || obj.NGUOISUA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOISUA", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOISUA", obj.NGUOISUA);
                }
                //command.Parameters.AddWithValue("@NGAYTAO", obj.NGAYTAO);
                if (obj.NGAYTAO == null || obj.NGAYTAO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYTAO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYTAO", DateTime.Parse(obj.NGAYTAO));
                }
                //command.Parameters.AddWithValue("@NGAYSUA", obj.NGAYSUA);
                if (obj.NGAYSUA == null || obj.NGAYSUA.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYSUA", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYSUA", DateTime.Parse(obj.NGAYSUA));
                }
                if (obj.SOGPLXTMP == null || obj.SOGPLXTMP.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOGPLXTMP", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOGPLXTMP", obj.SOGPLXTMP);
                }
                //command.Parameters.AddWithValue("@NGAYKTBC1" ,obj.NGAYKTBC1);
                if (obj.NGAYKTBC1 == null || obj.NGAYKTBC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYKTBC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYKTBC1", DateTime.Parse(obj.NGAYKTBC1));
                }

                if (obj.NGUOIKTBC1 == null || obj.NGUOIKTBC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC1", obj.NGUOIKTBC1);
                }
                //command.Parameters.AddWithValue("@NGAYKTBC2", obj.NGAYKTBC2);
                if (obj.NGAYKTBC2 == null || obj.NGAYKTBC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGAYKTBC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGAYKTBC2", DateTime.Parse(obj.NGAYKTBC2));
                }
                if (obj.NGUOIKTBC2 == null || obj.NGUOIKTBC2.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC2", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NGUOIKTBC2", obj.NGUOIKTBC2);
                }
                if (obj.MAIN == null || obj.MAIN.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAIN", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAIN", obj.MAIN);
                }
                //command.Parameters.AddWithValue("@KETQUADOISANHTW", obj.KETQUADOISANHTW);
                if (obj.KETQUADOISANHTW == null || obj.KETQUADOISANHTW.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KETQUADOISANHTW", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KETQUADOISANHTW", Boolean.Parse(obj.KETQUADOISANHTW));
                }
                if (obj.GHICHUKQDSTW == null || obj.GHICHUKQDSTW.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@GHICHUKQDSTW", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@GHICHUKQDSTW", obj.GHICHUKQDSTW);
                }
                if (obj.CHUKY == null || obj.CHUKY.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@CHUKY", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@CHUKY", obj.CHUKY);
                }
                //command.Parameters.AddWithValue("@TRANGTHAI", obj.TRANGTHAI);
                if (obj.TRANGTHAI == null || obj.TRANGTHAI.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TRANGTHAI", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TRANGTHAI", Int32.Parse(obj.TRANGTHAI) != 0);
                }
                if (obj.MAHTCAP == null || obj.MAHTCAP.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MAHTCAP", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MAHTCAP", obj.MAHTCAP);
                }
                //command.Parameters.AddWithValue("@IDS" ,obj.IDS);
                if (obj.TT_XULY_OLD == null || obj.TT_XULY_OLD.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TT_XULY_OLD", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TT_XULY_OLD", obj.TT_XULY_OLD);
                }
                //command.Parameters.AddWithValue("@KQ_BC1", obj.KQ_BC1);
                if (obj.KQ_BC1 == null || obj.KQ_BC1.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KQ_BC1", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KQ_BC1", Boolean.Parse(obj.KQ_BC1));
                }
                if (obj.KQ_BC1_GHICHU == null || obj.KQ_BC1_GHICHU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@KQ_BC1_GHICHU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@KQ_BC1_GHICHU", obj.KQ_BC1_GHICHU);
                }
                //command.Parameters.AddWithValue("@TRANSFER_FLAG", obj.TRANSFER_FLAG);
                if (obj.TRANSFER_FLAG == null || obj.TRANSFER_FLAG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@TRANSFER_FLAG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@TRANSFER_FLAG", Int32.Parse(obj.TRANSFER_FLAG));
                }
                if (obj.NAMCAPLANDAU == null || obj.NAMCAPLANDAU.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@NAMCAPLANDAU", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@NAMCAPLANDAU", obj.NAMCAPLANDAU);
                }
                if (obj.MATRICHNGANG == null || obj.MATRICHNGANG.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@MATRICHNGANG", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@MATRICHNGANG", obj.MATRICHNGANG);
                }
                if (obj.DIACHITRENGPLX == null || obj.DIACHITRENGPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX", obj.DIACHITRENGPLX);
                }
                if (obj.COQUANQUANLYGPLX == null || obj.COQUANQUANLYGPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@COQUANQUANLYGPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@COQUANQUANLYGPLX", obj.COQUANQUANLYGPLX);
                }
                if (obj.DIACHITRENGPLX_CHITIET == null || obj.DIACHITRENGPLX_CHITIET.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX_CHITIET", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DIACHITRENGPLX_CHITIET", obj.DIACHITRENGPLX_CHITIET);
                }
                //command.Parameters.AddWithValue("@IN_GPLX", obj.IN_GPLX);
                if (obj.IN_GPLX == null || obj.IN_GPLX.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@IN_GPLX", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@IN_GPLX", Int32.Parse(obj.IN_GPLX));
                }
                if (obj.SOSERI_GPLX_DACO == null || obj.SOSERI_GPLX_DACO.Trim().Length <= 0)
                {
                    command.Parameters.AddWithValue("@SOSERI_GPLX_DACO", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@SOSERI_GPLX_DACO", obj.SOSERI_GPLX_DACO);
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

        //Update trang thai
        public static String updateStatusList(List<NGUOI_LX> listData,String status)
        {
            Int32 rtn = 0;

            if (listData == null || listData.Count <= 0)
            {
                return "";
            }

            SqlConnection connection = Ultils.GetDBConnection();
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction("updateStatus");

                List<List<NGUOI_LX>> listTmp = Ultils.splitList(listData, 300).ToList();

                int update = 0;
                for (int i = 0; i < listTmp.Count; i++)
                {
                    if (listTmp.Count > 0)
                    {
                        update = updateStatus(connection, transaction,listTmp[i], status);
                        if (update <= 0)
                        {
                            throw new Exception("Update không thành công!");
                        }
                        rtn += update;
                    }
                }
                // Attempt to commit the transaction.
                transaction.Commit();
                return rtn.ToString();
            }
            catch(Exception ex)
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

        private static Int32 updateStatus(SqlConnection connection, SqlTransaction transaction, List<NGUOI_LX> listData, String status)
        {
            if (listData == null || listData.Count <= 0)
            {
                return 0;
            }
            try
            {
                //Tao SQL
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE [dbo].[NguoiLX_HoSo] SET TT_Xuly=@status WHERE MADK IN (");
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
                SqlCommand command = new SqlCommand(sb.ToString(), connection);
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.AddWithValue("@status", status);
                //Set param
                i = 1;
                foreach (NGUOI_LX user in listData)
                {
                    // parameter
                    command.Parameters.AddWithValue("@MADK" + i.ToString(), user.MADK);
                    i++;
                }
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("updateStatus Loi: " + ex.Message);
                return -1;
                throw ex;
            }
        }

    }
}
