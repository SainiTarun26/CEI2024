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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewBind();
                    BindBarChart();
                    BindDoughnutChart();
                    OfficersGridBind();
                }
            }
            catch { }

        }

        private void GridViewBind()
        {
            LoginId = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.DivisionsDistrictHistory(LoginId);
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

        private void BindBarChart()
        {
            LoginId = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.DivisionsDistrictHistory(LoginId);

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
                borderWidth: 1
            }},
            {{
                label: 'Pending',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesInitiated)},
backgroundColor: 'rgba(255, 99, 71, 0.8)',
                borderColor: 'rgba(255, 99, 71, 1)',
                borderWidth: 1
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
                // Handle the case when there is no data
                // Display a message or take appropriate action
            }
        }

        private void BindDoughnutChart()
        {

            DataSet ds = new DataSet();
            ds = cei.DasboardPieChartCalculations();
            TotalRequestRecieved.Text = ds.Tables[0].Rows[0]["TotalCount"].ToString();
            TextBox30.Text = ds.Tables[0].Rows[0]["AcceptedOrRejected"].ToString();
            In_process.Text = ds.Tables[0].Rows[0]["InprogressCount"].ToString();
            Initiated.Text = ds.Tables[0].Rows[0]["InitiatedCount"].ToString();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                var labelsValues = new[] { "Initiated", "Inprogress", "Accepted", "Rejected" };
                var labels = new[] { "Percentage_Initiated", "Percentage_Inprogress", "Percentage_Accepted", "Percentage_Rejected" };

                // Extract values from the DataTable
                var values = labels.Select(label => Convert.ToInt32(dt.Rows[0][label])).ToArray();

                // Render the JavaScript code to create the Chart.js chart
                string script = $@"var ctx = document.getElementById('myDoughnutChart').getContext('2d');var myDoughnutChart = new Chart(ctx, {{
    type: 'doughnut',
    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(labelsValues)},
        datasets: [
            {{
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(values)},
                backgroundColor: ['rgba(238, 9, 121,0.8)', 'rgba(60,179,113,0.8)', 'rgba(255, 99, 71, 0.8)', 'rgba(29, 75, 227, 0.8)'],
                borderColor: ['rgba(238, 9, 121,1)', 'rgba(60,179,113,1)', 'rgba(255, 99, 71, 1)', 'rgba(29, 75, 227, 1)'],
                borderWidth: 1
            }}
        ]
    }},
    options: {{
        responsive: false, // Set to false to prevent automatic resizing
        maintainAspectRatio: true, // Set to true to keep the aspect ratio of the chart
        title: {{
            display: true,
        }}
    }}

}});
";

                // Register the JavaScript code on the page
                ScriptManager.RegisterStartupScript(this, GetType(), "DoughnutChartScript", script, true);

            }
            else
            {
                // Handle the case when there is no data
                // Display a message or take appropriate action
            }

        }

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
    }
}