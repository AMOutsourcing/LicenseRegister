using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPLX.Data.DataModel
{
    public class TmpObj
    {
        public int iValue { get; set; }
        public String nValue { get; set; }
        public String nText { get; set; }

        public TmpObj(String value, String text)
        {
            this.nValue = value;
            this.nText = text;
        }

        public TmpObj(int value, String text)
        {
            this.iValue = value;
            this.nText = text;
        }
    }
}
