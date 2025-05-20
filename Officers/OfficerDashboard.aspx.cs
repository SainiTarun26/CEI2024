using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class OfficerDashboard : System.Web.UI.Page
    {

        CEI cei = new CEI();
        string LoginId = string.Empty;
        string Division = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //GridViewDivisionBind();
                    BindBarChart();
                    BindDoughnutChart();
                    OfficersGridBind();
                    GetDataforOfficer();
                }
            }
            catch (Exception ex)
            {
            //
            }
        }
        private void GetDataforOfficer()
        {
            try
            {
                LoginId = Session["StaffID"].ToString();
                DataSet ds = new DataSet();
                ds = cei.Getdataforofficerdashboard(LoginId);
                TotalRequestRecieved.Text = ds.Tables[0].Rows[0]["TotalRequest"].ToString();
                txtApprovalAndReject.Text = ds.Tables[0].Rows[0]["ActionTaken"].ToString();
                In_process.Text = ds.Tables[0].Rows[0]["InProcess"].ToString();
                Initiated.Text = ds.Tables[0].Rows[0]["NewApplication"].ToString();
                if (ds.Tables.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            { }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
                LinkButton LinkButton3 = (LinkButton)e.Row.FindControl("LinkButton3");
                LinkButton LinkButton5 = (LinkButton)e.Row.FindControl("LinkButton5");
                if (LinkButton1.CommandArgument.ToString() == ""|| LinkButton1.CommandArgument.ToString() == "0")
                {
                    LinkButton1.Enabled = false;
                }
                if (LinkButton2.CommandArgument.ToString() == "" || LinkButton2.CommandArgument.ToString() == "0")
                {
                    LinkButton2.Enabled = false;
                }
                if (LinkButton3.CommandArgument.ToString() == "" || LinkButton3.CommandArgument.ToString() == "0")
                {
                    LinkButton3.Enabled = false;
                }
                if (LinkButton5.CommandArgument.ToString() == "" || LinkButton5.CommandArgument.ToString() == "0")
                {
                    LinkButton5.Enabled = false;
                }
            }
        }
        //private void GridViewDivisionBind()
        //{
        //    LoginId = Session["StaffID"].ToString();
        //    DataSet ds = new DataSet();
        //    ds = cei.DivisionInspectionHistory(LoginId);
        //    TotalRequestRecieved.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
        //    //TextBox30.Text = ds.Tables[0].Rows[0]["ActionTaken"].ToString();
        //    In_process.Text = ds.Tables[0].Rows[0]["InProgress"].ToString();
        //    Initiated.Text = ds.Tables[0].Rows[0]["Initiated"].ToString();
        //    if (ds.Tables.Count > 0)
        //    {
        //        GridView2.DataSource = ds;
        //        GridView2.DataBind();

        //    }
        //    else
        //    {
        //        GridView2.DataSource = null;
        //        GridView2.DataBind();
        //        string script = "alert(\"No Record Found\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    }
        //}
        //private void GridViewBind()
        //{
        //    if (Convert.ToString(Session["Area"]) != null && Convert.ToString(Session["Area"]) != "")
        //    {
        //        Division = Convert.ToString(Session["Area"]);
        //    }
        //    DataTable ds = new DataTable();
        //    ds = cei.RequestPendingDivision(Division);
        //    if (ds.Rows.Count > 0)
        //    {
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();

        //    }
        //    else
        //    {
        //        GridView1.DataSource = null;
        //        GridView1.DataBind();
        //        string script = "alert(\"No Record Found\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    }
        //}
        private void GridViewBind()
        {

            LoginId = Session["StaffID"].ToString();
            DataTable ds = new DataTable();
            //ds = cei.RequestPendingDivision(LoginId);
            ds = cei.RequestPendingDivisionForOfficers(LoginId);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridViewBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Session["Id"] = string.Empty;
                string CreatedDate = string.Empty;
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblDistrictofData = (Label)row.FindControl("lblDistrictofData");
                Session["DistrictOfData"] = lblDistrictofData.Text.Trim();

                if (e.CommandName == "Select15Days")
                {
                    Session["Days"] = "15days";
                }
                else if (e.CommandName == "Select15to30Days")
                {
                    Session["Days"] = "15to30days";
                }
                else if (e.CommandName == "Select30to45Days")
                {
                    Session["Days"] = "30to45days";
                }
                else if (e.CommandName == "SelectMoreThan45Days")
                {
                    Session["Days"] = "Morethen45days";
                }
                //GridView1.Visible = false;
                //GridView2.Visible = false;
                //BindDaysGridView();
                //GridView3.Visible = true;
                Response.Redirect("/Officers/DistrictData.aspx", false);
                BindBarChart();
                BindDoughnutChart();

            }
            catch (Exception)
            {

                // throw;
            }

        }
        private void BindBarChart()
        {
            LoginId = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.RecordsDivisionDistrict(LoginId);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                // Assuming dt has "Total" and "Inprogressorpending" columns
                var categories = dt.AsEnumerable().Select(row => row.Field<string>("DistrictofData")).ToArray();
                var valuesRecordCount = dt.AsEnumerable().Select(row => row.Field<int>("RecordCount")).ToArray();
                var valuesInitiated = dt.AsEnumerable().Select(row => row.Field<int>("Inprogressorpending")).ToArray();

                // Duplicate the data 15 times
                categories = Enumerable.Repeat(categories, 1).SelectMany(x => x).ToArray();
                valuesRecordCount = Enumerable.Repeat(valuesRecordCount, 5).SelectMany(x => x).ToArray();
                valuesInitiated = Enumerable.Repeat(valuesInitiated, 5).SelectMany(x => x).ToArray();

                // Render the JavaScript code to create the Chart.js chart
                string script = $@"var ctx = document.getElementById('myChart').getContext('2d');var myChart = new Chart(ctx, 
        {{    type: 'bar',    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(categories)},
        datasets: [
            {{
                label: 'Total Record',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesRecordCount)},
                backgroundColor: 'rgba(60,179,113,0.8)',
                borderColor: 'rgba(60,179,113,1)',
                borderWidth: 1,
 barThickness: 20
            }},
            {{
                label: 'Pending',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesInitiated)},
backgroundColor: 'rgba(255, 99, 71, 0.8)',
                borderColor: 'rgba(255, 99, 71, 1)',
                borderWidth: 1,
 barThickness: 20
            }}
        ]
    }},
    options: {{
        scales: {{
            y: {{
                beginAtZero: true
            }}
        }}
    }}
}});
";
                ScriptManager.RegisterStartupScript(this, GetType(), "ChartScript", script, true);
            }
            else
            {
            }
        }
        #region Navneet Changed on 20-may-2025
        private void BindDoughnutChart()
        {
            string LoginId = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.OfficerDashboardDaughnutChart(LoginId);
            string approvedCount = ds.Tables[0].Rows[0]["AcceptedCount"].ToString();
            string RejectedCount = ds.Tables[0].Rows[0]["RejectedCount"].ToString();
            string ReturnCount = ds.Tables[0].Rows[0]["ReturnCount"].ToString();
            string Initiated = ds.Tables[0].Rows[0]["NewApplicationCount"].ToString();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                var labelsValues = new[] { "New Applications", "In Process", "Accepted", "Rejected", "Returned" };
                var HoverValues = new[] { "New Applications" + " (" + Initiated + ")", "In Process" + " (" + In_process.Text + ")", "Accepted" + " (" + approvedCount + ")", "Rejected" + " (" + RejectedCount + ")", "Returned" + " (" + ReturnCount + ")" };
                var labels = new[] { "Percentage_NewApplication", "Percentage_Inprocess", "Percentage_Accepted", "Percentage_Rejected", "Percentage_Return" };

                // Extract values from the DataTable
                var values = labels.Select(label => Convert.ToInt32(dt.Rows[0][label])).ToArray();
                string[] backgroundColors = { "#fc7c56", "#eb1386", "#3d9c5c", "#f71d05", "#ADD8E6" }; // Customize colors here
                var percentages = labels.Select(label => Convert.ToDouble(dt.Rows[0][label])).ToArray();
                // Build the JavaScript code
                string script = $@"var ctx = document.getElementById('myDoughnutChart').getContext('2d');
var myDoughnutChart = new Chart(ctx, {{
    type: 'doughnut',
    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(labelsValues)},
        labelsWrite: {Newtonsoft.Json.JsonConvert.SerializeObject(HoverValues)},
        datasets: [
            {{
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(percentages)}, // Use percentages here
                backgroundColor: {Newtonsoft.Json.JsonConvert.SerializeObject(backgroundColors)},
                borderColor: {Newtonsoft.Json.JsonConvert.SerializeObject(backgroundColors)},
                borderWidth: 1
            }}
        ]
    }},
    options: {{
        responsive: false,
        maintainAspectRatio: true,
        title: {{
            display: true,
            text: ''
        }},
        tooltips: {{
            callbacks: {{
                label: function(tooltipItem, data) {{
                    var dataset = data.datasets[tooltipItem.datasetIndex];
                    var currentValue = dataset.data[tooltipItem.index];
                    return data.labelsWrite[tooltipItem.index] + ': ' + currentValue + '%'; // Display percentage
                }}
            }}
        }},
        legend: {{
            display: true,
            position: 'bottom'
        }},
        plugins: {{
            datalabels: {{
                formatter: function(value, context) {{
                    return value > 0 ? value + '%' : '';
                }},
                color: '#fff',
                anchor: 'end',
                align: 'start',
                offset: 10,
                borderWidth: 2,
                borderRadius: 4
            }}
        }}
    }}
}});
";
                // Register the JavaScript code on the page
                ScriptManager.RegisterStartupScript(this, GetType(), "DoughnutChartScript", script, true);
            }
            else
            {
            }
        }
        #endregion
        private void OfficersGridBind()
        {
            LoginId = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.StaffPendingDivisionWise(LoginId);
            if (ds.Tables.Count > 0)
            {
                OfficersGrid.DataSource = ds;
                OfficersGrid.DataBind();
            }
            else
            {
                OfficersGrid.DataSource = null;
                OfficersGrid.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblArea = (Label)row.FindControl("lblArea");
                    Session["Area"] = lblArea.Text.Trim();
                    if (e.CommandName == "Select")
                    {
                        GridView1.Visible = true;
                        GridView2.Visible = false;
                    }
                    BindBarChart();
                    Back.Visible = true;
                    PrintDistrict.Visible = true;
                    PrintDivision.Visible = false;
                    BindDoughnutChart();
                    GridViewBind();
                }
            }
            catch (Exception ex) 
            {
            
            }
        }

      

      
    }
}