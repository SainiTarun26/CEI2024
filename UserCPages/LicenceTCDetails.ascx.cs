using CEI_PRoject;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserCPages
{
    public partial class LicenceTCDetails : System.Web.UI.UserControl
    {
        CEI CEI = new CEI();

        public string GrUtrNo
        {
            get => txtGrUtrno.Text.Trim();
            set => txtGrUtrno.Text = value;
        }

        public string ChallanDate
        {
            get => txtGrUtrnoDate.Text.Trim();
            set => txtGrUtrnoDate.Text = value;
        }

        public string Amount
        {
            get => txtGrUtrnoAmount.Text.Trim();
            set => txtGrUtrnoAmount.Text = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Do nothing on load
        }

        public void BindChallanDetails(string applicationId)
        {
            DataSet ds = CEI.GetGrUtrNoAndChallanDetailByAppId(applicationId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                GrUtrNo = row["UtrnGrNo"]?.ToString();
                ChallanDate = row["ChallanDate"]?.ToString();
                Amount = row["Amount"]?.ToString();
            }
            else
            {
                GrUtrNo = "";
                ChallanDate = "";
                Amount = "";
            }
        }
    }
}
