using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace John.SocialClub.Data.DataModel
{
    [XmlRoot("BODY")]
    [XmlInclude(typeof(NGUOI_LX))]
    [XmlInclude(typeof(NGUOILX_HOSO))]
    [XmlInclude(typeof(GIAY_TO))]
    public class BODY
    {
        [XmlArray("")]
        [XmlArrayItem("NGUOI_LX")]
        public List<NGUOI_LX> ListNguoiLx = new List<NGUOI_LX>();

        [XmlArray("")]
        [XmlArrayItem("NGUOILX_HOSO")]
        public List<NGUOILX_HOSO> ListNguoiLxHs = new List<NGUOILX_HOSO>();

        [XmlArray("")]
        [XmlArrayItem("GIAY_TO")]
        public List<GIAY_TO> ListGiayTo = new List<GIAY_TO>();
    }
}
