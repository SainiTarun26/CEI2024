using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class AdminMaster : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string Division = string.Empty;
        string dated = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = (MasterPage)Master;
                var loginTypeLabel = (Label)master.FindControl("LoginType");
                if (loginTypeLabel != null)
                {
                    loginTypeLabel.Text = "Admin / Dashboard";
                }

                try
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        BindBarChart();
                        BindDoughnutChart();
                        GridViewBind();
                        OfficersGridBind();
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
                catch (Exception ex)
                { 

                }
            }
        }
        private void BindBarChart()
        {
            DataSet ds = cei.DasboardCalculations();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                // Assuming dt has "Total" and "Inprogressorpending" columns
                var categories = dt.AsEnumerable().Select(row => row.Field<string>("Division")).ToArray();
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
                // Register the JavaScript code on the page
                ScriptManager.RegisterStartupScript(this, GetType(), "ChartScript", script, true);
            }
            else
            {
            }
        }
        private void BindDoughnutChart()
        {
            DataSet ds = new DataSet();
            ds = cei.DasboardPieChartCalculations();
            TotalRequestRecieved.Text = ds.Tables[0].Rows[0]["TotalCount"].ToString();
            txtApprovalAndReject.Text = ds.Tables[0].Rows[0]["AcceptedOrRejected"].ToString();
            //TextBox30.Text = ds.Tables[0].Rows[0]["AcceptedOrRejected"].ToString();
            In_process.Text = ds.Tables[0].Rows[0]["InprogressCount"].ToString();
            Initiated.Text = ds.Tables[0].Rows[0]["InitiatedCount"].ToString();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                var labelsValues = new[] { "New Applications", "In Process", "Accepted", "Rejected" };
                var labels = new[] { "Percentage_Initiated", "Percentage_Inprogress", "Percentage_Accepted", "Percentage_Rejected" };

                // Extract values from the DataTable
                var values = labels.Select(label => Convert.ToInt32(dt.Rows[0][label])).ToArray();
                string[] backgroundColors = { "#fc7c56", "#eb1386", "#3d9c5c", "#f71d05" }; // Customize colors here
                var percentages = labels.Select(label => Convert.ToDouble(dt.Rows[0][label])).ToArray();
                // Build the JavaScript code
                string script = $@"var ctx = document.getElementById('myDoughnutChart').getContext('2d');
var myDoughnutChart = new Chart(ctx, {{
    type: 'doughnut',
    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(labelsValues)},
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
                    return data.labels[tooltipItem.index] + ': ' + currentValue + '%'; // Display percentage
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

        private void GridViewBind()
        {
            DataSet ds = new DataSet();
            ds = cei.AllInspectionHistory();
            if (ds.Tables.Count > 0)
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
        private void OfficersGridBind()
        {
            DataSet ds = new DataSet();
            ds = cei.StaffPendingRecordsCount();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        GridView1.Visible = false;
                        BindGridView();
                        GridView2.Visible = true;
                        
                    }
                    BindBarChart();
                    BindDoughnutChart();
                    Back.Visible = true;
                    PrintableDistrict.Visible = true;
                    PrintableDivision.Visible = false;
                }
            }
            catch { }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewBind();
            }
            catch
            {

            }
        }

        private void BindGridView()
        {
            try
            {
                if (Convert.ToString(Session["Area"]) != null && Convert.ToString(Session["Area"]) != "")
                {
                    Division = Convert.ToString(Session["Area"]);

                }
                DataTable ds = new DataTable();
                ds = cei.RequestPendingDivision(Division);
                if (ds.Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    string script = "alert(\"No Data Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), " script", script, true);
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
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
                Response.Redirect("/Admin/DistrictData.aspx");
                BindBarChart();
                BindDoughnutChart();

            }
            catch (Exception)
            {

                // throw;
            }

        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindGridView();
        }

      
    }
}