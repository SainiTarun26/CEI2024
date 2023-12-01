using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
                var categories = dt.AsEnumerable().Select(row => row.Field<int>("Total").ToString()).ToArray();
                var valuesRecordCount = dt.AsEnumerable().Select(row => row.Field<int>("Total")).ToArray();
                var valuesInitiated = dt.AsEnumerable().Select(row => row.Field<int>("Inprogressorpending")).ToArray();

                // Duplicate the data 15 times
                categories = Enumerable.Repeat(categories, 5).SelectMany(x => x).ToArray();
                valuesRecordCount = Enumerable.Repeat(valuesRecordCount, 5).SelectMany(x => x).ToArray();
                valuesInitiated = Enumerable.Repeat(valuesInitiated, 5).SelectMany(x => x).ToArray();

                // Render the JavaScript code to create the Chart.js chart
                string script = $@"
var ctx = document.getElementById('myChart').getContext('2d');
var myChart = new Chart(ctx, {{
    type: 'bar',
    data: {{
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




    }
}