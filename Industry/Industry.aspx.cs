using CEIHaryana.Model.Industry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;
using System.IO;

namespace CEIHaryana.Industry
{
    public partial class Industry1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string jsonData = ReadJsonFromRequestStream();

                if (!string.IsNullOrEmpty(jsonData))
                {
                    Response.Write(jsonData);
                    Response.End(); 
                }

            }
        }

        private string ReadJsonFromRequestStream()
        {
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}