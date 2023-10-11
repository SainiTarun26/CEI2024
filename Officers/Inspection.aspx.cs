using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;

namespace CEIHaryana.Officers
{
    public partial class Inspection : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        public void GetData()
        {
            ID = Session["InspectionId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.InspectionData(ID);
            txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
            txtApplicantType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
            string DemandNoticeOfLine = ds.Tables[0].Rows[0]["DemandNoticeOfLine"].ToString();
            Session["DemandNoticeOfLine"] = DemandNoticeOfLine;
            string Structure = ds.Tables[0].Rows[0]["StructureStabilityResolvedByAuthorizedEngineer"].ToString();
            Session["DemandNoticeOfLine"] = Structure;
        }
        protected void lnkDocument_Click(object sender, EventArgs e)
        {
            
            string fileName = Session["DemandNoticeOfLine"].ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
            }
        } 
        protected void lnkStructure_Click(object sender, EventArgs e)
        {
            
            string fileName = Session["DemandNoticeOfLine"].ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
            }
        }


    }
}