using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class Application : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        String REID = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                }
                else
                {

                }
            }
            catch
            {
            }

        }
        protected void GetUserQualification()
        {
            if (Session["WiremanId"] != null)
            {
                REID = Session["WiremanId"].ToString();
            }
            else
            {
                REID = Session["SupervisorID"].ToString();
            }
            //hdnId.Value = REID;

            DataSet ds = new DataSet();
            ds = CEI.QualificationData(REID);
            //if (ds.Tables.Count > 0)
            //{
            //    //;10th
            //    txtUniversity.Text = ds.Tables[0].Rows[0]["UniversityName10th"].ToString();
            //    string dp_Id3 = ds.Tables[0].Rows[0]["PassingYear10th"].ToString();
            //    txtPassingyear.Text = DateTime.Parse(dp_Id3).ToString("yyyy-MM-dd");
            //    txtmarks.Text = ds.Tables[0].Rows[0]["Marks"].ToString();
            //    txtprcntg.Text = ds.Tables[0].Rows[0]["Percentage10th"].ToString();
            //    //12thorITI
            //    string dp_Id = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();
            //    string dp_Id1 = ds.Tables[0].Rows[0]["NameofDiplomaDegree"].ToString();
            //    txtUniversity1.Text = ds.Tables[0].Rows[0]["UniversityName12thorITI"].ToString();
            //    string dp_Id4 = ds.Tables[0].Rows[0]["PassingYear12thorITI"].ToString();
            //    txtPassingyear1.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
            //    txtmarksObtained1.Text = ds.Tables[0].Rows[0]["MarksObtained12thorITI"].ToString();
            //    txtmarksmax1.Text = ds.Tables[0].Rows[0]["MarksMax12thorITI"].ToString();
            //    txtprcntg1.Text = ds.Tables[0].Rows[0]["Percentage12thorITI"].ToString();
            //    txtUniversity2.Text = ds.Tables[0].Rows[0]["UniversityNameDiplomaorDegree"].ToString();
            //    string dp_Id5 = ds.Tables[0].Rows[0]["PassingYearDiplomaorDegree"].ToString();
            //    txtPassingyear2.Text = DateTime.Parse(dp_Id5).ToString("yyyy-MM-dd");
            //    txtmarksObtained2.Text = ds.Tables[0].Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
            //    txtmarksmax2.Text = ds.Tables[0].Rows[0]["MarksMaxDiplomaorDegree"].ToString();
            //    txtprcntg2.Text = ds.Tables[0].Rows[0]["PercentageDiplomaorDegree"].ToString();
            //    string dp_Id2 = ds.Tables[0].Rows[0]["NameofDegree"].ToString();
            //    txtUniversity3.Text = ds.Tables[0].Rows[0]["UniversityNamePG"].ToString();
            //    string dp_Id6 = ds.Tables[0].Rows[0]["PassingYearPG"].ToString();
            //    txtPassingyear3.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
            //    txtmarksObtained3.Text = ds.Tables[0].Rows[0]["MarksObtainedPG"].ToString();
            //    txtmarksmax3.Text = ds.Tables[0].Rows[0]["MarksMaxPG"].ToString();
            //    txtprcntg3.Text = ds.Tables[0].Rows[0]["PercentagePG"].ToString();
            //}
        }


    }
}