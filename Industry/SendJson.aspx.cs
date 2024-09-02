using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;

namespace CEIHaryana.Industry
{
    public partial class SendJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btntestJson_Click(object sender, EventArgs e)
        {
            string jsonData = @"{
                'uname': 'testuser',
                'investorname': 'John Doe',
                'address': '1234 Elm Street',
                'useremail': 'john.doe@example.com',
                'country': 'India',
                'state': 'Haryana',
                'city': 'Gurgaon',
                'niccode': '12345',
                'pannumber': 'abcde1234t',
                'gstnumber': '22AAAAA0000A1Z5',
                'aadhar_number': '123456789012',
                'proposedbuilt_up_area': '1000',
                'mobile': '9876543210',
                'totalproposedprojectarea': '5000',
                'totalpurposedemployment': '100',
                'total_project_cost': '10000000',
                'project_site_district': 'Gurgaon',
                'landzoneuse_type': 'Commercial',
                'businessentity': 'Private',
                'projecttype': 'New',
                'projectid': 'P123456',
                'serviceid': '1',
                'projectserviceid': 'PS123456',
                'requestType': 'New',
                'cafType': 'Type1'
            }";


            string url = "https://ceiharyana.com/Industry/Industry.aspx"; // Replace with your actual URL
          //  string url = "https://localhost:44393/Industry/Industry.aspx"; // Replace with your actual URL

            PostJsonData(url, jsonData);
        }

        private void PostJsonData(string url, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(jsonData);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    Response.Write(result);
                    Response.End();
                }
            }
        }

    }
}