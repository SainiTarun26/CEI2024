using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CEIHaryana
{
    public class ExportUtility
    {
        public class FormlessPage : Page
        {
            public override void VerifyRenderingInServerForm(Control control) { }
        }
        private static string RenderPageWithServerExecute(string pagePathWithQuery)
        {
            var httpContext = HttpContext.Current;

            using (var stringWriter = new StringWriter())
            {
                httpContext.Server.Execute(pagePathWithQuery, stringWriter, preserveForm: true);
                return stringWriter.ToString();
            }
        }

        // Remove unwanted elements: <script>, <button>, and input buttons
        private static string CleanHtml(string rawHtml)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(rawHtml);

            var scriptNodes = htmlDoc.DocumentNode.SelectNodes("//script[not(@src)]");
            if (scriptNodes != null)
            {
                foreach (var script in scriptNodes)
                    script.Remove();
            }

            // Remove all <button> tags
            var buttonNodes = htmlDoc.DocumentNode.SelectNodes("//button");
            if (buttonNodes != null)
            {
                foreach (var button in buttonNodes)
                    button.Remove();
            }

            // Remove all input[type=button|submit|reset]
            var inputNodes = htmlDoc.DocumentNode.SelectNodes("//input[@type='button' or @type='submit' or @type='reset']");
            if (inputNodes != null)
            {
                foreach (var input in inputNodes)
                    input.Remove();
            }
            var imgNodes = htmlDoc.DocumentNode.SelectNodes("//img[@src]");
            if (imgNodes != null)
            {
                foreach (var img in imgNodes)
                {
                    var src = img.GetAttributeValue("src", "");
                    if (src.StartsWith("/attachment", StringComparison.OrdinalIgnoreCase))
                    {
                        img.SetAttributeValue("src", "https://uat.ceiharyana.com" + src);
                    }
                }
            }
            return htmlDoc.DocumentNode.OuterHtml;
        }

        // Public method: render + clean + zip
        public static void ExportCleanHtmlToZip(string pagePath, string queryString, ZipArchive zip, string outputFileName = "RegistrationInfo.html")
        {
            // Step 1: Render the ASPX page (full execution with server controls)
            string fullHtml = RenderPageWithServerExecute(pagePath + "?" + queryString);

            // Step 2: Clean the rendered HTML
            string cleanedHtml = CleanHtml(fullHtml);

            // Step 3: Write the cleaned HTML to the zip archive
            byte[] htmlBytes = Encoding.UTF8.GetBytes(cleanedHtml);
            ZipArchiveEntry pageEntry = zip.CreateEntry(outputFileName, CompressionLevel.Fastest);
            using (var entryStream = pageEntry.Open())
            {
                entryStream.Write(htmlBytes, 0, htmlBytes.Length);
            }
        }
    }
}