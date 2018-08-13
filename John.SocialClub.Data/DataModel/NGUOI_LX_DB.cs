using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace John.SocialClub.Data.DataModel
{
    public class NGUOI_LX_DB
    {
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
        public DateTime? NGAY_CAP_CMT { get; set; }
        public String NOI_CAP_CMT { get; set; }
        public String GHI_CHU { get; set; }
        public Boolean? TRANG_THAI { get; set; }
        public String NGUOI_TAO { get; set; }
        public String NGUOI_SUA { get; set; }
        public DateTime? NGAY_TAO { get; set; }
        public DateTime? NGAY_SUA { get; set; }
        public String GIOI_TINH { get; set; }
        public String HO_VA_TEN_IN { get; set; }
        public String SO_CMND_CU { get; set; }

        public static NGUOI_LX_DB copyData(NGUOI_LX data)
        {
            NGUOI_LX_DB obj = new NGUOI_LX_DB();
            obj.MADK = Ultils.NullValue(data.MADK);
            obj.DV_NHAN_HS = Ultils.NullValue(data.DV_NHAN_HS);
            obj.HO_DEM_NLX = Ultils.NullValue(data.HO_DEM_NLX);
            obj.TEN_NLX = Ultils.NullValue(data.TEN_NLX);
            obj.HO_VA_TEN = Ultils.NullValue(data.HO_VA_TEN);
            obj.MA_QUOC_TICH = Ultils.NullValue(data.MA_QUOC_TICH);
            obj.NGAY_SINH = Ultils.NullValue(data.NGAY_SINH);
            obj.NOI_TT = Ultils.NullValue(data.NOI_TT);
            if (obj.NOI_TT == null)
            {
                obj.NOI_TT = "";
            }
            obj.NOI_TT_MA_DVHC = Ultils.NullValue(data.NOI_TT_MA_DVHC);
            obj.NOI_TT_MA_DVQL = Ultils.NullValue(data.NOI_TT_MA_DVQL);
            obj.NOI_CT = Ultils.NullValue(data.NOI_CT);
            if (obj.NOI_CT == null)
            {
                obj.NOI_CT = "";
            }
            obj.NOI_CT_MA_DVHC = Ultils.NullValue(data.NOI_CT_MA_DVHC);
            obj.NOI_CT_MA_DVQL = Ultils.NullValue(data.NOI_CT_MA_DVQL);
            obj.SO_CMT = Ultils.NullValue(data.SO_CMT);

            obj.NOI_CAP_CMT = Ultils.NullValue(data.NOI_CAP_CMT);
            obj.GHI_CHU = Ultils.NullValue(data.GHI_CHU);

            obj.NGUOI_TAO = Ultils.NullValue(data.NGUOI_TAO);
            obj.NGUOI_SUA = Ultils.NullValue(data.NGUOI_SUA);
            obj.GIOI_TINH = Ultils.NullValue(data.GIOI_TINH);
            obj.HO_VA_TEN_IN = Ultils.NullValue(data.HO_VA_TEN_IN);
            obj.SO_CMND_CU = Ultils.NullValue(data.SO_CMND_CU);
            obj.TRANG_THAI = Ultils.NullValueBool(data.TRANG_THAI.ToString());
            obj.NGAY_CAP_CMT = Ultils.NullValueDate(data.NGAY_CAP_CMT);
            obj.NGAY_TAO = Ultils.NullValueDate(data.NGAY_TAO);
            obj.NGAY_SUA = Ultils.NullValueDate(data.NGAY_SUA);
            return obj;
        }
    }
}
