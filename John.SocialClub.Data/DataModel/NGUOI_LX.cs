using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace John.SocialClub.Data.DataModel
{
    public class NGUOI_LX
    {
        [XmlIgnore]
        public Int32 STT { get; set; }
        public String MADK { get; set; }
        public String DV_NHAN_HS { get; set; }
        public String HO_DEM_NLX { get; set; }
        public String TEN_NLX { get; set; }
        public String HO_VA_TEN { get; set; }
        public String MA_QUOC_TICH { get; set; }
        public String NGAY_SINH { get; set; }
        public String NOI_TT { get; set; }
        public String NOI_TT_MA_DVHC { get; set; }
        public String NOI_TT_MA_DVQL { get; set; }
        public String NOI_CT { get; set; }
        public String NOI_CT_MA_DVHC { get; set; }
        public String NOI_CT_MA_DVQL { get; set; }
        public String SO_CMT { get; set; }
        public String NGAY_CAP_CMT { get; set; }
        public String NOI_CAP_CMT { get; set; }
        public String GHI_CHU { get; set; }
        public Int32? TRANG_THAI { get; set; }
        public String NGUOI_TAO { get; set; }
        public String NGUOI_SUA { get; set; }
        public String NGAY_TAO { get; set; }
        public String NGAY_SUA { get; set; }
        public String GIOI_TINH { get; set; }
        public String HO_VA_TEN_IN { get; set; }
        public String SO_CMND_CU { get; set; }

        //public XmlSchema GetSchema()
        //{
        //    throw new NotImplementedException();
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    string attr1 = reader.GetAttribute("NGAY_CAP_CMT");
        //    string attr2 = reader.GetAttribute("TRANG_THAI");
        //    string attr3 = reader.GetAttribute("NGAY_TAO");
        //    string attr4 = reader.GetAttribute("NGAY_SUA");
        //    MADK = reader.GetAttribute("MADK");

        //    while (reader.Read())
        //    {
        //        switch (reader.NodeType)
        //        {
        //            case XmlNodeType.Element: // The node is an element.
        //                Console.Write("<" + reader.Name);
        //                Console.WriteLine(">");
        //                break;
        //            case XmlNodeType.Text: //Display the text in each element.
        //                Console.WriteLine(reader.Value);
        //                break;
        //            case XmlNodeType.EndElement: //Display the end of the element.
        //                Console.Write("</" + reader.Name);
        //                Console.WriteLine(">");
        //                break;
        //        }
        //    }

        //    NGAY_CAP_CMT = ConvertToNullable<DateTime>(attr1);
        //    TRANG_THAI = ConvertToNullable<Boolean>(attr2);
        //    NGAY_TAO = ConvertToNullable<DateTime>(attr3);
        //    NGAY_SUA = ConvertToNullable<DateTime>(attr4);
        //}

        private static T? ConvertToNullable<T>(string inputValue) where T : struct
        {
            if (string.IsNullOrEmpty(inputValue) || inputValue.Trim().Length == 0)
            {
                return null;
            }

            try
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                return (T)conv.ConvertFrom(inputValue);
            }
            catch (NotSupportedException)
            {
                // The conversion cannot be performed
                return null;
            }
        }

        //public void WriteXml(XmlWriter writer)
        //{
        //    writer.WriteElementString("MADK", this.MADK.ToString());
        //    writer.WriteElementString("DV_NHAN_HS", this.DV_NHAN_HS.ToString());
        //    writer.WriteElementString("HO_DEM_NLX", this.HO_DEM_NLX.ToString());
        //    writer.WriteElementString("TEN_NLX", this.TEN_NLX.ToString());
        //    writer.WriteElementString("HO_VA_TEN", this.HO_VA_TEN.ToString());
        //    writer.WriteElementString("MA_QUOC_TICH", this.MA_QUOC_TICH.ToString());
        //    writer.WriteElementString("NGAY_SINH", this.NGAY_SINH.ToString());
        //    writer.WriteElementString("NOI_TT", this.NOI_TT.ToString());
        //    writer.WriteElementString("NOI_TT_MA_DVHC", this.NOI_TT_MA_DVHC.ToString());
        //    writer.WriteElementString("NOI_CT", this.NOI_CT.ToString());
        //    writer.WriteElementString("NOI_CT_MA_DVHC", this.NOI_CT_MA_DVHC.ToString());
        //    writer.WriteElementString("NOI_CT_MA_DVQL", this.NOI_CT_MA_DVQL.ToString());
        //    writer.WriteElementString("SO_CMT", this.SO_CMT.ToString());
        //    writer.WriteElementString("NGAY_CAP_CMT", this.NGAY_CAP_CMT.ToString());
        //    writer.WriteElementString("NOI_CAP_CMT", this.NOI_CAP_CMT.ToString());
        //    writer.WriteElementString("GHI_CHU", this.GHI_CHU.ToString());
        //    writer.WriteElementString("TRANG_THAI", this.TRANG_THAI.ToString());
        //    writer.WriteElementString("NGUOI_TAO", this.NGUOI_TAO.ToString());
        //    writer.WriteElementString("NGUOI_SUA", this.NGUOI_SUA.ToString());
        //    writer.WriteElementString("NGAY_TAO", this.NGAY_TAO.ToString());
        //    writer.WriteElementString("NGAY_SUA", this.NGAY_SUA.ToString());
        //    writer.WriteElementString("GIOI_TINH", this.GIOI_TINH.ToString());
        //    writer.WriteElementString("HO_VA_TEN_IN", this.HO_VA_TEN_IN.ToString());
        //    writer.WriteElementString("SO_CMND_CU", this.SO_CMND_CU.ToString());
        //}
    }
}
