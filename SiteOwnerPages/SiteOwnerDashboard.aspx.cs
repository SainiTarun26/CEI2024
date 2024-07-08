using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SiteOwnerDashboard : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        //BindGridView();
                        GetDataforSiteowner();
                        //GetDataforLineGraphBinding();
                        //GetDataforGeneratingSetGraphBinding();
                        //GetDataforSubstationGraphBinding();
                    }
                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine("Error Message " + ex.Message.ToString());
                //throw;
            }
           
        }

        private void GetDataforSiteowner()
        {
            try
            {
                LoginId = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = cei.GetdataforSiteownerdashboard(LoginId);
                txtTotalinspection.Text = ds.Tables[0].Rows[0]["TotalInspections"].ToString();
                txtRejected.Text = ds.Tables[0].Rows[0]["Return"].ToString();
                txtApproved.Text = ds.Tables[0].Rows[0]["Approved"].ToString();
                txtPending.Text = ds.Tables[0].Rows[0]["Pending"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message " + ex.Message.ToString());
            }
        }
        private void GetDataforLineGraphBinding()
        {
            try
            {
                LoginId = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = cei.GetdataforSiteownerdashboardGraph(LoginId,"Line");
                if (ds.Tables.Count>0 && ds.Tables[0].Rows.Count >0)
                {
                    DataTable dt = ds.Tables[0];

                    // Assuming dt has "Total" and "Inprogressorpending" columns
                    var ApplicationStatus = dt.AsEnumerable().Select(row => row.Field<string>("ApplicationStatus")).ToArray();
                    var valuesReturn = dt.AsEnumerable().Select(row => row.Field<int>("Return")).ToArray();
                    var valuesPending = dt.AsEnumerable().Select(row => row.Field<int>("Pending")).ToArray();
                    var valuesRejected = dt.AsEnumerable().Select(row => row.Field<int>("Rejected")).ToArray();
                    var valuesApproved = dt.AsEnumerable().Select(row => row.Field<int>("Approved")).ToArray();

                    // Duplicate the data 15 times
                    ApplicationStatus = Enumerable.Repeat(ApplicationStatus, 1).SelectMany(x => x).ToArray();
                    valuesReturn = Enumerable.Repeat(valuesReturn, 5).SelectMany(x => x).ToArray();
                    valuesPending = Enumerable.Repeat(valuesPending, 5).SelectMany(x => x).ToArray();

                    valuesRejected = Enumerable.Repeat(valuesRejected, 5).SelectMany(x => x).ToArray();
                    valuesApproved = Enumerable.Repeat(valuesApproved, 5).SelectMany(x => x).ToArray();

                    // Render the JavaScript code to create the Chart.js chart
                    string script = $@"var ctx = document.getElementById('myChart').getContext('2d');var myChart = new Chart(ctx, 
            {{    type: 'bar',    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(ApplicationStatus)},
        datasets: [
{{
                label: 'Approved',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesApproved)},
        backgroundColor: 'rgba(61,197,142,1)',
                borderColor: 'rgba(61,197,142,1)',
                borderWidth: 3,
        barThickness: 25
            }},
{{
                label: 'Pending',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesPending)},
        backgroundColor: 'rgba(245, 136, 91, 1)',
                borderColor: 'rgba(241, 125, 92, 0.8)',
                borderWidth: 3,
        barThickness: 25
            }},
                        
{{
                label: 'Rejected',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesRejected)},
        backgroundColor: 'rgba(248, 44, 44, 1)',
                borderColor: 'rgba(248, 44, 44, 1)',
                borderWidth: 3,
        barThickness: 25
            }},
{{
                label: 'Return',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesReturn)},
                backgroundColor: 'rgba(232, 7, 157, 0.8)',
                borderColor: 'rgba(232, 7, 157, 0.8)',
                borderWidth: 3,
        barThickness: 25
            }},
            ]
            }},
            options: {{
            scales: {{
              x: {{
                grid: {{
                    color: 'rgba(0, 0, 0, 0.3)' // Darker black for x-axis grid lines
                }}
            }},
            y: {{
                beginAtZero: true,
                grid: {{
                    color: 'rgba(0, 0, 0, 0.3)' // Darker black for y-axis grid lines
                }}
            }}
            }}
        }}
    }});
    ";
                    // Register the JavaScript code on the page
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChartScript", script, true);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message " + ex.Message.ToString());
            }
        }
        private void GetDataforGeneratingSetGraphBinding()
        {
            try
            {
                LoginId = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = cei.GetdataforSiteownerdashboardGraph(LoginId, "Generating Set");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    // Assuming dt has "Total" and "Inprogressorpending" columns
                    var ApplicationStatus = dt.AsEnumerable().Select(row => row.Field<string>("ApplicationStatus")).ToArray();
                    var valuesReturn = dt.AsEnumerable().Select(row => row.Field<int>("Return")).ToArray();
                    var valuesPending = dt.AsEnumerable().Select(row => row.Field<int>("Pending")).ToArray();
                    var valuesRejected = dt.AsEnumerable().Select(row => row.Field<int>("Rejected")).ToArray();
                    var valuesApproved = dt.AsEnumerable().Select(row => row.Field<int>("Approved")).ToArray();

                    // Duplicate the data 15 times
                    ApplicationStatus = Enumerable.Repeat(ApplicationStatus, 1).SelectMany(x => x).ToArray();
                    valuesReturn = Enumerable.Repeat(valuesReturn, 5).SelectMany(x => x).ToArray();
                    valuesPending = Enumerable.Repeat(valuesPending, 5).SelectMany(x => x).ToArray();

                    valuesRejected = Enumerable.Repeat(valuesRejected, 5).SelectMany(x => x).ToArray();
                    valuesApproved = Enumerable.Repeat(valuesApproved, 5).SelectMany(x => x).ToArray();

                    // Render the JavaScript code to create the Chart.js chart
                    string script = $@"var ctx = document.getElementById('myChart2').getContext('2d');var myChart = new Chart(ctx, 
            {{    type: 'bar',    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(ApplicationStatus)},
        datasets: [
{{
                label: 'Approved',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesApproved)},
        backgroundColor: 'rgba(61,197,142,1)',
                borderColor: 'rgba(61,197,142,1)',
                borderWidth: 3,
        barThickness: 25
            }},
{{
                label: 'Pending',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesPending)},
        backgroundColor: 'rgba(245, 136, 91, 1)',
                borderColor: 'rgba(245, 136, 91, 1)',
                borderWidth: 3,
        barThickness: 25
            }},
{{
                label: 'Rejected',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesRejected)},
        backgroundColor: 'rgba(248, 44, 44, 1)',
                borderColor: 'rgba(248, 44, 44, 1)',
                borderWidth: 3,
        barThickness: 25
            }},
            {{
                label: 'Return',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesReturn)},
                backgroundColor: 'rgba(241, 58, 148, 1)',
                borderColor: 'rgba(241, 58, 148, 1)',
                borderWidth: 3,
        barThickness: 25
            }}         
            ]
            }},
            options: {{
            scales: {{
            x: {{
                grid: {{
                    color: 'rgba(0, 0, 0, 0.3)' // Darker black for x-axis grid lines
                }}
            }},
            y: {{
                beginAtZero: true,
                grid: {{
                    color: 'rgba(0, 0, 0, 0.3)' // Darker black for y-axis grid lines
                }}
            }}
            }}
        }}
    }});
    ";
                    // Register the JavaScript code on the page
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChartGeneratingScript", script, true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message " + ex.Message.ToString());
            }
        }
        private void GetDataforSubstationGraphBinding()
        {
            try
            {
                LoginId = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = cei.GetdataforSiteownerdashboardGraph(LoginId, "Substation Transformer");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];                   
                    // Assuming dt has "Total" and "Inprogressorpending" columns
                    var ApplicationStatus = dt.AsEnumerable().Select(row => row.Field<string>("ApplicationStatus")).ToArray();
                    var valuesReturn = dt.AsEnumerable().Select(row => row.Field<int>("Return")).ToArray();
                    var valuesPending = dt.AsEnumerable().Select(row => row.Field<int>("Pending")).ToArray();
                    var valuesRejected = dt.AsEnumerable().Select(row => row.Field<int>("Rejected")).ToArray();
                    var valuesApproved = dt.AsEnumerable().Select(row => row.Field<int>("Approved")).ToArray();

                    // Duplicate the data 15 times
                    ApplicationStatus = Enumerable.Repeat(ApplicationStatus, 1).SelectMany(x => x).ToArray();
                    valuesReturn = Enumerable.Repeat(valuesReturn, 5).SelectMany(x => x).ToArray();
                    valuesPending = Enumerable.Repeat(valuesPending, 5).SelectMany(x => x).ToArray();

                    valuesRejected = Enumerable.Repeat(valuesRejected, 5).SelectMany(x => x).ToArray();
                    valuesApproved = Enumerable.Repeat(valuesApproved, 5).SelectMany(x => x).ToArray();

                    // Render the JavaScript code to create the Chart.js chart
                    string script = $@"var ctx = document.getElementById('myChart3').getContext('2d');var myChart = new Chart(ctx, 
            {{    type: 'bar',    data: {{
        labels: {Newtonsoft.Json.JsonConvert.SerializeObject(ApplicationStatus)},
        datasets: [
           {{
                label: 'Approved',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesApproved)},
        backgroundColor: 'rgba(61,197,142,1)',
                borderColor: 'rgba(61,197,142,1)',
                borderWidth: 3,
        barThickness: 25
            }},
            
            {{
                label: 'Pending',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesPending)},
        backgroundColor: 'rgba(245, 136, 91, 1)',
                borderColor: 'rgba(245, 136, 91, 1)',
                borderWidth: 3,
        barThickness: 25
            }},

           {{
                label: 'Rejected',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesRejected)},
        backgroundColor: 'rgba(248, 44, 44, 1)',
                borderColor: 'rgba(248, 44, 44, 1)',
                borderWidth: 3,
        barThickness: 25
            }},
           {{
                label: 'Return',
                data: {Newtonsoft.Json.JsonConvert.SerializeObject(valuesReturn)},
                backgroundColor: 'rgba(232, 7, 157, 0.8)',
                borderColor: 'rgba(232, 7, 157, 0.8)',
                borderWidth: 3,
        barThickness: 25
            }}
            ]
            }},
            options: {{
            scales: {{
              x: {{
                grid: {{
                    color: 'rgba(0, 0, 0, 0.3)' // Darker black for x-axis grid lines
                }}
            }},
            y: {{
                beginAtZero: true,
                grid: {{
                    color: 'rgba(0, 0, 0, 0.3)' // Darker black for y-axis grid lines
                }}
            }}
            }}
        }}
    }});
    ";
                    // Register the JavaScript code on the page
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChartSubstationTransformerScript", script, true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message " + ex.Message.ToString());
            }
        }
        private void BindGridView()
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    LoginId = Convert.ToString(Session["SiteOwnerId"]);


                    DataTable ds = new DataTable();
                    ds = cei.GetdataforSiteownerdashboardGridview(LoginId);
                    if (ds.Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                    else
                    {
                        //string script = "alert(\"No Data Found\");";
                        //ScriptManager.RegisterStartupScript(this, GetType(), " script", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}