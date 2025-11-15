using CEI_PRoject;
using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto.Tls;
using StackExchange.Redis;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.UserPages
{
    //Page settd by neha 18-June-2025
    public partial class Documents : System.Web.UI.Page
    {
        string UserID = string.Empty;
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        ////Session["TempUniqueId"] = "";
                        Label1.Text = "Competency(Supervisor)";
                        UserID = Session["SupervisorID"].ToString();
                        HdnUserId.Value = UserID;
                        HdnUserType.Value = "Supervisor";
                        ////Apprenticecertificate.Visible = false;
                        ////Hdn_Apprenticecertificatevisible.Value = "";
                        LblChallanAmount.Text = "480";
                        lblDeclarationType.Text = "Certificate of Competency";
                        DetailsforDocuments(UserID);

                        ToGetTheDocumentsIfExisted(UserID);
                    }
                    else if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        ////Session["TempUniqueId"] = "";
                        Label1.Text = "Wireman Permit";
                        UserID = Session["WiremanId"].ToString();
                        HdnUserId.Value = UserID;
                        HdnUserType.Value = "Wireman";
                        //Apprenticecertificate.Visible = true;
                        //Hdn_Apprenticecertificatevisible.Value = "yes";
                        LblChallanAmount.Text = "240";
                        lblDeclarationType.Text = "Certificate of Permit";
                        DetailsforDocuments(UserID);

                        ToGetTheDocumentsIfExisted(UserID);
                    }
                    else
                    {
                        Response.Redirect("/AdminLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        #region to get Existing Documents
        private void ToGetTheDocumentsIfExisted(string userID)
        {
            // General documents
            int matricDocumentId = Convert.ToInt32(Hdn_DocumentId2.Value);
            GetDocumentbymatricDocumentId(userID, matricDocumentId);

            int CertificateOrDiplomaId = Convert.ToInt32(Hdn_DocumentId1.Value);
            GetDocumentbyCertificateOrDiplomaId(userID, CertificateOrDiplomaId, null);

            int DiplomaCertificateId = Convert.ToInt32(Hdn_DocumentId3.Value);
            GetDocumentByDiplomaCertificateId(userID, DiplomaCertificateId, null);

            int DegreeId = Convert.ToInt32(Hdn_DocumentId4.Value);
            GetDocumentByDegreeId(userID, DegreeId, null);

            int MasterDegreeId = Convert.ToInt32(Hdn_DocumentId5.Value);
            GetDocumentByMasterDegreeId(userID, MasterDegreeId, null);

            int ResidentProofId = Convert.ToInt32(Hdn_DocumentId6.Value);
            GetDocumentByResidentProofId(userID, ResidentProofId, null);

            int IDProofId = Convert.ToInt32(Hdn_DocumentId7.Value);
            GetDocumentByIDProofId(userID, IDProofId, null);

            int MedicalCertificateId = Convert.ToInt32(Hdn_DocumentId8.Value);
            GetDocumentByMedicalCertificateId(userID, MedicalCertificateId, null);

            int RetiredId = Convert.ToInt32(Hdn_DocumentId9.Value);
            GetDocumentByRetiredId(userID, RetiredId, null);

            int ApprenticeId = Convert.ToInt32(Hdn_DocumentId10.Value);
            GetDocumentByApprenticeId(userID, ApprenticeId, null);

            int EXP1Id = Convert.ToInt32(Hdn_DocumentId11.Value);
            int EXP1SubId = Convert.ToInt32(Hdn_SUBDocumentId11.Value);
            GetDocumentByEXP1Id(userID, EXP1Id, EXP1SubId);

            int EXP2Id = Convert.ToInt32(Hdn_DocumentId12.Value);
            int EXP2SubId = Convert.ToInt32(Hdn_SUBDocumentId12.Value);
            GetDocumentByEXP2Id(userID, EXP2Id, EXP2SubId);

            int EXP3Id = Convert.ToInt32(Hdn_DocumentId13.Value);
            int EXP3SubId = Convert.ToInt32(Hdn_SUBDocumentId13.Value);
            GetDocumentByEXP3Id(userID, EXP3Id, EXP3SubId);

            int EXP4Id = Convert.ToInt32(Hdn_DocumentId14.Value);
            int EXP4SubId = Convert.ToInt32(Hdn_SUBDocumentId14.Value);
            GetDocumentByEXP4Id(userID, EXP4Id, EXP4SubId);

            int EXP5Id = Convert.ToInt32(Hdn_DocumentId15.Value);
            int EXP5SubId = Convert.ToInt32(Hdn_SUBDocumentId15.Value);
            GetDocumentByEXP5Id(userID, EXP5Id, EXP5SubId);

            int EXP6Id = Convert.ToInt32(Hdn_DocumentId16.Value);
            int EXP6SubId = Convert.ToInt32(Hdn_SUBDocumentId16.Value);
            GetDocumentByEXP6Id(userID, EXP6Id, EXP6SubId);

            int EXP7Id = Convert.ToInt32(Hdn_DocumentId17.Value);
            int EXP7SubId = Convert.ToInt32(Hdn_SUBDocumentId17.Value);
            GetDocumentByEXP7Id(userID, EXP7Id, EXP7SubId);

            int EXP8Id = Convert.ToInt32(Hdn_DocumentId18.Value);
            int EXP8SubId = Convert.ToInt32(Hdn_SUBDocumentId18.Value);
            GetDocumentByEXP8Id(userID, EXP8Id, EXP8SubId);

            int EXP9Id = Convert.ToInt32(Hdn_DocumentId19.Value);
            int EXP9SubId = Convert.ToInt32(Hdn_SUBDocumentId19.Value);
            GetDocumentByEXP9Id(userID, EXP9Id, EXP9SubId);

            int EXP10Id = Convert.ToInt32(Hdn_DocumentId20.Value);
            int EXP10SubId = Convert.ToInt32(Hdn_SUBDocumentId20.Value);
            GetDocumentByEXP10Id(userID, EXP10Id, EXP10SubId);


            int tresurychallanId = Convert.ToInt32(Hdn_DocumentId21.Value);
            GetDocumentbytresurychallanId(userID, tresurychallanId);

            int CandidateImageId = Convert.ToInt32(Hdn_DocumentId22.Value);
            GetDocumentbyCandidateImageId(userID, CandidateImageId);

            int CandidateSignatureId = Convert.ToInt32(Hdn_DocumentId23.Value);
            GetDocumentbyCandidateSignatureId(userID, CandidateImageId);

        }

        private void GetDocumentbyCandidateSignatureId(string userID, int candidateImageId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, candidateImageId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();


                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document13.Value = "1";
                    lnkbtn_Delete13.Visible = true;
                    lnkbtn_Save13.Visible = true;
                    text13.Visible = false;
                    FileUpload13.Visible = false;
                    Button13.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentbyCandidateImageId(string userID, int candidateImageId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, candidateImageId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();


                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document12.Value = "1";
                    lnkbtn_Delete12.Visible = true;
                    lnkbtn_Save12.Visible = true;
                    text12.Visible = false;
                    FileUpload12.Visible = false;
                    Button12.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentbytresurychallanId(string userID, int tresurychallanId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, tresurychallanId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();
                string Utrn = dt.Rows[0]["UtrnNo"].ToString();
                DateTime challanDate = Convert.ToDateTime(dt.Rows[0]["challanDate"]);
                // txtdate.Text = challanDate.ToString("yyyy-MM-dd");


                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document11.Value = "1";
                    lnkbtn_Delete11.Visible = true;
                    lnkbtn_Save11.Visible = true;
                    txtdate.Text = challanDate.ToString("yyyy-MM-dd");
                    txtUtrNo.Text = Utrn.ToString();
                    txtdate.ReadOnly = true;
                    txtUtrNo.ReadOnly = true;
                    text11.Visible = false;
                    FileUpload11.Visible = false;
                    Button11.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByEXP10Id(string userID, int eXP10Id, int eXP10SubId)
        {

            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP10Id, eXP10SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document28.Value = "1";
                    lnkbtn_Delete28.Visible = true;
                    lnkbtn_Save28.Visible = true;
                    text28.Visible = false;
                    FileUpload28.Visible = false;
                    Button28.Visible = false;
                }
                else
                {
                    ////
                }
            }

        }

        private void GetDocumentByEXP9Id(string userID, int eXP9Id, int eXP9SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP9Id, eXP9SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document27.Value = "1";
                    lnkbtn_Delete27.Visible = true;
                    lnkbtn_Save27.Visible = true;
                    text27.Visible = false;
                    FileUpload27.Visible = false;
                    Button27.Visible = false;
                }
                else
                {
                    ////
                }
            }

        }

        private void GetDocumentByEXP8Id(string userID, int eXP8Id, int eXP8SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP8Id, eXP8SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document26.Value = "1";
                    lnkbtn_Delete26.Visible = true;
                    lnkbtn_Save26.Visible = true;
                    text26.Visible = false;
                    FileUpload26.Visible = false;
                    Button26.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByEXP7Id(string userID, int eXP7Id, int eXP7SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP7Id, eXP7SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document25.Value = "1";
                    lnkbtn_Delete25.Visible = true;
                    lnkbtn_Save25.Visible = true;
                    text25.Visible = false;
                    FileUpload25.Visible = false;
                    Button25.Visible = false;
                }
                else
                {
                    ////
                }
            }

        }

        private void GetDocumentByEXP6Id(string userID, int eXP6Id, int eXP6SubId)
        {

            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP6Id, eXP6SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document24.Value = "1";
                    lnkbtn_Delete24.Visible = true;
                    lnkbtn_Save24.Visible = true;
                    text24.Visible = false;
                    FileUpload24.Visible = false;
                    Button24.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByEXP5Id(string userID, int eXP5Id, int eXP5SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP5Id, eXP5SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document23.Value = "1";
                    lnkbtn_Delete23.Visible = true;
                    lnkbtn_Save23.Visible = true;
                    text23.Visible = false;
                    FileUpload23.Visible = false;
                    Button23.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByEXP4Id(string userID, int eXP4Id, int eXP4SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP4Id, eXP4SubId);

            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document22.Value = "1";
                    lnkbtn_Delete22.Visible = true;
                    lnkbtn_Save22.Visible = true;
                    text22.Visible = false;
                    FileUpload22.Visible = false;
                    Button22.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByEXP3Id(string userID, int eXP3Id, int eXP3SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP3Id, eXP3SubId);

            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document21.Value = "1";
                    lnkbtn_Delete21.Visible = true;
                    lnkbtn_Save21.Visible = true;
                    text21.Visible = false;
                    FileUpload21.Visible = false;
                    Button21.Visible = false;
                }
                else
                {
                    ////
                }
            }

        }

        private void GetDocumentByEXP2Id(string userID, int eXP2Id, int eXP2SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP2Id, eXP2SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document20.Value = "1";
                    lnkbtn_Delete20.Visible = true;
                    lnkbtn_Save20.Visible = true;
                    text20.Visible = false;
                    FileUpload20.Visible = false;
                    Button20.Visible = false;
                }
                else
                {
                    ////
                }
            }

        }

        private void GetDocumentByEXP1Id(string userID, int eXP1Id, int eXP1SubId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, eXP1Id, eXP1SubId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document19.Value = "1";
                    lnkbtn_Delete19.Visible = true;
                    lnkbtn_Save19.Visible = true;
                    text19.Visible = false;
                    FileUpload19.Visible = false;
                    Button19.Visible = false;
                }
                else
                {
                    ////
                }
            }

        }

        private void GetDocumentByApprenticeId(string userID, int apprenticeId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, apprenticeId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document10.Value = "1";
                    lnkbtn_Delete10.Visible = true;
                    lnkbtn_Save10.Visible = true;
                    text10.Visible = false;
                    FileUpload10.Visible = false;
                    Button10.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByRetiredId(string userID, int retiredId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, retiredId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document9.Value = "1";
                    lnkbtn_Delete9.Visible = true;
                    lnkbtn_Save9.Visible = true;
                    text9.Visible = false;
                    FileUpload9.Visible = false;
                    Button9.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByMedicalCertificateId(string userID, int medicalCertificateId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, medicalCertificateId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document8.Value = "1";
                    lnkbtn_Delete8.Visible = true;
                    lnkbtn_Save8.Visible = true;
                    text8.Visible = false;
                    FileUpload8.Visible = false;
                    Button8.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByIDProofId(string userID, int iDProofId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, iDProofId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();
                string ProofType = dt.Rows[0]["DocumentName"].ToString();
                ListItem itemProof = ddlIdproof.Items.FindByText(ProofType);
                if (itemProof != null)
                {
                    ddlIdproof.ClearSelection(); // optional, just to be sure
                    itemProof.Selected = true;
                }

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document4.Value = "1";
                    lnkbtn_Delete4.Visible = true;
                    lnkbtn_Save4.Visible = true;
                    ddlIdproof.Enabled = false;
                    text4.Visible = false;
                    FileUpload4.Visible = false;
                    Button4.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByResidentProofId(string userID, int residentProofId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, residentProofId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document3.Value = "1";
                    lnkbtn_Delete3.Visible = true;
                    lnkbtn_Save3.Visible = true;
                    text3.Visible = false;
                    FileUpload3.Visible = false;
                    Button3.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByMasterDegreeId(string userID, int masterDegreeId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, masterDegreeId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document18.Value = "1";
                    lnkbtn_Delete18.Visible = true;
                    lnkbtn_Save18.Visible = true;
                    text18.Visible = false;
                    FileUpload18.Visible = false;
                    Button18.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByDegreeId(string userID, int degreeId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, degreeId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document17.Value = "1";
                    lnkbtn_Delete17.Visible = true;
                    lnkbtn_Save17.Visible = true;
                    text17.Visible = false;
                    FileUpload17.Visible = false;
                    Button17.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentByDiplomaCertificateId(string userID, int diplomaCertificateId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, diplomaCertificateId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {


                    HdnField_Document16.Value = "1";
                    lnkbtn_Delete16.Visible = true;
                    lnkbtn_Save16.Visible = true;
                    text16.Visible = false;
                    FileUpload16.Visible = false;
                    Button16.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentbyCertificateOrDiplomaId(string userID, int certificateOrDiplomaId, object value)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, certificateOrDiplomaId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {


                    HdnField_Document15.Value = "1";
                    lnkbtn_Delete15.Visible = true;
                    lnkbtn_Save15.Visible = true;
                    text15.Visible = false;
                    FileUpload15.Visible = false;
                    Button15.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        private void GetDocumentbymatricDocumentId(string userID, int matricDocumentId)
        {
            DataTable dt = CEI.GetDocumentByUserIdAndDocId(userID, matricDocumentId, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string documentPath = dt.Rows[0]["DocumentPath"].ToString();

                if (!string.IsNullOrEmpty(documentPath))
                {
                    HdnField_Document2.Value = "1";
                    lnkbtn_Delete2.Visible = true;
                    lnkbtn_Save2.Visible = true;
                    text2.Visible = false;
                    FileUpload2.Visible = false;
                    Button2.Visible = false;
                }
                else
                {
                    ////
                }
            }
        }

        #endregion
        private void DetailsforDocuments(string userID)
        {

            DataSet ds = CEI.ToGetNewUserDetails(UserID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string Age = ds.Tables[0].Rows[0]["AgeInYears"].ToString();
                string Retired = ds.Tables[0].Rows[0]["RetiredEngineer"].ToString();
                string ApprenticeExperience = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();

                string Name12ITIDiploma = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();
                string NameofDiplomaDegree = ds.Tables[0].Rows[0]["NameofDiplomaDegree"].ToString();
                string NameofDegree = ds.Tables[0].Rows[0]["NameofDegree"].ToString();
                string NameofMasters = ds.Tables[0].Rows[0]["NameofMasters"].ToString();


                string HaveApprenticeCertificate = ds.Tables[0].Rows[0]["ExperiencedIn"].ToString();
                string Exp = ds.Tables[0].Rows[0]["ExperienceEmployerName"].ToString();
                string Exp1 = ds.Tables[0].Rows[0]["ExperienceEmployerName1"].ToString();
                string Exp2 = ds.Tables[0].Rows[0]["ExperienceEmployerName2"].ToString();
                string Exp3 = ds.Tables[0].Rows[0]["ExperienceEmployerName3"].ToString();
                string Exp4 = ds.Tables[0].Rows[0]["ExperienceEmployerName4"].ToString();
                string Exp5 = ds.Tables[0].Rows[0]["ExperienceEmployerName5"].ToString();
                string Exp6 = ds.Tables[0].Rows[0]["ExperienceEmployerName6"].ToString();
                string Exp7 = ds.Tables[0].Rows[0]["ExperienceEmployerName7"].ToString();
                string Exp8 = ds.Tables[0].Rows[0]["ExperienceEmployerName8"].ToString();
                string Exp9 = ds.Tables[0].Rows[0]["ExperienceEmployerName9"].ToString();

                HdnAge.Value = Age;
                Hdnretirment.Value = Retired;
                HdnName12ITIDiploma.Value = Name12ITIDiploma;
                HdnNameofDiplomaDegree.Value = NameofDiplomaDegree;
                HdnNameofDegree.Value = NameofDegree;
                HdnNameofMasters.Value = NameofMasters;
                HdnApprenticeExperience.Value = HaveApprenticeCertificate;

                LblExp.Text = Exp;
                LblExp1.Text = Exp1;
                LblExp2.Text = Exp2;
                LblExp3.Text = Exp3;
                LblExp4.Text = Exp4;
                LblExp5.Text = Exp5;
                LblExp6.Text = Exp6;
                LblExp7.Text = Exp7;
                LblExp8.Text = Exp8;
                LblExp9.Text = Exp9;



                HdnEXP.Value = Exp;
                HdnEXP1.Value = Exp1;
                HdnEXP2.Value = Exp2;
                HdnEXP3.Value = Exp3;
                HdnEXP4.Value = Exp4;
                HdnEXP5.Value = Exp5;
                HdnEXP6.Value = Exp6;
                HdnEXP7.Value = Exp7;
                HdnEXP8.Value = Exp8;
                HdnEXP9.Value = Exp9;
            }
            else
            {
            }
            int ageValue;
            if (int.TryParse(HdnAge.Value, out ageValue))
            {
                if (ageValue > 55)
                {
                    Medicalfitness.Visible = true;
                    Hdn_medicalcertificatevisible.Value = "yes";
                }
                else
                {
                    Medicalfitness.Visible = false;
                    Hdn_medicalcertificatevisible.Value = "";
                }
            }
            if (Hdnretirment.Value == "Yes")
            {
                Retired.Visible = true;
                Hdn_retirementcertificatevisible.Value = "yes";
            }
            else
            {
                Retired.Visible = false;
                Hdn_retirementcertificatevisible.Value = "";
            }



            //if (string.IsNullOrEmpty(HdnApprenticeExperience.Value) || HdnApprenticeExperience.Value == "Select")
            if (HdnApprenticeExperience.Value != "Apprenticeship Certificate")
            {
                Apprenticecertificate.Visible = false;
                Hdn_Apprenticecertificatevisible.Value = "";
            }
            else
            {
                Apprenticecertificate.Visible = true;
                Hdn_Apprenticecertificatevisible.Value = "yes";
            }

            #region Qualification Conditions
            if (string.IsNullOrEmpty(HdnName12ITIDiploma.Value) || HdnName12ITIDiploma.Value == "Select")
            {

                CertificateOrDiploma.Visible = false;
            }
            else
            {
                CertificateOrDiploma.Visible = true;
            }
            if (string.IsNullOrEmpty(HdnNameofDiplomaDegree.Value) || HdnNameofDiplomaDegree.Value == "Select")
            //if (HdnNameofDiplomaDegree.Value != "" && HdnNameofDiplomaDegree.Value != null)
            {
                Diploma.Visible = false;

            }
            else
            {
                Diploma.Visible = true;
            }
            //if (HdnNameofDegree.Value != "" && HdnNameofDegree.Value != null)
            if (string.IsNullOrEmpty(HdnNameofDegree.Value) || HdnNameofDegree.Value == "Select")
            {

                Degree.Visible = false;
            }
            else
            {
                Degree.Visible = true;
            }
            if (string.IsNullOrEmpty(HdnNameofMasters.Value) || HdnNameofMasters.Value == "Select")
            // if (HdnNameofMasters.Value != "" && HdnNameofMasters.Value != null)
            {
                MasterDegree.Visible = false;

            }
            else
            {
                MasterDegree.Visible = true;
            }
            #endregion
            #region Experience Conditions
            if (HdnEXP.Value != "" && HdnEXP.Value != null)
            {
                Exp.Visible = true;
            }
            else
            {
                Exp.Visible = false;
            }
            if (HdnEXP1.Value != "" && HdnEXP1.Value != null)
            {
                Exp1.Visible = true;
            }
            else
            {
                Exp1.Visible = false;
            }
            if (HdnEXP2.Value != "" && HdnEXP2.Value != null)
            {
                Exp2.Visible = true;
            }
            else
            {
                Exp2.Visible = false;
            }
            if (HdnEXP3.Value != "" && HdnEXP3.Value != null)
            {
                Exp3.Visible = true;
            }
            else
            {
                Exp3.Visible = false;
            }
            if (HdnEXP4.Value != "" && HdnEXP4.Value != null)
            {
                Exp4.Visible = true;
            }
            else
            {
                Exp4.Visible = false;
            }
            if (HdnEXP5.Value != "" && HdnEXP5.Value != null)
            {
                Exp5.Visible = true;
            }
            else
            {
                Exp5.Visible = false;
            }
            if (HdnEXP6.Value != "" && HdnEXP6.Value != null)
            {
                Exp6.Visible = true;
            }
            else
            {
                Exp6.Visible = false;
            }
            if (HdnEXP7.Value != "" && HdnEXP7.Value != null)
            {
                Exp7.Visible = true;
            }
            else
            {
                Exp7.Visible = false;
            }
            if (HdnEXP8.Value != "" && HdnEXP8.Value != null)
            {
                Exp8.Visible = true;
            }
            else
            {
                Exp8.Visible = false;
            }
            if (HdnEXP9.Value != "" && HdnEXP9.Value != null)
            {
                Exp9.Visible = true;
            }
            else
            {
                Exp9.Visible = false;
            }
            #endregion
        }

        #region Upload Documents
        protected void Button2_Click(object sender, EventArgs e)
        {
            ////if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload2, Button2, 39, lnkbtn_Delete2, lnkbtn_Save2, "Matriculation certificate indicating date of birth", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document2.Value = "1";
                    lnkbtn_Delete2.Visible = true;
                    lnkbtn_Save2.Visible = true;
                    text2.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload3, Button3, 34, lnkbtn_Delete3, lnkbtn_Save3, "Residence Proof", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document3.Value = "1";
                    lnkbtn_Delete3.Visible = true;
                    lnkbtn_Save3.Visible = true;
                    text3.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (ddlIdproof.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('Select the Id proof you want to Upload');", true);
                    return;
                }

                string selectedIdProof = ddlIdproof.SelectedItem.Text;
                string Result = SaveDocumentWithTransaction(FileUpload4, Button4, 33, lnkbtn_Delete4, lnkbtn_Save4, selectedIdProof, null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document4.Value = "1";
                    lnkbtn_Delete4.Visible = true;
                    lnkbtn_Save4.Visible = true;
                    ddlIdproof.Enabled = false;
                    text4.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            ////if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload8, Button8, 38, lnkbtn_Delete8, lnkbtn_Save8, "Medical fitness certificate", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document8.Value = "1";
                    lnkbtn_Delete8.Visible = true;
                    lnkbtn_Save8.Visible = true;
                    text8.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload9, Button9, 36, lnkbtn_Delete9, lnkbtn_Save9, "Copy of retirement orders", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document9.Value = "1";
                    lnkbtn_Delete9.Visible = true;
                    lnkbtn_Save9.Visible = true;
                    text9.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload10, Button10, 37, lnkbtn_Delete10, lnkbtn_Save10, "Apprentice Certificate", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document10.Value = "1";
                    lnkbtn_Delete10.Visible = true;
                    lnkbtn_Save10.Visible = true;
                    text10.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button11_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (string.IsNullOrWhiteSpace(txtUtrNo.Text) || string.IsNullOrWhiteSpace(txtdate.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('UTR No. and Date are required.');", true);
                    return;
                }
                string Result = SaveDocumentWithTransaction(FileUpload11, Button11, 40, lnkbtn_Delete11, lnkbtn_Save11, "Copy of treasury challan of fees deposited in any treasury of Haryana", txtUtrNo.Text, txtdate.Text, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document11.Value = "1";
                    lnkbtn_Delete11.Visible = true;
                    lnkbtn_Save11.Visible = true;
                    txtdate.ReadOnly = true;
                    txtUtrNo.ReadOnly = true;
                    text11.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button12_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransactionIfPhoto(FileUpload12, Button12, 31, lnkbtn_Delete12, "Candidate Image", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document12.Value = "1";
                    lnkbtn_Delete12.Visible = true;
                    lnkbtn_Save12.Visible = true;
                    text12.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransactionIfPhoto(FileUpload13, Button13, 32, lnkbtn_Delete13, "Candidate Signature", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document13.Value = "1";
                    lnkbtn_Delete13.Visible = true;
                    lnkbtn_Save13.Visible = true;
                    text13.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button15_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload15, Button15, 45, lnkbtn_Delete15, lnkbtn_Save15, "Certificate or Diploma in Wireman,Linemen & Electrician", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document15.Value = "1";
                    lnkbtn_Delete15.Visible = true;
                    lnkbtn_Save15.Visible = true;
                    text15.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button16_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload16, Button16, 46, lnkbtn_Delete16, lnkbtn_Save16, "Diploma Certificate", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document16.Value = "1";
                    lnkbtn_Delete16.Visible = true;
                    lnkbtn_Save16.Visible = true;
                    text16.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button17_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload17, Button17, 47, lnkbtn_Delete17, lnkbtn_Save17, "Degree Certificate", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document17.Value = "1";
                    lnkbtn_Delete17.Visible = true;
                    lnkbtn_Save17.Visible = true;
                    text17.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void Button18_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload18, Button18, 48, lnkbtn_Delete18, lnkbtn_Save18, "Master Degree Certificate", null, null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document18.Value = "1";
                    lnkbtn_Delete18.Visible = true;
                    lnkbtn_Save18.Visible = true;
                    text18.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        #endregion

        #region Delete Documents

        protected void lnkbtn_Delete2_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(Hdn_DocumentId2.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete2, lnkbtn_Save2, FileUpload2, Button2);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId, null);
                    if (IsDelete > 0)
                    {
                        ////    if (IsDelete)
                        ////{
                        HdnField_Document2.Value = "0";
                        text2.Visible = true;

                        lnkbtn_Delete2.Visible = false;
                        lnkbtn_Save2.Visible = false;
                        FileUpload2.Visible = true;
                        Button2.Visible = true;
                    }
                }
            }
        }
        protected void lnkbtn_Delete3_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            ////int fileId = Convert.ToInt32(btn.CommandArgument);
            int fileId1 = Convert.ToInt32(Hdn_DocumentId6.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId1 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete3, lnkbtn_Save3, FileUpload3, Button3);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId1, null);

                    if (IsDelete > 0)
                    {
                        ////    if (IsDelete)
                        ////{
                        HdnField_Document3.Value = "0";
                        text3.Visible = true;

                        lnkbtn_Delete3.Visible = false;
                        lnkbtn_Save3.Visible = false;
                        FileUpload3.Visible = true;
                        Button3.Visible = true;
                    }
                }
            }
        }
        protected void lnkbtn_Delete4_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            //// int fileId2 = Convert.ToInt32(btn.CommandArgument);
            int fileId2 = Convert.ToInt32(Hdn_DocumentId7.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId2 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete4, lnkbtn_Save4, FileUpload4, Button4);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId2, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        ////{
                        HdnField_Document4.Value = "0";
                        text4.Visible = true;
                        ddlIdproof.Enabled = true;
                        ddlIdproof.SelectedIndex = 0;

                        lnkbtn_Delete4.Visible = false;
                        lnkbtn_Save4.Visible = false;
                        FileUpload4.Visible = true;
                        Button4.Visible = true;
                    }
                }
            }
        }

        protected void lnkbtn_Delete8_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            ////int fileId = Convert.ToInt32(btn.CommandArgument);

            int fileId3 = Convert.ToInt32(Hdn_DocumentId8.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId3 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete8, lnkbtn_Save8, FileUpload8, Button8);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId3, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        ////{
                        HdnField_Document8.Value = "0";
                        text8.Visible = true;

                        lnkbtn_Delete8.Visible = false;
                        lnkbtn_Save8.Visible = false;
                        FileUpload8.Visible = true;
                        Button8.Visible = true;
                    }
                }
            }
        }
        protected void lnkbtn_Delete9_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            //int fileId = Convert.ToInt32(btn.CommandArgument);
            int fileId4 = Convert.ToInt32(Hdn_DocumentId9.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId4 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete9, lnkbtn_Save9, FileUpload9, Button9);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId4, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document9.Value = "0";
                            text9.Visible = true;

                            lnkbtn_Delete9.Visible = false;
                            lnkbtn_Save9.Visible = false;
                            FileUpload9.Visible = true;
                            Button9.Visible = true;
                        }
                    }
                }
            }
        }
        protected void lnkbtn_Delete10_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            //int fileId = Convert.ToInt32(btn.CommandArgument);
            int fileId5 = Convert.ToInt32(Hdn_DocumentId10.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId5 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete10, lnkbtn_Save10, FileUpload10, Button10);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId5, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document10.Value = "0";
                            text10.Visible = true;

                            lnkbtn_Delete10.Visible = false;
                            lnkbtn_Save10.Visible = false;
                            FileUpload10.Visible = true;
                            Button10.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete11_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId6 = Convert.ToInt32(Hdn_DocumentId21.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId6 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete11, lnkbtn_Save11, FileUpload11, Button11);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId6, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document11.Value = "0";
                            txtdate.ReadOnly = false;
                            txtUtrNo.ReadOnly = false;
                            text11.Visible = true;
                            txtdate.Text = "";
                            txtUtrNo.Text = "";

                            lnkbtn_Delete11.Visible = false;
                            lnkbtn_Save11.Visible = false;
                            FileUpload11.Visible = true;
                            Button11.Visible = true;
                        }
                    }
                }
            }
        }
        protected void lnkbtn_Delete12_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId7 = Convert.ToInt32(Hdn_DocumentId22.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId7 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete12, lnkbtn_Save12, FileUpload12, Button12);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId7, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document12.Value = "0";
                            text12.Visible = true;

                            lnkbtn_Delete12.Visible = false;
                            lnkbtn_Save12.Visible = false;
                            FileUpload12.Visible = true;
                            Button12.Visible = true;
                        }
                    }
                }
            }
        }
        protected void lnkbtn_Delete13_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId8 = Convert.ToInt32(Hdn_DocumentId23.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId8 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete13, lnkbtn_Save13, FileUpload13, Button13);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId8, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document13.Value = "0";
                            text13.Visible = true;

                            lnkbtn_Delete13.Visible = false;
                            lnkbtn_Save13.Visible = false;
                            FileUpload13.Visible = true;
                            Button13.Visible = true;
                        }
                    }

                }
            }
        }
        protected void lnkbtn_Delete15_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId9 = Convert.ToInt32(Hdn_DocumentId1.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId9 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete15, lnkbtn_Save15, FileUpload15, Button15);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId9, null);

                    if (IsDelete > 0)
                    {
                        {
                            HdnField_Document15.Value = "0";
                            text15.Visible = true;

                            lnkbtn_Delete15.Visible = false;
                            lnkbtn_Save15.Visible = false;
                            FileUpload15.Visible = true;
                            Button15.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete16_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId10 = Convert.ToInt32(Hdn_DocumentId3.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId10 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete16, lnkbtn_Save16, FileUpload16, Button16);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId10, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document16.Value = "0";
                            text16.Visible = true;

                            lnkbtn_Delete16.Visible = false;
                            lnkbtn_Save16.Visible = false;
                            FileUpload16.Visible = true;
                            Button16.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete17_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId11 = Convert.ToInt32(Hdn_DocumentId4.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId11 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete17, lnkbtn_Save17, FileUpload17, Button17);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId11, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document17.Value = "0";
                            text17.Visible = true;

                            lnkbtn_Delete17.Visible = false;
                            lnkbtn_Save17.Visible = false;
                            FileUpload17.Visible = true;
                            Button17.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete18_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId12 = Convert.ToInt32(Hdn_DocumentId5.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId12 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete18, lnkbtn_Save18, FileUpload18, Button18);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId12, null);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document18.Value = "0";
                            text18.Visible = true;

                            lnkbtn_Delete18.Visible = false;
                            lnkbtn_Save18.Visible = false;
                            FileUpload18.Visible = true;
                            Button18.Visible = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region Upload experience document

        protected void Button19_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload19, Button19, 35, lnkbtn_Delete19, lnkbtn_Save19, LblExp.Text + " Experience Letter1", null, null, 1);
                if (Result != null && Result != "")
                {
                    HdnField_Document19.Value = "1";
                    lnkbtn_Delete19.Visible = true;
                    lnkbtn_Save19.Visible = true;
                    text19.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload20, Button20, 35, lnkbtn_Delete20, lnkbtn_Save20, LblExp1.Text + " Experience Letter2", null, null, 2);
                if (Result != null && Result != "")
                {
                    HdnField_Document20.Value = "1";
                    lnkbtn_Delete20.Visible = true;
                    lnkbtn_Save20.Visible = true;
                    text20.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload21, Button21, 35, lnkbtn_Delete21, lnkbtn_Save21, LblExp2.Text + " Experience Letter3", null, null, 3);
                if (Result != null && Result != "")
                {
                    HdnField_Document21.Value = "1";
                    lnkbtn_Delete21.Visible = true;
                    lnkbtn_Save21.Visible = true;
                    text21.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload22, Button22, 35, lnkbtn_Delete22, lnkbtn_Save22, LblExp3.Text + " Experience Letter4", null, null, 4);
                if (Result != null && Result != "")
                {
                    HdnField_Document22.Value = "1";
                    lnkbtn_Delete22.Visible = true;
                    lnkbtn_Save22.Visible = true;
                    text22.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload23, Button23, 35, lnkbtn_Delete23, lnkbtn_Save23, LblExp4.Text + " Experience Letter5", null, null, 5);
                if (Result != null && Result != "")
                {
                    HdnField_Document23.Value = "1";
                    lnkbtn_Delete23.Visible = true;
                    lnkbtn_Save23.Visible = true;
                    text23.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload24, Button24, 35, lnkbtn_Delete24, lnkbtn_Save24, LblExp5.Text + " Experience Letter6", null, null, 6);
                if (Result != null && Result != "")
                {
                    HdnField_Document24.Value = "1";
                    lnkbtn_Delete24.Visible = true;
                    lnkbtn_Save24.Visible = true;
                    text24.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload25, Button25, 35, lnkbtn_Delete25, lnkbtn_Save25, LblExp6.Text + " Experience Letter7", null, null, 7);
                if (Result != null && Result != "")
                {
                    HdnField_Document25.Value = "1";
                    lnkbtn_Delete25.Visible = true;
                    lnkbtn_Save25.Visible = true;
                    text25.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload26, Button26, 35, lnkbtn_Delete26, lnkbtn_Save26, LblExp7.Text + " Experience Letter8", null, null, 8);
                if (Result != null && Result != "")
                {
                    HdnField_Document26.Value = "1";
                    lnkbtn_Delete26.Visible = true;
                    lnkbtn_Save26.Visible = true;
                    text26.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button27_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload27, Button27, 35, lnkbtn_Delete27, lnkbtn_Save27, LblExp8.Text + " Experience Letter9", null, null, 9);
                if (Result != null && Result != "")
                {
                    HdnField_Document27.Value = "1";
                    lnkbtn_Delete27.Visible = true;
                    lnkbtn_Save27.Visible = true;
                    text27.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void Button28_Click(object sender, EventArgs e)
        {
            //// if (IsSessionValid())
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                string Result = SaveDocumentWithTransaction(FileUpload28, Button28, 35, lnkbtn_Delete28, lnkbtn_Save28, LblExp9.Text + " Experience Letter10", null, null, 10);

                if (Result != null && Result != "")
                {
                    HdnField_Document28.Value = "1";
                    lnkbtn_Delete28.Visible = true;
                    lnkbtn_Save28.Visible = true;
                    text28.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        #endregion

        #region Delete experience Documents

        protected void lnkbtn_Delete19_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId13 = Convert.ToInt32(Hdn_DocumentId11.Value);
            int fileId13SUB1 = Convert.ToInt32(Hdn_SUBDocumentId11.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId13 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete19, lnkbtn_Save19, FileUpload19, Button19);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId13, fileId13SUB1);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document19.Value = "0";
                            text19.Visible = true;

                            lnkbtn_Delete19.Visible = false;
                            lnkbtn_Save19.Visible = false;
                            FileUpload19.Visible = true;
                            Button19.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete20_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId14 = Convert.ToInt32(Hdn_DocumentId12.Value);
            int fileId14SUB = Convert.ToInt32(Hdn_SUBDocumentId12.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId14 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete20, lnkbtn_Save20, FileUpload20, Button20);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId14, fileId14SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document20.Value = "0";
                            text20.Visible = true;

                            lnkbtn_Delete20.Visible = false;
                            lnkbtn_Save20.Visible = false;
                            FileUpload20.Visible = true;
                            Button20.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete21_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId15 = Convert.ToInt32(Hdn_DocumentId13.Value);
            int fileId15SUB = Convert.ToInt32(Hdn_SUBDocumentId13.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId15 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete21, lnkbtn_Save21, FileUpload21, Button21);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId15, fileId15SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document21.Value = "0";
                            text21.Visible = true;

                            lnkbtn_Delete21.Visible = false;
                            lnkbtn_Save21.Visible = false;
                            FileUpload21.Visible = true;
                            Button21.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete22_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId16 = Convert.ToInt32(Hdn_DocumentId14.Value);
            int fileId16SUB = Convert.ToInt32(Hdn_SUBDocumentId14.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId16 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete22, lnkbtn_Save22, FileUpload22, Button22);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId16, fileId16SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document22.Value = "0";
                            text22.Visible = true;

                            lnkbtn_Delete22.Visible = false;
                            lnkbtn_Save22.Visible = false;
                            FileUpload22.Visible = true;
                            Button22.Visible = true;
                        }
                    }
                }
            }
        }
        protected void lnkbtn_Delete23_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId17 = Convert.ToInt32(Hdn_DocumentId15.Value);
            int fileId17SUB = Convert.ToInt32(Hdn_SUBDocumentId15.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId17 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete23, lnkbtn_Save23, FileUpload23, Button23);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId17, fileId17SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document23.Value = "0";
                            text23.Visible = true;

                            lnkbtn_Delete23.Visible = false;
                            lnkbtn_Save23.Visible = false;
                            FileUpload23.Visible = true;
                            Button23.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete24_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId18 = Convert.ToInt32(Hdn_DocumentId16.Value);
            int fileId18SUB = Convert.ToInt32(Hdn_SUBDocumentId16.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId18 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete24, lnkbtn_Save24, FileUpload24, Button24);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId18, fileId18SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document24.Value = "0";
                            text24.Visible = true;

                            lnkbtn_Delete24.Visible = false;
                            lnkbtn_Save24.Visible = false;
                            FileUpload24.Visible = true;
                            Button24.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete25_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId19 = Convert.ToInt32(Hdn_DocumentId17.Value);
            int fileId19SUB = Convert.ToInt32(Hdn_SUBDocumentId17.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId19 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete25, lnkbtn_Save25, FileUpload25, Button25);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId19, fileId19SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document25.Value = "0";
                            text25.Visible = true;

                            lnkbtn_Delete25.Visible = false;
                            lnkbtn_Save25.Visible = false;
                            FileUpload25.Visible = true;
                            Button25.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete26_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId20 = Convert.ToInt32(Hdn_DocumentId18.Value);
            int fileId20SUB = Convert.ToInt32(Hdn_SUBDocumentId18.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId20 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete26, lnkbtn_Save26, FileUpload26, Button26);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId20, fileId20SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document26.Value = "0";
                            text26.Visible = true;

                            lnkbtn_Delete26.Visible = false;
                            lnkbtn_Save26.Visible = false;
                            FileUpload26.Visible = true;
                            Button26.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete27_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId21 = Convert.ToInt32(Hdn_DocumentId19.Value);
            int fileId21SUB = Convert.ToInt32(Hdn_SUBDocumentId19.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId21 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete27, lnkbtn_Save27, FileUpload27, Button27);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId21, fileId21SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document27.Value = "0";
                            text27.Visible = true;

                            lnkbtn_Delete27.Visible = false;
                            lnkbtn_Save27.Visible = false;
                            FileUpload27.Visible = true;
                            Button27.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkbtn_Delete28_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId22 = Convert.ToInt32(Hdn_DocumentId20.Value);
            int fileId22SUB = Convert.ToInt32(Hdn_SUBDocumentId20.Value);
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (fileId22 != 0)
                {
                    ////bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete28, lnkbtn_Save28, FileUpload28, Button28);
                    int IsDelete = CEI.DeleteDocumentOfNewUserWiremanAndSupervisor(Convert.ToString(HdnUserId.Value), fileId22, fileId22SUB);

                    if (IsDelete > 0)
                    {
                        ////if (IsDelete)
                        {
                            HdnField_Document28.Value = "0";
                            text28.Visible = true;

                            lnkbtn_Delete28.Visible = false;
                            lnkbtn_Save28.Visible = false;
                            FileUpload28.Visible = true;
                            Button28.Visible = true;
                        }
                    }
                }
            }
        }
        #endregion

        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            if (HdnUserType.Value == "Supervisor")
            {
                Response.Redirect("/UserPages/Supervisor_Registration_Details.aspx", false);
            }
            else if (HdnUserType.Value == "Wireman")
            {
                Response.Redirect("/UserPages/Wireman_Registration_Details.aspx", false);
            }
        }
        private bool IsValidPhoto(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile) return false;

            string ext = Path.GetExtension(fileUpload.FileName).ToLower();
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png") return false;

            if (fileUpload.PostedFile.ContentLength > 1048576) return false; // 1MB

            return true;
        }
        private string SaveDocumentWithTransactionIfPhoto(FileUpload fileUpload, Button uploadbutton, int DocumentId, LinkButton deleteButton, string documentName, string Utrn, string challandate, int? DocumentSubId)
        {
            string fileName = ""; string dbPath = ""; string fullPath = ""; string CurrentStatus = "";

            string CreatedBy = Convert.ToString(HdnUserId.Value);
            /// long TempUniqueId = (long)Session["TempUniqueId"];
            DataTable dt = CEI.ToGetStatusOfNewLicenceRequest(CreatedBy);

            if (dt != null && dt.Rows.Count > 0)
            {
               CurrentStatus = dt.Rows[0]["TypeOfRequest"].ToString();
            }
            string DocumentNametoSave = documentName.Replace(" ", "_").Replace("/", "_");

            if (!fileUpload.HasFile || !IsValidPhoto(fileUpload))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload a valid image file (.jpg, .jpeg, .png) (Max: 1MB)');", true);
                fileUpload.Focus();
                return null;
            }

            // Ensure directory exists
            string directoryPath = Server.MapPath($"~/Attachment/License_Documents/{CreatedBy}/");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Get extension and generate file name accordingly
            string extension = Path.GetExtension(fileUpload.FileName).ToLower();
            fileName = $"{DocumentNametoSave}_{DateTime.Now:yyyyMMddHHmmssFFF}{extension}";
            dbPath = $"/Attachment/License_Documents/{CreatedBy}/{fileName}";
            fullPath = Path.Combine(directoryPath, fileName);

            // Save image file
            fileUpload.SaveAs(fullPath);

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string documentId = CEI.InsertDocumentOfNewUserApplication(documentName, DocumentId, fileName, dbPath, Utrn, challandate, DocumentSubId, CreatedBy, CurrentStatus, transaction);
                    if (!string.IsNullOrEmpty(documentId))
                    {
                        deleteButton.CommandArgument = documentId;
                        fileUpload.Visible = false;
                        uploadbutton.Visible = false;
                        deleteButton.Visible = true;
                        //tickButton.Visible = true;
                        transaction.Commit();
                        return documentId;
                    }
                    else
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    return null;
                }
                finally
                {
                    transaction?.Dispose();
                    connection.Close();
                }
            }
        }
        private bool IsValidPdf(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile)
            {
                return false;
            }
            if (Path.GetExtension(fileUpload.FileName).ToLower() != ".pdf")
            {
                return false;
            }
            if (fileUpload.PostedFile.ContentLength > 1048576)   // Check file size (1 MB = 1048576 bytes)
            {
                return false;
            }
            return true;
        }
        private string SaveDocumentWithTransaction(FileUpload fileUpload, Button uploadbutton, int DocumentId, LinkButton deleteButton, LinkButton tickButton, string documentName, string Utrn, string challandate, int? DocumentSubId)
        {
            string fileName = ""; string dbPath = ""; string fullPath = ""; string CurrentStatus = "";

            string CreatedBy = Convert.ToString(HdnUserId.Value);
            ////long TempUniqueId = (long)Session["TempUniqueId"];
            DataTable dt = CEI.ToGetStatusOfNewLicenceRequest(CreatedBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                CurrentStatus = dt.Rows[0]["TypeOfRequest"].ToString();
            }
            string DocumentNametoSave = documentName.Replace(" ", "_").Replace("/", "_");

            if (!fileUpload.HasFile || !IsValidPdf(fileUpload))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload a valid PDF file (Max: 1MB)');", true);
                fileUpload.Focus();
                return null;
            }
            // Ensure directory exists
            ////string directoryPath = Server.MapPath($"~/Attachment/License_Documents/{TempUniqueId}/{CreatedBy}/");
            string directoryPath = Server.MapPath($"~/Attachment/License_Documents/{CreatedBy}/");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Generate file path and name
            fileName = $"{DocumentNametoSave}_{DateTime.Now:yyyyMMddHHmmssFFF}.pdf";
            ////dbPath = $"/Attachment/License_Documents/{TempUniqueId}/{CreatedBy}/{fileName}";
            dbPath = $"/Attachment/License_Documents/{CreatedBy}/{fileName}";
            fullPath = Path.Combine(directoryPath, fileName);

            // Save the uploaded file to the server folder
            fileUpload.SaveAs(fullPath);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string documentId = CEI.InsertDocumentOfNewUserApplication(documentName, DocumentId, fileName, dbPath, Utrn, challandate, DocumentSubId, CreatedBy, CurrentStatus, transaction);
                    if (!string.IsNullOrEmpty(documentId))
                    {
                        deleteButton.CommandArgument = documentId;
                        fileUpload.Visible = false;
                        uploadbutton.Visible = false;
                        deleteButton.Visible = true;
                        tickButton.Visible = true;
                        transaction.Commit();
                        return documentId;
                    }
                    else
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    return null;
                }
                finally
                {
                    transaction?.Dispose();
                    connection.Close();
                }
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (HdnUserId.Value == Convert.ToString(Session["WiremanId"])||HdnUserId.Value == Convert.ToString(Session["SupervisorID"]))
                {
                    if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
                    {
                        if (chkDeclaration.Checked == true)
                        {
                            bool allMandatoryUploaded = true;
                            string errorMessage = "";

                            if (HdnField_Document2.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Matriculation certificate indicating date of birth.<br>"; }
                            if (HdnField_Document3.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Residence Proof.<br>"; }
                            if (HdnField_Document4.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Identity Proof.<br>"; }
                            ////if (HdnField_Document5.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Degree/Diploma in Electrical Engineering/Electrical and Electronics Engineering or its equivalent.<br>"; }
                            ////if (HdnField_Document6.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            if (Convert.ToString(Hdn_medicalcertificatevisible.Value) == "yes" && Convert.ToString(Hdn_medicalcertificatevisible.Value) != "")
                            {
                                if (HdnField_Document8.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Medical fitness certificate (for age > 55).<br>"; }
                            }
                            if (Convert.ToString(Hdn_retirementcertificatevisible.Value) == "yes" && Convert.ToString(Hdn_retirementcertificatevisible.Value) != "")
                            {
                                if (HdnField_Document9.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Copy of retirement orders.<br>"; }
                            }
                            if (Convert.ToString(Hdn_Apprenticecertificatevisible.Value) == "yes" && Convert.ToString(Hdn_Apprenticecertificatevisible.Value) != "")
                            {
                                if (HdnField_Document10.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Apprentice Certificate.<br>"; }
                            }
                            if (HdnField_Document11.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Copy of treasury challan.<br>"; }
                            if (HdnField_Document12.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Candidate Image.<br>"; }
                            if (HdnField_Document13.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Candidate Signature.<br>"; }

                            if (CertificateOrDiploma.Visible)
                            {
                                if (HdnField_Document15.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Certificate or Diploma in Wireman,Linemen & Electrician.<br>"; }
                            }

                            if (Diploma.Visible)
                            {

                                if (HdnField_Document16.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Diploma Certificate.<br>"; }
                            }
                            if (Degree.Visible)
                            {
                                if (HdnField_Document17.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Degree Certificate.<br>"; }
                            }
                            if (MasterDegree.Visible)
                            {
                                if (HdnField_Document18.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Master Degree Certificate.<br>"; }
                            }
                            if (Exp.Visible)
                            {
                                if (HdnField_Document19.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp1.Visible)
                            {
                                if (HdnField_Document20.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp2.Visible)
                            {
                                if (HdnField_Document21.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp3.Visible)
                            {
                                if (HdnField_Document22.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp4.Visible)
                            {
                                if (HdnField_Document23.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp5.Visible)
                            {
                                if (HdnField_Document24.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp6.Visible)
                            {
                                if (HdnField_Document25.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp7.Visible)
                            {
                                if (HdnField_Document26.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp8.Visible)
                            {
                                if (HdnField_Document27.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (Exp9.Visible)
                            {
                                if (HdnField_Document28.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Experience Certificate.<br>"; }
                            }
                            if (!allMandatoryUploaded)
                            {
                                string[] lines = errorMessage.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
                                string formattedMessage = ""; for (int i = 0; i < lines.Length; i++)
                                {
                                    formattedMessage += $"{i + 1}. {lines[i].Trim()}\\n";
                                }

                                string script = $"alert('{formattedMessage}');";
                                ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", script, true);
                                return;
                            }
                            ////string UniqueNumber = Session["TempUniqueId"].ToString().Trim();
                            ////if (Convert.ToString(UniqueNumber) != null && Convert.ToString(UniqueNumber) != "")
                            ////{
                            //// CEI.ToSaveDocumentsdataofNewregistration(UniqueNumber, HdnUserId.Value, HdnUserType.Value);
                            CEI.ToSaveDocumentsdataofNewregistration(HdnUserId.Value);
                            DataTable dt = CEI.GetApplicationStatusByUserId(HdnUserId.Value);
                            string CurrentStatus = "";
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                CurrentStatus = dt.Rows[0]["ApplicationStatus"].ToString();
                            }
                            CEI.InsertNewLicenceApplicationFromCEIByRegistrationNo("New", HdnUserId.Value, CurrentStatus);
                            ////Session["TempUniqueId"] = "";
                            ////Session["TempUniqueId"] = null;
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "if (confirm('New User Registration Process completed successfully.')) { window.location.href = '/AdminLogout.aspx'; }", true);
                            Response.Redirect("/UserPages/New_Application_Status.aspx", false);

                            //// }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        ////private bool DeleteDocumentWithTransaction(int documentId, LinkButton deleteButton, LinkButton tickButton, FileUpload fileUpload, Button uploadButton)
        ////{
        ////    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
        ////    {
        ////        SqlTransaction transaction = null;
        ////        try
        ////        {
        ////            connection.Open();
        ////            transaction = connection.BeginTransaction();
        ////            string documentPath = null;
        ////            using (SqlCommand cmd = new SqlCommand("sp_GetDocumentPathOfNewUser", connection, transaction))
        ////            {
        ////                cmd.CommandType = CommandType.StoredProcedure;
        ////                cmd.Parameters.AddWithValue("@DocumentId", documentId);
        ////                object result = cmd.ExecuteScalar();
        ////                if (result != null)
        ////                {
        ////                    documentPath = result.ToString();
        ////                }
        ////            }
        ////            // Delete from the database
        ////            using (SqlCommand cmd = new SqlCommand("sp_DeleteDocumentOfNewUser", connection, transaction))
        ////            {
        ////                cmd.CommandType = CommandType.StoredProcedure;
        ////                cmd.Parameters.AddWithValue("@DocumentId", documentId);
        ////                int rowsAffected = cmd.ExecuteNonQuery();
        ////                if (rowsAffected == 0)
        ////                {
        ////                    transaction.Rollback();
        ////                    return false;
        ////                }
        ////            }
        ////            // Delete from the server
        ////            if (!string.IsNullOrEmpty(documentPath))
        ////            {
        ////                string fullPath = Server.MapPath(documentPath);
        ////                if (File.Exists(fullPath))
        ////                {
        ////                    File.Delete(fullPath);
        ////                }
        ////            }
        ////            transaction.Commit();
        ////            // Reset UI Elements
        ////            fileUpload.Visible = true;
        ////            uploadButton.Visible = true;
        ////            deleteButton.Visible = false;
        ////            tickButton.Visible = false;
        ////            return true;
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            transaction?.Rollback();
        ////            string errorMessage = ex.Message.Replace("'", "\\'");
        ////            ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
        ////            return false;
        ////        }
        ////        finally
        ////        {
        ////            transaction?.Dispose();
        ////            connection.Close();
        ////        }
        ////    }
        ////}
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/AdminLogout.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {
                if (Convert.ToString(HdnUserType.Value) != null && Convert.ToString(HdnUserType.Value) != "")
                {
                    if (HdnUserType.Value == "Supervisor")
                    {
                        CEI.BackToEditDetailsOfNewRegisteredUser(HdnUserId.Value);
                        Session["UserIDForEdit"] = Convert.ToString(HdnUserId.Value);

                        Response.Redirect("/UserPages/Update_Supervisor_Qualification.aspx", false);
                    }
                    else if (HdnUserType.Value == "Wireman")
                    {
                        CEI.BackToEditDetailsOfNewRegisteredUser(HdnUserId.Value);
                        Session["UserIDForEdit"] = Convert.ToString(HdnUserId.Value);

                        Response.Redirect("/UserPages/Update_Wireman_Qualification.aspx", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Edit!!!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Edit!!!')", true);
            }
        }

        ////private bool IsSessionValid()
        ////{
        ////    if (!string.IsNullOrEmpty(Convert.ToString(HdnUserId.Value)))
        ////    {
        ////        if (string.IsNullOrEmpty(Convert.ToString(Session["TempUniqueId"])))
        ////        {
        ////            GenerateUniqueTempId();
        ////        }
        ////        return true;
        ////    }
        ////    return false;
        ////}
        ////private void GenerateUniqueTempId()
        ////{
        ////    Session["TempUniqueId"] = "";
        ////    Random rnd = new Random();
        ////    int randomNumber = rnd.Next(1000000000, int.MaxValue);
        ////    string currentDate = DateTime.Now.ToString("ddMMyyyy");

        ////    string combined = randomNumber.ToString() + currentDate; // "127878893816042025"
        ////    long finalNumber = long.Parse(combined); // Convert to long
        ////    Session["TempUniqueId"] = finalNumber;
        ////}

    }
}