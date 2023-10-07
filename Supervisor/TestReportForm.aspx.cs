using CEI_PRoject;
using CEIHaryana.TestReport;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportForm : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string REID = string.Empty;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // BindListBoxInstallationType();
                GetDetails();
            }

        }

        protected void GetDetails()
        {
            try
            {
                REID = Session["id"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataForAdmin(REID);

                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtInstallation.Text = dp_Id;
                if (dp_Id == "Firm/Organization/Company/Department")
                {
                    agency.Visible = true;
                    individual.Visible = false;
                }
                else
                {
                    individual.Visible = true;
                    agency.Visible = false;
                }

                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                TxtPremises.Text = dp_Id1;
                string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                //txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                txtVoltagelevel.Text = dp_Id3;
                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                string dp_Id8 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                string dp_Id9 = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                string dp_Id10 = ds.Tables[0].Rows[0]["TypeOfInstallation2"].ToString();
                string dp_Id11 = ds.Tables[0].Rows[0]["NumberOfInstallation2"].ToString();
                string dp_Id12 = ds.Tables[0].Rows[0]["TypeOfInstallation3"].ToString();
                string dp_Id13 = ds.Tables[0].Rows[0]["NumberOfInstallation3"].ToString();
                string dp_Id14 = ds.Tables[0].Rows[0]["TypeOfInstallation4"].ToString();
                string dp_Id15 = ds.Tables[0].Rows[0]["NumberOfInstallation4"].ToString();
                string dp_Id16 = ds.Tables[0].Rows[0]["TypeOfInstallation5"].ToString();
                string dp_Id17 = ds.Tables[0].Rows[0]["NumberOfInstallation5"].ToString();
                string dp_Id18 = ds.Tables[0].Rows[0]["TypeOfInstallation6"].ToString();
                string dp_Id19 = ds.Tables[0].Rows[0]["NumberOfInstallation6"].ToString();
                string dp_Id20 = ds.Tables[0].Rows[0]["TypeOfInstallation7"].ToString();
                string dp_Id21 = ds.Tables[0].Rows[0]["NumberOfInstallation7"].ToString();
                string dp_Id22 = ds.Tables[0].Rows[0]["TypeOfInstallation8"].ToString();
                string dp_Id23 = ds.Tables[0].Rows[0]["NumberOfInstallation8"].ToString();

                if (dp_Id8 != "")
                {
                    Installation.Visible = true;
                    installationType1.Visible = true;
                    txtinstallationType1.Text = dp_Id8;
                    txtinstallationNo1.Text = dp_Id9;
                }
                if (dp_Id10 != "")
                {
                    Installation.Visible = true;
                    installationType2.Visible = true;
                    txtinstallationType2.Text = dp_Id10;
                    txtinstallationNo2.Text = dp_Id11;
                }
                if (dp_Id12 != "")
                {
                    Installation.Visible = true;
                    installationType3.Visible = true;
                    txtinstallationType3.Text = dp_Id12;
                    txtinstallationNo3.Text = dp_Id13;
                }
                if (dp_Id14 != "")
                {
                    Installation.Visible = true;
                    installationType4.Visible = true;
                    txtinstallationType4.Text = dp_Id14;
                    txtinstallationNo4.Text = dp_Id15;
                }
                if (dp_Id16 != "")
                {
                    Installation.Visible = true;
                    installationType5.Visible = true;
                    txtinstallationType5.Text = dp_Id16;
                    txtinstallationNo5.Text = dp_Id17;
                }
                if (dp_Id18 != "")
                {
                    Installation.Visible = true;
                    installationType6.Visible = true;
                    txtinstallationType6.Text = dp_Id18;
                    txtinstallationNo6.Text = dp_Id19;
                }
                if (dp_Id20 != "")
                {
                    Installation.Visible = true;
                    installationType7.Visible = true;
                    txtinstallationType7.Text = dp_Id20;
                    txtinstallationNo7.Text = dp_Id21;
                }
                if (dp_Id22 != "")
                {
                    Installation.Visible = true;
                    installationType8.Visible = true;
                    txtinstallationType8.Text = dp_Id22;
                    txtinstallationNo8.Text = dp_Id23;
                }
            }
            catch { }
        }
        //private void BindListBoxInstallationType()
        //{
        //    DataSet dsWorkDetail = new DataSet();
        //    dsWorkDetail = CEI.GetddlInstallationType();
        //    ddlWorkDetail.DataSource = dsWorkDetail;
        //    ddlWorkDetail.DataTextField = "InstallationType";
        //    ddlWorkDetail.DataValueField = "Id";
        //    ddlWorkDetail.DataBind();
        //    ddlWorkDetail.Items.Insert(0, new ListItem("Select", "0"));
        //    dsWorkDetail.Clear();
        //}
        //protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string Value = ddlWorkDetail.SelectedItem.ToString();
        //    if (ddlWorkDetail.SelectedValue != "0")
        //    {
        //        Installation.Visible = true;
        //        installationType1.Visible = true;
        //        if (string.IsNullOrEmpty(txtinstallationType1.Text))
        //        {
        //            txtinstallationType1.Text = Value;
        //        }

        //        else if (txtinstallationType1.Text != string.Empty && string.IsNullOrEmpty(txtinstallationType2.Text))
        //        {
        //            installationType2.Visible = true;
        //            txtinstallationType2.Text = Value;
        //        }
        //        else if (string.IsNullOrEmpty(txtinstallationType3.Text))
        //        {
        //            installationType3.Visible = true;
        //            txtinstallationType3.Text = Value;
        //        }
        //        else if (string.IsNullOrEmpty(txtinstallationType4.Text))
        //        {
        //            installationType4.Visible = true;
        //            txtinstallationType4.Text = Value;
        //        }
        //        else if (string.IsNullOrEmpty(txtinstallationType5.Text))
        //        {
        //            installationType5.Visible = true;
        //            txtinstallationType5.Text = Value;
        //        }
        //        else if (string.IsNullOrEmpty(txtinstallationType6.Text))
        //        {

        //            installationType6.Visible = true;
        //            txtinstallationType6.Text = Value;
        //        }
        //        else if (string.IsNullOrEmpty(txtinstallationType7.Text))
        //        {
        //            installationType7.Visible = true;
        //            txtinstallationType7.Text = Value;
        //        }
        //        else if (string.IsNullOrEmpty(txtinstallationType8.Text))
        //        {
        //            installationType8.Visible = true;
        //            txtinstallationType8.Text = Value;
        //        }
        //        if (ddlWorkDetail.SelectedValue != "0")
        //        {

        //            try
        //            {
        //                string selectedValue = ddlWorkDetail.SelectedValue;
        //                ListItem itemToRemove = ddlWorkDetail.Items.FindByValue(selectedValue);
        //                if (itemToRemove != null)
        //                {
        //                    ddlWorkDetail.Items.Remove(itemToRemove);
        //                }
        //            }
        //            catch (Exception)
        //            { }
        //            ddlWorkDetail.SelectedValue = "0";

        //        }
        //    }
        //}
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType1.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}

            installationType1.Visible = false;
            txtinstallationType1.Text = string.Empty;
            txtinstallationNo1.Text = string.Empty;
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            // string valueToAddBack = txtinstallationType2.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType2.Visible = false;
            txtinstallationType2.Text = string.Empty;
            txtinstallationNo2.Text = string.Empty;
        }

        protected void btnDelete3_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType3.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType3.Visible = false;
            txtinstallationType3.Text = string.Empty;
            txtinstallationNo3.Text = string.Empty;
        }

        protected void btnDelete4_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType4.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType4.Visible = false;
            txtinstallationType4.Text = string.Empty;
            txtinstallationNo4.Text = string.Empty;
        }

        protected void btnDelete5_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType5.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType5.Visible = false;
            txtinstallationType5.Text = string.Empty;
            txtinstallationNo5.Text = string.Empty;
        }

        protected void btnDelete6_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType4.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType4.Visible = false;
            txtinstallationType4.Text = string.Empty;
            txtinstallationNo4.Text = string.Empty;
        }

        protected void btnDelete7_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType7.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType7.Visible = false;
            txtinstallationType7.Text = string.Empty;
            txtinstallationNo7.Text = string.Empty;
        }

        protected void btnDelete8_Click(object sender, EventArgs e)
        {
            //string valueToAddBack = txtinstallationType8.Text;

            //if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            //{
            //    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
            //    ddlWorkDetail.Items.Add(newItem);

            //}
            installationType8.Visible = false;
            txtinstallationType8.Text = string.Empty;
            txtinstallationNo8.Text = string.Empty;
        }



        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = Session["id"].ToString();
                CEI.InsertTestReportData(Id, txtInstallation.Text, txtName.Text, txtagency.Text, txtAddress.Text, TxtPremises.Text,
                    txtVoltagelevel.Text, txtPhone.Text, txtStartDate.Text, txtCompletitionDate.Text, txtSanctionLoad.Text, txtinstallationType1.Text,
                    txtinstallationNo1.Text, txtinstallationType2.Text, txtinstallationNo2.Text, txtinstallationType3.Text,
                    txtinstallationNo3.Text, txtinstallationType4.Text, txtinstallationNo4.Text, txtinstallationType5.Text,
                    txtinstallationNo5.Text, txtinstallationType6.Text, txtinstallationNo6.Text, txtinstallationType7.Text,
                    txtinstallationNo7.Text, txtinstallationType8.Text, txtinstallationNo8.Text);

                string TestReportId = CEI.TestReportId();
                Page.Session["TestReportId"] = CEI.TestReportId();


                //Session["intallationType"] = txtinstallationType1.Text + ","+ txtinstallationNo1.Text + "|"+txtinstallationType2.Text + "," + txtinstallationNo2.Text + "|"+
                //    txtinstallationType3.Text + "," + txtinstallationNo3.Text + "|"+txtinstallationType4.Text + "," + txtinstallationNo4.Text + "|"+
                //    txtinstallationType5.Text + "," + txtinstallationNo5.Text + "|"+ txtinstallationType6.Text + "," + txtinstallationNo6.Text + "|"+ txtinstallationType7.Text + "," + txtinstallationNo7.Text + "|"+ 
                //    txtinstallationType8.Text + "," + txtinstallationNo8.Text ;

                //string installationTypeValue = Session["intallationType"] as string;

                //if (!string.IsNullOrEmpty(installationTypeValue))
                //{
                //    string[] installationTypeParts = installationTypeValue.Split('|');
                //    foreach (string part in installationTypeParts)
                //    {
                //        if (part.Contains("Line"))
                //        {
                //            Session["Line"] = part;
                //            break; 
                //        }
                //    }
                //}
                //string lineValue = Session["Line"] as string;

                //string sessionValue1 = null;
                //string sessionValue2 = null;

                //if (!string.IsNullOrEmpty(lineValue))
                //{
                //    string[] lineParts = lineValue.Split(',');
                //    if (lineParts.Length >= 2)
                //    {
                //        sessionValue1 = lineParts[0];
                //        sessionValue2 = lineParts[1];
                //    }
                //}



                Page.Session["installationType1"] = txtinstallationType1.Text;
                Page.Session["installationNo1"] = txtinstallationNo1.Text;

                Page.Session["installationType2"] = txtinstallationType2.Text;
                Page.Session["installationNo2"] = txtinstallationNo2.Text;

                Page.Session["installationType3"] = txtinstallationType3.Text;
                Page.Session["installationNo3"] = txtinstallationNo3.Text;

                Page.Session["installationType4"] = txtinstallationType4.Text;
                Page.Session["installationNo4"] = txtinstallationNo4.Text;

                Page.Session["installationType5"] = txtinstallationType5.Text;
                Page.Session["installationNo5"] = txtinstallationNo5.Text;

                Page.Session["installationType6"] = txtinstallationType6.Text;
                Page.Session["installationNo6"] = txtinstallationNo6.Text;

                Page.Session["installationType7"] = txtinstallationType7.Text;
                Page.Session["installationNo7"] = txtinstallationNo7.Text;

                Page.Session["installationType8"] = txtinstallationType8.Text;
                Page.Session["installationNo8"] = txtinstallationNo8.Text;
                RedirectPages();

            }
            catch
            {

            }
        }

        //public void SetSessionName(string TextBoxName, string TextboxValue)
        //{
        //    if (TextBoxName != null && TextBoxName != "" && TextBoxName == "Line")
        //    {
        //        Page.Session["Line"] = TextboxValue;
        //    }
        //    if (TextBoxName != null && TextBoxName != "" && TextBoxName == "Substation Transformer")
        //    {
        //        Page.Session["Substation"] = TextboxValue;
        //    }
        //    if (TextBoxName != null && TextBoxName != "" && TextBoxName == "Generating Set")
        //    {
        //        Page.Session["Generating"] = TextboxValue;
        //    }
        //}
        public void RedirectPages()
        {
            string[] installationTypes = { "installationType1", "installationType2", "installationType3", "installationType4", "installationType5", "installationType7", "installationType8", "installationNo8" };
            string[] installationNumbers = {"installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };
            Page.Session["Count"] = 0;
            Page.Session["Page"] = 0;
            int count = Convert.ToInt32(Session["Count"]);
            for (int i = count; i < installationNumbers.Length; i++)
            {
                sessionName = Session[installationTypes[i]] as string;
                sessionValue = Session[installationNumbers[i]] as string;
                if (!string.IsNullOrEmpty(sessionName))
                {
                    nextSessionName = Session[installationTypes[i + 1]] as string;
                    nextSessionValue = Session[installationNumbers[i + 1]] as string;
                    break;
                }
            }
            if (sessionName.Trim() == "Line")
            {
                Response.Redirect("/TestReport/LineTestReport.aspx");
            }
            else if (sessionName.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReport/SubstationTransformer.aspx");
            }
            else if (sessionName.Trim() == "Generating Station")
            {
                Response.Redirect("/TestReport/GeneratingSetTestReport.aspx");
            }
        }
       


    }
}