using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace John.SocialClub.Data.DataModel
{
    public class NGUOILX_HOSO_DB
    {
        public String MADK { get; set; }
        public String SOHOSO { get; set; }
        public String MACSDT { get; set; }
        public String MASOGTVT { get; set; }
        public String MADVNHANHSO { get; set; }
        public DateTime? NGAYNHANHSO { get; set; }
        public String NGUOINHANHSO { get; set; }
        public DateTime? NGAYHENTRA { get; set; }
        public Int32? MALOAIHS { get; set; }
        public String TT_XULY { get; set; }
        public String DUONGDANANH { get; set; }
        public Int32? CHATLUONGANH { get; set; }
        public DateTime? NGAYTHUNHANANH { get; set; }
        public String NGUOITHUNHANANH { get; set; }
        public String SOGPLXDACO { get; set; }
        public String HANGGPLXDACO { get; set; }
        public String DONVICAPGPLXDACO { get; set; }
        public String NOICAPGPLXDACO { get; set; }
        public String NGAYCAPGPLXDACO { get; set; }
        public String NGAYHHGPLXDACO { get; set; }
        public String NGAYTTGPLXDACO { get; set; }
        public String DONVIHOCLX { get; set; }
        public Int32? NAMHOCLX { get; set; }
        public String HANGGPLX { get; set; }
        public Int32? SONAMLX { get; set; }
        public Int32? SOKMLXANTOAN { get; set; }
        public Boolean? GIAYCNSK { get; set; }
        public String LYDOCAPDOI { get; set; }
        public String MUCDICHCAPDOI { get; set; }
        public Int32? NOIDUNGSH { get; set; }
        public String MAKHOAHOC { get; set; }
        public String HANGDAOTAO { get; set; }
        public String SOGIAYCNTN { get; set; }
        public String SoCCN { get; set; }
        public String MABC1 { get; set; }
        public Boolean? BC1_TUOITS { get; set; }
        public Boolean? BC1_THAMNIEN { get; set; }
        public String MABC2 { get; set; }
        public Boolean? KETQUABC2 { get; set; }
        public Int32? MALYDOTCBC2 { get; set; }
        public String MAKYSH { get; set; }
        public String SOBD { get; set; }
        public Int32? LANSH { get; set; }
        public String SOQDSH { get; set; }
        public DateTime? NGAYQDSH { get; set; }
        public Int32? KETQUA_LYTHUYET { get; set; }
        public String NHANXET_LYTHUYET { get; set; }
        public Int32? KETQUA_HINH { get; set; }
        public String NHANXET_HINH { get; set; }
        public Int32? KETQUA_DUONG { get; set; }
        public String NHANXET_DUONG { get; set; }
        public String KETQUASH { get; set; }
        public String SOQDTT { get; set; }
        public DateTime? NGAYQDTT { get; set; }
        public String NGUOIKY { get; set; }
        public String GHICHU { get; set; }
        public String NGUOITAO { get; set; }
        public String NGUOISUA { get; set; }
        public DateTime? NGAYTAO { get; set; }
        public DateTime? NGAYSUA { get; set; }
        public String SOGPLXTMP { get; set; }
        public DateTime? NGAYKTBC1 { get; set; }
        public String NGUOIKTBC1 { get; set; }
        public DateTime? NGAYKTBC2 { get; set; }
        public String NGUOIKTBC2 { get; set; }
        public String MAIN { get; set; }
        public Boolean? KETQUADOISANHTW { get; set; }
        public String GHICHUKQDSTW { get; set; }
        public String CHUKY { get; set; }
        public Boolean? TRANGTHAI { get; set; }
        public String MAHTCAP { get; set; }
        public long? IDS { get; set; }
        public String TT_XULY_OLD { get; set; }
        
        public Boolean? KQ_BC1 { get; set; }
        public String KQ_BC1_GHICHU { get; set; }
        
        public Int32? TRANSFER_FLAG { get; set; }
        public String NAMCAPLANDAU { get; set; }
        public String MATRICHNGANG { get; set; }
        public String DIACHITRENGPLX { get; set; }
        public String COQUANQUANLYGPLX { get; set; }
        public String DIACHITRENGPLX_CHITIET { get; set; }
        
        public Int32? IN_GPLX { get; set; }
        public String SOSERI_GPLX_DACO { get; set; }



        public static NGUOILX_HOSO_DB copyData(NGUOILX_HOSO data)
        {
            NGUOILX_HOSO_DB obj = new NGUOILX_HOSO_DB();
            obj.MADK = Ultils.NullValue(data.MADK);
            obj.SOHOSO = Ultils.NullValue(data.SOHOSO);
            obj.MACSDT = Ultils.NullValue(data.MACSDT);
            obj.MASOGTVT = Ultils.NullValue(data.MASOGTVT);
            obj.MADVNHANHSO = Ultils.NullValue(data.MADVNHANHSO);
            obj.NGAYNHANHSO = Ultils.NullValueDate(data.NGAYNHANHSO);
            obj.NGAYHENTRA = Ultils.NullValueDate(data.NGAYHENTRA);
            obj.MALOAIHS = Ultils.NullValueInt(data.MALOAIHS);

            obj.TT_XULY = Ultils.NullValue(data.TT_XULY);
            obj.DUONGDANANH = Ultils.NullValue(data.DUONGDANANH);
            obj.CHATLUONGANH = Ultils.NullValueInt(data.CHATLUONGANH);

            obj.NGAYTHUNHANANH = Ultils.NullValueDate(data.NGAYTHUNHANANH);
            obj.NGUOITHUNHANANH = Ultils.NullValue(data.NGUOITHUNHANANH);
            obj.SOGPLXDACO = Ultils.NullValue(data.SOGPLXDACO);
            obj.HANGGPLXDACO = Ultils.NullValue(data.HANGGPLXDACO);
            obj.DONVICAPGPLXDACO = Ultils.NullValue(data.DONVICAPGPLXDACO);
            obj.NOICAPGPLXDACO = Ultils.NullValue(data.NOICAPGPLXDACO);
            obj.NGAYCAPGPLXDACO = Ultils.NullValue(data.NGAYCAPGPLXDACO);
            obj.NGAYHHGPLXDACO = Ultils.NullValue(data.NGAYHHGPLXDACO);
            obj.NGAYTTGPLXDACO = Ultils.NullValue(data.NGAYTTGPLXDACO);
            obj.DONVIHOCLX = Ultils.NullValue(data.DONVIHOCLX);

            obj.NAMHOCLX = Ultils.NullValueInt(data.NAMHOCLX);
            obj.HANGGPLX = Ultils.NullValue(data.HANGGPLX);
            obj.SONAMLX = Ultils.NullValueInt(data.SONAMLX);
            obj.SOKMLXANTOAN = Ultils.NullValueInt(data.SOKMLXANTOAN);

            obj.GIAYCNSK = Ultils.NullValueBool(data.GIAYCNSK);
            obj.LYDOCAPDOI = Ultils.NullValue(data.LYDOCAPDOI);
            obj.MUCDICHCAPDOI = Ultils.NullValue(data.MUCDICHCAPDOI);
            obj.NOIDUNGSH = Ultils.NullValueInt(data.NOIDUNGSH);

            obj.MAKHOAHOC = Ultils.NullValue(data.MAKHOAHOC);
            obj.HANGDAOTAO = Ultils.NullValue(data.HANGDAOTAO);
            obj.SOGIAYCNTN = Ultils.NullValue(data.SOGIAYCNTN);
            obj.SoCCN = Ultils.NullValue(data.SOCCN);
            obj.MABC1 = Ultils.NullValue(data.MABC1);
            obj.BC1_TUOITS = Ultils.NullValueBool(data.BC1_TUOITS);
            obj.BC1_THAMNIEN = Ultils.NullValueBool(data.BC1_THAMNIEN);
            obj.MABC2 = Ultils.NullValue(data.MABC2);
            obj.KETQUABC2 = Ultils.NullValueBool(data.KETQUABC2);
            obj.MALYDOTCBC2 = Ultils.NullValueInt(data.MALYDOTCBC2);

            obj.MAKYSH = Ultils.NullValue(data.MAKYSH);
            obj.SOBD = Ultils.NullValue(data.SOBD);
            obj.LANSH = Ultils.NullValueInt(data.LANSH);

            obj.SOQDSH = Ultils.NullValue(data.SOQDSH);
            obj.NGAYQDSH = Ultils.NullValueDate(data.NGAYQDSH);
            obj.KETQUA_LYTHUYET = Ultils.NullValueInt(data.KETQUA_LYTHUYET);
            obj.NHANXET_LYTHUYET = Ultils.NullValue(data.NHANXET_LYTHUYET);
            obj.KETQUA_HINH = Ultils.NullValueInt(data.KETQUA_HINH);
            obj.NHANXET_HINH = Ultils.NullValue(data.NHANXET_HINH);
            obj.KETQUA_DUONG = Ultils.NullValueInt(data.KETQUA_DUONG);
            obj.NHANXET_DUONG = Ultils.NullValue(data.NHANXET_DUONG);
            obj.KETQUASH = Ultils.NullValue(data.KETQUASH);
            obj.SOQDTT = Ultils.NullValue(data.SOQDTT);
            obj.NGAYQDTT = Ultils.NullValueDate(data.NGAYQDTT);
            obj.NGUOIKY = Ultils.NullValue(data.NGUOIKY);
            obj.GHICHU = Ultils.NullValue(data.GHICHU);
            obj.NGUOITAO = Ultils.NullValue(data.NGUOITAO);
            obj.NGUOISUA = Ultils.NullValue(data.NGUOISUA);
            obj.NGAYTAO = Ultils.NullValueDate(data.NGAYTAO);
            obj.NGAYSUA = Ultils.NullValueDate(data.NGAYSUA);
            obj.SOGPLXTMP = Ultils.NullValue(data.SOGPLXTMP);
            obj.NGAYKTBC1 = Ultils.NullValueDate(data.NGAYKTBC1);
            obj.NGUOIKTBC1 = Ultils.NullValue(data.NGUOIKTBC1);
            obj.NGAYKTBC2 = Ultils.NullValueDate(data.NGAYKTBC2);
            obj.NGUOIKTBC2 = Ultils.NullValue(data.NGUOIKTBC2);
            obj.MAIN = Ultils.NullValue(data.MAIN);
            obj.KETQUADOISANHTW = Ultils.NullValueBool(data.KETQUADOISANHTW);
            obj.GHICHUKQDSTW = Ultils.NullValue(data.GHICHUKQDSTW);
            obj.CHUKY = Ultils.NullValue(data.CHUKY);
            obj.TRANGTHAI = Ultils.NullValueBool(data.TRANGTHAI);
            obj.MAHTCAP = Ultils.NullValue(data.MAHTCAP);
            if(data.IDS == null)
            {
                obj.IDS = null;
            }
            else
            {
                obj.IDS = Int64.Parse(data.IDS.ToString());
            }
            
            obj.TT_XULY_OLD = Ultils.NullValue(data.TT_XULY_OLD);
            obj.KQ_BC1 = Ultils.NullValueBool(data.KQ_BC1);
            obj.KQ_BC1_GHICHU = Ultils.NullValue(data.KQ_BC1_GHICHU);
            obj.TRANSFER_FLAG = Ultils.NullValueInt(data.TRANSFER_FLAG);
            obj.NAMCAPLANDAU = Ultils.NullValue(data.NAMCAPLANDAU);
            obj.MATRICHNGANG = Ultils.NullValue(data.MATRICHNGANG);
            obj.DIACHITRENGPLX = Ultils.NullValue(data.DIACHITRENGPLX);
            obj.COQUANQUANLYGPLX = Ultils.NullValue(data.COQUANQUANLYGPLX);
            obj.DIACHITRENGPLX_CHITIET = Ultils.NullValue(data.DIACHITRENGPLX_CHITIET);
            obj.IN_GPLX = Ultils.NullValueInt(data.IN_GPLX);
            obj.SOSERI_GPLX_DACO = Ultils.NullValue(data.SOSERI_GPLX_DACO);
            
            return obj;
        }
    }
}
