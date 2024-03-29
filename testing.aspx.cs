using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Iterate through the dynamically added FileUpload controls
            foreach (Control control in FileUploadPlaceholder.Controls)
            {
                //if (control is FileUpload)
                //{
                    FileUpload fileUpload = (FileUpload)control;
                    if (fileUpload.HasFile)
                    {
                        // Process the uploaded file
                        string fileName = Path.GetFileName(fileUpload.FileName);
                        // Save or do whatever you need with the file
                        fileUpload.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    }
                //}
            }
        }

        protected void AddFileUploadButton_Click(object sender, EventArgs e)
        {
            // Create a new FileUpload control
            FileUpload fileUpload = new FileUpload();
            fileUpload.ID = "FileUpload" + (FileUploadPlaceholder.Controls.Count + 1); // Unique ID for each control
            fileUpload.CssClass = "file-upload"; // Optional CSS class for styling

            // Add the FileUpload control to the placeholder
            FileUploadPlaceholder.Controls.Add(fileUpload);
        }
    }
}