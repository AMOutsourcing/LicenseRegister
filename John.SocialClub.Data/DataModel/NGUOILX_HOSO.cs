using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GPLX.Data.DataModel
{
    public class NGUOILX_HOSO
    {
        public static String TT_CHUAKETXUAT = "03";
        public static String TT_DAKETXUAT = "04";
        public String MADK { get; set; }
        public String SOHOSO { get; set; }
        public String MACSDT { get; set; }
        public String MASOGTVT { get; set; }
        public String MADVNHANHSO { get; set; }
        
        public String NGAYNHANHSO { get; set; }

        public String NGUOINHANHSO { get; set; }
        
        public String NGAYHENTRA { get; set; }
        
        public String MALOAIHS { get; set; }
        public String TT_XULY { get; set; }
        public String DUONGDANANH { get; set; }
        
        public String CHATLUONGANH { get; set; }
        
        public String NGAYTHUNHANANH { get; set; }
        public String NGUOITHUNHANANH { get; set; }
        public String SOGPLXDACO { get; set; }
        public String HANGGPLXDACO { get; set; }
        public String DONVICAPGPLXDACO { get; set; }
        public String NOICAPGPLXDACO { get; set; }
        public String NGAYCAPGPLXDACO { get; set; }
        public String NGAYHHGPLXDACO { get; set; }
        public String NGAYTTGPLXDACO { get; set; }
        public String DONVIHOCLX { get; set; }
        
        public String NAMHOCLX { get; set; }
        public String HANGGPLX { get; set; }
        
        public String SONAMLX { get; set; }
        
        public String SOKMLXANTOAN { get; set; }
        
        public String GIAYCNSK { get; set; }
        public String LYDOCAPDOI { get; set; }
        public String MUCDICHCAPDOI { get; set; }
        
        public String NOIDUNGSH { get; set; }
        public String MAKHOAHOC { get; set; }
        public String HANGDAOTAO { get; set; }
        public String SOGIAYCNTN { get; set; }
        public String SOCCN { get; set; }
        public String MABC1 { get; set; }
        
        public String BC1_TUOITS { get; set; }
        
        public String BC1_THAMNIEN { get; set; }
        public String MABC2 { get; set; }
        
        public String KETQUABC2 { get; set; }
        
        public String MALYDOTCBC2 { get; set; }
        public String MAKYSH { get; set; }
        public String SOBD { get; set; }
        
        public String LANSH { get; set; }
        public String SOQDSH { get; set; }
        
        public String NGAYQDSH { get; set; }
        public String KETQUA_LYTHUYET { get; set; }
        public String NHANXET_LYTHUYET { get; set; }
        
        public String KETQUA_HINH { get; set; }
        public String NHANXET_HINH { get; set; }
        
        public String KETQUA_DUONG { get; set; }
        public String NHANXET_DUONG { get; set; }
        public String KETQUASH { get; set; }
        public String SOQDTT { get; set; }
        
        public String NGAYQDTT { get; set; }
        public String NGUOIKY { get; set; }
        public String GHICHU { get; set; }
        public String NGUOITAO { get; set; }
        public String NGUOISUA { get; set; }
        
        public String NGAYTAO { get; set; }
        
        public String NGAYSUA { get; set; }
        public String SOGPLXTMP { get; set; }
        
        public String NGAYKTBC1 { get; set; }
        public String NGUOIKTBC1 { get; set; }
        
        public String NGAYKTBC2 { get; set; }
        public String NGUOIKTBC2 { get; set; }
        public String MAIN { get; set; }
        
        public String KETQUADOISANHTW { get; set; }
        public String GHICHUKQDSTW { get; set; }
        public String CHUKY { get; set; }
        
        public String TRANGTHAI { get; set; }
        public String MAHTCAP { get; set; }
        
        public long? IDS { get; set; }
        public String TT_XULY_OLD { get; set; }
        
        public String KQ_BC1 { get; set; }
        public String KQ_BC1_GHICHU { get; set; }
        
        public String TRANSFER_FLAG { get; set; }
        public String NAMCAPLANDAU { get; set; }
        public String MATRICHNGANG { get; set; }
        public String DIACHITRENGPLX { get; set; }
        public String COQUANQUANLYGPLX { get; set; }
        public String DIACHITRENGPLX_CHITIET { get; set; }
        
        public String IN_GPLX { get; set; }
        public String SOSERI_GPLX_DACO { get; set; }

        public void encodeImg()
        {
            if(DUONGDANANH != null && DUONGDANANH.Length > 0)
            {
                //Ma hoa base 64 anh
                //DUONGDANANH = Ultils.encodeJp2("@\"" + DUONGDANANH + "\"");
                DUONGDANANH = Ultils.encodeJp2(DUONGDANANH);
                //DUONGDANANH = Ultils.encodeJp2(@"F:\Project\CSharp\LicenseRegister\img\063-20180727-173357.jp2");
            }
        }
        public void writerXml(XmlWriter writer)
        {
            writer.WriteStartElement("NGUOILX_HOSO");
            writer.WriteElementString("MADK", this.MADK.ToString());
            writer.WriteElementString("SOHOSO", this.SOHOSO.ToString());
            writer.WriteElementString("MACSDT", this.MACSDT.ToString());
            writer.WriteElementString("MASOGTVT", this.MASOGTVT.ToString());
            writer.WriteElementString("MADVNHANHSO", this.MADVNHANHSO.ToString());
            writer.WriteElementString("NGAYNHANHSO", this.NGAYNHANHSO.ToString());
            writer.WriteElementString("NGUOINHANHSO", this.NGUOINHANHSO.ToString());
            writer.WriteElementString("NGAYHENTRA", this.NGAYHENTRA.ToString());
            writer.WriteElementString("MALOAIHS", this.MALOAIHS.ToString());
            writer.WriteElementString("TT_XULY", this.TT_XULY.ToString());
            writer.WriteElementString("DUONGDANANH", this.DUONGDANANH.ToString());
            writer.WriteElementString("CHATLUONGANH", this.CHATLUONGANH.ToString());
            writer.WriteElementString("NGAYTHUNHANANH", this.NGAYTHUNHANANH.ToString());
            writer.WriteElementString("NGUOITHUNHANANH", this.NGUOITHUNHANANH.ToString());
            writer.WriteElementString("SOGPLXDACO", this.SOGPLXDACO.ToString());
            writer.WriteElementString("HANGGPLXDACO", this.HANGGPLXDACO.ToString());
            writer.WriteElementString("DONVICAPGPLXDACO", this.DONVICAPGPLXDACO.ToString());
            writer.WriteElementString("NOICAPGPLXDACO", this.NOICAPGPLXDACO.ToString());
            writer.WriteElementString("NGAYCAPGPLXDACO", this.NGAYCAPGPLXDACO.ToString());
            writer.WriteElementString("NGAYHHGPLXDACO", this.NGAYHHGPLXDACO.ToString());
            writer.WriteElementString("NGAYTTGPLXDACO", this.NGAYTTGPLXDACO.ToString());
            writer.WriteElementString("DONVIHOCLX", this.DONVIHOCLX.ToString());
            writer.WriteElementString("NAMHOCLX", this.NAMHOCLX.ToString());
            writer.WriteElementString("HANGGPLX", this.HANGGPLX.ToString());
            writer.WriteElementString("SONAMLX", this.SONAMLX.ToString());
            writer.WriteElementString("SOKMLXANTOAN", this.SOKMLXANTOAN.ToString());
            writer.WriteElementString("GIAYCNSK", this.GIAYCNSK.ToString());
            writer.WriteElementString("LYDOCAPDOI", this.LYDOCAPDOI.ToString());
            writer.WriteElementString("MUCDICHCAPDOI", this.MUCDICHCAPDOI.ToString());
            writer.WriteElementString("NOIDUNGSH", this.NOIDUNGSH.ToString());
            writer.WriteElementString("MAKHOAHOC", this.MAKHOAHOC.ToString());
            writer.WriteElementString("HANGDAOTAO", this.HANGDAOTAO.ToString());
            writer.WriteElementString("SOGIAYCNTN", this.SOGIAYCNTN.ToString());
            writer.WriteElementString("SOCCN", this.SOCCN.ToString());
            writer.WriteElementString("MABC1", this.MABC1.ToString());
            writer.WriteElementString("BC1_TUOITS", this.BC1_TUOITS.ToString());
            writer.WriteElementString("BC1_THAMNIEN", this.BC1_THAMNIEN.ToString());
            writer.WriteElementString("MABC2", this.MABC2.ToString());
            writer.WriteElementString("KETQUABC2", this.KETQUABC2.ToString());
            writer.WriteElementString("MALYDOTCBC2", this.MALYDOTCBC2.ToString());
            writer.WriteElementString("MAKYSH", this.MAKYSH.ToString());
            writer.WriteElementString("SOBD", this.SOBD.ToString());
            writer.WriteElementString("LANSH", this.LANSH.ToString());
            writer.WriteElementString("SOQDSH", this.SOQDSH.ToString());
            writer.WriteElementString("NGAYQDSH", this.NGAYQDSH.ToString());
            writer.WriteElementString("KETQUA_LYTHUYET", this.KETQUA_LYTHUYET.ToString());
            writer.WriteElementString("NHANXET_LYTHUYET", this.NHANXET_LYTHUYET.ToString());
            writer.WriteElementString("KETQUA_HINH", this.KETQUA_HINH.ToString());
            writer.WriteElementString("NHANXET_HINH", this.NHANXET_HINH.ToString());
            writer.WriteElementString("KETQUA_DUONG", this.KETQUA_DUONG.ToString());
            writer.WriteElementString("NHANXET_DUONG", this.NHANXET_DUONG.ToString());
            writer.WriteElementString("KETQUASH", this.KETQUASH.ToString());
            writer.WriteElementString("SOQDTT", this.SOQDTT.ToString());
            writer.WriteElementString("NGAYQDTT", this.NGAYQDTT.ToString());
            writer.WriteElementString("NGUOIKY", this.NGUOIKY.ToString());
            writer.WriteElementString("GHICHU", this.GHICHU.ToString());
            writer.WriteElementString("NGUOITAO", this.NGUOITAO.ToString());
            writer.WriteElementString("NGUOISUA", this.NGUOISUA.ToString());
            writer.WriteElementString("NGAYTAO", this.NGAYTAO.ToString());
            writer.WriteElementString("NGAYSUA", this.NGAYSUA.ToString());
            writer.WriteElementString("SOGPLXTMP", this.SOGPLXTMP.ToString());
            writer.WriteElementString("NGAYKTBC1", this.NGAYKTBC1.ToString());
            writer.WriteElementString("NGUOIKTBC1", this.NGUOIKTBC1.ToString());
            writer.WriteElementString("NGAYKTBC2", this.NGAYKTBC2.ToString());
            writer.WriteElementString("NGUOIKTBC2", this.NGUOIKTBC2.ToString());
            writer.WriteElementString("MAIN", this.MAIN.ToString());
            writer.WriteElementString("KETQUADOISANHTW", this.KETQUADOISANHTW.ToString());
            writer.WriteElementString("GHICHUKQDSTW", this.GHICHUKQDSTW.ToString());
            writer.WriteElementString("CHUKY", this.CHUKY.ToString());
            writer.WriteElementString("TRANGTHAI", this.TRANGTHAI.ToString());
            writer.WriteElementString("MAHTCAP", this.MAHTCAP.ToString());
            writer.WriteElementString("IDS", this.IDS.ToString());
            writer.WriteElementString("TT_XULY_OLD", this.TT_XULY_OLD.ToString());
            writer.WriteElementString("KQ_BC1", this.KQ_BC1.ToString());
            writer.WriteElementString("KQ_BC1_GHICHU", this.KQ_BC1_GHICHU.ToString());
            writer.WriteElementString("TRANSFER_FLAG", this.TRANSFER_FLAG.ToString());
            writer.WriteElementString("NAMCAPLANDAU", this.NAMCAPLANDAU.ToString());
            writer.WriteElementString("MATRICHNGANG", this.MATRICHNGANG.ToString());
            writer.WriteElementString("DIACHITRENGPLX", this.DIACHITRENGPLX.ToString());
            writer.WriteElementString("COQUANQUANLYGPLX", this.COQUANQUANLYGPLX.ToString());
            writer.WriteElementString("DIACHITRENGPLX_CHITIET", this.DIACHITRENGPLX_CHITIET.ToString());
            writer.WriteElementString("IN_GPLX", this.IN_GPLX.ToString());
            writer.WriteElementString("SOSERI_GPLX_DACO", this.SOSERI_GPLX_DACO.ToString());
            writer.WriteEndElement();
        }
    }
}
