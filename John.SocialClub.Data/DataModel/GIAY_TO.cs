using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace John.SocialClub.Data.DataModel
{
    public class GIAY_TO
    {
        public String MADK { get; set; }
        public String MAGT { get; set; }
        public String SOHOSO { get; set; }
        public String TEN_NLX { get; set; }
        public String TRANGTHAI { get; set; }

        public void writerXml(XmlWriter writer)
        {
            writer.WriteStartElement("GIAY_TO");
            writer.WriteElementString("MADK", this.MADK.ToString());
            writer.WriteElementString("MAGT", this.MAGT.ToString());
            writer.WriteElementString("SOHOSO", this.SOHOSO.ToString());
            writer.WriteElementString("TEN_NLX", this.TEN_NLX.ToString());
            writer.WriteElementString("TRANGTHAI", this.TRANGTHAI.ToString());
            writer.WriteEndElement();
        }
    }
}
