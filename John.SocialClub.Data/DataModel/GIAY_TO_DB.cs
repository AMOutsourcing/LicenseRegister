using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPLX.Data.DataModel
{
    public class GIAY_TO_DB
    {
        public String MADK { get; set; }
        public Int32? MAGT { get; set; }
        public String SOHOSO { get; set; }
        public String TEN_NLX { get; set; }
        public Boolean? TRANGTHAI { get; set; }

        public static GIAY_TO_DB copyData(GIAY_TO data)
        {
            GIAY_TO_DB obj = new GIAY_TO_DB();
            obj.MADK = Ultils.NullValue(data.MADK);
            obj.MAGT = Ultils.NullValueInt(data.MAGT);
            obj.SOHOSO = Ultils.NullValue(data.SOHOSO);
            obj.TEN_NLX = Ultils.NullValue(data.TEN_NLX);
            obj.TRANGTHAI = Ultils.NullValueBool(data.TRANGTHAI);
            return obj;
        }
    }
}
