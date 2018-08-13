using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace John.SocialClub.Data.DataModel
{
    public class BODY
    {
        [XmlElement("NGUOI_LX")]
        public List<NGUOI_LX> ListNguoiLx = new List<NGUOI_LX>();
        
        [XmlElement("NGUOILX_HOSO")]
        public List<NGUOILX_HOSO> ListNguoiLxHs = new List<NGUOILX_HOSO>();
        
        [XmlElement("GIAY_TO")]
        public List<GIAY_TO> ListGiayTo = new List<GIAY_TO>();
    }
}
