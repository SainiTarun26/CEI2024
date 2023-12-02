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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindBarChart();
                    GridViewBind();
                    BindDoughnutChart();
                }
                catch             
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
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }},
            {{
                label: 'Pending',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesInitiated)},
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)',
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
            DataSet ds = cei.DasboardPieChartCalculations();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                // Assuming the columns are named as specified in your stored procedure
                var labels = new[] { "InitiatedCount", "InprogressCount", "AcceptedCount", "RejectedCount" };

                // Extract values from the DataTable
                var values = labels.Select(label => Convert.ToInt32(dt.Rows[0][label])).ToArray();

                // Render the JavaScript code to create the Chart.js chart
                string script = $@"var ctx = document.getElementById('myDoughnutChart').getContext('2d');var myDoughnutChart = new Chart(ctx, {{
    type: 'doughnut',
    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(labels)},
        datasets: [
            {{
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(values)},
                backgroundColor: ['rgba(255, 99, 132, 0.2)', 'rgba(75, 192, 192, 0.2)', 'rgba(255, 205, 86, 0.2)', 'rgba(54, 162, 235, 0.2)'],
                borderColor: ['rgba(255, 99, 132, 1)', 'rgba(75, 192, 192, 1)', 'rgba(255, 205, 86, 1)', 'rgba(54, 162, 235, 1)'],
                borderWidth: 1
            }}
        ]
    }},
    options: {{
        responsive: false, // Set to false to prevent automatic resizing
        maintainAspectRatio: true, // Set to true to keep the aspect ratio of the chart
        title: {{
            display: true,
            text: 'Doughnut Chart Example'
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
                        Response.Redirect("/Admin/RequestPendingDivision.aspx", false);
                    }
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



    }
}