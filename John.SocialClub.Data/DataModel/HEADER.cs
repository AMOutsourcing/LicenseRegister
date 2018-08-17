using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GPLX.Data.DataModel
{
    public class HEADER
    {
        public String MA_GIAO_DICH { get; set; }
        public String MA_DV_GUI { get; set; }
        public String TEN_DV_GUI { get; set; }
        public String NGAY_GUI { get; set; }
        public String NGUOI_GUI { get; set; }
        public String TONG_SO_BAN_GHI { get; set; }

        public BODY BODY { get; set; }

        //[XmlElement("BODY")]
        //public List<NGUOI_LX> ListNguoiLx { get; set; }
    }
}
