using CEIHaryana.Contractor;
using CEIHaryana.Model.Industry;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;
using static System.Net.WebRequestMethods;

namespace CEI_PRoject
{

    public class CEI
    {
        private int tCounter = 1;
        private int lCounter = 1;
        private SqlParameter outputParam;
        #region Bind DropDown Draw State
        public DataSet WorkIntimationGridData(string LicenceNo)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationGridData", LicenceNo);
        }
        #endregion

        #region AdminLogin
        public int checkLogin(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_Admin_Login";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //AdvNo = (string)ViewState["AdvNo"];
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20).Value = UserName;
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 20).Value = Password;
            cmd.Parameters.Add(new SqlParameter("@ret", SqlDbType.NVarChar, 50));
            cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
            outputParam = new SqlParameter("@Status", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            int k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
            return k;
        }
        public string Status()
        {
            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion

        public int checkUserLogin(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_LoginMaster";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //AdvNo = (string)ViewState["AdvNo"];
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 40).Value = UserName;
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 40).Value = Password;
            cmd.Parameters.Add(new SqlParameter("@ret", SqlDbType.NVarChar, 50));
            cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
            outputParam = new SqlParameter("@Status", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            int k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
            return k;
        }

        #region Check ApplicationStatus
        public DataSet checkApplicationStatus(string UserName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApplicationStatus", UserName);
        }
        //public void checkApplicationStatus(string UserName)
        //{
        //    SqlConnection con = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    string sqlProc = "sp_ApplicationStatus";

        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = sqlProc;
        //    cmd.Connection = con;
        //    cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 50).Value = UserName;
        //    cmd.ExecuteNonQuery();
        //}

        #endregion
        #region UpdateInspection
        public void UpdateInspectionData(string Id_Update, string TestRportId, string Inspectiontype, string ApplicantType, string InstallationType,
              string VoltageLevel, string RequestLetterFromConcernedOfficer, string ManufacturingTestReportOfEqipment,
              string SingleLineDiagramOfLine, string DemandNoticeOfLine, string CopyOfNoticeIssuedByUHBVNorDHBVN,
              string InvoiceOfTransferOfPersonalSubstation, string ManufacturingTestCertificateOfTransformer,
              string SingleLineDiagramofTransformer, string InvoiceoffireExtinguisheratSite, string InvoiceOfDGSetOfGeneratingSet,
              string ManufacturingCerificateOfDGSet, string InvoiceOfExptinguisherOrApparatusAtsite,
              string StructureStabilityResolvedByAuthorizedEngineer, string Staff, string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateInspection");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id_Update);
            cmd.Parameters.AddWithValue("@TestRportId ", TestRportId);
            //  cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel ", VoltageLevel);
            cmd.Parameters.AddWithValue("@RequestLetterFromConcernedOfficer ", RequestLetterFromConcernedOfficer);
            cmd.Parameters.AddWithValue("@ManufacturingTestReportOfEqipment ", ManufacturingTestReportOfEqipment);
            cmd.Parameters.AddWithValue("@SingleLineDiagramOfLine ", SingleLineDiagramOfLine);
            cmd.Parameters.AddWithValue("@DemandNoticeOfLine ", DemandNoticeOfLine);
            cmd.Parameters.AddWithValue("@CopyOfNoticeIssuedByUHBVNorDHBVN ", CopyOfNoticeIssuedByUHBVNorDHBVN);
            cmd.Parameters.AddWithValue("@InvoiceOfTransferOfPersonalSubstation ", InvoiceOfTransferOfPersonalSubstation);
            cmd.Parameters.AddWithValue("@ManufacturingTestCertificateOfTransformer ", ManufacturingTestCertificateOfTransformer);
            cmd.Parameters.AddWithValue("@SingleLineDiagramofTransformer ", SingleLineDiagramofTransformer);
            cmd.Parameters.AddWithValue("@InvoiceoffireExtinguisheratSite ", InvoiceoffireExtinguisheratSite);
            cmd.Parameters.AddWithValue("@InvoiceOfDGSetOfGeneratingSet ", InvoiceOfDGSetOfGeneratingSet);
            cmd.Parameters.AddWithValue("@ManufacturingCerificateOfDGSet ", ManufacturingCerificateOfDGSet);
            cmd.Parameters.AddWithValue("@InvoiceOfExptinguisherOrApparatusAtsite ", InvoiceOfExptinguisherOrApparatusAtsite);
            cmd.Parameters.AddWithValue("@StructureStabilityResolvedByAuthorizedEngineer ", StructureStabilityResolvedByAuthorizedEngineer);
            cmd.Parameters.AddWithValue("@Staff", Staff);
            //cmd.Parameters.AddWithValue("@Division", Division);              
            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Intimtion Data
        public void IntimationDataInsertion(string Id, string ContractorId, string ApplicantTypeCode, string PowerUtility, string PowerUtilityWing, string ZoneName,
         string CircleName, string DivisionName, string SubDivisionName,
         string ContractorType, string NameOfOwner, string NameOfAgency, string ContactNo, string Address, string District, string Pincode,
         string PremisesType, string OtherPremises, string VoltageLevel, string PANNumber, string TypeOfInstallation1, string NumberOfInstallation1, string TypeOfInstallation2, string NumberOfInstallation2,
         string TypeOfInstallation3, string NumberOfInstallation3,
         //string TypeOfInstallation4, string NumberOfInstallation4, string TypeOfInstallation5, string NumberOfInstallation5,
         //string TypeOfInstallation6, string NumberOfInstallation6, string TypeOfInstallation7, string NumberOfInstallation7, string TypeOfInstallation8, string NumberOfInstallation8,
         string Email, string WorkStartDate, string CompletionDate,
         string AnyWorkIssued, string CopyOfWorkOrder, string CompletionDateasPerOrder, string ApplicantType, string CreatedBy, string SanctionLoad, string InspectionType, string TotalCapacity,
         SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_WorkIntimationRegistration", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ContractorId", ContractorId);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantTypeCode);     //
            cmd.Parameters.AddWithValue("@ContractorType", ContractorType);
            cmd.Parameters.AddWithValue("@PowerUtility", PowerUtility == "Select" ? DBNull.Value : (object)PowerUtility);        //*
            cmd.Parameters.AddWithValue("@PowerUtilityWing", PowerUtilityWing == "Select" ? DBNull.Value : (object)PowerUtilityWing);//*
            cmd.Parameters.AddWithValue("@ZoneName", ZoneName == "Select" ? DBNull.Value : (object)ZoneName);
            cmd.Parameters.AddWithValue("@CircleName", CircleName == "Select" ? DBNull.Value : (object)CircleName);
            cmd.Parameters.AddWithValue("@DivisionName", DivisionName == "Select" ? DBNull.Value : (object)DivisionName);
            cmd.Parameters.AddWithValue("@SubDivisionName", SubDivisionName == "Select" ? DBNull.Value : (object)SubDivisionName);
            cmd.Parameters.AddWithValue("@NameOfOwner", String.IsNullOrEmpty(NameOfOwner) ? DBNull.Value : (object)NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", String.IsNullOrEmpty(NameOfAgency) ? DBNull.Value : (object)NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@Address", String.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
            cmd.Parameters.AddWithValue("@District", String.IsNullOrEmpty(District) ? DBNull.Value : (object)District);
            cmd.Parameters.AddWithValue("@Pincode", String.IsNullOrEmpty(Pincode) ? DBNull.Value : (object)Pincode);
            cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
            cmd.Parameters.AddWithValue("@OtherPremises", String.IsNullOrEmpty(OtherPremises) ? DBNull.Value : (object)OtherPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@PANNumber", String.IsNullOrEmpty(PANNumber) ? DBNull.Value : (object)PANNumber);
            cmd.Parameters.AddWithValue("@TypeOfInstallation1", TypeOfInstallation1);
            cmd.Parameters.AddWithValue("@NumberOfInstallation1", NumberOfInstallation1);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", String.IsNullOrEmpty(TypeOfInstallation2) ? DBNull.Value : (object)TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@NumberOfInstallation2", String.IsNullOrEmpty(NumberOfInstallation2) ? DBNull.Value : (object)NumberOfInstallation2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", String.IsNullOrEmpty(TypeOfInstallation3) ? DBNull.Value : (object)TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@NumberOfInstallation3", String.IsNullOrEmpty(NumberOfInstallation3) ? DBNull.Value : (object)NumberOfInstallation3);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation4", String.IsNullOrEmpty(TypeOfInstallation4) ? DBNull.Value : (object)TypeOfInstallation4);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation4", String.IsNullOrEmpty(NumberOfInstallation4) ? DBNull.Value : (object)NumberOfInstallation4);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation5", String.IsNullOrEmpty(TypeOfInstallation5) ? DBNull.Value : (object)TypeOfInstallation5);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation5", String.IsNullOrEmpty(NumberOfInstallation5) ? DBNull.Value : (object)NumberOfInstallation5);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation6", String.IsNullOrEmpty(TypeOfInstallation6) ? DBNull.Value : (object)TypeOfInstallation6);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation6", String.IsNullOrEmpty(NumberOfInstallation6) ? DBNull.Value : (object)NumberOfInstallation6);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation7", String.IsNullOrEmpty (TypeOfInstallation7) ? DBNull.Value : (object)TypeOfInstallation7);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation7", String.IsNullOrEmpty(NumberOfInstallation7) ? DBNull.Value : (object)NumberOfInstallation7);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation8", String.IsNullOrEmpty(TypeOfInstallation8) ? DBNull.Value : (object)TypeOfInstallation8);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation8", String.IsNullOrEmpty(NumberOfInstallation8) ? DBNull.Value : (object)NumberOfInstallation8);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@WorkStartDate", WorkStartDate);
            cmd.Parameters.AddWithValue("@CompletionDate", CompletionDate);
            cmd.Parameters.AddWithValue("@AnyWorkIssued", AnyWorkIssued);
            cmd.Parameters.AddWithValue("@CopyOfWorkOrder", String.IsNullOrEmpty(CopyOfWorkOrder) ? DBNull.Value : (object)CopyOfWorkOrder);
            //cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateasPerOrder);
            DateTime CompletionDateForOrder;
            if (DateTime.TryParse(CompletionDateasPerOrder, out CompletionDateForOrder) && CompletionDateForOrder != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateForOrder);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@SanctionLoad", SanctionLoad);
            cmd.Parameters.AddWithValue("@InspectionType", InspectionType);
            cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

        }
        public string projectId()
        {
            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        public void AddInstallations(string IntimationId, string Typeofinstallation, int Noofinstallation, string CreatedBy, string TypeOfInspection, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InstallationsCount", transaction.Connection, transaction);
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Typeofinstallation", Typeofinstallation);
            cmd.Parameters.AddWithValue("@Noofinstallation", Noofinstallation);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@InspectionType", TypeOfInspection);
            cmd.ExecuteNonQuery();
            //con.Close();
        }

        public void UpdateInstallations(string Id, string IntimationId)
        {
            SqlCommand cmd = new SqlCommand("sp_CheckTestReportHistory");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateInstallations(string Id, string IntimationId, SqlTransaction transaction)
        {

            SqlCommand cmd = new SqlCommand("sp_CheckTestReportHistory", transaction.Connection, transaction);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.ExecuteNonQuery();
            //con.Close();

        }
        public DataSet InsertSiteOwnerData(string SiteOwnerUserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertSiteOwnerLogin", SiteOwnerUserId);
        }

        #endregion
        #region Insert Supervisor Data
        public void InserSupervisorData(string REID, string Name, string Age, string FatherName, string Address, string District, string State, string PinCode, string PhoneNo,
      string Qualification, string Email, string CertificateOld, string CertificateNew, string DateofIntialissue, string DateofExpiry,
      string DateofRenewal, string votagelevel, string voltageWithEffect, string AnyContractor, string AttachedContractorld,
    string CreatedBy, string UserId, string NewUserId, string IPAddress)
        {

            SqlCommand cmd = new SqlCommand("sp_SetWiremanandSuperwiserDetails");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            #region old Code
            //cmd.Parameters.AddWithValue("@REID", REID);
            //cmd.Parameters.AddWithValue("@Name", Name);
            //cmd.Parameters.AddWithValue("@Age", Age);
            //cmd.Parameters.AddWithValue("@FatherName", FatherName);
            //cmd.Parameters.AddWithValue("@Address", Address);
            //cmd.Parameters.AddWithValue("@District", District);
            //cmd.Parameters.AddWithValue("@State", State);
            //cmd.Parameters.AddWithValue("@PinCode", PinCode);
            //cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            //cmd.Parameters.AddWithValue("@Qualification", Qualification);
            //cmd.Parameters.AddWithValue("@Email", Email);
            //cmd.Parameters.AddWithValue("@CertificateOld", CertificateOld);
            //cmd.Parameters.AddWithValue("@CertificateNew", CertificateNew);
            //cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            //cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            //cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            //cmd.Parameters.AddWithValue("@votagelevel", votagelevel);
            //cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect);
            //cmd.Parameters.AddWithValue("@AnyContractor", AnyContractor);
            //cmd.Parameters.AddWithValue("@AttachedContractorld", AttachedContractorld);
            //cmd.Parameters.AddWithValue("@Category", "Supervisor");
            //cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
            //cmd.Parameters.AddWithValue("@UserId", UserId);
            // cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            #endregion

            cmd.Parameters.AddWithValue("@REID", REID);
            cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(Name) ? DBNull.Value : (object)Name);
            cmd.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(Age) ? DBNull.Value : (object)Age);
            cmd.Parameters.AddWithValue("@FatherName", string.IsNullOrEmpty(FatherName) ? DBNull.Value : (object)FatherName);
            cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
            cmd.Parameters.AddWithValue("@District", District == "Select" ? DBNull.Value : (object)District);
            cmd.Parameters.AddWithValue("@State", State == "Select" ? DBNull.Value : (object)State);
            cmd.Parameters.AddWithValue("@PinCode", string.IsNullOrEmpty(PinCode) ? DBNull.Value : (object)PinCode);
            cmd.Parameters.AddWithValue("@PhoneNo", string.IsNullOrEmpty(PhoneNo) ? DBNull.Value : (object)PhoneNo);
            cmd.Parameters.AddWithValue("@Qualification", Qualification == "Select" ? DBNull.Value : (object)Qualification);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
            cmd.Parameters.AddWithValue("@CertificateOld", string.IsNullOrEmpty(CertificateOld) ? DBNull.Value : (object)CertificateOld);
            cmd.Parameters.AddWithValue("@CertificateNew", string.IsNullOrEmpty(CertificateNew) ? DBNull.Value : (object)CertificateNew);
            cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            //DateTime initialIssueDate;
            //if (DateTime.TryParse(DateofIntialissue, out initialIssueDate) && initialIssueDate != DateTime.MinValue)
            //{
            //    cmd.Parameters.AddWithValue("@DateofIntialissue", initialIssueDate);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@DateofIntialissue", DBNull.Value);
            //}
            cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            //DateTime expiryDate;
            //if (DateTime.TryParse(DateofExpiry, out expiryDate) && expiryDate != DateTime.MinValue)
            //{
            //    cmd.Parameters.AddWithValue("@DateofExpiry", expiryDate);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@DateofExpiry", DBNull.Value);
            //}
            cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            //DateTime renewalDate;
            //if (DateTime.TryParse(DateofRenewal, out renewalDate) && renewalDate != DateTime.MinValue)
            //{
            //    cmd.Parameters.AddWithValue("@DateofRenewal", renewalDate);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@DateofRenewal", DBNull.Value);
            //}
            cmd.Parameters.AddWithValue("@votagelevel", votagelevel == "Select" ? DBNull.Value : (object)votagelevel);
            cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect);
            //DateTime voltageWithEffectDate;
            //if (DateTime.TryParse(voltageWithEffect, out voltageWithEffectDate) && voltageWithEffectDate != DateTime.MinValue)
            //{
            //    cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffectDate);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@voltageWithEffect", DBNull.Value);
            //}
            cmd.Parameters.AddWithValue("@AnyContractor", AnyContractor == "Select" ? DBNull.Value : (object)AnyContractor);
            cmd.Parameters.AddWithValue("@AttachedContractorld", string.IsNullOrEmpty(AttachedContractorld) ? DBNull.Value : (object)AttachedContractorld);
            cmd.Parameters.AddWithValue("@Category", "Supervisor");
            cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@NewUserId", NewUserId);

            cmd.Parameters.AddWithValue("@IPAddress", string.IsNullOrEmpty(IPAddress) ? DBNull.Value : (object)IPAddress);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Wireman Data
        public void InserWireManData(string REID, string Name, string Age, string FatherName, string Address, string District, string State, string PinCode, string PhoneNo,
      string Qualification, string Email, string CertificateOld, string CertificateNew, string DateofIntialissue, string DateofExpiry,
      string DateofRenewal, string AnyContractor, string AttachedContractorld,
    string CreatedBy, string UserId, string NewUserId, string IPAddress)
        {

            SqlCommand cmd = new SqlCommand("sp_SetWiremanandSuperwiserDetails");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            #region
            //cmd.Parameters.AddWithValue("@REID", REID);
            //cmd.Parameters.AddWithValue("@Name", Name);
            //cmd.Parameters.AddWithValue("@Age", Age);
            //cmd.Parameters.AddWithValue("@FatherName", FatherName);
            //cmd.Parameters.AddWithValue("@Address", Address);
            //cmd.Parameters.AddWithValue("@District", District);
            //cmd.Parameters.AddWithValue("@State", State);
            //cmd.Parameters.AddWithValue("@PinCode", PinCode);
            //cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            //cmd.Parameters.AddWithValue("@Qualification", Qualification);
            //cmd.Parameters.AddWithValue("@Email", Email);
            //cmd.Parameters.AddWithValue("@CertificateOld", CertificateOld);
            //cmd.Parameters.AddWithValue("@CertificateNew", CertificateNew);
            //cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            //cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            //cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            //cmd.Parameters.AddWithValue("@AnyContractor", AnyContractor);
            //cmd.Parameters.AddWithValue("@AttachedContractorld", AttachedContractorld);
            //cmd.Parameters.AddWithValue("@Category", "Wireman");
            //cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
            //cmd.Parameters.AddWithValue("@UserId", UserId);
            //cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            #endregion
            cmd.Parameters.AddWithValue("@REID", REID);
            cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(Name) ? DBNull.Value : (object)Name);
            cmd.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(Age) ? DBNull.Value : (object)Age);
            cmd.Parameters.AddWithValue("@FatherName", string.IsNullOrEmpty(FatherName) ? DBNull.Value : (object)FatherName);
            cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
            cmd.Parameters.AddWithValue("@District", District == "Select" ? DBNull.Value : (object)District);
            cmd.Parameters.AddWithValue("@State", State == "Select" ? DBNull.Value : (object)State);
            cmd.Parameters.AddWithValue("@PinCode", string.IsNullOrEmpty(PinCode) ? DBNull.Value : (object)PinCode);
            cmd.Parameters.AddWithValue("@PhoneNo", string.IsNullOrEmpty(PhoneNo) ? DBNull.Value : (object)PhoneNo);
            cmd.Parameters.AddWithValue("@Qualification", Qualification == "Select" ? DBNull.Value : (object)Qualification);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
            cmd.Parameters.AddWithValue("@CertificateOld", string.IsNullOrEmpty(CertificateOld) ? DBNull.Value : (object)CertificateOld);
            cmd.Parameters.AddWithValue("@CertificateNew", string.IsNullOrEmpty(CertificateNew) ? DBNull.Value : (object)CertificateNew);
            DateTime initialIssueDate;
            if (DateTime.TryParse(DateofIntialissue, out initialIssueDate) && initialIssueDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateofIntialissue", initialIssueDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofIntialissue", DBNull.Value);
            }
            DateTime expiryDate;
            if (DateTime.TryParse(DateofExpiry, out expiryDate) && expiryDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateofExpiry", expiryDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofExpiry", DBNull.Value);
            }
            DateTime renewalDate;
            if (DateTime.TryParse(DateofRenewal, out renewalDate) && renewalDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateofRenewal", renewalDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofRenewal", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@AnyContractor", AnyContractor == "Select" ? DBNull.Value : (object)AnyContractor);
            cmd.Parameters.AddWithValue("@AttachedContractorld", string.IsNullOrEmpty(AttachedContractorld) ? DBNull.Value : (object)AttachedContractorld);
            cmd.Parameters.AddWithValue("@Category", "Wireman");
            cmd.Parameters.AddWithValue("@Createdby", string.IsNullOrEmpty(CreatedBy) ? DBNull.Value : (object)CreatedBy);
            cmd.Parameters.AddWithValue("@UserId", string.IsNullOrEmpty(UserId) ? DBNull.Value : (object)UserId);
            cmd.Parameters.AddWithValue("@NewUserId", string.IsNullOrEmpty(NewUserId) ? DBNull.Value : (object)NewUserId);
            cmd.Parameters.AddWithValue("@IPAddress", string.IsNullOrEmpty(IPAddress) ? DBNull.Value : (object)IPAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Contractor Data
        public void InsertContractorData(string ContractorID, string UserId, string NewUserId, string Name, string FatherName, string FirmName, string GSTNumber, string RegisteredOffice,
      string State, string Districtoffirm, string PinCode, string BranchOffice, string BranchState, string BranchDistrictoffirm,
      string BranchPinCode, string PhoneNo, string Email, string DateofIntialissue, string DateofRenewal, string DateofExpiry,
      string votagelevel, string voltageWithEffect, string LicenceOld, string LicenceNew, string IPAddress, string Createdby)
        {

            SqlCommand cmd = new SqlCommand("sp_setContractorRegistrationDetails");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            #region old code
            //cmd.Parameters.AddWithValue("@ContractorID", ContractorID);
            //cmd.Parameters.AddWithValue("@UserId", UserId);
            //cmd.Parameters.AddWithValue("@Name", Name);
            //cmd.Parameters.AddWithValue("@FatherName", FatherName);
            //cmd.Parameters.AddWithValue("@FirmName", FirmName);
            //cmd.Parameters.AddWithValue("@GSTNumber", GSTNumber);
            //cmd.Parameters.AddWithValue("@RegisteredOffice", RegisteredOffice);
            //cmd.Parameters.AddWithValue("@State", State);
            //cmd.Parameters.AddWithValue("@Districtoffirm", Districtoffirm);
            //cmd.Parameters.AddWithValue("@PinCode", PinCode);
            //cmd.Parameters.AddWithValue("@BranchOffice", BranchOffice);
            //cmd.Parameters.AddWithValue("@BranchState", BranchState);
            //cmd.Parameters.AddWithValue("@BranchDistrictoffirm", BranchDistrictoffirm);
            //cmd.Parameters.AddWithValue("@BranchPinCode", BranchPinCode);
            //cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            //cmd.Parameters.AddWithValue("@Email", Email);
            //cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            //cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            //cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            //cmd.Parameters.AddWithValue("@votagelevel", votagelevel);
            //cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect);
            //cmd.Parameters.AddWithValue("@LicenceOld", LicenceOld);
            //cmd.Parameters.AddWithValue("@LicenceNew", LicenceNew);
            //cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            //cmd.Parameters.AddWithValue("@Createdby", Createdby);
            #endregion
            cmd.Parameters.AddWithValue("@ContractorID", string.IsNullOrEmpty(ContractorID) ? DBNull.Value : (object)ContractorID);
            cmd.Parameters.AddWithValue("@UserId", string.IsNullOrEmpty(UserId) ? DBNull.Value : (object)UserId);
            cmd.Parameters.AddWithValue("@NewUserId", string.IsNullOrEmpty(NewUserId) ? DBNull.Value : (object)NewUserId);
            cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(Name) ? DBNull.Value : (object)Name);
            cmd.Parameters.AddWithValue("@FatherName", string.IsNullOrEmpty(FatherName) ? DBNull.Value : (object)FatherName);
            cmd.Parameters.AddWithValue("@FirmName", string.IsNullOrEmpty(FirmName) ? DBNull.Value : (object)FirmName);
            cmd.Parameters.AddWithValue("@GSTNumber", string.IsNullOrEmpty(GSTNumber) ? DBNull.Value : (object)GSTNumber);
            cmd.Parameters.AddWithValue("@RegisteredOffice", string.IsNullOrEmpty(RegisteredOffice) ? DBNull.Value : (object)RegisteredOffice);
            cmd.Parameters.AddWithValue("@State", State == "Select" ? DBNull.Value : (object)State);
            cmd.Parameters.AddWithValue("@Districtoffirm", Districtoffirm == "Select" ? DBNull.Value : (object)Districtoffirm);
            cmd.Parameters.AddWithValue("@PinCode", string.IsNullOrEmpty(PinCode) ? DBNull.Value : (object)PinCode);
            cmd.Parameters.AddWithValue("@BranchOffice", string.IsNullOrEmpty(BranchOffice) ? DBNull.Value : (object)BranchOffice);
            cmd.Parameters.AddWithValue("@BranchState", BranchState == "Select" ? DBNull.Value : (object)BranchState);
            cmd.Parameters.AddWithValue("@BranchDistrictoffirm", BranchDistrictoffirm == "Select" ? DBNull.Value : (object)BranchDistrictoffirm);
            cmd.Parameters.AddWithValue("@BranchPinCode", string.IsNullOrEmpty(BranchPinCode) ? DBNull.Value : (object)BranchPinCode);
            cmd.Parameters.AddWithValue("@PhoneNo", string.IsNullOrEmpty(PhoneNo) ? DBNull.Value : (object)PhoneNo);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
            //cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            DateTime initialIssueDate;
            if (DateTime.TryParse(DateofIntialissue, out initialIssueDate) && initialIssueDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateofIntialissue", initialIssueDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofIntialissue", DBNull.Value);
            }
            //cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            DateTime renewalDate;
            if (DateTime.TryParse(DateofRenewal, out renewalDate) && renewalDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateofRenewal", renewalDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofRenewal", DBNull.Value);
            }
            //cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            DateTime expiryDate;
            if (DateTime.TryParse(DateofExpiry, out expiryDate) && expiryDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateofExpiry", expiryDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofExpiry", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@votagelevel", votagelevel == "Select" ? DBNull.Value : (object)votagelevel);
            //cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect);
            DateTime voltageWithEffectDate;
            if (DateTime.TryParse(voltageWithEffect, out voltageWithEffectDate) && voltageWithEffectDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffectDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@voltageWithEffect", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@LicenceOld", string.IsNullOrEmpty(LicenceOld) ? DBNull.Value : (object)LicenceOld);
            cmd.Parameters.AddWithValue("@LicenceNew", string.IsNullOrEmpty(LicenceNew) ? DBNull.Value : (object)LicenceNew);
            cmd.Parameters.AddWithValue("@IPAddress", string.IsNullOrEmpty(IPAddress) ? DBNull.Value : (object)IPAddress);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Update Line Data
        public void UpdateLineData(string ID, string Count/*, string RejectOrApprovedFronContractor, string ReasonForRejection*/)
        {
            SqlCommand cmd = new SqlCommand("sp_ContractorTestReortApproval");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Count", Count);
            cmd.Parameters.AddWithValue("@RejectOrApprovedFronContractor", "Submit");
            // cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Line Data
        public void InsertLineData(string IdUpdate, string Count, string IntimationId, string LineVoltage, string OtherVoltageType, string OtherVoltage, string LineLength, string LineType, string NoOfCircuit,
                     string Conductortype, string NumberofPoleTower, string ConductorSize, string GroundWireSize, string NmbrofRailwayCrossing,
                     string NmbrofRoadCrossing, string NmbrofRiverCanalCrossing, string NmbrofPowerLineCrossing, string NmbrofEarthing,
                     //            string EarthingType1,
                     //            string Valueinohms1, string EarthingType2, string Valueinohms2, string EarthingType3, string Valueinohms3, string EarthingType4, string Valueinohms4, string EarthingType5, string Valueinohms5, string
                     //EarthingType6, string Valueinohms6, string EarthingType7, string Valueinohms7, string EarthingType8, string Valueinohms8, string EarthingType9, string Valueinohms9, string EarthingType10, string
                     //Valueinohms10, string EarthingType11, string Valueinohms11, string EarthingType12, string Valueinohms12, string EarthingType13, string Valueinohms13, string EarthingType14, string Valueinohms14, string
                     //EarthingType15, string Valueinohms15,
                     string NoofPoleTowerForOverheadCable, string CableSize, string RailwayCrossingNoForOC, string RoadCrossingNoForOC,
                     string RiverCanalCrossingNoForOC, string PowerLineCrossingNoForOc, string RedPhaseEarthWire, string YellowPhaseEarth,
                     string BluePhaseEarthWire, string RedPhaseYellowPhase, string RedPhaseBluePhase, string BluePhaseYellowPhase, string PhasewireNeutralwire,
                     string PhasewireEarth, string NeutralwireEarth, string TypeofCable, string OtherCable, string SizeofCable, string Cablelaidin,
                     string RedPhaseEarthWirefor440orAbove, string YellowPhaseEarthWire440orAbove, string BluePhaseEarthWire440orAbove,
                     string RedPhaseYellowPhase440orAbove, string RedPhaseBluePhase440orAbove, string BluePhaseYellowPhase440orAbove,
                     string PhasewireNeutralwire220OrAbove, string PhasewireEarth220OrAbove, string NeutralwireEarth220OrAbove, string CreatedBy, string LineName, SqlTransaction transaction
         )
        {
            //SqlCommand cmd = new SqlCommand("sp_WorkIntimationRegistrationBySiteOwner", transaction.Connection, transaction);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlCommand cmd = new SqlCommand("sp_InserLineData", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}

            cmd.CommandType = CommandType.StoredProcedure;
            #region
            //cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            //cmd.Parameters.AddWithValue("@Count", Count);
            //cmd.Parameters.AddWithValue("@Id", LineId);
            //cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            //cmd.Parameters.AddWithValue("@LineVoltage", LineVoltage);
            //cmd.Parameters.AddWithValue("@LineLength", LineLength);
            //cmd.Parameters.AddWithValue("@OtherVoltageType", OtherVoltageType);
            //cmd.Parameters.AddWithValue("@OtherVoltage", OtherVoltage);
            //cmd.Parameters.AddWithValue("@LineType", LineType);
            //cmd.Parameters.AddWithValue("@NoOfCircuit", NoOfCircuit);
            //cmd.Parameters.AddWithValue("@Conductortype", Conductortype);
            //cmd.Parameters.AddWithValue("@NumberofPoleTower", NumberofPoleTower);
            //cmd.Parameters.AddWithValue("@ConductorSize", ConductorSize);
            //cmd.Parameters.AddWithValue("@GroundWireSize", GroundWireSize);
            //cmd.Parameters.AddWithValue("@NmbrofRailwayCrossing", NmbrofRailwayCrossing);
            //cmd.Parameters.AddWithValue("@NmbrofRoadCrossing", NmbrofRoadCrossing);
            //cmd.Parameters.AddWithValue("@NmbrofRiverCanalCrossing", NmbrofRiverCanalCrossing);
            //cmd.Parameters.AddWithValue("@NmbrofPowerLineCrossing", NmbrofPowerLineCrossing);
            //cmd.Parameters.AddWithValue("@NmbrofEarthing", NmbrofEarthing);
            //cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1);
            //cmd.Parameters.AddWithValue("@Valueinohms1", Valueinohms1);
            //cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2);
            //cmd.Parameters.AddWithValue("@Valueinohms2", Valueinohms2);
            //cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3);
            //cmd.Parameters.AddWithValue("@Valueinohms3", Valueinohms3);
            //cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4);
            //cmd.Parameters.AddWithValue("@Valueinohms4", Valueinohms4);
            //cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5);
            //cmd.Parameters.AddWithValue("@Valueinohms5", Valueinohms5);
            //cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6);
            //cmd.Parameters.AddWithValue("@Valueinohms6", Valueinohms6);
            //cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7);
            //cmd.Parameters.AddWithValue("@Valueinohms7", Valueinohms7);
            //cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8);
            //cmd.Parameters.AddWithValue("@Valueinohms8", Valueinohms8);
            //cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9);
            //cmd.Parameters.AddWithValue("@Valueinohms9", Valueinohms9);
            //cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10);
            //cmd.Parameters.AddWithValue("@Valueinohms10", Valueinohms10);
            //cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11);
            //cmd.Parameters.AddWithValue("@Valueinohms11", Valueinohms11);
            //cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12);
            //cmd.Parameters.AddWithValue("@Valueinohms12", Valueinohms12);
            //cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13);
            //cmd.Parameters.AddWithValue("@Valueinohms13", Valueinohms13);
            //cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14);
            //cmd.Parameters.AddWithValue("@Valueinohms14", Valueinohms15);
            //cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15);
            //cmd.Parameters.AddWithValue("@Valueinohms15", Valueinohms15);
            //cmd.Parameters.AddWithValue("@NoofPoleTowerForOverheadCable", NoofPoleTowerForOverheadCable);
            //cmd.Parameters.AddWithValue("@CableSize", CableSize);
            //cmd.Parameters.AddWithValue("@RailwayCrossingNoForOC", RailwayCrossingNoForOC);
            //cmd.Parameters.AddWithValue("@RoadCrossingNoForOC", RoadCrossingNoForOC);
            //cmd.Parameters.AddWithValue("@RiverCanalCrossingNoForOC", RiverCanalCrossingNoForOC);
            //cmd.Parameters.AddWithValue("@PowerLineCrossingNoForOc", PowerLineCrossingNoForOc);
            //cmd.Parameters.AddWithValue("@RedPhaseEarthWire", RedPhaseEarthWire);
            //cmd.Parameters.AddWithValue("@YellowPhaseEarth", YellowPhaseEarth);
            //cmd.Parameters.AddWithValue("@BluePhaseEarthWire", BluePhaseEarthWire);
            //cmd.Parameters.AddWithValue("@RedPhaseYellowPhase", RedPhaseYellowPhase);
            //cmd.Parameters.AddWithValue("@RedPhaseBluePhase", RedPhaseBluePhase);
            //cmd.Parameters.AddWithValue("@BluePhaseYellowPhase", BluePhaseYellowPhase);
            //cmd.Parameters.AddWithValue("@PhasewireNeutralwire", PhasewireNeutralwire);
            //cmd.Parameters.AddWithValue("@PhasewireEarth", PhasewireEarth);
            //cmd.Parameters.AddWithValue("@NeutralwireEarth", NeutralwireEarth);
            //cmd.Parameters.AddWithValue("@TypeofCable", TypeofCable);
            //cmd.Parameters.AddWithValue("@OtherCable", OtherCable);
            //cmd.Parameters.AddWithValue("@SizeofCable", SizeofCable);
            //cmd.Parameters.AddWithValue("@Cablelaidin", Cablelaidin);
            //cmd.Parameters.AddWithValue("@RedPhaseEarthWirefor440orAbove", RedPhaseEarthWirefor440orAbove);
            //cmd.Parameters.AddWithValue("@YellowPhaseEarthWire440orAbove", YellowPhaseEarthWire440orAbove);
            //cmd.Parameters.AddWithValue("@BluePhaseEarthWire440orAbove", BluePhaseEarthWire440orAbove);
            //cmd.Parameters.AddWithValue("@RedPhaseYellowPhase440orAbove", RedPhaseYellowPhase440orAbove);
            //cmd.Parameters.AddWithValue("@RedPhaseBluePhase440orAbove", RedPhaseBluePhase440orAbove);
            //cmd.Parameters.AddWithValue("@BluePhaseYellowPhase440orAbove", BluePhaseYellowPhase440orAbove);
            //cmd.Parameters.AddWithValue("@PhasewireNeutralwire220OrAbove", PhasewireNeutralwire220OrAbove);
            //cmd.Parameters.AddWithValue("@PhasewireEarth220OrAbove", PhasewireEarth220OrAbove);
            //cmd.Parameters.AddWithValue("@NeutralwireEarth220OrAbove", NeutralwireEarth220OrAbove);
            //cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            #endregion
            cmd.Parameters.AddWithValue("@IdUpdate", String.IsNullOrEmpty(IdUpdate) ? null : IdUpdate);
            cmd.Parameters.AddWithValue("@Count", String.IsNullOrEmpty(Count) ? null : Count);
            //cmd.Parameters.AddWithValue("@Id", String.IsNullOrEmpty(LineId) ? null : LineId);
            cmd.Parameters.AddWithValue("@IntimationId", String.IsNullOrEmpty(IntimationId) ? null : IntimationId);
            cmd.Parameters.AddWithValue("@LineVoltage", String.IsNullOrEmpty(LineVoltage) ? null : LineVoltage);
            cmd.Parameters.AddWithValue("@LineLength", String.IsNullOrEmpty(LineLength) ? null : LineLength);
            cmd.Parameters.AddWithValue("@OtherVoltageType", OtherVoltageType == "Select" ? null : OtherVoltageType);
            cmd.Parameters.AddWithValue("@OtherVoltage", OtherVoltage);
            cmd.Parameters.AddWithValue("@LineType", String.IsNullOrEmpty(LineType) ? null : LineType);
            cmd.Parameters.AddWithValue("@NoOfCircuit", NoOfCircuit == "Select" ? null : NoOfCircuit);
            cmd.Parameters.AddWithValue("@Conductortype", Conductortype == "Select" ? null : Conductortype);
            cmd.Parameters.AddWithValue("@NumberofPoleTower", String.IsNullOrEmpty(NumberofPoleTower) ? null : NumberofPoleTower);
            cmd.Parameters.AddWithValue("@ConductorSize", String.IsNullOrEmpty(ConductorSize) ? null : ConductorSize);
            cmd.Parameters.AddWithValue("@GroundWireSize", String.IsNullOrEmpty(GroundWireSize) ? null : GroundWireSize);
            cmd.Parameters.AddWithValue("@NmbrofRailwayCrossing", String.IsNullOrEmpty(NmbrofRailwayCrossing) ? null : NmbrofRailwayCrossing);
            cmd.Parameters.AddWithValue("@NmbrofRoadCrossing", String.IsNullOrEmpty(NmbrofRoadCrossing) ? null : NmbrofRoadCrossing);
            cmd.Parameters.AddWithValue("@NmbrofRiverCanalCrossing", String.IsNullOrEmpty(NmbrofRiverCanalCrossing) ? null : NmbrofRiverCanalCrossing);
            cmd.Parameters.AddWithValue("@NmbrofPowerLineCrossing", String.IsNullOrEmpty(NmbrofPowerLineCrossing) ? null : NmbrofPowerLineCrossing);
            cmd.Parameters.AddWithValue("@NmbrofEarthing", NmbrofEarthing == "Select" ? null : NmbrofEarthing);
            //cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1 == "Select" ? null : EarthingType1);

            //cmd.Parameters.AddWithValue("@Valueinohms1", string.IsNullOrEmpty(Valueinohms1) ? DBNull.Value : (object)Valueinohms1);
            ////cmd.Parameters.AddWithValue("@Valueinohms1", String.IsNullOrEmpty(Valueinohms1) ? null : Valueinohms1);
            //cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2 == "Select" ? null : EarthingType2);
            //cmd.Parameters.AddWithValue("@Valueinohms2", String.IsNullOrEmpty(Valueinohms2) ? DBNull.Value : (object)Valueinohms2);
            //cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3 == "Select" ? null : EarthingType3);
            //cmd.Parameters.AddWithValue("@Valueinohms3", String.IsNullOrEmpty(Valueinohms3) ? DBNull.Value : (object)Valueinohms3);
            //cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4 == "Select" ? null : EarthingType4);
            //cmd.Parameters.AddWithValue("@Valueinohms4", String.IsNullOrEmpty(Valueinohms4) ? DBNull.Value : (object)Valueinohms4);
            //cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5 == "Select" ? null : EarthingType5);
            //cmd.Parameters.AddWithValue("@Valueinohms5", String.IsNullOrEmpty(Valueinohms5) ? DBNull.Value : (object)Valueinohms5);
            //cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6 == "Select" ? null : EarthingType6);
            //cmd.Parameters.AddWithValue("@Valueinohms6", String.IsNullOrEmpty(Valueinohms6) ? DBNull.Value : (object)Valueinohms6);
            //cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7 == "Select" ? null : EarthingType7);
            //cmd.Parameters.AddWithValue("@Valueinohms7", String.IsNullOrEmpty(Valueinohms7) ? DBNull.Value : (object)Valueinohms7);
            //cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8 == "Select" ? null : EarthingType8);
            //cmd.Parameters.AddWithValue("@Valueinohms8", String.IsNullOrEmpty(Valueinohms8) ? DBNull.Value : (object)Valueinohms8);
            //cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9 == "Select" ? null : EarthingType9);
            //cmd.Parameters.AddWithValue("@Valueinohms9", String.IsNullOrEmpty(Valueinohms9) ? DBNull.Value : (object)Valueinohms9);
            //cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10 == "Select" ? null : EarthingType10);
            //cmd.Parameters.AddWithValue("@Valueinohms10", String.IsNullOrEmpty(Valueinohms10) ? DBNull.Value : (object)Valueinohms10);
            //cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11 == "Select" ? null : EarthingType11);
            //cmd.Parameters.AddWithValue("@Valueinohms11", String.IsNullOrEmpty(Valueinohms11) ? DBNull.Value : (object)Valueinohms11);
            //cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12 == "Select" ? null : EarthingType12);
            //cmd.Parameters.AddWithValue("@Valueinohms12", String.IsNullOrEmpty(Valueinohms12) ? DBNull.Value : (object)Valueinohms12);
            //cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13 == "Select" ? null : EarthingType13);
            //cmd.Parameters.AddWithValue("@Valueinohms13", String.IsNullOrEmpty(Valueinohms13) ? DBNull.Value : (object)Valueinohms13);
            //cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14 == "Select" ? null : EarthingType14);
            //cmd.Parameters.AddWithValue("@Valueinohms14", String.IsNullOrEmpty(Valueinohms14) ? DBNull.Value : (object)Valueinohms14);
            //cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15 == "Select" ? null : EarthingType15);
            //cmd.Parameters.AddWithValue("@Valueinohms15", String.IsNullOrEmpty(Valueinohms15) ? DBNull.Value : (object)Valueinohms15);
            cmd.Parameters.AddWithValue("@NoofPoleTowerForOverheadCable", String.IsNullOrEmpty(NoofPoleTowerForOverheadCable) ? null : NoofPoleTowerForOverheadCable);
            cmd.Parameters.AddWithValue("@CableSize", String.IsNullOrEmpty(CableSize) ? null : CableSize);
            cmd.Parameters.AddWithValue("@RailwayCrossingNoForOC", String.IsNullOrEmpty(RailwayCrossingNoForOC) ? null : RailwayCrossingNoForOC);
            cmd.Parameters.AddWithValue("@RoadCrossingNoForOC", String.IsNullOrEmpty(RoadCrossingNoForOC) ? null : RoadCrossingNoForOC);
            cmd.Parameters.AddWithValue("@RiverCanalCrossingNoForOC", String.IsNullOrEmpty(RiverCanalCrossingNoForOC) ? null : RiverCanalCrossingNoForOC);
            cmd.Parameters.AddWithValue("@PowerLineCrossingNoForOc", String.IsNullOrEmpty(PowerLineCrossingNoForOc) ? null : PowerLineCrossingNoForOc);
            cmd.Parameters.AddWithValue("@RedPhaseEarthWire", String.IsNullOrEmpty(RedPhaseEarthWire) ? null : RedPhaseEarthWire);
            cmd.Parameters.AddWithValue("@YellowPhaseEarth", String.IsNullOrEmpty(YellowPhaseEarth) ? null : YellowPhaseEarth);
            cmd.Parameters.AddWithValue("@BluePhaseEarthWire", String.IsNullOrEmpty(BluePhaseEarthWire) ? null : BluePhaseEarthWire);
            cmd.Parameters.AddWithValue("@RedPhaseYellowPhase", String.IsNullOrEmpty(RedPhaseYellowPhase) ? null : RedPhaseYellowPhase);
            cmd.Parameters.AddWithValue("@RedPhaseBluePhase", String.IsNullOrEmpty(RedPhaseBluePhase) ? null : RedPhaseBluePhase);
            cmd.Parameters.AddWithValue("@BluePhaseYellowPhase", String.IsNullOrEmpty(BluePhaseYellowPhase) ? null : BluePhaseYellowPhase);
            cmd.Parameters.AddWithValue("@PhasewireNeutralwire", String.IsNullOrEmpty(PhasewireNeutralwire) ? null : PhasewireNeutralwire);
            cmd.Parameters.AddWithValue("@PhasewireEarth", String.IsNullOrEmpty(PhasewireEarth) ? null : PhasewireEarth);
            cmd.Parameters.AddWithValue("@NeutralwireEarth", String.IsNullOrEmpty(NeutralwireEarth) ? null : NeutralwireEarth);
            cmd.Parameters.AddWithValue("@TypeofCable", TypeofCable == "Select" ? null : TypeofCable);
            cmd.Parameters.AddWithValue("@OtherCable", String.IsNullOrEmpty(OtherCable) ? null : OtherCable);
            cmd.Parameters.AddWithValue("@SizeofCable", String.IsNullOrEmpty(SizeofCable) ? null : SizeofCable);
            cmd.Parameters.AddWithValue("@Cablelaidin", Cablelaidin == "Select" ? null : Cablelaidin);
            cmd.Parameters.AddWithValue("@RedPhaseEarthWirefor440orAbove", String.IsNullOrEmpty(RedPhaseEarthWirefor440orAbove) ? null : RedPhaseEarthWirefor440orAbove);
            cmd.Parameters.AddWithValue("@YellowPhaseEarthWire440orAbove", String.IsNullOrEmpty(YellowPhaseEarthWire440orAbove) ? null : YellowPhaseEarthWire440orAbove);
            cmd.Parameters.AddWithValue("@BluePhaseEarthWire440orAbove", String.IsNullOrEmpty(BluePhaseEarthWire440orAbove) ? null : BluePhaseEarthWire440orAbove);
            cmd.Parameters.AddWithValue("@RedPhaseYellowPhase440orAbove", String.IsNullOrEmpty(RedPhaseYellowPhase440orAbove) ? null : RedPhaseYellowPhase440orAbove);
            cmd.Parameters.AddWithValue("@RedPhaseBluePhase440orAbove", String.IsNullOrEmpty(RedPhaseBluePhase440orAbove) ? null : RedPhaseBluePhase440orAbove);
            cmd.Parameters.AddWithValue("@BluePhaseYellowPhase440orAbove", String.IsNullOrEmpty(BluePhaseYellowPhase440orAbove) ? null : BluePhaseYellowPhase440orAbove);
            cmd.Parameters.AddWithValue("@PhasewireNeutralwire220OrAbove", String.IsNullOrEmpty(PhasewireNeutralwire220OrAbove) ? null : PhasewireNeutralwire220OrAbove);
            cmd.Parameters.AddWithValue("@PhasewireEarth220OrAbove", String.IsNullOrEmpty(PhasewireEarth220OrAbove) ? null : PhasewireEarth220OrAbove);
            cmd.Parameters.AddWithValue("@NeutralwireEarth220OrAbove", String.IsNullOrEmpty(NeutralwireEarth220OrAbove) ? null : NeutralwireEarth220OrAbove);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@LineName", LineName);
            cmd.ExecuteNonQuery();
            //con.Close();
        }
        #endregion

        #region Insert Substation Data
        public void InsertSubstationData(string IdUpdate, string Count, string TestReportId, string IntimationId, string TransformerSerialNumber, string TransformerCapacityType, string TransformerCapacity, string TranformerType,
    string PrimaryVoltage, string SecondoryVoltage, string OilCapacity, string BreakDownVoltageofOil, string HtInsulationHVEarth,
    string LtInsulationLVEarth, string LowestvaluebetweenHTLTSide, string LightningArrestorLocation, string OtherLALocation,
    string TypeofHTPrimarySideSwitch, string NumberOfEarthing, string EarthingType1, string Valueinohms1,
    string UsedFor1, string OtherEarthing1, string EarthingType2, string Valueinohms2, string UsedFor2, string OtherEarthing2, string EarthingType3, string Valueinohms3, string UsedFor3, string OtherEarthing3,
    string EarthingType4, string Valueinohms4, string UsedFor4, string OtherEarthing4, string EarthingType5, string Valueinohms5, string UsedFor5, string OtherEarthing5,
    string EarthingType6, string Valueinohms6, string UsedFor6, string OtherEarthing6, string EarthingType7, string Valueinohms7, string UsedFor7, string OtherEarthing7,
    string EarthingType8, string Valueinohms8, string UsedFor8, string OtherEarthing8, string EarthingType9, string Valueinohms9, string UsedFor9, string OtherEarthing9,
    string EarthingType10, string Valueinohms10, string UsedFor10, string OtherEarthing10, string EarthingType11, string Valueinohms11, string UsedFor11, string OtherEarthing11,
    string EarthingType12, string Valueinohms12, string UsedFor12, string OtherEarthing12, string EarthingType13, string Valueinohms13, string UsedFor13, string OtherEarthing13,
    string EarthingType14, string Valueinohms14, string UsedFor14, string OtherEarthing14, string EarthingType15, string Valueinohms15, string UsedFor15, string OtherEarthing15,
    string EarthingType16, string Valueinohms16, string UsedFor16, string OtherEarthing16, string EarthingType17, string Valueinohms17, string UsedFor17, string OtherEarthing17,
    string EarthingType18, string Valueinohms18, string UsedFor18, string OtherEarthing18, string EarthingType19, string Valueinohms19, string UsedFor19, string OtherEarthing19,
    string EarthingType20, string Valueinohms20, string UsedFor20, string OtherEarthing20, string LoadBreakingCapacityOfBreakerInKA, string TypeOfLTProtection,
    string CapacityOfIndividualFuseInAMPS, string CapacityOfLTBreakerInAMPS, string LoadBreakingCapacityOfBreakerInAMPS, string SeaLevelOfTransformerInMeters, string CreatedBy, string SubstationName)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertSubstationTransformerData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            #region old code
            //cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            //cmd.Parameters.AddWithValue("@Count", Count);
            //cmd.Parameters.AddWithValue("@Id", Id);
            //cmd.Parameters.AddWithValue("@TestReportId", TestReportId);
            //cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            //cmd.Parameters.AddWithValue("@TransformerSerialNumber", TransformerSerialNumber);
            //cmd.Parameters.AddWithValue("@TransformerCapacityType", TransformerCapacityType);
            //cmd.Parameters.AddWithValue("@TransformerCapacity", TransformerCapacity);
            //cmd.Parameters.AddWithValue("@TranformerType", TranformerType);
            //cmd.Parameters.AddWithValue("@PrimaryVoltage", PrimaryVoltage);
            //cmd.Parameters.AddWithValue("@SecondoryVoltage", SecondoryVoltage);
            //cmd.Parameters.AddWithValue("@OilCapacity", OilCapacity);
            //cmd.Parameters.AddWithValue("@BreakDownVoltageofOil", BreakDownVoltageofOil);
            //cmd.Parameters.AddWithValue("@HtInsulationHVEarth", HtInsulationHVEarth);
            //cmd.Parameters.AddWithValue("@LtInsulationLVEarth", LtInsulationLVEarth);
            //cmd.Parameters.AddWithValue("@LowestvaluebetweenHTLTSide", LowestvaluebetweenHTLTSide);
            //cmd.Parameters.AddWithValue("@LightningArrestorLocation", LightningArrestorLocation);
            //cmd.Parameters.AddWithValue("@OtherLALocation", OtherLALocation);
            //cmd.Parameters.AddWithValue("@TypeofHTPrimarySideSwitch", TypeofHTPrimarySideSwitch);
            //cmd.Parameters.AddWithValue("@NumberOfEarthing", NumberOfEarthing);
            //cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1);
            //cmd.Parameters.AddWithValue("@Valueinohms1", Valueinohms1);
            //cmd.Parameters.AddWithValue("@UsedFor1", UsedFor1);
            //cmd.Parameters.AddWithValue("@OtherEarthing1", OtherEarthing1);
            //cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2);
            //cmd.Parameters.AddWithValue("@Valueinohms2", Valueinohms2);
            //cmd.Parameters.AddWithValue("@UsedFor2", UsedFor2);
            //cmd.Parameters.AddWithValue("@OtherEarthing2", OtherEarthing2);
            //cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3);
            //cmd.Parameters.AddWithValue("@Valueinohms3", Valueinohms3);
            //cmd.Parameters.AddWithValue("@UsedFor3", UsedFor3);
            //cmd.Parameters.AddWithValue("@OtherEarthing3", OtherEarthing3);
            //cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4);
            //cmd.Parameters.AddWithValue("@Valueinohms4", Valueinohms4);
            //cmd.Parameters.AddWithValue("@UsedFor4", UsedFor4);
            //cmd.Parameters.AddWithValue("@OtherEarthing4", OtherEarthing4);
            //cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5);
            //cmd.Parameters.AddWithValue("@Valueinohms5", Valueinohms5);
            //cmd.Parameters.AddWithValue("@UsedFor5", UsedFor5);
            //cmd.Parameters.AddWithValue("@OtherEarthing5", OtherEarthing5);
            //cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6);
            //cmd.Parameters.AddWithValue("@Valueinohms6", Valueinohms6);
            //cmd.Parameters.AddWithValue("@UsedFor6", UsedFor6);
            //cmd.Parameters.AddWithValue("@OtherEarthing6", OtherEarthing6);
            //cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7);
            //cmd.Parameters.AddWithValue("@Valueinohms7", Valueinohms7);
            //cmd.Parameters.AddWithValue("@UsedFor7", UsedFor7);
            //cmd.Parameters.AddWithValue("@OtherEarthing7", OtherEarthing7);
            //cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8);
            //cmd.Parameters.AddWithValue("@Valueinohms8", Valueinohms8);
            //cmd.Parameters.AddWithValue("@UsedFor8", UsedFor8);
            //cmd.Parameters.AddWithValue("@OtherEarthing8", OtherEarthing8);
            //cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9);
            //cmd.Parameters.AddWithValue("@Valueinohms9", Valueinohms9);
            //cmd.Parameters.AddWithValue("@UsedFor9", UsedFor9);
            //cmd.Parameters.AddWithValue("@OtherEarthing9", OtherEarthing9);
            //cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10);
            //cmd.Parameters.AddWithValue("@Valueinohms10", Valueinohms10);
            //cmd.Parameters.AddWithValue("@UsedFor10", UsedFor10);
            //cmd.Parameters.AddWithValue("@OtherEarthing10", OtherEarthing10);
            //cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11);
            //cmd.Parameters.AddWithValue("@Valueinohms11", Valueinohms11);
            //cmd.Parameters.AddWithValue("@UsedFor11", UsedFor11);
            //cmd.Parameters.AddWithValue("@OtherEarthing11", OtherEarthing11);
            //cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12);
            //cmd.Parameters.AddWithValue("@Valueinohms12", Valueinohms12);
            //cmd.Parameters.AddWithValue("@UsedFor12", UsedFor12);
            //cmd.Parameters.AddWithValue("@OtherEarthing12", OtherEarthing12);
            //cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13);
            //cmd.Parameters.AddWithValue("@Valueinohms13", Valueinohms13);
            //cmd.Parameters.AddWithValue("@UsedFor13", UsedFor13);
            //cmd.Parameters.AddWithValue("@OtherEarthing13", OtherEarthing13);
            //cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14);
            //cmd.Parameters.AddWithValue("@Valueinohms14", Valueinohms14);
            //cmd.Parameters.AddWithValue("@UsedFor14", UsedFor14);
            //cmd.Parameters.AddWithValue("@OtherEarthing14", OtherEarthing14);
            //cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15);
            //cmd.Parameters.AddWithValue("@Valueinohms15", Valueinohms15);
            //cmd.Parameters.AddWithValue("@UsedFor15", UsedFor15);
            //cmd.Parameters.AddWithValue("@OtherEarthing15", OtherEarthing15);
            //cmd.Parameters.AddWithValue("@EarthingType16", EarthingType16);
            //cmd.Parameters.AddWithValue("@Valueinohms16", Valueinohms16);
            //cmd.Parameters.AddWithValue("@UsedFor16", UsedFor16);
            //cmd.Parameters.AddWithValue("@OtherEarthing16", OtherEarthing16);
            //cmd.Parameters.AddWithValue("@EarthingType17", EarthingType17);
            //cmd.Parameters.AddWithValue("@Valueinohms17", Valueinohms17);
            //cmd.Parameters.AddWithValue("@UsedFor17", UsedFor17);
            //cmd.Parameters.AddWithValue("@OtherEarthing17", OtherEarthing17);
            //cmd.Parameters.AddWithValue("@EarthingType18", EarthingType18);
            //cmd.Parameters.AddWithValue("@Valueinohms18", Valueinohms18);
            //cmd.Parameters.AddWithValue("@UsedFor18", UsedFor18);
            //cmd.Parameters.AddWithValue("@OtherEarthing18", OtherEarthing18);
            //cmd.Parameters.AddWithValue("@EarthingType19", EarthingType19);
            //cmd.Parameters.AddWithValue("@Valueinohms19", Valueinohms19);
            //cmd.Parameters.AddWithValue("@UsedFor19", UsedFor19);
            //cmd.Parameters.AddWithValue("@OtherEarthing19", OtherEarthing19);
            //cmd.Parameters.AddWithValue("@EarthingType20", EarthingType20);
            //cmd.Parameters.AddWithValue("@Valueinohms20", Valueinohms20);
            //cmd.Parameters.AddWithValue("@UsedFor20", UsedFor20);
            //cmd.Parameters.AddWithValue("@OtherEarthing20", OtherEarthing20);
            //cmd.Parameters.AddWithValue("@LoadBreakingCapacityOfBreakerInKA", LoadBreakingCapacityOfBreakerInKA);
            //cmd.Parameters.AddWithValue("@TypeOfLTProtection", TypeOfLTProtection);
            //cmd.Parameters.AddWithValue("@CapacityOfIndividualFuseInAMPS", CapacityOfIndividualFuseInAMPS);
            //cmd.Parameters.AddWithValue("@CapacityOfLTBreakerInAMPS", CapacityOfLTBreakerInAMPS);
            //cmd.Parameters.AddWithValue("@LoadBreakingCapacityOfBreakerInAMPS", LoadBreakingCapacityOfBreakerInAMPS);
            //cmd.Parameters.AddWithValue("@SeaLevelOfTransformerInMeters", SeaLevelOfTransformerInMeters);
            //cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            #endregion
            cmd.Parameters.AddWithValue("@IdUpdate", String.IsNullOrEmpty(IdUpdate) ? null : IdUpdate);
            cmd.Parameters.AddWithValue("@Count", String.IsNullOrEmpty(Count) ? null : Count);
            // cmd.Parameters.AddWithValue("@Id", String.IsNullOrEmpty(Id) ? null : Id);
            cmd.Parameters.AddWithValue("@TestReportId", String.IsNullOrEmpty(TestReportId) ? null : TestReportId);
            cmd.Parameters.AddWithValue("@IntimationId", String.IsNullOrEmpty(IntimationId) ? null : IntimationId);
            cmd.Parameters.AddWithValue("@TransformerSerialNumber", String.IsNullOrEmpty(TransformerSerialNumber) ? null : TransformerSerialNumber);
            cmd.Parameters.AddWithValue("@TransformerCapacityType", String.IsNullOrEmpty(TransformerCapacityType) ? null : TransformerCapacityType);
            cmd.Parameters.AddWithValue("@TransformerCapacity", String.IsNullOrEmpty(TransformerCapacity) ? null : TransformerCapacity);
            cmd.Parameters.AddWithValue("@TranformerType", TranformerType == "Select" ? null : TranformerType);
            cmd.Parameters.AddWithValue("@PrimaryVoltage", PrimaryVoltage == "Select" ? null : PrimaryVoltage);
            cmd.Parameters.AddWithValue("@SecondoryVoltage", SecondoryVoltage == "Select" ? null : SecondoryVoltage);
            cmd.Parameters.AddWithValue("@OilCapacity", String.IsNullOrEmpty(OilCapacity) ? null : OilCapacity);
            cmd.Parameters.AddWithValue("@BreakDownVoltageofOil", String.IsNullOrEmpty(BreakDownVoltageofOil) ? null : BreakDownVoltageofOil);
            cmd.Parameters.AddWithValue("@HtInsulationHVEarth", String.IsNullOrEmpty(HtInsulationHVEarth) ? null : HtInsulationHVEarth);
            cmd.Parameters.AddWithValue("@LtInsulationLVEarth", String.IsNullOrEmpty(LtInsulationLVEarth) ? null : LtInsulationLVEarth);
            cmd.Parameters.AddWithValue("@LowestvaluebetweenHTLTSide", String.IsNullOrEmpty(LowestvaluebetweenHTLTSide) ? null : LowestvaluebetweenHTLTSide);
            cmd.Parameters.AddWithValue("@LightningArrestorLocation", LightningArrestorLocation == "Select" ? null : LightningArrestorLocation);
            cmd.Parameters.AddWithValue("@OtherLALocation", String.IsNullOrEmpty(OtherLALocation) ? null : OtherLALocation);
            cmd.Parameters.AddWithValue("@TypeofHTPrimarySideSwitch", TypeofHTPrimarySideSwitch == "Select" ? null : TypeofHTPrimarySideSwitch);
            cmd.Parameters.AddWithValue("@NumberOfEarthing", NumberOfEarthing == "Select" ? null : NumberOfEarthing);
            cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1 == "Select" ? null : EarthingType1);
            cmd.Parameters.AddWithValue("@Valueinohms1", String.IsNullOrEmpty(Valueinohms1) ? null : Valueinohms1);
            cmd.Parameters.AddWithValue("@UsedFor1", UsedFor1 == "Select" ? null : UsedFor1);
            cmd.Parameters.AddWithValue("@OtherEarthing1", String.IsNullOrEmpty(OtherEarthing1) ? null : OtherEarthing1);

            cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2 == "Select" ? null : EarthingType2);
            cmd.Parameters.AddWithValue("@Valueinohms2", String.IsNullOrEmpty(Valueinohms2) ? null : Valueinohms2);
            cmd.Parameters.AddWithValue("@UsedFor2", UsedFor2 == "Select" ? null : UsedFor2);
            cmd.Parameters.AddWithValue("@OtherEarthing2", String.IsNullOrEmpty(OtherEarthing2) ? null : OtherEarthing2);

            cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3 == "Select" ? null : EarthingType3);
            cmd.Parameters.AddWithValue("@Valueinohms3", String.IsNullOrEmpty(Valueinohms3) ? null : Valueinohms3);
            cmd.Parameters.AddWithValue("@UsedFor3", UsedFor3 == "Select" ? null : UsedFor3);
            cmd.Parameters.AddWithValue("@OtherEarthing3", String.IsNullOrEmpty(OtherEarthing3) ? null : OtherEarthing3);

            cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4 == "Select" ? null : EarthingType4);
            cmd.Parameters.AddWithValue("@Valueinohms4", String.IsNullOrEmpty(Valueinohms4) ? null : Valueinohms4);
            cmd.Parameters.AddWithValue("@UsedFor4", UsedFor4 == "Select" ? null : UsedFor4);
            cmd.Parameters.AddWithValue("@OtherEarthing4", String.IsNullOrEmpty(OtherEarthing4) ? null : OtherEarthing4);

            cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5 == "Select" ? null : EarthingType5);
            cmd.Parameters.AddWithValue("@Valueinohms5", String.IsNullOrEmpty(Valueinohms5) ? null : Valueinohms5);
            cmd.Parameters.AddWithValue("@UsedFor5", UsedFor5 == "Select" ? null : UsedFor5);
            cmd.Parameters.AddWithValue("@OtherEarthing5", String.IsNullOrEmpty(OtherEarthing5) ? null : OtherEarthing5);


            cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6 == "Select" ? null : EarthingType6);
            cmd.Parameters.AddWithValue("@Valueinohms6", String.IsNullOrEmpty(Valueinohms6) ? null : Valueinohms6);
            cmd.Parameters.AddWithValue("@UsedFor6", UsedFor6 == "Select" ? null : UsedFor6);
            cmd.Parameters.AddWithValue("@OtherEarthing6", String.IsNullOrEmpty(OtherEarthing6) ? null : OtherEarthing6);

            cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7 == "Select" ? null : EarthingType7);
            cmd.Parameters.AddWithValue("@Valueinohms7", String.IsNullOrEmpty(Valueinohms7) ? null : Valueinohms7);
            cmd.Parameters.AddWithValue("@UsedFor7", UsedFor7 == "Select" ? null : UsedFor7);
            cmd.Parameters.AddWithValue("@OtherEarthing7", String.IsNullOrEmpty(OtherEarthing7) ? null : OtherEarthing7);

            cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8 == "Select" ? null : EarthingType8);
            cmd.Parameters.AddWithValue("@Valueinohms8", String.IsNullOrEmpty(Valueinohms8) ? null : Valueinohms8);
            cmd.Parameters.AddWithValue("@UsedFor8", UsedFor8 == "Select" ? null : UsedFor8);
            cmd.Parameters.AddWithValue("@OtherEarthing8", String.IsNullOrEmpty(OtherEarthing8) ? null : OtherEarthing8);

            cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9 == "Select" ? null : EarthingType9);
            cmd.Parameters.AddWithValue("@Valueinohms9", String.IsNullOrEmpty(Valueinohms9) ? null : Valueinohms9);
            cmd.Parameters.AddWithValue("@UsedFor9", UsedFor9 == "Select" ? null : UsedFor9);
            cmd.Parameters.AddWithValue("@OtherEarthing9", String.IsNullOrEmpty(OtherEarthing9) ? null : OtherEarthing9);

            cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10 == "Select" ? null : EarthingType10);
            cmd.Parameters.AddWithValue("@Valueinohms10", String.IsNullOrEmpty(Valueinohms10) ? null : Valueinohms10);
            cmd.Parameters.AddWithValue("@UsedFor10", UsedFor10 == "Select" ? null : UsedFor10);
            cmd.Parameters.AddWithValue("@OtherEarthing10", String.IsNullOrEmpty(OtherEarthing10) ? null : OtherEarthing10);

            cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11 == "Select" ? null : EarthingType11);
            cmd.Parameters.AddWithValue("@Valueinohms11", String.IsNullOrEmpty(Valueinohms11) ? null : Valueinohms11);
            cmd.Parameters.AddWithValue("@UsedFor11", UsedFor11 == "Select" ? null : UsedFor11);
            cmd.Parameters.AddWithValue("@OtherEarthing11", String.IsNullOrEmpty(OtherEarthing11) ? null : OtherEarthing11);

            cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12 == "Select" ? null : EarthingType12);
            cmd.Parameters.AddWithValue("@Valueinohms12", String.IsNullOrEmpty(Valueinohms12) ? null : Valueinohms12);
            cmd.Parameters.AddWithValue("@UsedFor12", UsedFor12 == "Select" ? null : UsedFor12);
            cmd.Parameters.AddWithValue("@OtherEarthing12", String.IsNullOrEmpty(OtherEarthing12) ? null : OtherEarthing12);

            cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13 == "Select" ? null : EarthingType13);
            cmd.Parameters.AddWithValue("@Valueinohms13", String.IsNullOrEmpty(Valueinohms13) ? null : Valueinohms13);
            cmd.Parameters.AddWithValue("@UsedFor13", UsedFor13 == "Select" ? null : UsedFor13);
            cmd.Parameters.AddWithValue("@OtherEarthing13", String.IsNullOrEmpty(OtherEarthing13) ? null : OtherEarthing13);

            cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14 == "Select" ? null : EarthingType14);
            cmd.Parameters.AddWithValue("@Valueinohms14", String.IsNullOrEmpty(Valueinohms14) ? null : Valueinohms14);
            cmd.Parameters.AddWithValue("@UsedFor14", UsedFor14 == "Select" ? null : UsedFor14);
            cmd.Parameters.AddWithValue("@OtherEarthing14", String.IsNullOrEmpty(OtherEarthing14) ? null : OtherEarthing14);

            cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15 == "Select" ? null : EarthingType15);
            cmd.Parameters.AddWithValue("@Valueinohms15", String.IsNullOrEmpty(Valueinohms15) ? null : Valueinohms15);
            cmd.Parameters.AddWithValue("@UsedFor15", UsedFor15 == "Select" ? null : UsedFor15);
            cmd.Parameters.AddWithValue("@OtherEarthing15", String.IsNullOrEmpty(OtherEarthing15) ? null : OtherEarthing15);

            cmd.Parameters.AddWithValue("@EarthingType16", EarthingType16 == "Select" ? null : EarthingType16);
            cmd.Parameters.AddWithValue("@Valueinohms16", String.IsNullOrEmpty(Valueinohms16) ? null : Valueinohms16);
            cmd.Parameters.AddWithValue("@UsedFor16", UsedFor16 == "Select" ? null : UsedFor16);
            cmd.Parameters.AddWithValue("@OtherEarthing16", String.IsNullOrEmpty(OtherEarthing16) ? null : OtherEarthing16);

            cmd.Parameters.AddWithValue("@EarthingType17", EarthingType17 == "Select" ? null : EarthingType17);
            cmd.Parameters.AddWithValue("@Valueinohms17", String.IsNullOrEmpty(Valueinohms17) ? null : Valueinohms17);
            cmd.Parameters.AddWithValue("@UsedFor17", UsedFor17 == "Select" ? null : UsedFor17);
            cmd.Parameters.AddWithValue("@OtherEarthing17", String.IsNullOrEmpty(OtherEarthing17) ? null : OtherEarthing17);

            cmd.Parameters.AddWithValue("@EarthingType18", EarthingType18 == "Select" ? null : EarthingType18);
            cmd.Parameters.AddWithValue("@Valueinohms18", String.IsNullOrEmpty(Valueinohms18) ? null : Valueinohms18);
            cmd.Parameters.AddWithValue("@UsedFor18", UsedFor18 == "Select" ? null : UsedFor18);
            cmd.Parameters.AddWithValue("@OtherEarthing18", String.IsNullOrEmpty(OtherEarthing18) ? null : OtherEarthing18);

            cmd.Parameters.AddWithValue("@EarthingType19", EarthingType19 == "Select" ? null : EarthingType19);
            cmd.Parameters.AddWithValue("@Valueinohms19", String.IsNullOrEmpty(Valueinohms19) ? null : Valueinohms19);
            cmd.Parameters.AddWithValue("@UsedFor19", UsedFor19 == "Select" ? null : UsedFor19);
            cmd.Parameters.AddWithValue("@OtherEarthing19", String.IsNullOrEmpty(OtherEarthing19) ? null : OtherEarthing19);

            cmd.Parameters.AddWithValue("@EarthingType20", EarthingType20 == "Select" ? null : EarthingType20);
            cmd.Parameters.AddWithValue("@Valueinohms20", String.IsNullOrEmpty(Valueinohms20) ? null : Valueinohms20);
            cmd.Parameters.AddWithValue("@UsedFor20", UsedFor20 == "Select" ? null : UsedFor20);
            cmd.Parameters.AddWithValue("@OtherEarthing20", String.IsNullOrEmpty(OtherEarthing20) ? null : OtherEarthing20);

            cmd.Parameters.AddWithValue("@LoadBreakingCapacityOfBreakerInKA", String.IsNullOrEmpty(LoadBreakingCapacityOfBreakerInKA) ? null : LoadBreakingCapacityOfBreakerInKA);
            cmd.Parameters.AddWithValue("@TypeOfLTProtection", TypeOfLTProtection == "Select" ? null : TypeOfLTProtection);
            cmd.Parameters.AddWithValue("@CapacityOfIndividualFuseInAMPS", String.IsNullOrEmpty(CapacityOfIndividualFuseInAMPS) ? null : CapacityOfIndividualFuseInAMPS);
            cmd.Parameters.AddWithValue("@CapacityOfLTBreakerInAMPS", String.IsNullOrEmpty(CapacityOfLTBreakerInAMPS) ? null : CapacityOfLTBreakerInAMPS);
            cmd.Parameters.AddWithValue("@LoadBreakingCapacityOfBreakerInAMPS", String.IsNullOrEmpty(LoadBreakingCapacityOfBreakerInAMPS) ? null : LoadBreakingCapacityOfBreakerInAMPS);
            cmd.Parameters.AddWithValue("@SeaLevelOfTransformerInMeters", String.IsNullOrEmpty(SeaLevelOfTransformerInMeters) ? null : SeaLevelOfTransformerInMeters);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@SubstationName", SubstationName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string GenerateUniqueSubstation()
        {
            SqlCommand cmd = new SqlCommand("sp_GenerateSubstationId");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region Update Substation Data
        public void UpdateSubstationData(string ID, string Count, string installaionInvoice, string ManufacturingReport)
        {
            SqlCommand cmd = new SqlCommand("sp_SubstationTestReportApproval");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Count", Count);
            cmd.Parameters.AddWithValue("@RejectOrApprovedFronContractor", "Submit");
            cmd.Parameters.AddWithValue("@installaionInvoice", installaionInvoice);
            cmd.Parameters.AddWithValue("@ManufacturingReport", ManufacturingReport);
            // cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateSubstationDataifExisting(string ID, string Count)
        {
            SqlCommand cmd = new SqlCommand("sp_SubstationTestReportApprovalifExisting");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Count", Count);
            cmd.Parameters.AddWithValue("@RejectOrApprovedFronContractor", "Submit");
            // cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
        #region Update GeneratingSet Data
        public void UpdateGeneratingSetData(string ID, string Count, string installaionInvoice, string ManufacturingReport)
        {
            SqlCommand cmd = new SqlCommand("sp_GeneratingTestReportApproval");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Count", Count);
            cmd.Parameters.AddWithValue("@RejectOrApprovedFronContractor", "Submit");
            cmd.Parameters.AddWithValue("@installaionInvoice", installaionInvoice);
            cmd.Parameters.AddWithValue("@ManufacturingReport", ManufacturingReport);
            //cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateGeneratingSetDataifExisting(string ID, string Count)
        {
            SqlCommand cmd = new SqlCommand("sp_GeneratingTestReportApprovalifExisting");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Count", Count);
            cmd.Parameters.AddWithValue("@RejectOrApprovedFronContractor", "Submit");
            //cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        #region Update Inspection Data
        public void UpdateInspectionData(string ID)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateStatus");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert GeneratingSet Data
        public void InsertGeneratingSetData(string IdUpdate, string Count, string IntimationId, string GeneratingSetCapacityType, string GeneratingSetCapacity, string SerialNumbrOfAcGenerator, string GeneratingSetType, string GeneratorVoltageLevel, string CurrenntCapacityOfBreaker,
 string BreakingCapacityofBreaker, string TypeOfPlant, string CapacityOfPlantType, string CapacityOfPlant, string HighestVoltageLevelOfDCString, string LowestInsulationBetweenDCWireToEarth,
 string NoOfPowerPCV, string LTACBreakerCapacity, string ACCablesLowestInsulation, string NumberOfEarthing, string EarthingType1, string EarthingValue1, string UsedFor1, string OtherEarthing1, string EarthingType2,
 string EarthingValue2, string UsedFor2, string OtherEarthing2, string EarthingType3, string EarthingValue3, string UsedFor3, string OtherEarthing3, string EarthingType4, string EarthingValue4, string UsedFor4, string OtherEarthing4, string EarthingType5, string EarthingValue5,
 string UsedFor5, string OtherEarthing5, string EarthingType6, string EarthingValue6, string UsedFor6, string OtherEarthing6, string EarthingType7, string EarthingValue7, string UsedFor7, string OtherEarthing7, string EarthingType8, string EarthingValue8,
 string UsedFor8, string OtherEarthing8, string EarthingType9, string EarthingValue9, string UsedFor9, string OtherEarthing9, string EarthingType10, string EarthingValue10, string UsedFor10, string OtherEarthing10, string EarthingType11, string EarthingValue11,
 string UsedFor11, string OtherEarthing11, string EarthingType12, string EarthingValue12, string UsedFor12, string OtherEarthing12, string EarthingType13, string EarthingValue13, string UsedFor13, string OtherEarthing13, string EarthingType14,
 string EarthingValue14, string UsedFor14, string OtherEarthing14, string EarthingType15, string EarthingValue15, string UsedFor15, string OtherEarthing15, string CreatedBy, string GeneratingSetName)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertGeneratingSetData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            #region old code
            //cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            //cmd.Parameters.AddWithValue("@Count", Count);
            //cmd.Parameters.AddWithValue("@Id", Id);
            //cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            //cmd.Parameters.AddWithValue("@GeneratingSetCapacityType", GeneratingSetCapacityType);
            //cmd.Parameters.AddWithValue("@GeneratingSetCapacity", GeneratingSetCapacity);
            //cmd.Parameters.AddWithValue("@SerialNumbrOfAcGenerator", SerialNumbrOfAcGenerator);
            //cmd.Parameters.AddWithValue("@GeneratingSetType", GeneratingSetType);
            //cmd.Parameters.AddWithValue("@GeneratorVoltageLevel", GeneratorVoltageLevel);
            //cmd.Parameters.AddWithValue("@CurrenntCapacityOfBreaker", CurrenntCapacityOfBreaker);
            //cmd.Parameters.AddWithValue("@BreakingCapacityofBreaker", BreakingCapacityofBreaker);
            //cmd.Parameters.AddWithValue("@TypeOfPlant", TypeOfPlant);
            //cmd.Parameters.AddWithValue("@CapacityOfPlantType", CapacityOfPlantType);
            //cmd.Parameters.AddWithValue("@CapacityOfPlant", CapacityOfPlant);
            //cmd.Parameters.AddWithValue("@HighestVoltageLevelOfDCString", HighestVoltageLevelOfDCString);
            //cmd.Parameters.AddWithValue("@LowestInsulationBetweenDCWireToEarth", LowestInsulationBetweenDCWireToEarth);
            //cmd.Parameters.AddWithValue("@NoOfPowerPCV", NoOfPowerPCV);
            //cmd.Parameters.AddWithValue("@LTACBreakerCapacity", LTACBreakerCapacity);
            //cmd.Parameters.AddWithValue("@ACCablesLowestInsulation", ACCablesLowestInsulation);
            //cmd.Parameters.AddWithValue("@NumberOfEarthing", NumberOfEarthing);
            //cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1);
            //cmd.Parameters.AddWithValue("@EarthingValue1", EarthingValue1);
            //cmd.Parameters.AddWithValue("@UsedFor1", UsedFor1);
            //cmd.Parameters.AddWithValue("@OtherEarthing1", OtherEarthing1);

            //cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2);
            //cmd.Parameters.AddWithValue("@EarthingValue2", EarthingValue2);
            //cmd.Parameters.AddWithValue("@UsedFor2", UsedFor2);
            //cmd.Parameters.AddWithValue("@OtherEarthing2", OtherEarthing2);

            //cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3);
            //cmd.Parameters.AddWithValue("@EarthingValue3", EarthingValue3);
            //cmd.Parameters.AddWithValue("@UsedFor3", UsedFor3);
            //cmd.Parameters.AddWithValue("@OtherEarthing3", OtherEarthing3);

            //cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4);
            //cmd.Parameters.AddWithValue("@EarthingValue4", EarthingValue4);
            //cmd.Parameters.AddWithValue("@UsedFor4", UsedFor4);
            //cmd.Parameters.AddWithValue("@OtherEarthing4", OtherEarthing4);

            //cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5);
            //cmd.Parameters.AddWithValue("@EarthingValue5", EarthingValue5);
            //cmd.Parameters.AddWithValue("@UsedFor5", UsedFor5);
            //cmd.Parameters.AddWithValue("@OtherEarthing5", OtherEarthing5);

            //cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6);
            //cmd.Parameters.AddWithValue("@EarthingValue6", EarthingValue6);
            //cmd.Parameters.AddWithValue("@UsedFor6", UsedFor6);
            //cmd.Parameters.AddWithValue("@OtherEarthing6", OtherEarthing6);

            //cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7);
            //cmd.Parameters.AddWithValue("@EarthingValue7", EarthingValue7);
            //cmd.Parameters.AddWithValue("@UsedFor7", UsedFor7);
            //cmd.Parameters.AddWithValue("@OtherEarthing7", OtherEarthing7);

            //cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8);
            //cmd.Parameters.AddWithValue("@EarthingValue8", EarthingValue8);
            //cmd.Parameters.AddWithValue("@UsedFor8", UsedFor8);
            //cmd.Parameters.AddWithValue("@OtherEarthing8", OtherEarthing8);

            //cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9);
            //cmd.Parameters.AddWithValue("@EarthingValue9", EarthingValue9);
            //cmd.Parameters.AddWithValue("@UsedFor9", UsedFor9);
            //cmd.Parameters.AddWithValue("@OtherEarthing9", OtherEarthing9);

            //cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10);
            //cmd.Parameters.AddWithValue("@EarthingValue10", EarthingValue10);
            //cmd.Parameters.AddWithValue("@UsedFor10", UsedFor10);
            //cmd.Parameters.AddWithValue("@OtherEarthing10", OtherEarthing10);

            //cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11);
            //cmd.Parameters.AddWithValue("@EarthingValue11", EarthingValue11);
            //cmd.Parameters.AddWithValue("@UsedFor11", UsedFor11);
            //cmd.Parameters.AddWithValue("@OtherEarthing11", OtherEarthing11);

            //cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12);
            //cmd.Parameters.AddWithValue("@EarthingValue12", EarthingValue12);
            //cmd.Parameters.AddWithValue("@UsedFor12", UsedFor12);
            //cmd.Parameters.AddWithValue("@OtherEarthing12", OtherEarthing12);

            //cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13);
            //cmd.Parameters.AddWithValue("@EarthingValue13", EarthingValue13);
            //cmd.Parameters.AddWithValue("@UsedFor13", UsedFor13);
            //cmd.Parameters.AddWithValue("@OtherEarthing13", OtherEarthing13);

            //cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14);
            //cmd.Parameters.AddWithValue("@EarthingValue14", EarthingValue14);
            //cmd.Parameters.AddWithValue("@UsedFor14", UsedFor14);
            //cmd.Parameters.AddWithValue("@OtherEarthing14", OtherEarthing14);

            //cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15);
            //cmd.Parameters.AddWithValue("@EarthingValue15", EarthingValue15);
            //cmd.Parameters.AddWithValue("@UsedFor15", UsedFor15);
            //cmd.Parameters.AddWithValue("@OtherEarthing15", OtherEarthing15);

            //cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            #endregion
            cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            cmd.Parameters.AddWithValue("@Count", string.IsNullOrEmpty(Count) ? DBNull.Value : (object)Count);
            // cmd.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(Id) ? DBNull.Value : (object)Id);
            cmd.Parameters.AddWithValue("@IntimationId", string.IsNullOrEmpty(IntimationId) ? DBNull.Value : (object)IntimationId);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacityType", string.IsNullOrEmpty(GeneratingSetCapacityType) ? DBNull.Value : (object)GeneratingSetCapacityType);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacity", string.IsNullOrEmpty(GeneratingSetCapacity) ? DBNull.Value : (object)GeneratingSetCapacity);
            cmd.Parameters.AddWithValue("@SerialNumbrOfAcGenerator", string.IsNullOrEmpty(SerialNumbrOfAcGenerator) ? DBNull.Value : (object)SerialNumbrOfAcGenerator);
            cmd.Parameters.AddWithValue("@GeneratingSetType", GeneratingSetType == "Select" ? DBNull.Value : (object)GeneratingSetType);
            cmd.Parameters.AddWithValue("@GeneratorVoltageLevel", string.IsNullOrEmpty(GeneratorVoltageLevel) ? DBNull.Value : (object)GeneratorVoltageLevel);
            cmd.Parameters.AddWithValue("@CurrenntCapacityOfBreaker", string.IsNullOrEmpty(CurrenntCapacityOfBreaker) ? DBNull.Value : (object)CurrenntCapacityOfBreaker);
            cmd.Parameters.AddWithValue("@BreakingCapacityofBreaker", string.IsNullOrEmpty(BreakingCapacityofBreaker) ? DBNull.Value : (object)BreakingCapacityofBreaker);
            cmd.Parameters.AddWithValue("@TypeOfPlant", TypeOfPlant == "Select" ? DBNull.Value : (object)TypeOfPlant);
            cmd.Parameters.AddWithValue("@CapacityOfPlantType", CapacityOfPlantType == "Select" ? DBNull.Value : (object)CapacityOfPlantType);
            cmd.Parameters.AddWithValue("@CapacityOfPlant", string.IsNullOrEmpty(CapacityOfPlant) ? DBNull.Value : (object)CapacityOfPlant);
            cmd.Parameters.AddWithValue("@HighestVoltageLevelOfDCString", string.IsNullOrEmpty(HighestVoltageLevelOfDCString) ? DBNull.Value : (object)HighestVoltageLevelOfDCString);
            cmd.Parameters.AddWithValue("@LowestInsulationBetweenDCWireToEarth", string.IsNullOrEmpty(LowestInsulationBetweenDCWireToEarth) ? DBNull.Value : (object)LowestInsulationBetweenDCWireToEarth);
            cmd.Parameters.AddWithValue("@NoOfPowerPCV", string.IsNullOrEmpty(NoOfPowerPCV) ? DBNull.Value : (object)NoOfPowerPCV);
            cmd.Parameters.AddWithValue("@LTACBreakerCapacity", string.IsNullOrEmpty(LTACBreakerCapacity) ? DBNull.Value : (object)LTACBreakerCapacity);
            cmd.Parameters.AddWithValue("@ACCablesLowestInsulation", string.IsNullOrEmpty(ACCablesLowestInsulation) ? DBNull.Value : (object)ACCablesLowestInsulation);
            cmd.Parameters.AddWithValue("@NumberOfEarthing", string.IsNullOrEmpty(NumberOfEarthing) ? DBNull.Value : (object)NumberOfEarthing);

            cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1 == "Select" ? DBNull.Value : (object)EarthingType1);
            cmd.Parameters.AddWithValue("@EarthingValue1", string.IsNullOrEmpty(EarthingValue1) ? DBNull.Value : (object)EarthingValue1);
            cmd.Parameters.AddWithValue("@UsedFor1", UsedFor1 == "Select" ? DBNull.Value : (object)UsedFor1);
            cmd.Parameters.AddWithValue("@OtherEarthing1", string.IsNullOrEmpty(OtherEarthing1) ? DBNull.Value : (object)OtherEarthing1);

            cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2 == "Select" ? DBNull.Value : (object)EarthingType2);
            cmd.Parameters.AddWithValue("@EarthingValue2", string.IsNullOrEmpty(EarthingValue2) ? DBNull.Value : (object)EarthingValue2);
            cmd.Parameters.AddWithValue("@UsedFor2", UsedFor2 == "Select" ? DBNull.Value : (object)UsedFor2);
            cmd.Parameters.AddWithValue("@OtherEarthing2", string.IsNullOrEmpty(OtherEarthing2) ? DBNull.Value : (object)OtherEarthing2);

            cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3 == "Select" ? DBNull.Value : (object)EarthingType3);
            cmd.Parameters.AddWithValue("@EarthingValue3", string.IsNullOrEmpty(EarthingValue3) ? DBNull.Value : (object)EarthingValue3);
            cmd.Parameters.AddWithValue("@UsedFor3", UsedFor3 == "Select" ? DBNull.Value : (object)UsedFor3);
            cmd.Parameters.AddWithValue("@OtherEarthing3", string.IsNullOrEmpty(OtherEarthing3) ? DBNull.Value : (object)OtherEarthing3);

            cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4 == "Select" ? DBNull.Value : (object)EarthingType4);
            cmd.Parameters.AddWithValue("@EarthingValue4", string.IsNullOrEmpty(EarthingValue4) ? DBNull.Value : (object)EarthingValue4);
            cmd.Parameters.AddWithValue("@UsedFor4", UsedFor4 == "Select" ? DBNull.Value : (object)UsedFor4);
            cmd.Parameters.AddWithValue("@OtherEarthing4", string.IsNullOrEmpty(OtherEarthing4) ? DBNull.Value : (object)OtherEarthing4);

            cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5 == "Select" ? DBNull.Value : (object)EarthingType5);
            cmd.Parameters.AddWithValue("@EarthingValue5", string.IsNullOrEmpty(EarthingValue5) ? DBNull.Value : (object)EarthingValue5);
            cmd.Parameters.AddWithValue("@UsedFor5", UsedFor5 == "Select" ? DBNull.Value : (object)UsedFor5);
            cmd.Parameters.AddWithValue("@OtherEarthing5", string.IsNullOrEmpty(OtherEarthing5) ? DBNull.Value : (object)OtherEarthing5);

            cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6 == "Select" ? DBNull.Value : (object)EarthingType6);
            cmd.Parameters.AddWithValue("@EarthingValue6", string.IsNullOrEmpty(EarthingValue6) ? DBNull.Value : (object)EarthingValue6);
            cmd.Parameters.AddWithValue("@UsedFor6", UsedFor6 == "Select" ? DBNull.Value : (object)UsedFor6);
            cmd.Parameters.AddWithValue("@OtherEarthing6", string.IsNullOrEmpty(OtherEarthing6) ? DBNull.Value : (object)OtherEarthing6);

            cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7 == "Select" ? DBNull.Value : (object)EarthingType7);
            cmd.Parameters.AddWithValue("@EarthingValue7", string.IsNullOrEmpty(EarthingValue7) ? DBNull.Value : (object)EarthingValue7);
            cmd.Parameters.AddWithValue("@UsedFor7", UsedFor7 == "Select" ? DBNull.Value : (object)UsedFor7);
            cmd.Parameters.AddWithValue("@OtherEarthing7", string.IsNullOrEmpty(OtherEarthing7) ? DBNull.Value : (object)OtherEarthing7);

            cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8 == "Select" ? DBNull.Value : (object)EarthingType8);
            cmd.Parameters.AddWithValue("@EarthingValue8", string.IsNullOrEmpty(EarthingValue8) ? DBNull.Value : (object)EarthingValue8);
            cmd.Parameters.AddWithValue("@UsedFor8", UsedFor8 == "Select" ? DBNull.Value : (object)UsedFor8);
            cmd.Parameters.AddWithValue("@OtherEarthing8", string.IsNullOrEmpty(OtherEarthing8) ? DBNull.Value : (object)OtherEarthing8);

            cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9 == "Select" ? DBNull.Value : (object)EarthingType9);
            cmd.Parameters.AddWithValue("@EarthingValue9", string.IsNullOrEmpty(EarthingValue9) ? DBNull.Value : (object)EarthingValue9);
            cmd.Parameters.AddWithValue("@UsedFor9", UsedFor9 == "Select" ? DBNull.Value : (object)UsedFor9);
            cmd.Parameters.AddWithValue("@OtherEarthing9", string.IsNullOrEmpty(OtherEarthing9) ? DBNull.Value : (object)OtherEarthing9);

            cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10 == "Select" ? DBNull.Value : (object)EarthingType10);
            cmd.Parameters.AddWithValue("@EarthingValue10", string.IsNullOrEmpty(EarthingValue10) ? DBNull.Value : (object)EarthingValue10);
            cmd.Parameters.AddWithValue("@UsedFor10", UsedFor10 == "Select" ? DBNull.Value : (object)UsedFor10);
            cmd.Parameters.AddWithValue("@OtherEarthing10", string.IsNullOrEmpty(OtherEarthing10) ? DBNull.Value : (object)OtherEarthing10);

            cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11 == "Select" ? DBNull.Value : (object)EarthingType11);
            cmd.Parameters.AddWithValue("@EarthingValue11", string.IsNullOrEmpty(EarthingValue11) ? DBNull.Value : (object)EarthingValue11);
            cmd.Parameters.AddWithValue("@UsedFor11", UsedFor11 == "Select" ? DBNull.Value : (object)UsedFor11);
            cmd.Parameters.AddWithValue("@OtherEarthing11", string.IsNullOrEmpty(OtherEarthing11) ? DBNull.Value : (object)OtherEarthing11);

            cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12 == "Select" ? DBNull.Value : (object)EarthingType12);
            cmd.Parameters.AddWithValue("@EarthingValue12", string.IsNullOrEmpty(EarthingValue12) ? DBNull.Value : (object)EarthingValue12);
            cmd.Parameters.AddWithValue("@UsedFor12", UsedFor12 == "Select" ? DBNull.Value : (object)UsedFor12);
            cmd.Parameters.AddWithValue("@OtherEarthing12", string.IsNullOrEmpty(OtherEarthing12) ? DBNull.Value : (object)OtherEarthing12);

            cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13 == "Select" ? DBNull.Value : (object)EarthingType9);
            cmd.Parameters.AddWithValue("@EarthingValue13", string.IsNullOrEmpty(EarthingValue13) ? DBNull.Value : (object)EarthingValue13);
            cmd.Parameters.AddWithValue("@UsedFor13", UsedFor13 == "Select" ? DBNull.Value : (object)EarthingType9);
            cmd.Parameters.AddWithValue("@OtherEarthing13", string.IsNullOrEmpty(OtherEarthing13) ? DBNull.Value : (object)OtherEarthing13);

            cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14 == "Select" ? DBNull.Value : (object)EarthingType14);
            cmd.Parameters.AddWithValue("@EarthingValue14", string.IsNullOrEmpty(EarthingValue14) ? DBNull.Value : (object)EarthingValue14);
            cmd.Parameters.AddWithValue("@UsedFor14", UsedFor14 == "Select" ? DBNull.Value : (object)UsedFor14);
            cmd.Parameters.AddWithValue("@OtherEarthing14", string.IsNullOrEmpty(OtherEarthing14) ? DBNull.Value : (object)OtherEarthing14);

            cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15 == "Select" ? DBNull.Value : (object)EarthingType15);
            cmd.Parameters.AddWithValue("@EarthingValue15", string.IsNullOrEmpty(EarthingValue15) ? DBNull.Value : (object)EarthingValue15);
            cmd.Parameters.AddWithValue("@UsedFor15", UsedFor15 == "Select" ? DBNull.Value : (object)UsedFor15);
            cmd.Parameters.AddWithValue("@OtherEarthing15", string.IsNullOrEmpty(OtherEarthing15) ? DBNull.Value : (object)OtherEarthing15);

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@GeneratingSetName", GeneratingSetName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string GenerateUniqueGeneratingSetId()
        {
            SqlCommand cmd = new SqlCommand("sp_GeneratingSetId");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region Insert Phase Data
        public void InsertPhaseData(string Id, string InstallationType, string VoltageLevel, string CapacityMainSwitchAndBreaker, string NumberOfEarthing,
            string EarthingType1, string EarthingValue1, string UsedFor1, string EarthingType2, string EarthingValue2, string UsedFor2,
            string EarthingType3, string EarthingValue3, string UsedFor3, string EarthingType4, string EarthingValue4, string UsedFor4,
            string EarthingType5, string EarthingValue5, string UsedFor5, string EarthingType6, string EarthingValue6, string UsedFor6, string EarthingType7,
            string EarthingValue7, string UsedFor7, string EarthingType8, string EarthingValue8, string UsedFor8, string EarthingType9, string EarthingValue9,
            string UsedFor9, string EarthingType10, string EarthingValue10, string UsedFor10, string EarthingType11, string EarthingValue11, string UsedFor11,
            string EarthingType12, string EarthingValue12, string UsedFor12, string EarthingType13, string EarthingValue13, string UsedFor13, string EarthingType14,
            string EarthingValue14, string UsedFor14, string EarthingType15, string EarthingValue15, string UsedFor15, string MinimumIRValueBWwires,
            string NoOfRCCB, string RatingOfRCCB, string CurrentCarryingCpacity, string NoOfCircuit, string NoOfMotors)
        {
            SqlCommand cmd = new SqlCommand("sp_SingleOrThreePhase");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@CapacityMainSwitchAndBreaker", CapacityMainSwitchAndBreaker);
            cmd.Parameters.AddWithValue("@NumberOfEarthing", NumberOfEarthing);
            cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1);
            cmd.Parameters.AddWithValue("@EarthingValue1", EarthingValue1);
            cmd.Parameters.AddWithValue("@UsedFor1", UsedFor1);
            cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2);
            cmd.Parameters.AddWithValue("@EarthingValue2", EarthingValue2);
            cmd.Parameters.AddWithValue("@UsedFor2", UsedFor2);
            cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3);
            cmd.Parameters.AddWithValue("@EarthingValue3", EarthingValue3);
            cmd.Parameters.AddWithValue("@UsedFor3", UsedFor3);
            cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4);
            cmd.Parameters.AddWithValue("@EarthingValue4", EarthingValue4);
            cmd.Parameters.AddWithValue("@UsedFor4", UsedFor4);
            cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5);
            cmd.Parameters.AddWithValue("@EarthingValue5", EarthingValue5);
            cmd.Parameters.AddWithValue("@UsedFor5", UsedFor5);
            cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6);
            cmd.Parameters.AddWithValue("@EarthingValue6", EarthingValue6);
            cmd.Parameters.AddWithValue("@UsedFor6", UsedFor6);
            cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7);
            cmd.Parameters.AddWithValue("@EarthingValue7", EarthingValue7);
            cmd.Parameters.AddWithValue("@UsedFor7", UsedFor7);
            cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8);
            cmd.Parameters.AddWithValue("@EarthingValue8", EarthingValue8);
            cmd.Parameters.AddWithValue("@UsedFor8", UsedFor8);
            cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9);
            cmd.Parameters.AddWithValue("@EarthingValue9", EarthingValue9);
            cmd.Parameters.AddWithValue("@UsedFor9", UsedFor9);
            cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10);
            cmd.Parameters.AddWithValue("@EarthingValue10", EarthingValue10);
            cmd.Parameters.AddWithValue("@UsedFor10", UsedFor10);
            cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11);
            cmd.Parameters.AddWithValue("@EarthingValue11", EarthingValue11);
            cmd.Parameters.AddWithValue("@UsedFor11", UsedFor11);
            cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12);
            cmd.Parameters.AddWithValue("@EarthingValue12", EarthingValue12);
            cmd.Parameters.AddWithValue("@UsedFor12", UsedFor12);
            cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13);
            cmd.Parameters.AddWithValue("@EarthingValue13", EarthingValue13);
            cmd.Parameters.AddWithValue("@UsedFor13", UsedFor13);
            cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14);
            cmd.Parameters.AddWithValue("@EarthingValue14", EarthingValue14);
            cmd.Parameters.AddWithValue("@UsedFor14", UsedFor14);
            cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15);
            cmd.Parameters.AddWithValue("@EarthingValue15", EarthingValue15);
            cmd.Parameters.AddWithValue("@UsedFor15", UsedFor15);
            cmd.Parameters.AddWithValue("@MinimumIRValueBWwires", MinimumIRValueBWwires);
            cmd.Parameters.AddWithValue("@NoOfRCCB", NoOfRCCB);
            cmd.Parameters.AddWithValue("@RatingOfRCCB", RatingOfRCCB);
            cmd.Parameters.AddWithValue("@CurrentCarryingCpacity", CurrentCarryingCpacity);
            cmd.Parameters.AddWithValue("@NoOfCircuit", NoOfCircuit);
            cmd.Parameters.AddWithValue("@NoOfMotors", NoOfMotors);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion 
        #region Insert Test Report Data
        public void InsertTestReportData(string IntimationId, string InstallationFor, string NameOfOwner, string NameOfAgency, string ContactNo,
            string AddressOfSite, string TypeOfPremises, string VoltageLevel, string WorkStartDate, string WorkCompletionDate, string SanctionLoad,
            string InstallationType1, string TypeOfInstallation1, string InstallationType2, string TypeOfInstallation2, string
InstallationType3, string TypeOfInstallation3, string InstallationType4, string TypeOfInstallation4, string InstallationType5,
            string TypeOfInstallation5, string InstallationType6, string TypeOfInstallation6, string InstallationType7,
            string TypeOfInstallation7, string InstallationType8, string TypeOfInstallation8)
        {
            SqlCommand cmd = new SqlCommand("sp_TestReport");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.Parameters.AddWithValue("@InstallationFor", InstallationFor);
            cmd.Parameters.AddWithValue("@NameOfOwner", NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@AddressOfSite", AddressOfSite);
            cmd.Parameters.AddWithValue("@TypeOfPremises", TypeOfPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@WorkStartDate", WorkStartDate);
            cmd.Parameters.AddWithValue("@WorkCompletionDate", WorkCompletionDate);
            cmd.Parameters.AddWithValue("@SanctionLoad", SanctionLoad);
            cmd.Parameters.AddWithValue("@InstallationType1", InstallationType1);
            cmd.Parameters.AddWithValue("@TypeOfInstallation1", TypeOfInstallation1);
            cmd.Parameters.AddWithValue("@InstallationType2", InstallationType2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@InstallationType3", InstallationType3);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@InstallationType4", InstallationType4);
            cmd.Parameters.AddWithValue("@TypeOfInstallation4", TypeOfInstallation4);
            cmd.Parameters.AddWithValue("@InstallationType5", InstallationType5);
            cmd.Parameters.AddWithValue("@TypeOfInstallation5", TypeOfInstallation5);
            cmd.Parameters.AddWithValue("@InstallationType6", InstallationType6);
            cmd.Parameters.AddWithValue("@TypeOfInstallation6", TypeOfInstallation6);
            cmd.Parameters.AddWithValue("@InstallationType7", InstallationType7);
            cmd.Parameters.AddWithValue("@TypeOfInstallation7", TypeOfInstallation7);
            cmd.Parameters.AddWithValue("@InstallationType8", InstallationType8);
            cmd.Parameters.AddWithValue("@TypeOfInstallation8", TypeOfInstallation8);
            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

        }
        public string TestReportId()
        {
            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region Insert Lift Data
        public void InsertLiftData(string Id, string VoltageAndSystemOfSupply, string MVInstallation, string SerailNumber1, string Equipment1,
            string Voltage1, string FedFromDistribution1, string SerailNumber2, string Equipment2, string Voltage2, string FedFromDistribution2,
            string SerailNumber3, string Equipment3, string Voltage3, string FedFromDistribution3, string SerailNumber4, string Equipment4,
            string Voltage4, string FedFromDistribution4, string SerailNumber5, string Equipment5, string Voltage5,
            string FedFromDistribution5, string InsulationResistanceForInstallation,
            string RedYellowPhase, string RedBluePhase, string BlueYellowPhase, string RedPhaseEarthWire, string YellowPhaseEarthWire,
            string BluePhaseEarthWire, string NumberOfEarthing, string EarthingType1, string EarthingValue1, string EarthingType2,
            string EarthingValue2, string EarthingType3, string EarthingValue3, string EarthingType4,
            string EarthingValue4, string EarthingType5, string EarthingValue5, string EarthingType6, string EarthingValue6,
            string EarthingType7, string EarthingValue7, string EarthingType8, string EarthingValue8, string EarthingType9,
            string EarthingValue9, string EarthingType10, string EarthingValue10, string EarthingType11, string EarthingValue11,
            string EarthingType12, string EarthingValue12, string EarthingType13, string EarthingValue13, string EarthingType14,
            string EarthingValue14, string EarthingType15, string EarthingValue15)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertLift");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id);
            cmd.Parameters.AddWithValue("@VoltageAndSystemOfSu ", VoltageAndSystemOfSupply);
            cmd.Parameters.AddWithValue("@MVInstallation ", MVInstallation);
            cmd.Parameters.AddWithValue("@SerailNumber1 ", SerailNumber1);
            cmd.Parameters.AddWithValue("@Equipment1 ", Equipment1);
            cmd.Parameters.AddWithValue("@Voltage1 ", Voltage1);
            cmd.Parameters.AddWithValue("@FedFromDistribution1 ", FedFromDistribution1);
            cmd.Parameters.AddWithValue("@SerailNumber2", SerailNumber2);
            cmd.Parameters.AddWithValue("@Equipment2", Equipment1);
            cmd.Parameters.AddWithValue("@Voltage2", Voltage2);
            cmd.Parameters.AddWithValue("@FedFromDistribution2", FedFromDistribution2);
            cmd.Parameters.AddWithValue("@SerailNumber3", SerailNumber3);
            cmd.Parameters.AddWithValue("@Equipment3", Equipment3);
            cmd.Parameters.AddWithValue("@Voltage3", Voltage3);
            cmd.Parameters.AddWithValue("@FedFromDistribution3", FedFromDistribution3);
            cmd.Parameters.AddWithValue("@SerailNumber4", SerailNumber4);
            cmd.Parameters.AddWithValue("@Equipment4", Equipment4);
            cmd.Parameters.AddWithValue("@Voltage4", Voltage4);
            cmd.Parameters.AddWithValue("@FedFromDistribution4", FedFromDistribution4);
            cmd.Parameters.AddWithValue("@SerailNumber5", SerailNumber5);
            cmd.Parameters.AddWithValue("@Equipment5", Equipment5);
            cmd.Parameters.AddWithValue("@Voltage5", Voltage5);
            cmd.Parameters.AddWithValue("@FedFromDistribution5", FedFromDistribution5);
            cmd.Parameters.AddWithValue("@InsulationResistanceForInstallation", InsulationResistanceForInstallation);
            cmd.Parameters.AddWithValue("@RedYellowPhase", RedYellowPhase);
            cmd.Parameters.AddWithValue("@RedBluePhase", RedBluePhase);
            cmd.Parameters.AddWithValue("@BlueYellowPhase", BlueYellowPhase);
            cmd.Parameters.AddWithValue("@RedPhaseEarthWire", RedPhaseEarthWire);
            cmd.Parameters.AddWithValue("@YellowPhaseEarthWire", YellowPhaseEarthWire);
            cmd.Parameters.AddWithValue("@BluePhaseEarthWire", BluePhaseEarthWire);
            cmd.Parameters.AddWithValue("@NumberOfEarthing", NumberOfEarthing);
            cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1);
            cmd.Parameters.AddWithValue("@EarthingValue1", EarthingValue1);
            cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2);
            cmd.Parameters.AddWithValue("@EarthingValue2", EarthingValue2);
            cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3);
            cmd.Parameters.AddWithValue("@EarthingValue3", EarthingValue3);
            cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4);
            cmd.Parameters.AddWithValue("@EarthingValue4", EarthingValue4);
            cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5);
            cmd.Parameters.AddWithValue("@EarthingValue5", EarthingValue5);
            cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6);
            cmd.Parameters.AddWithValue("@EarthingValue6", EarthingValue6);
            cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7);
            cmd.Parameters.AddWithValue("@EarthingValue7", EarthingValue7);
            cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8);
            cmd.Parameters.AddWithValue("@EarthingValue8", EarthingValue8);
            cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9);
            cmd.Parameters.AddWithValue("@EarthingValue9", EarthingValue9);
            cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10);
            cmd.Parameters.AddWithValue("@EarthingValue10", EarthingValue10);
            cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11);
            cmd.Parameters.AddWithValue("@EarthingValue11", EarthingValue11);
            cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12);
            cmd.Parameters.AddWithValue("@EarthingValue12", EarthingValue12);
            cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13);
            cmd.Parameters.AddWithValue("@EarthingValue13", EarthingValue13);
            cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14);
            cmd.Parameters.AddWithValue("@EarthingValue14", EarthingValue14);
            cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15);
            cmd.Parameters.AddWithValue("@EarthingValue15", EarthingValue15);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Inspection Data
        public void InsertInspectionData(string ContactNo, string TestRportId, string ApplicantTypeCode, string IntimationId, string Inspectiontype, string ApplicantType, string InstallationType,
      string VoltageLevel, string LineLength, string TestReportCount, string RequestLetterFromConcernedOfficer, string ManufacturingTestReportOfEqipment,
      string SingleLineDiagramOfLine, string DemandNoticeOfLine, string CopyOfNoticeIssuedByUHBVNorDHBVN,
      string InvoiceOfTransferOfPersonalSubstation, string ManufacturingTestCertificateOfTransformer,
      string SingleLineDiagramofTransformer, string InvoiceoffireExtinguisheratSite, string InvoiceOfDGSetOfGeneratingSet,
      string ManufacturingCerificateOfDGSet, string InvoiceOfExptinguisherOrApparatusAtsite,
      string StructureStabilityResolvedByAuthorizedEngineer, string District, string Division, string PaymentMode, string DateOfSubmission, string CreatedBy,
      int TotalAmount, string transcationId, string TranscationDate, string ChallanAttachment
      )
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ContactNo ", ContactNo);

            cmd.Parameters.AddWithValue("@ContactNo ", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@TestRportId ", TestRportId);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode ", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel ", VoltageLevel);
            //cmd.Parameters.AddWithValue("@LineLength ", LineLength);
            cmd.Parameters.AddWithValue("@LineLength ", String.IsNullOrEmpty(LineLength) ? DBNull.Value : (object)LineLength);
            cmd.Parameters.AddWithValue("@TestReportCount ", TestReportCount);

            cmd.Parameters.AddWithValue("@RequestLetterFromConcernedOfficer ", String.IsNullOrEmpty(RequestLetterFromConcernedOfficer) ? DBNull.Value : (object)RequestLetterFromConcernedOfficer);
            cmd.Parameters.AddWithValue("@ManufacturingTestReportOfEqipment ", String.IsNullOrEmpty(ManufacturingTestReportOfEqipment) ? DBNull.Value : (object)ManufacturingTestReportOfEqipment);
            cmd.Parameters.AddWithValue("@SingleLineDiagramOfLine ", String.IsNullOrEmpty(SingleLineDiagramOfLine) ? DBNull.Value : (object)SingleLineDiagramOfLine);
            cmd.Parameters.AddWithValue("@DemandNoticeOfLine ", String.IsNullOrEmpty(DemandNoticeOfLine) ? DBNull.Value : (object)DemandNoticeOfLine);
            cmd.Parameters.AddWithValue("@CopyOfNoticeIssuedByUHBVNorDHBVN ", String.IsNullOrEmpty(CopyOfNoticeIssuedByUHBVNorDHBVN) ? DBNull.Value : (object)CopyOfNoticeIssuedByUHBVNorDHBVN);
            cmd.Parameters.AddWithValue("@InvoiceOfTransferOfPersonalSubstation ", String.IsNullOrEmpty(InvoiceOfTransferOfPersonalSubstation) ? DBNull.Value : (object)InvoiceOfTransferOfPersonalSubstation);
            cmd.Parameters.AddWithValue("@ManufacturingTestCertificateOfTransformer ", String.IsNullOrEmpty(ManufacturingTestCertificateOfTransformer) ? DBNull.Value : (object)ManufacturingTestCertificateOfTransformer);
            cmd.Parameters.AddWithValue("@SingleLineDiagramofTransformer ", String.IsNullOrEmpty(SingleLineDiagramofTransformer) ? DBNull.Value : (object)SingleLineDiagramofTransformer);
            cmd.Parameters.AddWithValue("@InvoiceoffireExtinguisheratSite ", String.IsNullOrEmpty(InvoiceoffireExtinguisheratSite) ? DBNull.Value : (object)InvoiceoffireExtinguisheratSite);
            cmd.Parameters.AddWithValue("@InvoiceOfDGSetOfGeneratingSet ", String.IsNullOrEmpty(InvoiceOfDGSetOfGeneratingSet) ? DBNull.Value : (object)InvoiceOfDGSetOfGeneratingSet);
            cmd.Parameters.AddWithValue("@ManufacturingCerificateOfDGSet ", String.IsNullOrEmpty(ManufacturingCerificateOfDGSet) ? DBNull.Value : (object)ManufacturingCerificateOfDGSet);
            cmd.Parameters.AddWithValue("@InvoiceOfExptinguisherOrApparatusAtsite ", String.IsNullOrEmpty(InvoiceOfExptinguisherOrApparatusAtsite) ? DBNull.Value : (object)InvoiceOfExptinguisherOrApparatusAtsite);
            cmd.Parameters.AddWithValue("@StructureStabilityResolvedByAuthorizedEngineer ", String.IsNullOrEmpty(StructureStabilityResolvedByAuthorizedEngineer) ? DBNull.Value : (object)StructureStabilityResolvedByAuthorizedEngineer);
            cmd.Parameters.AddWithValue("@District ", District);
            cmd.Parameters.AddWithValue("@Division ", Division);
            cmd.Parameters.AddWithValue("@PaymentMode ", PaymentMode);//
            DateTime SubmitionDate;
            if (DateTime.TryParse(DateOfSubmission, out SubmitionDate) && SubmitionDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", SubmitionDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", DBNull.Value);
            }
            //cmd.Parameters.AddWithValue("@DateOfSubmission ", DateOfSubmission);

            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.Parameters.AddWithValue("@TransactionId ", transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@TransctionDate ", TranscationDate);
            cmd.Parameters.AddWithValue("@ChallanAttachment ", ChallanAttachment);
            outputParam = new SqlParameter("@GeneratedId", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            //int generatedId = Convert.ToInt32(outputParam.Value);

            con.Close();
        }



        public string InspectionId()
        {
            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion



        #region Update Work Intimation Contractor Data
        public void updateWorkIntimation(string Id)
        {
            SqlCommand cmd = new SqlCommand("sp_ContractorDataUpdate");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Update Inspection Data

        public void updateInspection(string InspectionID, string StaffId, string IntimatiomnId, int count, string Installationtype,
                string AcceptedOrReReturn, string Reason, string ReasonType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_InspectionReview", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", InspectionID);
                        cmd.Parameters.AddWithValue("@StaffId", StaffId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimatiomnId);
                        cmd.Parameters.AddWithValue("@count", count);
                        cmd.Parameters.AddWithValue("@Installationtype ", Installationtype);
                        cmd.Parameters.AddWithValue("@AcceptedOrReturn ", AcceptedOrReReturn);
                        cmd.Parameters.AddWithValue("@ReasonForRejection ", Reason);
                        cmd.Parameters.AddWithValue("@ReasonType ", ReasonType);
                        //cmd.Parameters.AddWithValue("@AdditionalNotes", AdditonalNotes);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    //throw;
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        public void updateInspectionCEI(string InspectionID, string StaffId, string IntimatiomnId, int count, string Installationtype,
               string AcceptedOrReReturn, string Reason, string ReasonType)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InspectionReview");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", InspectionID);
                cmd.Parameters.AddWithValue("@StaffId", StaffId);
                cmd.Parameters.AddWithValue("@IntimationId", IntimatiomnId);
                cmd.Parameters.AddWithValue("@count", count);
                cmd.Parameters.AddWithValue("@Installationtype ", Installationtype);
                cmd.Parameters.AddWithValue("@AcceptedOrReturn ", AcceptedOrReReturn);
                cmd.Parameters.AddWithValue("@ReasonForRejection ", Reason);
                cmd.Parameters.AddWithValue("@ReasonType ", ReasonType);
                //cmd.Parameters.AddWithValue("@AdditionalNotes", AdditonalNotes);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw;
            }

        }

        public void InspectionFinalAction(string InspectionID, string StaffId, string AcceptedOrReReturn, string Reason, string suggestions, string InspectionDate, SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InspectionApproveReject", transaction.Connection, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", InspectionID);
                cmd.Parameters.AddWithValue("@StaffId", StaffId);
                cmd.Parameters.AddWithValue("@AcceptedOrRejected", AcceptedOrReReturn);
                cmd.Parameters.AddWithValue("@ReasonForRejection", Reason);
                cmd.Parameters.AddWithValue("@Suggestion", suggestions);
                //cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                DateTime InsDate;
                if (DateTime.TryParse(InspectionDate, out InsDate) && InsDate != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@InspectionDate", DBNull.Value);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }





        #endregion  
        #region Update Inspection PendingPayment Data
        public void updateInspectionPending(string ID, string TransactionId, string TransctionDate, string ChallanAttachment)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateInspectionPaymentHistory");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID ", ID);
            cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
            cmd.Parameters.AddWithValue("@TransctionDate ", TransctionDate);
            cmd.Parameters.AddWithValue("@ChallanAttachment", ChallanAttachment);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        public string GenerateUniqueID()
        {
            SqlCommand cmd = new SqlCommand("sp_generateLineId");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }

        #region Bind DropDown Draw State
        public DataSet GetddlDrawState()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getStateForDropdown");
        }
        #endregion

        #region Bind DropDown Draw Earthing
        public DataSet GetddlEarthing()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Earthing");
        }
        #endregion

        #region Bind DropDown Draw State
        public DataSet GetddlDrawDistrict(string State)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDistrictForDropdownState", State);
        }
        #endregion 
        #region Get Contractor Data
        public DataSet GetContractorData(string REID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_updateContractorData", REID);
        }
        #endregion
        #region Get Supervisor Data
        public DataSet GetSupervisorData(string REID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSuperwiserDetails", REID);
        }
        #endregion
        public string ValidateOTP(string mobilenumber)
        {
            //string mobilenumber = Session["Contact"].ToString();
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);

            string otp = otpInt.ToString("D6");
            //Session["OTP"] = otp;

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://smpanelv.yieldplus.in/api/mt/SendSMS?APIKey=546t3yI5n06VJogf7Keaiw&senderid=SDEI&channel=Trans&DCS=0&flashsms=0&number=" + mobilenumber + "&text=Dear Customer " + otp + " is the OTP for your request send to CEI Department, HRY. OTPs are SECRET. DO NOT share OTP with anyone --SAFEDOT&route=2&peid=1101407410000040566");
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();

            respStreamReader.Close();
            myResp.Close();
            return otp;
        }
        public string ValidateOTPthroughEmail(string Email)
        {
            //string mobilenumber = Session["Contact"].ToString();
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);

            string otp = otpInt.ToString("D6");
            //Session["OTP"] = otp;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("haryanacei@gmail.com");
            mailMessage.To.Add(Email); mailMessage.Subject = "OTP For Test Report";
            string body = $"Dear Customer,\n\n" + otp + " is the OTP for your request send to CEI Department, HRY.OTPs are SECRET.DO NOT share OTP with anyone.Thank you for choosing our services. If you have any questions or need further assistance, please feel free to contact our support team.\n\n Best regards,\n\n[CEI Haryana]";
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("haryanacei@gmail.com", "httnrdifrwgfnzrv");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            return otp;
        }
        public void NewCredentialsthroughEmail(string Email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("haryanacei@gmail.com");
            mailMessage.To.Add(Email);
            mailMessage.Subject = "Credentials";
            string body = $"Dear Customer,\n\nWe are pleased to inform you that your account has been successfully created. Your user ID is the first 4 characters of your name combined with your date of birth.\n\nThank you for choosing our services. If you have any questions or need further assistance, please feel free to contact our support team.\n\nBest regards,\n[CEI Haryana]";
            mailMessage.Body = body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("haryanacei@gmail.com", "httnrdifrwgfnzrv");
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }

        public void SiteOwnerCredentials(string Email, string pan)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("haryanacei@gmail.com");
            mailMessage.To.Add(Email); mailMessage.Subject = "Your Site Owner ID and Password";
            string body = $"Dear Customer,\n\nWe are pleased to inform you that your account has been successfully created. Your user id is {pan} and Password is 123456 Visit Website http://ceiharyana.com/ \n\nThank you for choosing our services. If you have any questions or need further assistance, please feel free to contact our support team.\n\nBest regards,\n[CEI Haryana]"; ;
            mailMessage.Body = body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("haryanacei@gmail.com", "httnrdifrwgfnzrv");
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }


        public DataTable InspectionHistoryForAdminData(string LoginId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InspectionHistoryForAdmin", LoginId);
        }
        #region Get WorkIntimationDataForAdmin Data
        public DataSet GetWorkIntimationDataForAdmin(string REID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationData", REID);
        }
        #endregion
        public DataSet GetddlEarthingSubstation()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_EarthingSubstation");
        }
        public DataSet GetddlPrimaryVotlage()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PrimaryVoltage");
        }
        public DataSet GetddlPremises()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Premises");
        }
        public DataSet GetContractorContact(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetContractorContactNo", UserId);
        }
        public DataSet GetddlTestReportVoltage()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TestReprortVoltage");
        }
        public DataSet GetddlAssignedWorkForSupervisor()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_WorkDetail");
        }
        public DataSet GetContractorNotifications(string ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ContractorNotificationData", ID);
        }
        public DataSet GetddlInstallationType()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InstallatioType");
        }
        public DataSet GetSuppervisorLineTestReportData(string LineID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLineDataBySupervisor", LineID);
        }
        public DataSet GetSubstationDataBySupervisor(string SubstationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSubstationDataBySupervisor", SubstationId);
        }
        public DataSet GetGeneraterSetData(string GeneratingId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetGeneraterSetDataBySupervisor", GeneratingId);
        }
        public DataSet GetddlDistrict()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AreaCovered");
        }
        public DataSet GetddlDrawDistrictddl()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDistrictForDropdown");
        }
        public DataSet GetddlDrawContractor()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getContractorForDropdown");
        }
        public DataSet GetQualification()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetQualificatiohn");
        }
        public DataSet GetddlVoltageLevel()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetVoltageLevel");
        }
        public DataSet GetContractorData()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetContractorDetails");
        }
        public DataSet GetContractorDataForLiftEscalator()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetContractorDetailsForLiftEscalator");
        }
        public DataTable GetContractorDataforgrid(string loginType, string ID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetContractorData", loginType, ID);
        }
        public DataTable GetWiremanorSuperwiserData(string category, string loginType, string ID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetWiremanorSuperwiserData", category, loginType, ID);
        }
        public DataTable SearchSupervisororWiremen(string searchterm, string category)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetWiremanorSuperwiserData", searchterm, category);
        }
        //Neeraj 26-12
        public DataTable WorkIntimationData(string LoginID, string searchText = null)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationProjects", LoginID, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
       
        // public DataSet LineDataWithId(int ID) gurmeet
        public DataSet LineDataWithId(string ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLineDataWithId", ID);
        }
        public DataSet LineTestReportData(string LineID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLineData", LineID);
        }
        public DataSet SubstationTestReportData(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SubstationDataWithId", Id);
        }
        public DataSet StaffLogin(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_StaffLogin", Id);
        }
        public DataSet ActionTaken(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InspectionActionTakenData", Id);
        }
        public DataSet InspectionData(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData", Id);
        } 
        public DataSet GetInspectionData(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportHistoryForSiteOwner", Id);
        }
        public DataTable SiteOwnerLineData(string PanId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerLineReportData", PanId);
        }
        public DataSet TransformerTestReportData(string SubStationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSubstationHistory", SubStationId);
        }
        public DataTable TestReportSubstationData(string SubStationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerTransformerReportData", SubStationId);
        }
        public DataTable TestReportGeneratingData(string PanId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerGeneratingReportData", PanId);
        }
        public DataTable SiteOwnerInspectionData(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistory", SiteOwnerId);
        }
        public DataSet GeneratingTestReportData(string GeneratingSetId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetGenratingSetHistory", GeneratingSetId);
        }
        public DataSet GeneratingTestReportDataWithId(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GeneratingDataWithId", Id);
        }
        public DataTable GetStaffAssignedToContractor(string ID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffAssignedtoContractor", ID);
        }
        public DataSet GetddlVoltageForLine(string voltage)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_LineVoltage", voltage);
        }
        public DataTable WorkIntimationDataforAdmin()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationProjectsforAdmin");
        }
        public DataTable WorkIntimationDataforSupervisor(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSupervisor", Id);
        }
        public int SetDataInStaffAssined(string REID, string projectId, string AssignBy, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_setDataInStaffAssined", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REID ", REID);
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@AssignBy", AssignBy);
            int rowsAffected = cmd.ExecuteNonQuery();

            cmd.Dispose();

            return rowsAffected;
            //return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_setDataInStaffAssined", REID, projectId, AssignBy, transaction);            

        }
        public int updateUserRegistration(int registrationId)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_updateUserRegistration", registrationId);
        }

        public int UserDocuments(string UserId, string flpPhotourl8, string flpPhotourl, string flpPhotourl1, string flpPhotourl2, string flpPhotourl3, string flpPhotourl4, string flpPhotourl5, string flpPhotourl9, string flpPhotourl6, string flpPhotourl7)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UserDocuments", UserId, flpPhotourl8, flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl9, flpPhotourl6, flpPhotourl7);
        }
        public DataTable RegistrationDetails()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetRegistrationDataSupervisor");
        }
        public DataTable WirmenRegistrationDetails()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetRegistrationDataWiremen");
        }
        public static int DropRegistrationData(int registrationId)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DropUserRegistration", registrationId);
        }

        public DataSet checkGSTexist(string GSTnumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_checkGST", GSTnumber);
        }

        public DataSet checkLicenceexist(string LicenceNew, string LicenceOld)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_checkLicence", LicenceNew, LicenceOld);
        }
        public DataSet checkLicenceexistUpdated(string LicenceNew, string LicenceOld, string ContractorId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_checkLicenceUpdated", LicenceNew, LicenceOld, ContractorId);
        }
        public DataSet checkCertificateexist(string CertificateOld, string CertificateNew)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckCertificate", CertificateOld, CertificateNew);
        }
        public DataSet checkCertificateexistupdated(string CertificateOld, string CertificateNew, string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckCertificateupdated", CertificateOld, CertificateNew, Id);
        }

        public DataSet SearchingOnGeneraterSet(string searchterm, string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SearchingGeneraterSet", searchterm, LoginId);
        }

        public DataSet SearchingOnSubstation(string searchterm, string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SearchingSubstation", searchterm, LoginId);
        }
        public DataSet SearchingOnLine(string searchterm, string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SearchingLineData", searchterm, LoginId);
        }

        public DataSet SearchingOnIntimation(string searchterm, string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SearchingIntimationData", searchterm, LoginId);
        }
        public DataSet GetSuperVisorContact(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSupervisorData", UserId);
        }
        public DataSet GetTestReportHistoryForUpdate(string Type, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SearchingTestReportHistory", Type, TestReportId);
        }
        public DataSet GetTestReportDataForUpdate(string Type, string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SearchingOnTestHistoryData", Type, Id);
        }
        public DataTable LineDataForAdmin()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Linedataforadmin");
        }
        public DataTable SubstationDataForAdmin()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Substationdataforadmin");
        }
        public DataTable GeneratingDataForAdmin()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Generatingdataforadmin");
        }
        public DataSet GetddlSecondaryVotlage()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SecondryVoltage");
        }
        public DataSet GetSiteOwnerNotifications(string ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerNotifiction", ID);
        }
        public DataSet GetPaymentInformation(string Id, string IntimationId) //not in use
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_paymentCalculation", Id, IntimationId);
        }
        public string GetTotalPaymentInformation(string Id, string IntimationId)
        {
            SqlCommand cmd = new SqlCommand("sp_TotalPayment");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            outputParam = new SqlParameter("@TotalPayment", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            if (outputParam != null)
            {
                return outputParam.Value.ToString();
            }
            else
            {
                return null;
            }
        }

        public DataTable SiteOwnerPeroidicInspectionData(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetSiteOwnerPeriodicInspection", SiteOwnerId);
        }

        public DataSet GetSupervisorNotifications()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SupervisorNotificationData");
        }

        public DataSet GetSuppervisorTestReportHistory(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TestReportHistoryForSupervisor", LoginId);
            // return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TestReportInstallationsHistory ", LoginId);
        }
        public DataTable TestReportDataForAdmin()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TestReportHistoryAdmin");
        }
        public DataSet TestReportContractorHistory(string LoginId, string Type)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ReportsHistory", LoginId, Type);
        }
        public DataSet AllInspectionHistory()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AllRequestsForAdmin");
        }
        #region Update TestReport Data
        public void UpdateTestReportData(string ID, string RejectOrApprovedFronContractor, string ReasonForRejection)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateTestReports");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@RejectOrApprovedFronContractor", RejectOrApprovedFronContractor);
            cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        //public DataTable RequestPendingDivision(string Division)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetRecordsAccordingToDays", Division);
        //}
        public DataTable RequestPendingDivision(string UserID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetRecordsAccordingToDays", UserID);
        }


        public DataTable RequestPendingDaysData(string dated, string Division, string District)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ShowRequestPendingDaysData", dated, Division, District);
        }
        public DataSet DasboardCalculations()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DashboardCalculations");
        }
        public DataSet DasboardPieChartCalculations()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_BindDashboardPiechart");
        }
        public DataSet StaffPendingRecordsCount()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_StaffPendingRecordsCount");
        }

        public DataSet DdlToAssign()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ToAssign");
        }
        #region Update Inspection Data For Action
        public int UpdateInspectionDataOnAction(string ID, string AssignTo, string AssignFrom)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateAction");
            //SqlCommand cmd = new SqlCommand("sp_UpdateAction_Testing");

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Staff", AssignTo);
            cmd.Parameters.AddWithValue("@AssignFrom", AssignFrom);
            //cmd.Parameters.AddWithValue("@AcceptedOrRejected", AcceptedOrRejected);
            //cmd.Parameters.AddWithValue("@ReasonForRejection", ReasonForRejection);
            //cmd.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
            int x = cmd.ExecuteNonQuery();
            con.Close();
            return x;
        }
        #endregion

        public DataSet DivisionsDistrictHistory(string loginid)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DivisionDistrictsHistory", loginid);
        }
        public DataSet GetRecordsDivisionistrict(string loginid)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetRecordsDivisionistrict", loginid);
        }

        public DataSet StaffPendingDivisionWise(string loginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_StaffDivisionWise", loginId);
        }
        public DataTable ShowPendingDivisionDaysData(string dated, string Division, string District)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ShowPendingDivisionDaysData", dated, Division, District);
        }

        public DataSet DivisionInspectionHistory(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DivisionRequestHistory", LoginId);
        }
        public DataTable SiteOwnerPendingPayment(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PendingInspectionPaymentData", SiteOwnerId);
        }
        public DataSet RecordsDivisionDistrict(string loginid)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_BindDivisionBarGraph", loginid);
        }
        public DataSet GetStaffDetailsDropDown(string Division)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffDetails", Division);
        }
        public DataSet GetDdlDivisionData()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDivision");
        }
        public DataSet GetDivisionData(string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDivisionForDistrict", District);
        }
        #region Bind DropDown To Bind District by Division
        public DataSet GetddldistrictfromDivision(string Area)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDistrictForDropdownDivision", Area);
        }
        #endregion

        public DataSet ConsolidateSearchData(string SubmittedDate, string EndDate, string Division, string District, string Status, string Inspectiontype,
    string PendingWith, string OwnerApplication, string GSTNumber, string Assignto)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ConsolidatedSearch", SubmittedDate, EndDate, Division,
                District, Status, Inspectiontype, PendingWith, OwnerApplication, GSTNumber, Assignto);
        }
        //    public void ConsolidateSearchData(string SubmittedDate, string EndDate, string Division, string District, string Status, string Inspectiontype,
        //string PendingWith, string OwnerApplication, string GSTNumber, string Assignto)
        //    {
        //        try
        //        {

        //            SqlCommand cmd = new SqlCommand("sp_ConsolidatedSearch");
        //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //            cmd.Connection = con;
        //            if (con.State == ConnectionState.Closed)
        //            {
        //                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //                con.Open();
        //            }
        //            cmd.Parameters.AddWithValue("@SubmittedDate", SubmittedDate);
        //            cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //            cmd.Parameters.AddWithValue("@Division", Division);
        //            cmd.Parameters.AddWithValue("@District", District);
        //            cmd.Parameters.AddWithValue("@Status", Status);
        //            cmd.Parameters.AddWithValue("@Inspectiontype", Inspectiontype);
        //            cmd.Parameters.AddWithValue("@PendingWith", PendingWith);
        //            cmd.Parameters.AddWithValue("@OwnerApplication", OwnerApplication);
        //            cmd.Parameters.AddWithValue("@GSTNumber", GSTNumber);
        //            cmd.Parameters.AddWithValue("@AssignTo", Assignto);
        //            cmd.ExecuteNonQuery();
        //            //int generatedId = Convert.ToInt32(outputParam.Value);

        //            con.Close();


        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }

        //    }

        //public DataTable GetInstllationsforSupervisor(string IntimationId)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallation", IntimationId);

        //}
        public DataTable GetInstllationsforSupervisor(string IntimationId, string SupervisorId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallation", IntimationId, SupervisorId);

        }
        public DataTable WorkIntimationHistoryforSupervisor(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationHistoryForSupervisor", Id);
        }
        public DataTable GetInstllationHistorySupervisor(string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationHistory", IntimationId);

        }

        public DataSet GetDetailsByPanNumberId(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsByPanNumberId", PANNumber);
        }
        public DataSet GetDetailsByPanNumberIdLift(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsByPanNumberIdLift", PANNumber);
        }
        #region Insert New user data Data
        public void InserNewUserData(string ApplicationFor, string Name, string Age, string CalculatedAge, string FatherName,
            string gender, string aadhar, string Address, string District, string State, string PinCode, string PhoneNo, string Email,
            string Category, string CreatedBy, string UserId,
            string CommunicationAddress, string CommState, string CommDistrict, string CommPin, string Password, string IPAddress)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_NewUserRegistration");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ApplicationFor", ApplicationFor);
                cmd.Parameters.AddWithValue("@Name", Name);
                //cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@CalculatedAge", CalculatedAge);
                cmd.Parameters.AddWithValue("@FatherName", FatherName);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Aadhar", aadhar);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@District", District);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@PinCode", PinCode);
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Category", Category);
                cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CommunicationAddress", CommunicationAddress);
                cmd.Parameters.AddWithValue("@CommState", CommState);
                cmd.Parameters.AddWithValue("@CommDistrict", CommDistrict);
                cmd.Parameters.AddWithValue("@CommPin", CommPin);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@IPAddres", IPAddress);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        public DataSet GetddlSecondaryVotlage(string Volts)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SecondryVoltage", Volts);
        }
        public DataSet GetddlPrimaryVotlage(string Volts)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PrimaryVoltage", Volts);
        }
        public DataSet TestReportData(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSiteOwner", PANNumber);
        }
        public DataSet SiteOwnerInstallations(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationForSiteOwner", IntimationId);
        }
        public DataSet GetData(string Inspectiontype, string IntimationId, string Count)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDataForInspection", Inspectiontype, IntimationId, Count);
        }

        public void InsertnewUseQualification(string UserId, string UniversityName10th, string PassingYear10th, string MarksObtained10th, string MarksMax10th, string Percentage10th,
              string Name12ITIDiploma, string UniversityName12thorITI, string PassingYear12thorITI, string MarksObtained12thorITI, string MarksMax12thorITI, string Percentage12thorITI,
              string NameofDiplomaDegree, string UniversityNameDiplomaorDegree, string PassingYearDiplomaorDegree, string MarksObtainedDiplomaorDegree, string MarksMaxDiplomaorDegree, string PercentageDiplomaorDegree,
              string NameofDegree, string UniversityNamePG, string PassingYearPG, string MarksObtainedPG, string MarksMaxPG, string PercentagePG,
              string NameofMasters, string MastersUniversityName, string MastersPassingYear, string MasterMarksObtained, string MastersMarksMax, string MatersPercentage,
              string IsCertificateofCompetency, string CertificateofCompetency1, string PermitNo1, string IssuingAuthority1, string IssueDate1, string ExpiryDate,
              string EmployedPermanent, string PermanentEmployerName, string PostDescription, string FromDate, string ToDate,
              string Experience, string TraningUnder, string ExperienceEmployerName, string ExperiencePostDescription, string ExperienceFromDate, string ExperienceToDate,
              string Experience1, string TraningUnder1, string ExperienceEmployerName1, string ExperiencePostDescription1, string ExperienceFromDate1, string ExperienceToDate1,
              string Experience2, string TraningUnder2, string ExperienceEmployerName2, string ExperiencePostDescription2, string ExperienceFromDate2, string ExperienceToDate2,
              string Experience3, string TraningUnder3, string ExperienceEmployerName3, string ExperiencePostDescription3, string ExperienceFromDate3, string ExperienceToDate3,
              string Experience4, string TraningUnder4, string ExperienceEmployerName4, string ExperiencePostDescription4, string ExperienceFromDate4, string ExperienceToDate4,
              string TotalExperience, string RetiredEngineer
              )
        {
            SqlCommand cmd = new SqlCommand("sp_InsertUserQualification");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@UniversityName10th", UniversityName10th);
            cmd.Parameters.AddWithValue("@PassingYear10th", PassingYear10th);
            cmd.Parameters.AddWithValue("@MarksObtained10th", MarksObtained10th);
            cmd.Parameters.AddWithValue("@MarksMax10th", MarksMax10th);
            cmd.Parameters.AddWithValue("@Percentage10th", Percentage10th);

            cmd.Parameters.AddWithValue("@Name12ITIDiploma", Name12ITIDiploma);
            cmd.Parameters.AddWithValue("@UniversityName12thorITI", UniversityName12thorITI);
            cmd.Parameters.AddWithValue("@PassingYear12thorITI", PassingYear12thorITI);
            cmd.Parameters.AddWithValue("@MarksObtained12thorITI", MarksObtained12thorITI);
            cmd.Parameters.AddWithValue("@MarksMax12thorITI", MarksMax12thorITI);
            cmd.Parameters.AddWithValue("@Percentage12thorITI", Percentage12thorITI);

            cmd.Parameters.AddWithValue("@NameofDiplomaDegree", NameofDiplomaDegree);
            cmd.Parameters.AddWithValue("@UniversityNameDiplomaorDegree", UniversityNameDiplomaorDegree);
            cmd.Parameters.AddWithValue("@PassingYearDiplomaorDegree", PassingYearDiplomaorDegree);
            cmd.Parameters.AddWithValue("@MarksObtainedDiplomaorDegree", MarksObtainedDiplomaorDegree);
            cmd.Parameters.AddWithValue("@MarksMaxDiplomaorDegree", MarksMaxDiplomaorDegree);
            cmd.Parameters.AddWithValue("@PercentageDiplomaorDegree", PercentageDiplomaorDegree);

            cmd.Parameters.AddWithValue("@NameofDegree", NameofDegree);
            cmd.Parameters.AddWithValue("@UniversityNamePG", UniversityNamePG);
            cmd.Parameters.AddWithValue("@PassingYearPG", PassingYearPG);
            cmd.Parameters.AddWithValue("@MarksObtainedPG", MarksObtainedPG);
            cmd.Parameters.AddWithValue("@MarksMaxPG", MarksMaxPG);
            cmd.Parameters.AddWithValue("@PercentagePG", PercentagePG);

            cmd.Parameters.AddWithValue("@NameofMasters", NameofMasters);
            cmd.Parameters.AddWithValue("@MastersUniversityName", MastersUniversityName);
            cmd.Parameters.AddWithValue("@MastersPassingYear", MastersPassingYear);
            cmd.Parameters.AddWithValue("@MasterMarksObtained", MasterMarksObtained);
            cmd.Parameters.AddWithValue("@MastersMarksMax", MastersMarksMax);
            cmd.Parameters.AddWithValue("@MastersPercentage", MatersPercentage);

            cmd.Parameters.AddWithValue("@IsCertificateofCompetency", IsCertificateofCompetency);
            cmd.Parameters.AddWithValue("@CertificateofCompetency1", CertificateofCompetency1);
            cmd.Parameters.AddWithValue("@PermitNo1", PermitNo1);
            cmd.Parameters.AddWithValue("@IssuingAuthority1", IssuingAuthority1);
            cmd.Parameters.AddWithValue("@IssueDate1", IssueDate1);
            cmd.Parameters.AddWithValue("@ExpiryDate1", ExpiryDate);
            //cmd.Parameters.AddWithValue("@CertificateofCompetency2", CertificateofCompetency2);
            //cmd.Parameters.AddWithValue("@PermitNo2", PermitNo2);
            //cmd.Parameters.AddWithValue("@IssuingAuthority2", IssuingAuthority2);
            //cmd.Parameters.AddWithValue("@IssueDate2", IssueDate2);
            cmd.Parameters.AddWithValue("@EmployedPermanent", EmployedPermanent);
            cmd.Parameters.AddWithValue("@EmployerName", PermanentEmployerName);
            cmd.Parameters.AddWithValue("@PostDescription", PostDescription);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);

            cmd.Parameters.AddWithValue("@ExperiencedIn", Experience);
            cmd.Parameters.AddWithValue("@TrainingUnder", TraningUnder);
            cmd.Parameters.AddWithValue("@ExperienceEmployerName", ExperienceEmployerName);
            cmd.Parameters.AddWithValue("@ExperiencePostDescription", ExperiencePostDescription);
            cmd.Parameters.AddWithValue("@ExperienceFromDate", ExperienceFromDate);
            cmd.Parameters.AddWithValue("@ExperienceToDate", ExperienceToDate);

            cmd.Parameters.AddWithValue("@ExperiencedIn1", Experience1);
            cmd.Parameters.AddWithValue("@TrainingUnder1", TraningUnder1);
            cmd.Parameters.AddWithValue("@ExperienceEmployerName1", ExperienceEmployerName1);
            cmd.Parameters.AddWithValue("@ExperiencePostDescription1", ExperiencePostDescription1);
            cmd.Parameters.AddWithValue("@ExperienceFromDate1", ExperienceFromDate1);
            cmd.Parameters.AddWithValue("@ExperienceToDate1", ExperienceToDate1);

            cmd.Parameters.AddWithValue("@ExperiencedIn2", Experience2);
            cmd.Parameters.AddWithValue("@TrainingUnder2", TraningUnder2);
            cmd.Parameters.AddWithValue("@ExperienceEmployerName2", ExperienceEmployerName2);
            cmd.Parameters.AddWithValue("@ExperiencePostDescription2", ExperienceEmployerName2);
            cmd.Parameters.AddWithValue("@ExperienceFromDate2 ", ExperienceFromDate2);
            cmd.Parameters.AddWithValue("@ExperienceToDate2 ", ExperienceToDate2);

            cmd.Parameters.AddWithValue("@ExperiencedIn3", Experience3);
            cmd.Parameters.AddWithValue("@TrainingUnder3", TraningUnder3);
            cmd.Parameters.AddWithValue("@ExperienceEmployerName3", ExperienceEmployerName3);
            cmd.Parameters.AddWithValue("@ExperiencePostDescription3", ExperiencePostDescription3);
            cmd.Parameters.AddWithValue("@ExperienceFromDate3 ", ExperienceFromDate3);
            cmd.Parameters.AddWithValue("@ExperienceToDate3 ", ExperienceToDate3);

            cmd.Parameters.AddWithValue("@ExperiencedIn4", Experience4);
            cmd.Parameters.AddWithValue("@TrainingUnder4", TraningUnder4);
            cmd.Parameters.AddWithValue("@ExperienceEmployerName4", ExperienceEmployerName4);
            cmd.Parameters.AddWithValue("@ExperiencePostDescription4", ExperiencePostDescription4);
            cmd.Parameters.AddWithValue("@ExperienceFromDate4 ", ExperienceFromDate4);
            cmd.Parameters.AddWithValue("@ExperienceToDate4 ", ExperienceToDate4);

            cmd.Parameters.AddWithValue("@TotalExperience ", TotalExperience);
            cmd.Parameters.AddWithValue("@RetiredEngineer", RetiredEngineer);
            //cmd.Parameters.AddWithValue("@ExperienceEmployerName1", txtEmployer.Text);
            //cmd.Parameters.AddWithValue("@ExperiencePostDescription1", txtDescript.Text);
            //cmd.Parameters.AddWithValue("@ExperienceFromDate1", txtFrm1.Text);
            //cmd.Parameters.AddWithValue("@ExperienceToDate1", txtToDate.Text);
            //cmd.Parameters.AddWithValue("@RetiredEmployerName", RetiredEmployerName);
            //cmd.Parameters.AddWithValue("@RetiredPostDescription", RetiredPostDescription);
            //cmd.Parameters.AddWithValue("@RetiredFromDate", RetiredFromDate);
            //cmd.Parameters.AddWithValue("@RetiredToDate", RetiredToDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #region Contractor Application Form Data
        public void ContractorApplicationData(string GSTNumber, string StyleOfCompany, string CompanyRegisterdOffice, string CompanyPartnerOrDirector,
              string CompanyPenalities, string LibraryAvailable, string AgentName, string ManufacturingFirmOrProductionUnit, string ContractorLicencePreviouslyGranted,
             string NameOfIssuingAuthority, string DateOfBirth, string DateOfLicenseExpiring, string ContractorLicencePreviouslyGrantedWithSameName,
             string LicenseNoIfYes, string DateoFIssue, string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_SetContractorApplicationFormData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GSTNumber", GSTNumber);
            cmd.Parameters.AddWithValue("StyleOfCompany", StyleOfCompany);
            cmd.Parameters.AddWithValue("@CompanyRegisterdOffice", CompanyRegisterdOffice);
            cmd.Parameters.AddWithValue("@CompanyPartnerOrDirector", CompanyPartnerOrDirector);
            cmd.Parameters.AddWithValue("@CompanyPenalities", CompanyPenalities);
            cmd.Parameters.AddWithValue("@LibraryAvailable", LibraryAvailable);
            cmd.Parameters.AddWithValue("@AgentName", AgentName);
            cmd.Parameters.AddWithValue("@ManufacturingFirmOrProductionUnit", ManufacturingFirmOrProductionUnit);
            cmd.Parameters.AddWithValue("@ContractorLicencePreviouslyGranted", ContractorLicencePreviouslyGranted);
            cmd.Parameters.AddWithValue("@NameOfIssuingAuthority", NameOfIssuingAuthority);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@DateOfLicenseExpiring", DateOfLicenseExpiring);
            cmd.Parameters.AddWithValue("@ContractorLicencePreviouslyGrantedWithSameName", ContractorLicencePreviouslyGrantedWithSameName);
            cmd.Parameters.AddWithValue("@LicenseNoIfYes", LicenseNoIfYes);
            cmd.Parameters.AddWithValue("@DateoFIssue", DateoFIssue);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void ContractorPartners(string TypeOfAuthority, string Name, string Address, string State, string District, string Pincode, string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_ContractorPartners");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TypeOfAuthority", TypeOfAuthority);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Pincode", Pincode);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        #endregion

        #region Insert ApplicationLift And Esculator
        public void InsertListAndEscalators(string UserId, string ApplicantType, string ApplicantName, string ApplicantContact, string ApplicantOfficeAdd,
            string ApplicantState, string ApplicantDistt, string ApplicantPincode, string AgentName, string AgentContect, string AgentAddres, string AgentState,
            string AgentDistt, string AgentPincode, string OwnerName, string OwnerAddres, string OwnerState, string OwnerDistrict, string OwnerPincode,
            string ErectionDate, string TypeOfLift, string MakersName, string MakersLocalAgent, string MakersAddress, string ContractSpeedLift, string ContractLoadLift,
            string LiftCapcityMaxNoOfPerson, string TotalWeightLiftCar, string WeightCounterWeight, string NoOfSuspensionRoops, string Description, string Weight,
            string Size, string PitDepth, string TravelAndNoOfFloors, string ConstructionDetailsOverheadArrangement)
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertLiftEscalators");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId ", UserId);
            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@ApplicantNames", ApplicantName);
            cmd.Parameters.AddWithValue("@ApplicantContactNo", ApplicantContact);
            cmd.Parameters.AddWithValue("@ApplicantOfficeAddress", ApplicantOfficeAdd);
            cmd.Parameters.AddWithValue("@ApplicantState", ApplicantState);
            cmd.Parameters.AddWithValue("@ApplicantDistrict", ApplicantDistt);
            cmd.Parameters.AddWithValue("@ApplicantPinCode", ApplicantPincode);
            cmd.Parameters.AddWithValue("@AgentName", AgentName);
            cmd.Parameters.AddWithValue("@AgentContactNo", AgentContect);
            cmd.Parameters.AddWithValue("@AgentAddress", AgentAddres);
            cmd.Parameters.AddWithValue("@AgentState", AgentState);
            cmd.Parameters.AddWithValue("@AgentDistrict", AgentDistt);
            cmd.Parameters.AddWithValue("@AgentPincode", AgentPincode);
            cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
            cmd.Parameters.AddWithValue("@OwnerAddress", OwnerAddres);
            cmd.Parameters.AddWithValue("@OwnerState", OwnerState);
            cmd.Parameters.AddWithValue("@OwnerDistrict", OwnerDistrict);
            cmd.Parameters.AddWithValue("@OwnerPincode", OwnerPincode);
            cmd.Parameters.AddWithValue("@ErectionDate", ErectionDate);
            cmd.Parameters.AddWithValue("@TypeOfLift", TypeOfLift);
            cmd.Parameters.AddWithValue("@MakersName", MakersName);
            cmd.Parameters.AddWithValue("@MakersLocalAgent", MakersLocalAgent);
            cmd.Parameters.AddWithValue("@MakersAddress", MakersAddress);
            cmd.Parameters.AddWithValue("@ContractSpeedLift", ContractSpeedLift);
            cmd.Parameters.AddWithValue("@ContractLoadLift", ContractLoadLift);
            cmd.Parameters.AddWithValue("@LiftCapcityMaxNoOfPerson", LiftCapcityMaxNoOfPerson);
            cmd.Parameters.AddWithValue("@TotalWeightLiftCar", TotalWeightLiftCar);
            cmd.Parameters.AddWithValue("@WeightCounterWeight", WeightCounterWeight);
            cmd.Parameters.AddWithValue("@NoOfSuspensionRoops", NoOfSuspensionRoops);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@PitDepth", PitDepth);
            cmd.Parameters.AddWithValue("@TravelAndNoOfFloors", TravelAndNoOfFloors);
            cmd.Parameters.AddWithValue("@ConstructionDetailsOverheadArrangement", ConstructionDetailsOverheadArrangement);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        public DataTable GetPartnersDirectorDate(string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PartnersDirectorData", CreatedBy);
        }
        public DataSet GetWorkIntimationDataForPrint(string REID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationData_ForPrint", REID);
        }


        public int DocumentsForContactor(string Last3YearsITRAndBalanceSheet, string PanCard, string AdhaarNo, string AgeCertificate, string CalbrationFromNABLOrTestingLaboratoryofequipment, string CopyOfAnnexure3And5, string StatusOfCompanyProof, string MajorWorkesCarried, string DetailsofWorkPermited, string ElibraryasperANNEXURE2, string PreviouslyGrantedLicense, string CreatedBy)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ContractorDocuments", Last3YearsITRAndBalanceSheet, PanCard, AdhaarNo, AgeCertificate, CalbrationFromNABLOrTestingLaboratoryofequipment, CopyOfAnnexure3And5, StatusOfCompanyProof, MajorWorkesCarried, DetailsofWorkPermited, ElibraryasperANNEXURE2, PreviouslyGrantedLicense, CreatedBy);
        }
        #region InsertApplicationLift And Esculator Document
        //public void LiftEsculatorDocument(string REID, string flpPhotourl, string flpPhotourl1, string flpPhotourl2, string flpPhotourl3,
        //    string flpPhotourl4, string flpPhotourl5, string flpPhotourl6)
        //{
        //    SqlCommand cmd = new SqlCommand("Sp_LiftEsculatorDocument");
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //    cmd.Connection = con;
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //        con.Open();
        //    }
        //    cmd.Parameters.AddWithValue("@UserId", REID);
        //    cmd.Parameters.AddWithValue("@CopyOfAnnualInsurancePolicy", flpPhotourl);
        //    cmd.Parameters.AddWithValue("@CopyOfChallanTreasury", flpPhotourl1);
        //    cmd.Parameters.AddWithValue("@AnnualMaintenanceContract", flpPhotourl2);
        //    cmd.Parameters.AddWithValue("@SaftyCertificate", flpPhotourl3);
        //    cmd.Parameters.AddWithValue("@FormA", flpPhotourl4);
        //    cmd.Parameters.AddWithValue("@FormB", flpPhotourl5);
        //    cmd.Parameters.AddWithValue("@FormC", flpPhotourl6);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}


        #endregion

        public DataSet GetQualificationHistory(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetUserQualification", id);

        }
        public int LiftEsculatorDocument(string flpPhotourl, string flpPhotourl1, string flpPhotourl2, string flpPhotourl3, string flpPhotourl4, string flpPhotourl5, string flpPhotourl6, string REID)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_LiftEsculatorDocuments", flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, REID);
        }

        public DataTable ContractorBasicInformation(string UserId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetContractorBasicInformation", UserId);

        }
        public DataSet QualificationData(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetRegistrationForm", LoginId);

        }
        public DataSet GetReportsHistory(string Type, string IntimationId, string Count, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportId", Type, IntimationId, Count, TestReportId);

        }
        public DataSet GetTestReportHistoryFromSupervisor()
        {
            //return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TestReportInstallationsHistoryFromSupervisor");
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TestReportHistoryForAdmin");
        }

        public DataSet ToCalculateAge(string userid)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetCalculatedAge", userid);
        }
        public DataSet checkAadharexist(string Aadhar)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckAadhar", Aadhar);
        }
        #region insert ContractorTeam
        public void InsertContractorTeam(string TypeofEmployee, string LicenseNo, string issueDate, string Validity, string Qualification, string CreatedBy)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Sp_InsertContractorTeam");
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TypeOfEmployee", TypeofEmployee);
            cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo);
            cmd.Parameters.AddWithValue("@LicenseIssueDate", issueDate);
            cmd.Parameters.AddWithValue("@LicenseValidity", Validity);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetContractorTeam(string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetContractorTeam", CreatedBy);
        }
        #endregion


        #region insert ContractotpEmail
        public string OTPthroughEmail(string Email)
        {
            //string mobilenumber = Session["Contact"].ToString();
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);

            string otp = otpInt.ToString("D6");
            //Session["OTP"] = otp;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("haryanacei@gmail.com");
            mailMessage.To.Add(Email); mailMessage.Subject = "Contractor Login OTP";
            string body = $"Dear Customer,\n\n" + otp + " is the OTP for your request send to the Contractor.OTPs are SECRET.DO NOT share OTP with anyone.Thank you for choosing our services. If you have any questions or need further assistance, please feel free to contact our support team.\n\n Best regards,\n\n[CEI Haryana]";
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("haryanacei@gmail.com", "httnrdifrwgfnzrv");
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
            return otp;
        }
        #endregion
        public DataTable checkvacantSupervisor(string LicenseNo)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckVacantSupervisor", LicenseNo);
        }
        #region SupervisorCertificateRenewal
        public DataSet GetSupervisorDataForRenewal(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetSuperviserForRenewal", id);
        }
        public DataSet GetContractorSupData(string ContractorId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetContractorSupRenewalData", ContractorId);
        }
        public DataSet GetCurrentContractorforSupervisor(string SupervisorID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetCurrentContractorForSupervisor", SupervisorID);
        }
        public int InsertRenewalSupervisorData(string Category, string ExtendedBy, string CurrentCertificateNo, string ExpiryDate, string DOB,
           string Age, string Email, string ContactNo, string Address, string State, string District, string Pincode,
           string ModeOfPayment, string NameofTressury, string ChallanGRNno, string DateOfChallan, string Amount, string PaymentChallan,
           string TypeOfEmployer, string CurrentContractorName, string CurrentContractorLicence, string OtherEmployerName, string OtherAddress, string OtherState,
           string OtherDistrict, string OtherPincode,
           string AnyChangedContractor,
           string DateFrom, string DateTo, string ChangedContractorName, string ChangedContractorLicence, string ChangedContractorAddress,
           //string DepositedTreasuryChallan
           string PresentWorkingStatus,
           string MedicalCertificate, string duringcancelperiod,
           string CreatedBy
           )
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_InsertSupervisorRenewalData");
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@ExtendedBy", ExtendedBy);
            cmd.Parameters.AddWithValue("@CurrentCertificate", CurrentCertificateNo);
            cmd.Parameters.AddWithValue("@ExpiryDate", ExpiryDate);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@PhoneNo", ContactNo);
            cmd.Parameters.AddWithValue("@PersonAddress", Address);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@PinCode", Pincode);
            cmd.Parameters.AddWithValue("@ModeOfPayment", ModeOfPayment);
            cmd.Parameters.AddWithValue("@NameTreasury", NameofTressury);
            cmd.Parameters.AddWithValue("@TransactionId", ChallanGRNno);
            cmd.Parameters.AddWithValue("@TransactionDate", DateOfChallan);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            //cmd.Parameters.AddWithValue("@RenewalFee", );
            //cmd.Parameters.AddWithValue("@RenewalLateFee", );
            // cmd.Parameters.AddWithValue("@PaymentChallan", PaymentChallan);
            cmd.Parameters.AddWithValue("@EmployerType", TypeOfEmployer);
            cmd.Parameters.AddWithValue("@ContractorLicence", CurrentContractorLicence);
            cmd.Parameters.AddWithValue("@ContractorName", CurrentContractorName);
            cmd.Parameters.AddWithValue("@OtherEmployerName", OtherEmployerName);
            cmd.Parameters.AddWithValue("@OtherEmployerAddress", OtherAddress);
            cmd.Parameters.AddWithValue("@OtherEmployerState", OtherState);
            cmd.Parameters.AddWithValue("@OtherEmployerDistrict", OtherDistrict);
            cmd.Parameters.AddWithValue("@OtherEmployerPinCode", OtherPincode);
            cmd.Parameters.AddWithValue("@AnyChangedContractor", AnyChangedContractor);
            cmd.Parameters.AddWithValue("@ChangingDateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@ChangingDateTo", DateTo);
            cmd.Parameters.AddWithValue("@ChangingContractorName", ChangedContractorName);
            cmd.Parameters.AddWithValue("@ChangingContractorLicence", ChangedContractorLicence);
            cmd.Parameters.AddWithValue("@ChangingEmployerAdress", ChangedContractorAddress);
            cmd.Parameters.AddWithValue("@MedicalCertificate", MedicalCertificate);
            cmd.Parameters.AddWithValue("@ChallanFees", PaymentChallan);
            cmd.Parameters.AddWithValue("@CanceledCertificate", duringcancelperiod);
            cmd.Parameters.AddWithValue("@PresentWorkingStatus", PresentWorkingStatus);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            int x = cmd.ExecuteNonQuery();
            con.Close();
            return x;
        }



        #endregion
        #region LicenceUpgradationSupervisor
        public DataTable GetSupervisorLiceceUpgradationData(string id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetSupervisorLicenceUpgradationData", id);
        }

        public DataSet GetddlVoltageLevelForUpgradation(string Voltage)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_VoltageForUpdradation", Voltage);
        }
        public DataSet GetddlVoltageLevelBeforeUpgradation(string VoltageID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_LineVoltageAppliedBefore", VoltageID);
        }

        public int InsertUpgradationSupervisorData(string CurrentCertificateNo, string DateOfExpiry, string CurrentVolatgeLevel,
           string Age, string Email, string ContactNo, string Address, string State, string District, string PinCode, string RequestVoltageForUpgradation,
           string UpgradationEarlier, string DateOfInterview, string VoltageBeforeUpgradation, string ExperienceCertificate,
           string CreatedBy
          )
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Sp_InsertLicenceUpgradationSupervisor");
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@ApplicantName", ApplicantName);
            cmd.Parameters.AddWithValue("@CurrentCertificate", CurrentCertificateNo);
            cmd.Parameters.AddWithValue("@DateOfExpiry", DateOfExpiry);
            cmd.Parameters.AddWithValue("@CurrentAutorizedVoltage", CurrentVolatgeLevel);
            //cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@PhoneNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Pincode", PinCode);
            cmd.Parameters.AddWithValue("@RequestVoltageForUpgradation", RequestVoltageForUpgradation);
            cmd.Parameters.AddWithValue("@ApplyUpgradationEarlier", UpgradationEarlier);
            //cmd.Parameters.AddWithValue("@UpgradationEarlierDate", DateOfInterview);
            DateTime UpgradationDate;
            if (DateTime.TryParse(DateOfInterview, out UpgradationDate) && UpgradationDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@UpgradationEarlierDate", UpgradationDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@UpgradationEarlierDate", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@ScopeVoltageLevelApplied", VoltageBeforeUpgradation == "Select" ? null : VoltageBeforeUpgradation);
            cmd.Parameters.AddWithValue("@ExperienceCertificate", ExperienceCertificate);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            int x = cmd.ExecuteNonQuery();
            con.Close();
            return x;

        }

        public void InsertSupervisorExperience(string Experience1, string TraningUnder1, string EmployerName1, string PostDescription1, string ExperienceFrom1, string ExperienceTo1,
           string Experience2, string TraningUnder2, string EmployerName2, string PostDescription2, string ExperienceFrom2, string ExperienceTo2,
           string Experience3, string TraningUnder3, string EmployerName3, string PostDescription3, string ExperienceFrom3, string ExperienceTo3,
            string Experience4, string TraningUnder4, string EmployerName4, string PostDescription4, string ExperienceFrom4, string ExperienceTo4,
             string Experience5, string TraningUnder5, string EmployerName5, string PostDescription5, string ExperienceFrom5, string ExperienceTo5,
           string TotalExperience, string CreatedBy
         )
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_InsertSupervisiorExperience");
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Experience1", Experience1);
                cmd.Parameters.AddWithValue("@TraningUnder1", TraningUnder1);
                cmd.Parameters.AddWithValue("@EmployerName1", EmployerName1);
                cmd.Parameters.AddWithValue("@PostDescription1", PostDescription1);
                DateTime DateTo;
                if (DateTime.TryParse(ExperienceFrom1, out DateTo) && DateTo != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@From1", DateTo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@From1", DBNull.Value);
                }
                //cmd.Parameters.AddWithValue("@From1", ExperienceFrom1);
                //cmd.Parameters.AddWithValue("@To1", ExperienceTo1);
                DateTime DateFrom;
                if (DateTime.TryParse(ExperienceTo1, out DateFrom) && DateFrom != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@To1", DateFrom);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@To1", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Experience2", Experience2);
                cmd.Parameters.AddWithValue("@TraningUnder2", TraningUnder2);
                cmd.Parameters.AddWithValue("@EmployerName2", String.IsNullOrEmpty(EmployerName2) ? null : EmployerName2);
                cmd.Parameters.AddWithValue("@PostDescription2", String.IsNullOrEmpty(PostDescription2) ? null : PostDescription2);
                //cmd.Parameters.AddWithValue("@From2", ExperienceFrom2);
                //cmd.Parameters.AddWithValue("@To2", ExperienceTo2);
                DateTime DateFrom1;
                if (DateTime.TryParse(ExperienceFrom2, out DateFrom1) && DateFrom1 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@From2", DateFrom1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@From2", DBNull.Value);
                }
                DateTime DateTo1;
                if (DateTime.TryParse(ExperienceTo2, out DateTo1) && DateTo1 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@To2", DateTo1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@To2", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Experience3", Experience3);
                cmd.Parameters.AddWithValue("@TraningUnder3", TraningUnder3);
                cmd.Parameters.AddWithValue("@EmployerName3", String.IsNullOrEmpty(EmployerName3) ? null : EmployerName3);
                cmd.Parameters.AddWithValue("@PostDescription3", String.IsNullOrEmpty(PostDescription3) ? null : PostDescription3);
                //cmd.Parameters.AddWithValue("@From3", ExperienceFrom3);
                //cmd.Parameters.AddWithValue("@To3", ExperienceTo3);
                DateTime DateFrom2;
                if (DateTime.TryParse(ExperienceFrom2, out DateFrom2) && DateFrom2 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@From3", DateFrom2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@From3", DBNull.Value);
                }
                DateTime DateTo2;
                if (DateTime.TryParse(ExperienceTo2, out DateTo2) && DateTo2 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@To3", DateTo2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@To3", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Experience4", Experience4);
                cmd.Parameters.AddWithValue("@TraningUnder4", TraningUnder4);
                cmd.Parameters.AddWithValue("@EmployerName4", String.IsNullOrEmpty(EmployerName4) ? null : EmployerName4);
                cmd.Parameters.AddWithValue("@PostDescription4", String.IsNullOrEmpty(PostDescription4) ? null : PostDescription4);
                //cmd.Parameters.AddWithValue("@From4", ExperienceFrom4);
                //cmd.Parameters.AddWithValue("@To4", ExperienceTo4);
                DateTime DateFrom3;
                if (DateTime.TryParse(ExperienceFrom4, out DateFrom3) && DateFrom3 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@From4", DateFrom3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@From4", DBNull.Value);
                }
                DateTime DateTo3;
                if (DateTime.TryParse(ExperienceTo4, out DateTo3) && DateTo3 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@To4", DateTo3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@To4", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Experience5", Experience5);
                cmd.Parameters.AddWithValue("@TraningUnder5", TraningUnder5);
                cmd.Parameters.AddWithValue("@EmployerName5", String.IsNullOrEmpty(EmployerName5) ? null : EmployerName5);
                cmd.Parameters.AddWithValue("@PostDescription5", String.IsNullOrEmpty(PostDescription5) ? null : PostDescription5);
                //cmd.Parameters.AddWithValue("@From5 ", ExperienceFrom5);
                //cmd.Parameters.AddWithValue("@To5", ExperienceTo5);
                DateTime DateFrom4;
                if (DateTime.TryParse(ExperienceFrom5, out DateFrom4) && DateFrom4 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@From5", DateFrom4);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@From5", DBNull.Value);
                }
                DateTime DateTo4;
                if (DateTime.TryParse(ExperienceTo5, out DateTo4) && DateTo4 != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@To5", DateTo4);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@To5", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@TotalExperience", TotalExperience);
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }

        #endregion
        #region CalculateDate
        public string CalculateDate(DateTime currentDate, DateTime selectedExpiryDate)
        {
            int yearsRemaining = currentDate.Year - selectedExpiryDate.Year;
            int monthsRemaining = currentDate.Month - selectedExpiryDate.Month;
            int daysRemaining = currentDate.Day - selectedExpiryDate.Day;

            if (daysRemaining < 0)
            {
                monthsRemaining--;
                int daysInPreviousMonth = DateTime.DaysInMonth(currentDate.Year, (currentDate.Month == 1) ? 12 : currentDate.Month - 1);
                daysRemaining += daysInPreviousMonth;

                if (currentDate.Day < selectedExpiryDate.Day)
                {
                    monthsRemaining++;
                }
            }
            if (monthsRemaining < 0)
            {
                yearsRemaining--;
                monthsRemaining += 12;
            }
            daysRemaining = Math.Abs(daysRemaining);
            string Result = "";
            if (yearsRemaining > 0)
            {
                Result += $"{yearsRemaining} years";
            }
            if (monthsRemaining > 0)
            {
                if (!string.IsNullOrEmpty(Result))
                {
                    Result += ", ";
                }
                Result += $"{monthsRemaining} months";
            }
            if (daysRemaining > 0)
            {
                if (!string.IsNullOrEmpty(Result))
                {
                    Result += ", ";
                }
                Result += $"{daysRemaining} days";
            }
            return Result;
        }

        #endregion
        #region ContractorCertificateRenewal
        public DataSet GetContractorDataForRenewal(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetContractorDataForRenewal", id);
        }
        public int InsertRenewalContractorRequestData(string LicenceNo, string DateOfExpiry, string Extendedby, string DOB, string Age, string Email,
        string ContactNo, string Address, string State, string District, string PinCode, string ModeOfPayment, string NameTreasury, string TransactionID,
        string TransactionDate, string Amount, string EquipmentTestedCertificate, string IncomeTaxCertificate, string BalanceSheet, string CalibrationCertificate,
        string WorkDetails, string AnnexureIIICopy, string Form_ECopy, string TreasuryChallan, string PaymentReceipt, string CreatedBy)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_InsertRenewalContractorRequestData");
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LicenceNo", LicenceNo);
            cmd.Parameters.AddWithValue("@DateOfExpiry", DateOfExpiry);
            cmd.Parameters.AddWithValue("@ExtendedBy", Extendedby);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@PinCode", PinCode);
            cmd.Parameters.AddWithValue("@ModeOfPayment", ModeOfPayment);
            cmd.Parameters.AddWithValue("@NameTreasury", NameTreasury);
            cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
            cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            //cmd.Parameters.AddWithValue("@RenewalFee", RenewalFee);
            //cmd.Parameters.AddWithValue("@LateFee", LateFee);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@EquipmentTestedCertificate", EquipmentTestedCertificate);
            cmd.Parameters.AddWithValue("@IncomeTaxCertificate", IncomeTaxCertificate);
            cmd.Parameters.AddWithValue("@BalanceSheet", BalanceSheet);
            cmd.Parameters.AddWithValue("@CalibrationCertificate", CalibrationCertificate);
            cmd.Parameters.AddWithValue("@WorkDetails", WorkDetails);
            cmd.Parameters.AddWithValue("@AnnexureIIICopy", AnnexureIIICopy);
            cmd.Parameters.AddWithValue("@Form_ECopy", Form_ECopy);
            cmd.Parameters.AddWithValue("@TreasuryChallan", TreasuryChallan);
            cmd.Parameters.AddWithValue("@PaymentReceipt", PaymentReceipt);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            int x = cmd.ExecuteNonQuery();
            con.Close();
            return x;
        }
        #endregion
        #region deattached/Attached
        public DataSet WorkIntimationGridDataForDeAttach(string LicenceNo)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ContractorRequestToDeattachStaff", LicenceNo);
        }
        #endregion
        public DataTable SearchContractorData(string searchText, string category)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_SearchOnStaffDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchText", searchText);
                command.Parameters.AddWithValue("@category", category);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }

        #region Officer
        public DataSet Getdataforofficerdashboard(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Getdataforofficer", LoginId);
        }
        public DataSet OfficerDashboardDaughnutChart(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_BindOfficerDashboardDaughnutChart", LoginId);
        }
        public DataSet InProcessRequest(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInProcessRequest", Id);
        }
        public DataSet NewRequestRecieved(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_NewRequestReceived", Id);
        }
        public DataSet AcceptOrReject(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AcceptRejectInspection", Id);
        }
        public DataSet TotalRequest(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TotalRequestOfInspection", Id);
        }
        #endregion
        #region forAdmin        
        public DataSet TotalRequestInspectionForAdmin(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TotalRequestInspectionForAdmin", LoginId);
        }
        public DataSet NeWRequestInspectionForAdmin(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_NewRequestReceivedForAdmin", LoginId);
        }
        public DataSet InProcessRequestInspectionForAdmin(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetProcessRequestForAdmin", LoginId);
        }
        public DataSet AcceptedOrRejectedRequestInspectionForAdmin(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AcceptRejectInspectionForAdmin", LoginId);
        }
        #endregion

        public DataTable GetDocumanetName(string Categary)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDocumentNameForInspection", Categary);

        }
        public DataSet DdlToStaffAssign(string Division)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetStaffAssign", Division);
        }

        public DataSet GetContractorName(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetContractorName", UserId);
        }
        public DataSet GetsupervisorName(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetSupervisorName", UserId);
        }

        public DataTable Payment(string intimationId, string count, string installationtypeId, string InspectionType)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IntimationId", intimationId);
                command.Parameters.AddWithValue("@Count", count);
                command.Parameters.AddWithValue("@InspectionType", InspectionType);
                command.Parameters.AddWithValue("@InstallationTypeID", installationtypeId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }
        public DataSet GetSiteOwnerDetails(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerDetails", LoginId);
        }
        //public DataTable GetDocumentlist(string ApplicantType, string InstallationType, string InspectionType, string DesignatedOfficer, string PlantLocation)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentCheckList", ApplicantType, InstallationType, InspectionType, DesignatedOfficer, PlantLocation);
        //}

        public DataTable GetDocumentlist(string ApplicantType, string InstallationType, string InspectionType, string DesignatedOfficer, string PlantLocation, int inspectionIdPrm)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentCheckList", ApplicantType, InstallationType, InspectionType, DesignatedOfficer, PlantLocation, inspectionIdPrm);
        }
        #region printing test report code line substation generating set printing   
        public DataSet LineDataWithIdForPrintTestReport(string ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLineDataWithId_ForPrintTestReport", ID);
        }
        public DataSet SubstationTestReportDataForPrintTestReport(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SubstationDataWithId_ForPrintTestReport", Id);
        }
        public DataSet GeneratingTestReportDataWithIdForPrintTestReport(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GeneratingDataWithId_ForPrintTestReport", Id);
        }
        #endregion

        public DataSet ViewDocuments(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDocuments", InspectionId);
        }
        #region Insert Inspection Data NewCode

        public void InsertInspectionDataNewCode(string InstallationTypeID, string ContactNo, string ApplicantTypeCode, string IntimationId, string Inspectiontype, string ApplicantType, string InstallationType,
    string VoltageLevel, string District, string Division, string PaymentMode, string DateOfSubmission, string InspectionRemarks, string CreatedBy,
    decimal TotalAmount, string para_Assigned, string transcationId, string TranscationDate, string ChallanAttachment, int InspectID, string KVA, string DemandNotice, int TotalCapacity, int MaxVoltage,
    int ServiceType, SqlTransaction transaction
    )
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionData_NewCodeForMultiple", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InstallationTypeID ", InstallationTypeID);

            cmd.Parameters.AddWithValue("@ContactNo ", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);

            //cmd.Parameters.AddWithValue("@TestRportId ", TestRportId);

            cmd.Parameters.AddWithValue("@ApplicantTypeCode ", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel ", VoltageLevel);

            //cmd.Parameters.AddWithValue("@LineLength ", String.IsNullOrEmpty(LineLength) ? DBNull.Value : (object)LineLength);
            //cmd.Parameters.AddWithValue("@TestReportCount ", TestReportCount);

            cmd.Parameters.AddWithValue("@District ", District);
            cmd.Parameters.AddWithValue("@Division ", Division);
            cmd.Parameters.AddWithValue("@PaymentMode ", PaymentMode);//
            DateTime SubmitionDate;
            if (DateTime.TryParse(DateOfSubmission, out SubmitionDate) && SubmitionDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", SubmitionDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@InspectionRemarks ", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.Parameters.AddWithValue("@TransactionId ", transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@AssignTo", para_Assigned);
            cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            cmd.Parameters.AddWithValue("@ChallanAttachment", null);
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@SactionVoltage", KVA);
            cmd.Parameters.AddWithValue("@DemandDocument", DemandNotice);
            cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
            cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
            //outputParam = new SqlParameter("@GeneratedId", SqlDbType.NVarChar, 50);
            outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
        }
        #endregion

        public DataTable ShowPendingDivisionDaysData(string dated, string Division)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ShowPendingDivisionDaysData", dated, Division);
        }

        //public DataSet DetailstoPrintFormInspectionDetails(int ID)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDetailsforPrintForm", ID);
        //}
        //public DataSet GetAttachmentsDatainInspectionForm(string InspectionId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachmentsinInspectionForm", InspectionId);
        //}
        public DataTable RequestPendingDivisionForOfficers(string UserID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_GetRecordsAccordingToDaysForOfficers", UserID);
        }

        #region upgradation Intimation
        public void IntimationDataInsertionForSiteOwner(string Id, string ContractorID, string ContractorType, string ApplicantTypeCode, string ApplicantType, string PowerUtility, string PowerUtilityWing,
               string ZoneName, string CircleName, string DivisionName, string SubDivisionName,      /*string TanNumber,*/ string NameOfOwner, string NameOfAgency, string ContactNo, string Address, /*string District*/ string Pincode,
         /*string PANNumber, string NewUserId,*/ string Email, string InspectionType, string CreatedBy)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_UpdateSiteOwnerDetailsInWorkIntimation";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //AdvNo = (string)ViewState["AdvNo"];
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ContractorID", ContractorID);
            cmd.Parameters.AddWithValue("@ContractorType", ContractorType);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@PowerUtility", PowerUtility);
            cmd.Parameters.AddWithValue("@PowerUtilityWing", PowerUtilityWing);
            cmd.Parameters.AddWithValue("@ZoneName", ZoneName);
            cmd.Parameters.AddWithValue("@CircleName", CircleName);
            cmd.Parameters.AddWithValue("@DivisionName", DivisionName);
            cmd.Parameters.AddWithValue("@SubDivisionName", SubDivisionName);
            //cmd.Parameters.AddWithValue("@TanNumber", String.IsNullOrEmpty(TanNumber) ? null : TanNumber);
            cmd.Parameters.AddWithValue("@NameOfOwner", String.IsNullOrEmpty(NameOfOwner) ? null : NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", String.IsNullOrEmpty(NameOfAgency) ? null : NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            //cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Pincode", Pincode);
            // cmd.Parameters.AddWithValue("@PANNumber", PANNumber);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@InspectionType", InspectionType);
            cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
            // cmd.Parameters.AddWithValue("@NewUserId", NewUserId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertionForApplicationDetails(string Id, string ContractorId, string PremisesType, string OtherPremises, string VoltageLevel,
  string SanctionLoad, string TypeOfInstallation1, string NumberOfInstallation1, string TypeOfInstallation2, string NumberOfInstallation2,
  string TypeOfInstallation3, string NumberOfInstallation3, string CreatedBy, string TotalCapacity, SqlTransaction transaction)
        {
            //SqlConnection con = new SqlConnection();
            //SqlCommand cmd = new SqlCommand();
            //string sqlProc = "sp_UpdateApplicationDetailsInWorkIntimation";
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            SqlCommand cmd = new SqlCommand("sp_UpdateApplicationDetailsInWorkIntimation", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.CommandText = sqlProc;
            //cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ContractorId", ContractorId);
            cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
            cmd.Parameters.AddWithValue("@OtherPremises", String.IsNullOrEmpty(OtherPremises) ? DBNull.Value : (object)OtherPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@SanctionLoad", SanctionLoad);
            cmd.Parameters.AddWithValue("@TypeOfInstallation1", TypeOfInstallation1);
            cmd.Parameters.AddWithValue("@NumberOfInstallation1", NumberOfInstallation1);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", String.IsNullOrEmpty(TypeOfInstallation2) ? DBNull.Value : (object)TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@NumberOfInstallation2", String.IsNullOrEmpty(NumberOfInstallation2) ? DBNull.Value : (object)NumberOfInstallation2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", String.IsNullOrEmpty(TypeOfInstallation3) ? DBNull.Value : (object)TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@NumberOfInstallation3", String.IsNullOrEmpty(NumberOfInstallation3) ? DBNull.Value : (object)NumberOfInstallation3);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
            //outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            //outputParam.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            //con.Close();

        }

        public void InsertionForWorkScheduleInWoIntimation(string Id, string ContractorId, //string WorkStartDate, string CompletionDate,
         string AnyWorkIssued, string CopyOfWorkOrder, string CompletionDateasPerOrder, string CreatedBy)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_UpdateWorkScheduleInWorkIntimation";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //AdvNo = (string)ViewState["AdvNo"];
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ContractorId", ContractorId);
            //cmd.Parameters.AddWithValue("@WorkStartDate", WorkStartDate);
            //cmd.Parameters.AddWithValue("@CompletionDate", CompletionDate);
            cmd.Parameters.AddWithValue("@AnyWorkIssued", AnyWorkIssued);
            cmd.Parameters.AddWithValue("@CopyOfWorkOrder", String.IsNullOrEmpty(CopyOfWorkOrder) ? DBNull.Value : (object)CopyOfWorkOrder);
            //cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateasPerOrder);
            DateTime CompletionDateForOrder;
            if (DateTime.TryParse(CompletionDateasPerOrder, out CompletionDateForOrder) && CompletionDateForOrder != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateForOrder);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public int RemovePrivousSupervisiorToContractor(string IntimationId, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_RemovePrivousSupervisiorToContractor", transaction.Connection, transaction);
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)

            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@WorkIntimationId ", IntimationId);
            int x = cmd.ExecuteNonQuery();
            //con.Close();
            return x;

        }

        public void AssignSupervisiorToContractor(string IntimationId, String StaffAssined, string AssignBy, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_AssignSupervisorToContractor", transaction.Connection, transaction);
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)

            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@WorkIntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@StaffAssined", StaffAssined);
            //cmd.Parameters.AddWithValue("@AssingDate", AssignDate);
            cmd.Parameters.AddWithValue("@AssignBy", AssignBy);
            //cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
            //con.Close();
        }

        public void AddInstallations2(string IntimationId, string Typeofinstallation, int Noofinstallation, string loginId, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateInstallationsCountNew", transaction.Connection, transaction);
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Typeofinstallation", Typeofinstallation);
            cmd.Parameters.AddWithValue("@Noofinstallation", Noofinstallation);
            cmd.Parameters.AddWithValue("@CreatedBy", loginId);
            cmd.ExecuteNonQuery();
            //con.Close();

        }
        #endregion

        public DataSet PrintSubstrationTransformer(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApproveCertificate", LoginId);
        }


        public void InspectionFinalAction(string InspectionID, string StaffId, string AcceptedOrReReturn, string Reason, string suggestions, string InspectionDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InspectionApproveReject");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", InspectionID);
                cmd.Parameters.AddWithValue("@StaffId", StaffId);
                cmd.Parameters.AddWithValue("@AcceptedOrRejected", AcceptedOrReReturn);
                cmd.Parameters.AddWithValue("@ReasonForRejection", Reason);
                cmd.Parameters.AddWithValue("@Suggestion", suggestions);
                //cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                DateTime InsDate;
                if (DateTime.TryParse(InspectionDate, out InsDate) && InsDate != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@InspectionDate", DBNull.Value);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                //throw;
            }

        }

        public DataSet checkPreviewInspection(int InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_checkPreviewInspection", InspectionId);
        }
        public DataSet GetTestReport(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport", Id);
        }

        public DataSet getDivisionName()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Get_DivisionName");
        }
        public DataSet getStaffName(string DivisionName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Get_StaffName", DivisionName);
        }
        public DataSet UploadSignature(string DivisionName, string Staff, byte[] Signature, string fileExtensionFormatpara)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Upload_Signature", DivisionName, Staff, Signature, fileExtensionFormatpara);
        }
        public DataSet GetReturnInspectionForContractor(string ContractorLogin)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ReturnedInspection_PendingAssignment_AtContractor", ContractorLogin);
        }
        public DataSet GetAssignedGridDataForContractor(string ContractorLogin)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetAssigenedTestReportForContractor", ContractorLogin);
        }
        public DataSet ContractorRemarks(string ID, string TestRportId, string RemarkForContractor)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertRemarksForContractor", ID, TestRportId, RemarkForContractor);
        }

        #region siteowner periodicInspection
        public DataSet GetInstallationType()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationType");
        }
        public DataSet GetSiteOwnerAdress(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOwnerAdress", id);
        }
        public DataSet GetSiteOwnerAdress_Industry(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOwnerAdressForIndustry", id);
        }
        public DataSet GetPeriodicDetails(string adress, string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsAdressWise", adress, id);
        }
        public DataSet InspectionRenewal(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDataForInspectionRenewal", id);
        }
        public DataSet GetPeriodicDetails(string adress, string id, int NoOfDays, string InstallationType)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsAdressWise", adress, id, NoOfDays, InstallationType);
        }
        public DataSet GetPeriodicDetailsIndustry(string adress, string id, int NoOfDays, string InstallationType)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsAdressWiseIndustry", adress, id, NoOfDays, InstallationType);
        }
        //      public void InsertInspectionRenewalData(string IntimationId, int InspectionId, string InstallationType, string InstallationName,
        //string TestReportId, string InspectionDate, string InspectionDueDate, string DelayedDays, string Voltage, string Capacity, string Address, string District, string Division, string CreatedBy, string Status)
        //      {
        //          try
        //          {
        //              using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
        //              {
        //                  using (SqlCommand cmd = new SqlCommand("sp_InsertInspectionRenewalData", con))
        //                  {
        //                      cmd.CommandType = CommandType.StoredProcedure;
        //                      cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
        //                      cmd.Parameters.AddWithValue("@InspectionId", InspectionId);
        //                      cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
        //                      cmd.Parameters.AddWithValue("@InstallationName", InstallationName);

        //                      cmd.Parameters.AddWithValue("@TestReportId", TestReportId);
        //                      cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
        //                      cmd.Parameters.AddWithValue("@InspectionDueDate", InspectionDueDate);
        //                      cmd.Parameters.AddWithValue("@DelayedDays", DelayedDays);
        //                      cmd.Parameters.AddWithValue("@Voltage", Voltage);
        //                      if (string.IsNullOrWhiteSpace(Capacity))
        //                      {
        //                          cmd.Parameters.AddWithValue("@Capacity", DBNull.Value);
        //                      }
        //                      else
        //                      {
        //                          cmd.Parameters.AddWithValue("@Capacity", Capacity);
        //                      }
        //                      cmd.Parameters.AddWithValue("@Address", Address);
        //                      cmd.Parameters.AddWithValue("@District", District);
        //                      cmd.Parameters.AddWithValue("@Division", Division);
        //                      cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        //                      cmd.Parameters.AddWithValue("@Status", Status);
        //                      con.Open();
        //                      cmd.ExecuteNonQuery();
        //                  }
        //              }
        //          }
        //          catch (Exception ex)
        //          {

        //          }
        //      }

        public void InsertInspectionRenewalData(string IntimationId, string InspectionId, string InstallationType, string InstallationName,
 string TestReportId, string TestReportCount, string InspectionDate, string InspectionDueDate, /*string DelayedDays,*/ string Voltage, string Capacity, string Address, string CompleteAdress,
 string AdressDistrict, string OwnerName, string District, string Division, string CreatedBy, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertInspectionRenewalData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@InspectionId", InspectionId);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@InstallationName", InstallationName);

                        cmd.Parameters.AddWithValue("@TestReportId", TestReportId);
                        cmd.Parameters.AddWithValue("@TestReportCount", TestReportCount);
                        cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                        cmd.Parameters.AddWithValue("@InspectionDueDate", InspectionDueDate);
                        //cmd.Parameters.AddWithValue("@DelayedDays", DelayedDays);
                        cmd.Parameters.AddWithValue("@Voltage", Voltage);
                        if (string.IsNullOrWhiteSpace(Capacity))
                        {
                            cmd.Parameters.AddWithValue("@Capacity", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Capacity", Capacity);
                        }
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@CompleteAdress", CompleteAdress);
                        cmd.Parameters.AddWithValue("@AdressDistrict", AdressDistrict);
                        cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Division", Division);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public DataSet GetAddressToFilterCart(string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressTofilterCart", CreatedBy);
        }
        public DataSet GetAddressToFilterCartForIndustry(string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressTofilterCartForIndustry", CreatedBy);
        }
        public DataSet GetAddressToFilterCart()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressTofilterCart");
        }
        public DataSet ShowDataToCart(string address, string CartID, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_GetCartData", address, CartID, CreatedBy);
        }
        public DataSet ToRemoveDataCart(int InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_ToRemoveDataFromCart", InspectionId);
        }

        #endregion

        #region siteownerDashboard
        public DataSet GetdataforSiteownerdashboard(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDataforSiteownerDashbard", LoginId);
        }
        public DataSet GetdataforSiteownerdashboardGraph(string LoginId, string InstallationType)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDataforSiteownerDashbardGraph", LoginId, InstallationType);
        }
        public DataTable GetdataforSiteownerdashboardGridview(string LoginId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SiteOwnerDashboardGridview", LoginId);
        }
        public DataSet SiteOwnerDashbordCapsule(string LoginId, string ApplicationStatus)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SiteownerDashbordInspections", LoginId, ApplicationStatus);
        }
        #endregion

        public DataSet checkPanNumber(string PanNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckPanNumber", PanNumber);
        }
        #region Existing Inspection
        public DataSet SiteOwnerExistingInstallations(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationforExistingInspection", IntimationId);
        }

        public void InsertExistingInspectionData(string TestReportId, string IntimationId, string TestReportCount, string ApplicantType, string InstallationType, string VoltageLevel,
       string District, string Division, string InspectionType, string CreatedBy
        //string ApprovedDate, string ApproximateYears, string InspectionNewOrExist, string PreviousInspection
        )
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_InsertExistingInspection";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TestRportId", TestReportId);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.Parameters.AddWithValue("@TestReportCount", TestReportCount);
            cmd.Parameters.AddWithValue("@ApplicantType", String.IsNullOrEmpty(ApplicantType) ? DBNull.Value : (object)ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Division", Division);
            cmd.Parameters.AddWithValue("@Inspectiontype", InspectionType);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            //cmd.Parameters.AddWithValue("@ApprovedDate", String.IsNullOrEmpty(ApprovedDate) ? DBNull.Value : (object)ApprovedDate);
            //cmd.Parameters.AddWithValue("@ApproximateYears", ApproximateYears);
            //cmd.Parameters.AddWithValue("@InspectionNewOrExist", InspectionNewOrExist);
            //cmd.Parameters.AddWithValue("@PreviousInspectionDate", PreviousInspection);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataSet ExistingInspectionData(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetExistingInspections", PANNumber);
        }
        //public DataSet ExistingInspectionData_Industry(string PANNumber)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetExistingInspectionsForIndustry", PANNumber);
        //}

        #endregion
        public DataSet ToGetDatafromCart(string address, string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ToGetDatafromCart", address, CartId);
        }

        public void InsertInspectinData(string CartId, string TotalCapacity, string MaxVoltage, string InstallationType, string TestRportId,
 string IntimationId, string VoltageLevel, string ApplicantType, string District, string Division, string AssignTo,
 string PaymentMode, int TotalAmount, int status, string CreatedBy, int ServiceType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertintoTempTable", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CartId", CartId);
                        cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                        cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@TestRportId", TestRportId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                        cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Division", Division);
                        cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                        //cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
                        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                        cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
                        //cmd.Parameters.AddWithValue("@Status", Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable GetAssignInspection(string inspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetAssignToViaInpectionId", inspectionId);
        }

        public DataSet GetPeriodicdataAfterCart(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicdataAfterCart", CartId);
        }

        public DataSet GetDocumentforPeriodic(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentforPeriodic", CartId);
        }

        public string InsertPeriodicInspectionData(string TypeOfInspection, string CartId, string IntimationId, string ApplicantType,
          string InstallationType, string VoltageLevel, string District, string Division,
   string AssignTo, string PaymentMode, string TotalAmount, string TransactionId, string TransctionDate,
   string CreatedBy, string TotalCapacity, string MaxVoltage, int InspectID, int ServiceType, SqlTransaction transaction)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeriodicInspectionData", transaction.Connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfInspection", TypeOfInspection);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                    cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                    cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                    cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@Division", Division);
                    cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                    cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
                    cmd.Parameters.AddWithValue("@TransctionDate", TransctionDate);
                    cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
                    cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                    cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);

                    cmd.Parameters.AddWithValue("@InspectID", InspectID);
                    cmd.Parameters.AddWithValue("@ServiceType", ServiceType);

                    outputParam = new SqlParameter("@Ret_InspectionID", SqlDbType.NVarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string RetVal = cmd.Parameters["@Ret_InspectionID"].Value.ToString();
                    cmd.Parameters.Clear();
                    return RetVal;
                }

            }
        }

        public string InsertPeriodicInspectionDataNew(string TypeOfInspection, string CartId, string TransactionId, string TransctionDate,
        string CreatedBy, int InspectID, SqlTransaction transaction)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeriodicInspectionDataNew", transaction.Connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfInspection", TypeOfInspection);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
                    cmd.Parameters.AddWithValue("@TransactionDate", TransctionDate);
                    cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
                    cmd.Parameters.AddWithValue("@InspectID", InspectID);
                    outputParam = new SqlParameter("@Ret_InspectionID", SqlDbType.NVarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string RetVal = cmd.Parameters["@Ret_InspectionID"].Value.ToString();
                    cmd.Parameters.Clear();
                    return RetVal;
                }

            }
        }
        public DataSet ToGetStaffIdforPeriodic(string Division, string Staff, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffIdforPeriodic", Division, Staff, District);
        }

        public DataSet GetDataForSingleInspection(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDataForSingleInspection", Id);
        }
        public static int GetAffectedRowsCountByCartId(string cartId)
        {
            int count = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_CheckRowAffected", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    con.Open();
                    count = (int)cmd.ExecuteScalar();
                }
            }

            return count;
        }

        #region powerUtility
        public DataSet GetUtilityName()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getUtilityName");
        }
        public DataSet GetWingName(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getWingName", id);
        }
        public DataSet GetZoneName(string UtilityId, string WingId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getZoneName", UtilityId, WingId);
        }
        public DataSet GetCirclesName(string UtilityId, string WingId, string ZoneId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getCircles", UtilityId, WingId, ZoneId);
        }
        public DataSet GetDivisionName(string UtilityId, string WingId, string ZoneId, string CircleId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDivision", UtilityId, WingId, ZoneId, CircleId);
        }
        public DataSet GetSubDivisionName(string UtilityId, string WingId, string ZoneId, string CircleId, string DivisionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getSub_Divisions", UtilityId, WingId, ZoneId, CircleId, DivisionId);
        }
        public DataSet GetSubDivisionEmail(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getEmailsForSubdivision", id);
        }
        #endregion       
        public DataSet NewRequestRecievedAsPeriodic(string Id, string TypeOfInspection)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_NewRequestReceivedAsPeriodic", Id, TypeOfInspection);
        }
        #region siteownerNewRegistration
        public DataTable CheckSiteownerPan(string PanNumber)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckSiteownerPan", PanNumber);
        }

        public int InsertSiteOwnerRegistration(string ApplicantType, string ApplicantCode, string PanTanNumber, string ElectricalInstallationFor, string NameOfOwner, string NameofAgency
                    , string Address, string District, string PinCode, string PhoneNumber, string Email)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertRegistrationSiteOwner", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                    cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantCode);
                    cmd.Parameters.AddWithValue("@PANNumber", PanTanNumber);
                    //cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                    cmd.Parameters.AddWithValue("@ContractorType", ElectricalInstallationFor);
                    cmd.Parameters.AddWithValue("@NameOfOwner", NameOfOwner);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@NameOfAgency", NameofAgency);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    //cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@Pincode", PinCode);
                    cmd.Parameters.AddWithValue("@ContactNo", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    int Ad = cmd.ExecuteNonQuery();
                    return Ad;
                }

            }
        }

        #endregion
        #region SLD 
        //public DataTable SldHistory(string SiteOwnerId)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ApproveSdlHistory", SiteOwnerId);
        //}


        public DataSet ViewSldDocuments(string loginId, string searchText = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_getSdlDocument", loginId, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
        public DataSet PrintApprovalLetter(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApprovalCertificateForPreodic", Id);
        }
        public DataSet getInstallations(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getInstallationTypeForLetter", Id);
        }

        public void SldRequestForAdmin(string SLD_ID, string Status_type, string ActionTaken, string Rejection, string SiteOwnerId)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "Sp_SdlRequest";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@SLD_ID", SLD_ID);
            cmd.Parameters.AddWithValue("@Status_type", Status_type);
            cmd.Parameters.AddWithValue("@ActionTaken", ActionTaken);
            cmd.Parameters.AddWithValue("@Rejection", String.IsNullOrEmpty(Rejection) ? DBNull.Value : (object)Rejection);
            cmd.Parameters.AddWithValue("@SiteOwnerId", SiteOwnerId);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataSet ViewSldDocumentsFoApproval(string LoginId, string searchText = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_getSdlDocumentFoApproval", LoginId, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
        //public DataTable UpdateSLD(string Id, string path, string SiteOwnerId)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_UpdateSdlData", Id, path, SiteOwnerId);
        //}
        public DataTable SldReturnHistory(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SdlReturnHistory", SiteOwnerId);
        }

        //public DataSet UploadSldDocument(string SiteOwnerID, string Path, string Createdby, string SiteOwnerAddress, string OwnerName, string UserType)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_InsertSdlData", SiteOwnerID, Path, Createdby, SiteOwnerAddress, OwnerName, UserType);
        //}

        public void SldApprovedByAdmin(string SLD_ID, string Status_type, string ActionTaken, string SLDApproved, string Remarks, string Rejection)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "Sp_ApproveSdlByAdmin";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@SLD_ID", SLD_ID);
            cmd.Parameters.AddWithValue("@Status_type", Status_type);
            cmd.Parameters.AddWithValue("@ActionTaken", ActionTaken);
            cmd.Parameters.AddWithValue("@SLDApproved", SLDApproved);
            cmd.Parameters.AddWithValue("@Remarks", String.IsNullOrEmpty(Remarks) ? DBNull.Value : (object)Remarks);
            cmd.Parameters.AddWithValue("@Rejection", String.IsNullOrEmpty(Rejection) ? DBNull.Value : (object)Rejection);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable SldHistoryinIndustry(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_SdlHistory", SiteOwnerId);
        }

        public int UploadSldDocument_Industry(string SiteOwnerID, string Path, string Createdby, string SiteOwnerAddress, string OwnerName, string UserType, string serviceid)
        {
            // Prepare the output parameter
            SqlParameter outputParam = new SqlParameter("@InsertedSLD_ID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            // Execute the stored procedure and pass the output parameter
            DBTask.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                CommandType.StoredProcedure,
                "Sp_InsertSdlData_Industry",
                new SqlParameter("@SiteOwnerID", SiteOwnerID),
                new SqlParameter("@Path", Path),
                new SqlParameter("@Createdby", Createdby),
                new SqlParameter("@SiteOwnerAddress", SiteOwnerAddress),
                new SqlParameter("@OwnerName", OwnerName),
                new SqlParameter("@UserType", UserType),
                new SqlParameter("@ServiceId", serviceid),
                outputParam  // Include the output parameter
            );

            // Retrieve the output parameter value
            int insertedSLD_ID = (int)outputParam.Value;

            // Return the inserted SLD_ID
            return insertedSLD_ID;
        }

        //public Industry_Api_Post_DataformatModel GetIndustry_OutgoingRequestFormat_Sld(int _inspectionIdparams, string _actionType, string _projectId = null, string _serviceId = null, string _PanNo = null)
        //{
        //    Industry_Api_Post_DataformatModel model = new Industry_Api_Post_DataformatModel();
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand cmd = new SqlCommand("sp_Industry_Create_OutgoingRequest_Format_Sld", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);
        //            cmd.Parameters.AddWithValue("@ActionType", _actionType);
        //            cmd.Parameters.AddWithValue("@ProjectId", (object)_projectId ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@ServiceId", (object)_serviceId ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@PanNo", (object)_PanNo ?? DBNull.Value);


        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    model = new Industry_Api_Post_DataformatModel
        //                    {
        //                        PremisesType = reader["PremisesType"] != DBNull.Value ? reader["PremisesType"].ToString() : null,
        //                        InspectionId = Convert.ToInt32(reader["InspectionId"]),
        //                        InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
        //                        IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
        //                        ActionTaken = reader["ActionTaken"].ToString(),
        //                        CommentByUserLogin = reader["CommentByUserLogin"].ToString(),
        //                        CommentDate = Convert.ToDateTime(reader["CommentDate"]),
        //                        Comments = reader["Comments"].ToString(),
        //                        Id = reader["Id"].ToString(),
        //                        ProjectId = reader["ProjectId"].ToString(),
        //                        ServiceId = reader["ServiceId"].ToString()
        //                    };

        //                    return model;
        //                }
        //            }
        //        }
        //        connection.Close();
        //    }
        //    return model;
        //    //return null;
        //}


        public void LogToIndustryApiSuccessDatabase_Sld(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody, Industry_Api_Post_DataformatModel apiData)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("sp_Industry_Api_DataSent__Sld_SuccessLog", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@InspectionId", apiData.InspectionId);
                    command.Parameters.AddWithValue("@InspectionLogId", apiData.InspectionLogId);
                    command.Parameters.AddWithValue("@HepcDataId", apiData.IncomingJsonId);
                    command.Parameters.AddWithValue("@ActionTaken", string.IsNullOrEmpty(apiData.ActionTaken) ? (object)DBNull.Value : apiData.ActionTaken);
                    command.Parameters.AddWithValue("@CommentByUserLogin", string.IsNullOrEmpty(apiData.CommentByUserLogin) ? (object)DBNull.Value : apiData.CommentByUserLogin);
                    command.Parameters.AddWithValue("@CommentDate", apiData.CommentDate);
                    command.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(apiData.Comments) ? (object)DBNull.Value : apiData.Comments);
                    command.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(apiData.Id) ? (object)DBNull.Value : apiData.Id);
                    command.Parameters.AddWithValue("@ProjectId", string.IsNullOrEmpty(apiData.ProjectId) ? (object)DBNull.Value : apiData.ProjectId);
                    command.Parameters.AddWithValue("@ServiceId", string.IsNullOrEmpty(apiData.ServiceId) ? (object)DBNull.Value : apiData.ServiceId);

                    command.Parameters.AddWithValue("@RequestUrl", requestUrl);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod);
                    command.Parameters.AddWithValue("@RequestHeaders", string.IsNullOrEmpty(requestHeaders) ? (object)DBNull.Value : requestHeaders);
                    command.Parameters.AddWithValue("@RequestContentType", string.IsNullOrEmpty(requestContentType) ? (object)DBNull.Value : requestContentType);
                    command.Parameters.AddWithValue("@RequestBody", string.IsNullOrEmpty(requestBody) ? (object)DBNull.Value : requestBody);
                    command.Parameters.AddWithValue("@ResponseStatusCode", string.IsNullOrEmpty(responseStatusCode) ? (object)DBNull.Value : responseStatusCode);
                    command.Parameters.AddWithValue("@ResponseHeaders", string.IsNullOrEmpty(responseHeaders) ? (object)DBNull.Value : responseHeaders);
                    command.Parameters.AddWithValue("@ResponseBody", string.IsNullOrEmpty(responseBody) ? (object)DBNull.Value : responseBody);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new TokenManagerException(
                        "An error occurred while logging to the database",
                        requestUrl,
                        requestMethod,
                        requestHeaders,
                        requestContentType,
                        requestBody,
                        responseStatusCode,
                        responseHeaders,
                        ex.Message.ToString(),
                        apiData.PremisesType,
                        apiData.InspectionId,
                        apiData.InspectionLogId,
                        apiData.IncomingJsonId,
                        apiData.ActionTaken,
                        apiData.CommentByUserLogin,
                        apiData.CommentDate,
                        apiData.Comments,
                        apiData.Id,
                        apiData.ProjectId,
                        apiData.ServiceId);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //public DataTable UpdateSLD_Industry(string Id, string path, string SiteOwnerId, string serviceid)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_UpdateSdlData_Industry", Id, path, SiteOwnerId, serviceid);
        //}


        #endregion

        #region industry
        //after industry merge 20 july

        public DataSet TestReportData_Industry(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSiteOwner_Industry", PANNumber);
        }

        public DataSet SiteOwnerInstallations_Industry(string IntimationId, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationForSiteOwner_Industry", IntimationId, TestReportId);
        }

        public DataTable GetDocumentlist_Industry(string ApplicantType, string InstallationType, string InspectionType, string DesignatedOfficer, string PlantLocation, int inspectionIdPrm)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentCheckList_Industry", ApplicantType, InstallationType, InspectionType, DesignatedOfficer, PlantLocation, inspectionIdPrm);
        }

        //public DataTable Payment_Industry(string intimationId, string count, string installationtypeId, string InspectionType)
        //{
        //    DataTable result = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_Industry", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@IntimationId", intimationId);
        //        command.Parameters.AddWithValue("@Count", count);
        //        command.Parameters.AddWithValue("@InspectionType", InspectionType);
        //        command.Parameters.AddWithValue("@InstallationTypeID", installationtypeId);

        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(result);
        //    }

        //    return result;
        //}

        public DataSet GetData_Industry(string Inspectiontype, string IntimationId, string Count)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDataForInspection_Industry", Inspectiontype, IntimationId, Count);
        }

        public void InsertInspectionDataNewCode_Industry(string ContactNo, string TestRportId, string ApplicantTypeCode, string IntimationId, string Inspectiontype, string ApplicantType, string InstallationType,
string VoltageLevel, string LineLength, string TestReportCount, string District, string Division, string PaymentMode, string DateOfSubmission, string InspectionRemarks, string CreatedBy,
int TotalAmount, string transcationId, string TranscationDate, string ChallanAttachment, int InspectID, string KVA, string DemandNotice, SqlTransaction transaction
)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionData_NewCode_Industry", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactNo ", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@TestRportId ", TestRportId);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode ", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel ", VoltageLevel);
            cmd.Parameters.AddWithValue("@LineLength ", String.IsNullOrEmpty(LineLength) ? DBNull.Value : (object)LineLength);
            cmd.Parameters.AddWithValue("@TestReportCount ", TestReportCount);

            cmd.Parameters.AddWithValue("@District ", District);
            cmd.Parameters.AddWithValue("@Division ", Division);
            cmd.Parameters.AddWithValue("@PaymentMode ", PaymentMode);//
            DateTime SubmitionDate;
            if (DateTime.TryParse(DateOfSubmission, out SubmitionDate) && SubmitionDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", SubmitionDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@InspectionRemarks ", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.Parameters.AddWithValue("@TransactionId ", transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            cmd.Parameters.AddWithValue("@ChallanAttachment", null);
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@SactionVoltage", KVA);
            cmd.Parameters.AddWithValue("@DemandDocument", DemandNotice);
            //outputParam = new SqlParameter("@GeneratedId", SqlDbType.NVarChar, 50);
            outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
        }

        public DataTable SiteOwnerInspectionData_Industry(string SiteOwnerId, string TestReportId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistory_Industry", SiteOwnerId, TestReportId);
        }
        public DataSet InspectionData_Industry(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData", Id);
        }
        public DataSet ViewDocuments_Industry(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDocuments_Industry", InspectionId);
        }
        public DataSet GetTestReport_Industry(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Industry", Id);
        }
        public DataSet ContractorRemarks_Industry(string ID, string TestRportId, string RemarkForContractor)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertRemarksForContractor_Industry", ID, TestRportId, RemarkForContractor);
        }

        public void LogToIndustryApiSuccessDatabase(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody, Industry_Api_Post_DataformatModel apiData)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("sp_Industry_Api_DataSent_SuccessLog", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@InspectionId", apiData.InspectionId);
                    command.Parameters.AddWithValue("@InspectionLogId", apiData.InspectionLogId);
                    command.Parameters.AddWithValue("@HepcDataId", apiData.IncomingJsonId);
                    command.Parameters.AddWithValue("@ActionTaken", string.IsNullOrEmpty(apiData.ActionTaken) ? (object)DBNull.Value : apiData.ActionTaken);
                    command.Parameters.AddWithValue("@CommentByUserLogin", string.IsNullOrEmpty(apiData.CommentByUserLogin) ? (object)DBNull.Value : apiData.CommentByUserLogin);
                    command.Parameters.AddWithValue("@CommentDate", apiData.CommentDate);
                    command.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(apiData.Comments) ? (object)DBNull.Value : apiData.Comments);
                    command.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(apiData.Id) ? (object)DBNull.Value : apiData.Id);
                    command.Parameters.AddWithValue("@ProjectId", string.IsNullOrEmpty(apiData.ProjectId) ? (object)DBNull.Value : apiData.ProjectId);
                    command.Parameters.AddWithValue("@ServiceId", string.IsNullOrEmpty(apiData.ServiceId) ? (object)DBNull.Value : apiData.ServiceId);

                    command.Parameters.AddWithValue("@RequestUrl", requestUrl);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod);
                    command.Parameters.AddWithValue("@RequestHeaders", string.IsNullOrEmpty(requestHeaders) ? (object)DBNull.Value : requestHeaders);
                    command.Parameters.AddWithValue("@RequestContentType", string.IsNullOrEmpty(requestContentType) ? (object)DBNull.Value : requestContentType);
                    command.Parameters.AddWithValue("@RequestBody", string.IsNullOrEmpty(requestBody) ? (object)DBNull.Value : requestBody);
                    command.Parameters.AddWithValue("@ResponseStatusCode", string.IsNullOrEmpty(responseStatusCode) ? (object)DBNull.Value : responseStatusCode);
                    command.Parameters.AddWithValue("@ResponseHeaders", string.IsNullOrEmpty(responseHeaders) ? (object)DBNull.Value : responseHeaders);
                    command.Parameters.AddWithValue("@ResponseBody", string.IsNullOrEmpty(responseBody) ? (object)DBNull.Value : responseBody);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new TokenManagerException(
                        "An error occurred while logging to the database",
                        requestUrl,
                        requestMethod,
                        requestHeaders,
                        requestContentType,
                        requestBody,
                        responseStatusCode,
                        responseHeaders,
                        ex.Message.ToString(),
                        apiData.PremisesType,
                        apiData.InspectionId,
                        apiData.InspectionLogId,
                        apiData.IncomingJsonId,
                        apiData.ActionTaken,
                        apiData.CommentByUserLogin,
                        apiData.CommentDate,
                        apiData.Comments,
                        apiData.Id,
                        apiData.ProjectId,
                        apiData.ServiceId);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //public Industry_Api_Post_DataformatModel GetIndustry_OutgoingRequestFormat(int _inspectionIdparams, string _actionType, string _projectId = null, string _serviceId = null, string _PanNo = null)
        //{
        //    Industry_Api_Post_DataformatModel model = new Industry_Api_Post_DataformatModel();
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand cmd = new SqlCommand("sp_Industry_Create_OutgoingRequest_Format", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);
        //            cmd.Parameters.AddWithValue("@ActionType", _actionType);
        //            cmd.Parameters.AddWithValue("@ProjectId", (object)_projectId ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@ServiceId", (object)_serviceId ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@PanNo", (object)_PanNo ?? DBNull.Value);


        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    model = new Industry_Api_Post_DataformatModel
        //                    {
        //                        PremisesType = reader["PremisesType"] != DBNull.Value ? reader["PremisesType"].ToString() : null,
        //                        InspectionId = Convert.ToInt32(reader["InspectionId"]),
        //                        InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
        //                        IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
        //                        ActionTaken = reader["ActionTaken"].ToString(),
        //                        CommentByUserLogin = reader["CommentByUserLogin"].ToString(),
        //                        CommentDate = Convert.ToDateTime(reader["CommentDate"]),
        //                        Comments = reader["Comments"].ToString(),
        //                        Id = reader["Id"].ToString(),
        //                        ProjectId = reader["ProjectId"].ToString(),
        //                        ServiceId = reader["ServiceId"].ToString()
        //                    };

        //                    return model;
        //                }
        //            }
        //        }
        //        connection.Close();
        //    }
        //    return model;
        //    //return null;
        //}

        public void LogToIndustryApiErrorDatabase(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody, Industry_Api_Post_DataformatModel apiData)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("sp_LogIndustryApiError", connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@InspectionId", apiData.InspectionId);
                    command.Parameters.AddWithValue("@InspectionLogId", apiData.InspectionLogId);
                    command.Parameters.AddWithValue("@HepcDataId", apiData.IncomingJsonId);
                    command.Parameters.AddWithValue("@ActionTaken", string.IsNullOrEmpty(apiData.ActionTaken) ? (object)DBNull.Value : apiData.ActionTaken);
                    command.Parameters.AddWithValue("@CommentByUserLogin", string.IsNullOrEmpty(apiData.CommentByUserLogin) ? (object)DBNull.Value : apiData.CommentByUserLogin);
                    command.Parameters.AddWithValue("@CommentDate", apiData.CommentDate);
                    command.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(apiData.Comments) ? (object)DBNull.Value : apiData.Comments);
                    command.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(apiData.Id) ? (object)DBNull.Value : apiData.Id);
                    command.Parameters.AddWithValue("@ProjectId", string.IsNullOrEmpty(apiData.ProjectId) ? (object)DBNull.Value : apiData.ProjectId);
                    command.Parameters.AddWithValue("@ServiceId", string.IsNullOrEmpty(apiData.ServiceId) ? (object)DBNull.Value : apiData.ServiceId);

                    // Add parameters required by the stored procedure
                    command.Parameters.AddWithValue("@RequestUrl", requestUrl ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestHeaders", requestHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestContentType", requestContentType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestBody", requestBody ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseStatusCode", responseStatusCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseHeaders", responseHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseBody", responseBody ?? (object)DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    // Handle the exception as needed
                    // You might want to log this exception to a file or another table for debugging
                    Console.WriteLine("An error occurred while logging to the database: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public IndustryApiLogDetails Post_Industry_Inspection_StageWise_JsonData(string url, object inputObject, Industry_Api_Post_DataformatModel ApiPostformatresult, string accessToken)
        {
            IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
            string result;
            var inputJson = JsonConvert.SerializeObject(inputObject);

            // Disable the 100-continue behavior
            ServicePointManager.Expect100Continue = false;

            // Create the web request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Bearer " + accessToken;
            request.ProtocolVersion = HttpVersion.Version11;

            // Convert JSON string to bytes using UTF8 encoding
            byte[] data = Encoding.UTF8.GetBytes(inputJson);
            request.ContentLength = data.Length;

            string requestHeaders = string.Join(", ", request.Headers.AllKeys.Select(k => $"{k}: {request.Headers[k]}"));

            try
            {

                //logDetails = new IndustryApiLogDetails
                //{
                //    Url = "https://investharyana.in/api/getrefresh-token",
                //    Method = request.Method,
                //    RequestHeaders = requestHeaders,
                //    ContentType = request.ContentType,
                //    RequestBody = inputJson,
                //    ResponseStatusCode = "ok",
                //    ResponseHeaders = "",
                //    ResponseBody = "",
                //    ErrorMessage = string.Empty
                //};



                // Write data to the request stream
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                // Get the response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = new StreamReader(response.GetResponseStream()))
                    {
                        result = responseStream.ReadToEnd();
                    }

                    string responseHeaders = string.Join(", ", response.Headers.AllKeys.Select(k => $"{k}: {response.Headers[k]}"));

                    logDetails = new IndustryApiLogDetails
                    {
                        Url = url,
                        Method = request.Method,
                        RequestHeaders = requestHeaders,
                        ContentType = request.ContentType,
                        RequestBody = inputJson,
                        ResponseStatusCode = response.StatusCode.ToString(),
                        ResponseHeaders = responseHeaders,
                        ResponseBody = result,
                        ErrorMessage = string.Empty
                    };
                }
            }
            catch (WebException ex)
            {
                string response = string.Empty;
                if (ex.Response != null)
                {
                    using (var responseStream = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        response = responseStream.ReadToEnd();
                    }
                }

                throw new IndustryApiException(
                    ex.Message,
                    url,
                    request.Method,
                    requestHeaders,
                    request.ContentType,
                    inputJson,
                    ex.Status.ToString(),
                    ex.Response?.Headers.ToString() ?? string.Empty,
                    response,
                    ApiPostformatresult.PremisesType.ToString(),
                    ApiPostformatresult.InspectionId,
                    ApiPostformatresult.InspectionLogId,
                    ApiPostformatresult.IncomingJsonId,
                    ApiPostformatresult.ActionTaken,
                    ApiPostformatresult.CommentByUserLogin,
                    ApiPostformatresult.CommentDate,
                    ApiPostformatresult.Comments,
                    ApiPostformatresult.Id,
                    ApiPostformatresult.ProjectId,
                    ApiPostformatresult.ServiceId
                );
            }

            return logDetails;
        }

        public string IndustryTokenApiReturnedErrorMessage(TokenManagerException ex)
        {
            string errorMessage = "An error occurred";
            try
            {
                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(ex.ResponseBody);
                if (responseObject != null && responseObject.ContainsKey("errorMessage"))
                {
                    errorMessage = responseObject["errorMessage"];
                }
            }
            catch (Exception parseException)
            {
                // Log or handle parse exception if necessary
            }

            return errorMessage;
        }
        public string IndustryApiReturnedErrorMessage(IndustryApiException ex)
        {
            string errorMessage = "An error occurred";
            try
            {
                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(ex.ResponseBody);
                if (responseObject != null && responseObject.ContainsKey("errorMessage"))
                {
                    errorMessage = responseObject["errorMessage"];
                }
            }
            catch (Exception parseException)
            {
                // Log or handle parse exception if necessary
            }

            return errorMessage;
        }

        public Industry_Api_Post_DataformatModel GetIndustry_OutgoingRequestFormat_HepcPending_ErrorLogs(int _inspectionLogId)
        {
            Industry_Api_Post_DataformatModel model = new Industry_Api_Post_DataformatModel();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_Industry_Format_HepcErrorLogs", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InspectionLogId", _inspectionLogId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model = new Industry_Api_Post_DataformatModel
                            {
                                PremisesType = reader["PremisesType"] != DBNull.Value ? reader["PremisesType"].ToString() : null,
                                InspectionId = Convert.ToInt32(reader["InspectionId"]),
                                InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
                                IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
                                ActionTaken = reader["ActionTaken"].ToString(),
                                CommentByUserLogin = reader["CommentByUserLogin"].ToString(),
                                CommentDate = Convert.ToDateTime(reader["CommentDate"]),
                                Comments = reader["Comments"].ToString(),
                                Id = reader["Id"].ToString(),
                                ProjectId = reader["ProjectId"].ToString(),
                                ServiceId = reader["ServiceId"].ToString()
                            };

                            return model;
                        }
                    }
                }
                connection.Close();
            }
            return model;
            //return null;
        }
        #endregion

        public DataSet GetOwnerAdress(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getSiteAddress", id);
        }

        public void updateInspectionPeriodic(string InspectionID, string StaffId, string IntimatiomnId, string Installationtype,
    string AcceptedOrReReturn, string Reason, string ReasonType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InspectionReviewForPeriodic", connection))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", InspectionID);
                        cmd.Parameters.AddWithValue("@StaffId", StaffId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimatiomnId);
                        //cmd.Parameters.AddWithValue("@count", count);
                        cmd.Parameters.AddWithValue("@Installationtype ", Installationtype);
                        cmd.Parameters.AddWithValue("@AcceptedOrReturn ", AcceptedOrReReturn);
                        cmd.Parameters.AddWithValue("@ReasonForRejection ", Reason);
                        cmd.Parameters.AddWithValue("@ReasonType ", ReasonType);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    //throw;
                }
                finally
                {
                    connection.Close();
                }

            }

        }
        public DataSet GetTypeOfInspection(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetTypeOfInspection", Id);
        }
        public DataSet GetPeriodicType(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicType", CartId);
        }
        public DataSet GetDocumentsforPeriodicIfExist(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentsforPeriodicIfExist", InspectionId);
        }
        public DataSet GetTestReportDataIfPeriodic(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodic", Id);
        }


        public string CheckServerStatus(string url)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";

                    // Making a simple GET request to the server
                    string response = client.DownloadString(url);

                    // If the request is successful, return a success message
                    return "Server is reachable.";
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure || ex.Status == WebExceptionStatus.Timeout)
                {
                    // Server is down or unreachable
                    return "Server is down or unreachable.";
                }
                else
                {
                    // Some other WebException occurred
                    return $"Server might be down. Error: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions if necessary
                return $"An error occurred: {ex.Message}";
            }
        }

        public string GetIndustry_RequestType_Sld(int _inspectionIdparams)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string result = "No data found";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GetIndustry_RequestType_Sld", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader["UserType"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = $"An error occurred: {ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }


        public string GetIndustry_RequestType_New(int _inspectionIdparams)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string result = "No data found";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GetIndustry_RequestType_New", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader["Inspectiontype"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = $"An error occurred: {ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public void LogToIndustryApiErrorDatabase_Sld(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody, Industry_Api_Post_DataformatModel apiData)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("sp_LogIndustryApiError_Sld", connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@InspectionId", apiData.InspectionId);
                    command.Parameters.AddWithValue("@InspectionLogId", apiData.InspectionLogId);
                    command.Parameters.AddWithValue("@HepcDataId", apiData.IncomingJsonId);
                    command.Parameters.AddWithValue("@ActionTaken", string.IsNullOrEmpty(apiData.ActionTaken) ? (object)DBNull.Value : apiData.ActionTaken);
                    command.Parameters.AddWithValue("@CommentByUserLogin", string.IsNullOrEmpty(apiData.CommentByUserLogin) ? (object)DBNull.Value : apiData.CommentByUserLogin);
                    command.Parameters.AddWithValue("@CommentDate", apiData.CommentDate);
                    command.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(apiData.Comments) ? (object)DBNull.Value : apiData.Comments);
                    command.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(apiData.Id) ? (object)DBNull.Value : apiData.Id);
                    command.Parameters.AddWithValue("@ProjectId", string.IsNullOrEmpty(apiData.ProjectId) ? (object)DBNull.Value : apiData.ProjectId);
                    command.Parameters.AddWithValue("@ServiceId", string.IsNullOrEmpty(apiData.ServiceId) ? (object)DBNull.Value : apiData.ServiceId);

                    // Add parameters required by the stored procedure
                    command.Parameters.AddWithValue("@RequestUrl", requestUrl ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestHeaders", requestHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestContentType", requestContentType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestBody", requestBody ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseStatusCode", responseStatusCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseHeaders", responseHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseBody", responseBody ?? (object)DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    // Handle the exception as needed
                    // You might want to log this exception to a file or another table for debugging
                    Console.WriteLine("An error occurred while logging to the database: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet checkPassword(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckPassword", UserId);
        }
        public DataSet changePassword(string UserId, string Password)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_updatePassword", UserId, Password);
        }
        public string InsertPeriodicInspectionData_Industry(string TypeOfInspection, string CartId, string IntimationId, string ApplicantType,
       string InstallationType, string VoltageLevel, string District, string Division,
 string AssignTo, string PaymentMode, string TotalAmount, string TransactionId, string TransctionDate,
 string CreatedBy, string TotalCapacity, string MaxVoltage, string UserType, int InspectID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeriodicInspectionData_Industry", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfInspection", TypeOfInspection);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                    cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                    cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                    cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@Division", Division);
                    cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                    cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
                    cmd.Parameters.AddWithValue("@TransctionDate", TransctionDate);
                    cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
                    cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                    cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
                    cmd.Parameters.AddWithValue("@UserType", UserType);
                    cmd.Parameters.AddWithValue("@InspectID", InspectID);
                    outputParam = new SqlParameter("@Ret_InspectionID", SqlDbType.NVarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string RetVal = cmd.Parameters["@Ret_InspectionID"].Value.ToString();
                    cmd.Parameters.Clear();
                    return RetVal;
                }

            }
        }

        public DataSet PrintIndustryCirtificate_New(string LoginId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApproveCertificate_Industry_New", LoginId);
        }
        public DataSet ViewCartData(string SiteOwnerId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressforViewCart", SiteOwnerId);
        }
        public DataSet ViewInspection(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ViewPeriodicInspection", CartId);
        }
        public DataSet DetailstoPrintFormofPeriodicInspectionDetails(int ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDetailsforPeriodicPrintForm", ID);
        }
        public DataSet GetDetailsToViewCart(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCart", InspectionId);
        }
        public DataSet ContractorRemarksInPeriodic(string ID, string RemarkForContractor)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertRemarksForContractorINPeriodic", ID, RemarkForContractor);
        }
        public DataSet GetReturnInspectionForContractorIfPeriodic(string ContractorLogin)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ReturnedInspection_PendingAssignment_AtContractor_IFPeriodic", ContractorLogin);
        }
        public DataTable GetReturnedPeriodicInspections(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ReturnedPeriodicInspections", Id);
        }
        public string GetIndustry_InsertSdlData_Check(string _SiteOwnerID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string result = "0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_InsertSdlData_Industry_Check", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SiteOwnerID", _SiteOwnerID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader["Result"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = $"An error occurred: {ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public void LogToIndustryApiErrorDatabase_Scheduler(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody, Industry_Api_Post_DataformatModel apiData)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("sp_LogIndustryApiError_Scheduler", connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@InspectionId", apiData.InspectionId);
                    command.Parameters.AddWithValue("@InspectionLogId", apiData.InspectionLogId);
                    command.Parameters.AddWithValue("@HepcDataId", apiData.IncomingJsonId);
                    command.Parameters.AddWithValue("@ActionTaken", string.IsNullOrEmpty(apiData.ActionTaken) ? (object)DBNull.Value : apiData.ActionTaken);
                    command.Parameters.AddWithValue("@CommentByUserLogin", string.IsNullOrEmpty(apiData.CommentByUserLogin) ? (object)DBNull.Value : apiData.CommentByUserLogin);
                    command.Parameters.AddWithValue("@CommentDate", apiData.CommentDate);
                    command.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(apiData.Comments) ? (object)DBNull.Value : apiData.Comments);
                    command.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(apiData.Id) ? (object)DBNull.Value : apiData.Id);
                    command.Parameters.AddWithValue("@ProjectId", string.IsNullOrEmpty(apiData.ProjectId) ? (object)DBNull.Value : apiData.ProjectId);
                    command.Parameters.AddWithValue("@ServiceId", string.IsNullOrEmpty(apiData.ServiceId) ? (object)DBNull.Value : apiData.ServiceId);

                    // Add parameters required by the stored procedure
                    command.Parameters.AddWithValue("@RequestUrl", requestUrl ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestHeaders", requestHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestContentType", requestContentType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestBody", requestBody ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseStatusCode", responseStatusCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseHeaders", responseHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseBody", responseBody ?? (object)DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    // Handle the exception as needed
                    // You might want to log this exception to a file or another table for debugging
                    Console.WriteLine("An error occurred while logging to the database: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void LogToIndustryApiSuccessDatabase_Scheduler(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody, Industry_Api_Post_DataformatModel apiData)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("sp_Industry_Api_DataSent_SuccessLog_Scheduler", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@InspectionId", apiData.InspectionId);
                    command.Parameters.AddWithValue("@InspectionLogId", apiData.InspectionLogId);
                    command.Parameters.AddWithValue("@HepcDataId", apiData.IncomingJsonId);
                    command.Parameters.AddWithValue("@ActionTaken", string.IsNullOrEmpty(apiData.ActionTaken) ? (object)DBNull.Value : apiData.ActionTaken);
                    command.Parameters.AddWithValue("@CommentByUserLogin", string.IsNullOrEmpty(apiData.CommentByUserLogin) ? (object)DBNull.Value : apiData.CommentByUserLogin);
                    command.Parameters.AddWithValue("@CommentDate", apiData.CommentDate);
                    command.Parameters.AddWithValue("@Comments", string.IsNullOrEmpty(apiData.Comments) ? (object)DBNull.Value : apiData.Comments);
                    command.Parameters.AddWithValue("@Id", string.IsNullOrEmpty(apiData.Id) ? (object)DBNull.Value : apiData.Id);
                    command.Parameters.AddWithValue("@ProjectId", string.IsNullOrEmpty(apiData.ProjectId) ? (object)DBNull.Value : apiData.ProjectId);
                    command.Parameters.AddWithValue("@ServiceId", string.IsNullOrEmpty(apiData.ServiceId) ? (object)DBNull.Value : apiData.ServiceId);

                    command.Parameters.AddWithValue("@RequestUrl", requestUrl);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod);
                    command.Parameters.AddWithValue("@RequestHeaders", string.IsNullOrEmpty(requestHeaders) ? (object)DBNull.Value : requestHeaders);
                    command.Parameters.AddWithValue("@RequestContentType", string.IsNullOrEmpty(requestContentType) ? (object)DBNull.Value : requestContentType);
                    command.Parameters.AddWithValue("@RequestBody", string.IsNullOrEmpty(requestBody) ? (object)DBNull.Value : requestBody);
                    command.Parameters.AddWithValue("@ResponseStatusCode", string.IsNullOrEmpty(responseStatusCode) ? (object)DBNull.Value : responseStatusCode);
                    command.Parameters.AddWithValue("@ResponseHeaders", string.IsNullOrEmpty(responseHeaders) ? (object)DBNull.Value : responseHeaders);
                    command.Parameters.AddWithValue("@ResponseBody", string.IsNullOrEmpty(responseBody) ? (object)DBNull.Value : responseBody);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new TokenManagerException(
                        "An error occurred while logging to the database",
                        requestUrl,
                        requestMethod,
                        requestHeaders,
                        requestContentType,
                        requestBody,
                        responseStatusCode,
                        responseHeaders,
                        ex.Message.ToString(),
                        apiData.PremisesType,
                        apiData.InspectionId,
                        apiData.InspectionLogId,
                        apiData.IncomingJsonId,
                        apiData.ActionTaken,
                        apiData.CommentByUserLogin,
                        apiData.CommentDate,
                        apiData.Comments,
                        apiData.Id,
                        apiData.ProjectId,
                        apiData.ServiceId);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetDetailsToViewCartforSupervisor(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCartForSupervisor", InspectionId);
        }
        public DataSet GetSuggestions()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSuggestions");
        }
        public DataSet InsertSuggestions(string Suggestions)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SaveSuggestions", Suggestions);
        }
        public DataSet ViewCartDataIndustry(string SiteOwnerId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressforViewCart_Industry", SiteOwnerId);
        }
        public DataSet ViewInspectionHistory(string SiteOwnerId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ViewInspectionHistoryForPeriodicIndustry", SiteOwnerId);
        }
        public DataTable SiteOwnerInspectionDataforPeriodicIndustry(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistoryForPeriodic_Industry", SiteOwnerId);
        }
        public DataSet ToRemoveUploadededSingature(int Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_RemoveUploadededSingature", Id);
        }
        public DataSet AuthenticateResetUser(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AuthenticateResetUser", UserId);
        }
        public DataSet UserResetPassword(string UserId, string Password)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ResetUserPassword", UserId, Password);
        }
        public DataTable GetSiteOwnerData()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerData");
        }

        //Created On 11-Sept-2024
        public DataTable GetTransferReport()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTransferReport");
        }

        public DataTable GetTransferSearchReport(DateTime? DateFrom, DateTime? DateTo, string TransferTo, string Status, string InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTransferSearchReport",
                DateFrom ?? (object)DBNull.Value,
                DateTo ?? (object)DBNull.Value,
                string.IsNullOrEmpty(TransferTo) ? DBNull.Value : (object)TransferTo,
                string.IsNullOrEmpty(Status) ? DBNull.Value : (object)Status,
                string.IsNullOrEmpty(InspectionId) ? DBNull.Value : (object)InspectionId);
        }

        #region Insert Intimtion Data By Siteowner
        public DataSet GetWorkIntimationDataAtSiteOwner(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationDataBySiteOwner", Id);
        }

        public void IntimationDataInsertionBySiteowner(string SiteOwnerId, string ApplicantType, string ApplicantTypeCode, string ContractorType, string PowerUtility, string PowerUtilityWing, string ZoneName,
                                          string CircleName, string DivisionName, string SubDivisionName, string NameOfOwner, string NameOfAgency, string ContactNo,
                                          string Address, string District, string Pincode, string PremisesType, string OtherPremises, string VoltageLevel, string PANNumber,
                                          string TypeOfInstallation2, string NumberOfInstallation2, string TypeOfInstallation3, string NumberOfInstallation3,
                                          string Email, string Createdby, string SanctionLoad, string InspectionType, string TotalCapacity, string SanctionLoadValue, string SiteOwnerPassword, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_WorkIntimationRegistrationBySiteOwner", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@SiteOwnerId", SiteOwnerId);
            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@ContractorType", String.IsNullOrEmpty(ContractorType) ? DBNull.Value : (object)ContractorType);
            cmd.Parameters.AddWithValue("@PowerUtility", String.IsNullOrEmpty(PowerUtility) ? DBNull.Value : (object)PowerUtility);
            cmd.Parameters.AddWithValue("@PowerUtilityWing", String.IsNullOrEmpty(PowerUtilityWing) ? DBNull.Value : (object)PowerUtilityWing);
            cmd.Parameters.AddWithValue("@ZoneName", String.IsNullOrEmpty(ZoneName) ? DBNull.Value : (object)ZoneName);
            cmd.Parameters.AddWithValue("@CircleName", String.IsNullOrEmpty(CircleName) ? DBNull.Value : (object)CircleName);
            cmd.Parameters.AddWithValue("@DivisionName", String.IsNullOrEmpty(DivisionName) ? DBNull.Value : (object)DivisionName);
            cmd.Parameters.AddWithValue("@SubDivisionName", String.IsNullOrEmpty(SubDivisionName) ? DBNull.Value : (object)SubDivisionName);
            cmd.Parameters.AddWithValue("@NameOfOwner", String.IsNullOrEmpty(NameOfOwner) ? DBNull.Value : (object)NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", String.IsNullOrEmpty(NameOfAgency) ? DBNull.Value : (object)NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@Address", String.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
            cmd.Parameters.AddWithValue("@District", District == "Select" ? DBNull.Value : (object)District);
            cmd.Parameters.AddWithValue("@Pincode", String.IsNullOrEmpty(Pincode) ? DBNull.Value : (object)Pincode);
            cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
            cmd.Parameters.AddWithValue("@OtherPremises", String.IsNullOrEmpty(OtherPremises) ? DBNull.Value : (object)OtherPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@PANNumber", String.IsNullOrEmpty(PANNumber) ? DBNull.Value : (object)PANNumber);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", String.IsNullOrEmpty(TypeOfInstallation2) ? DBNull.Value : (object)TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@NumberOfInstallation2", String.IsNullOrEmpty(NumberOfInstallation2) ? DBNull.Value : (object)NumberOfInstallation2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", String.IsNullOrEmpty(TypeOfInstallation3) ? DBNull.Value : (object)TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@NumberOfInstallation3", String.IsNullOrEmpty(NumberOfInstallation3) ? DBNull.Value : (object)NumberOfInstallation3);
            cmd.Parameters.AddWithValue("@Email", String.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
            cmd.Parameters.AddWithValue("@Createdby", String.IsNullOrEmpty(Createdby) ? DBNull.Value : (object)Createdby);
            cmd.Parameters.AddWithValue("@SanctionLoad", String.IsNullOrEmpty(SanctionLoad) ? DBNull.Value : (object)SanctionLoad);
            cmd.Parameters.AddWithValue("@InspectionType", String.IsNullOrEmpty(InspectionType) ? DBNull.Value : (object)InspectionType);
            cmd.Parameters.AddWithValue("@TotalCapacity", String.IsNullOrEmpty(TotalCapacity) ? DBNull.Value : (object)TotalCapacity);
            cmd.Parameters.AddWithValue("@SanctionLoadValue", String.IsNullOrEmpty(SanctionLoadValue) ? DBNull.Value : (object)SanctionLoadValue);
            cmd.Parameters.AddWithValue("@SiteOwnerPassword", String.IsNullOrEmpty(SiteOwnerPassword) ? DBNull.Value : (object)SiteOwnerPassword);

            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

            string registrationId = outputParam.Value.ToString();

        }

        public void AddInstallationsCreatedbySiteOwner(string IntimationId, string Typeofinstallation, int Noofinstallation, string CreatedBy, string TypeOfInspection, SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InstallationsCountCreatedbySiteOwner", transaction.Connection, transaction);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                cmd.Parameters.AddWithValue("@Typeofinstallation", Typeofinstallation);
                cmd.Parameters.AddWithValue("@Noofinstallation", Noofinstallation);
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.Parameters.AddWithValue("@InspectionType", TypeOfInspection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
        }

        #endregion
        //Created on 12-Sept-2024
        public DataSet DdlToTransferStaff()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffForTransfer");
        }
        public DataSet GetStaffAssigned(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ToGetAssignedOfficer", CartId);
        }

        public DataTable WorkIntimationDataforSiteOwner(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsDetailsForSiteOwner", Id);
        }
        public DataTable InstallationDataforSiteOwner(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationDetails", Id);
        }
        public int InsertGeneratingSetData_Existing_HavingPreviousReport(string IdUpdate, string Count, string IntimationId, string GeneratingSetCapacityType,
            string GeneratingSetCapacity, string SerialNumbrOfAcGenerator, string GeneratingSetType, string GeneratorVoltageLevel, string TypeOfPlant,
            string MakeType,
             string LastInspectionDate, string ApplicantType, string VoltageLevel, string District, string Division, string Inspectiontype,
            string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertGeneratingSetData_Existing_HavingPreviousReport");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            cmd.Parameters.AddWithValue("@Count", string.IsNullOrEmpty(Count) ? DBNull.Value : (object)Count);
            cmd.Parameters.AddWithValue("@IntimationId", string.IsNullOrEmpty(IntimationId) ? DBNull.Value : (object)IntimationId);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacityType", string.IsNullOrEmpty(GeneratingSetCapacityType) ? DBNull.Value : (object)GeneratingSetCapacityType);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacity", string.IsNullOrEmpty(GeneratingSetCapacity) ? DBNull.Value : (object)GeneratingSetCapacity);
            cmd.Parameters.AddWithValue("@SerialNumbrOfAcGenerator", string.IsNullOrEmpty(SerialNumbrOfAcGenerator) ? DBNull.Value : (object)SerialNumbrOfAcGenerator);
            cmd.Parameters.AddWithValue("@GeneratingSetType", GeneratingSetType == "Select" ? DBNull.Value : (object)GeneratingSetType);
            cmd.Parameters.AddWithValue("@GeneratorVoltageLevel", string.IsNullOrEmpty(GeneratorVoltageLevel) ? DBNull.Value : (object)GeneratorVoltageLevel);
            cmd.Parameters.AddWithValue("@TypeOfPlant", TypeOfPlant == "Select" ? DBNull.Value : (object)TypeOfPlant);
            cmd.Parameters.AddWithValue("@MakeType", MakeType);

            cmd.Parameters.AddWithValue("@LastInspectionDate", String.IsNullOrEmpty(LastInspectionDate) ? null : LastInspectionDate);
            cmd.Parameters.AddWithValue("@ApplicantType", String.IsNullOrEmpty(ApplicantType) ? null : ApplicantType);
            cmd.Parameters.AddWithValue("@VoltageLevel", String.IsNullOrEmpty(VoltageLevel) ? null : VoltageLevel);
            cmd.Parameters.AddWithValue("@District", String.IsNullOrEmpty(District) ? null : District);
            cmd.Parameters.AddWithValue("@Division", String.IsNullOrEmpty(Division) ? null : Division);
            cmd.Parameters.AddWithValue("@Inspectiontype", String.IsNullOrEmpty(Inspectiontype) ? null : Inspectiontype);

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter returnStatusParam = new SqlParameter("@ReturnStatus", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(returnStatusParam);
            cmd.ExecuteNonQuery();
            con.Close();

            Int32 returnStatus = (Int32)returnStatusParam.Value;

            return returnStatus;
        }
        public int InsertSubstationData_Existing_HavingPreviousReport(string IdUpdate, string Count, string IntimationId, string TransformerSerialNumber, string TransformerCapacityType, string TransformerCapacity, string TranformerType,
 string PrimaryVoltage, string SecondoryVoltage, string MakeType,
 string LastInspectionDate, string ApplicantType, string VoltageLevel, string District, string Division, string Inspectiontype,
 string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertSubstationTransformerData_Existing_HavingPreviousReport");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUpdate", String.IsNullOrEmpty(IdUpdate) ? null : IdUpdate);
            cmd.Parameters.AddWithValue("@Count", String.IsNullOrEmpty(Count) ? null : Count);
            cmd.Parameters.AddWithValue("@IntimationId", String.IsNullOrEmpty(IntimationId) ? null : IntimationId);
            cmd.Parameters.AddWithValue("@TransformerSerialNumber", String.IsNullOrEmpty(TransformerSerialNumber) ? null : TransformerSerialNumber);
            cmd.Parameters.AddWithValue("@TransformerCapacityType", String.IsNullOrEmpty(TransformerCapacityType) ? null : TransformerCapacityType);
            cmd.Parameters.AddWithValue("@TransformerCapacity", String.IsNullOrEmpty(TransformerCapacity) ? null : TransformerCapacity);
            cmd.Parameters.AddWithValue("@TranformerType", TranformerType == "Select" ? null : TranformerType);
            cmd.Parameters.AddWithValue("@PrimaryVoltage", PrimaryVoltage == "Select" ? null : PrimaryVoltage);
            cmd.Parameters.AddWithValue("@SecondoryVoltage", SecondoryVoltage == "Select" ? null : SecondoryVoltage);
            cmd.Parameters.AddWithValue("@MakeType", MakeType);

            cmd.Parameters.AddWithValue("@LastInspectionDate", String.IsNullOrEmpty(LastInspectionDate) ? null : LastInspectionDate);

            cmd.Parameters.AddWithValue("@ApplicantType", String.IsNullOrEmpty(ApplicantType) ? null : ApplicantType);
            cmd.Parameters.AddWithValue("@VoltageLevel", String.IsNullOrEmpty(VoltageLevel) ? null : VoltageLevel);
            cmd.Parameters.AddWithValue("@District", String.IsNullOrEmpty(District) ? null : District);
            cmd.Parameters.AddWithValue("@Division", String.IsNullOrEmpty(Division) ? null : Division);
            cmd.Parameters.AddWithValue("@Inspectiontype", String.IsNullOrEmpty(Inspectiontype) ? null : Inspectiontype);

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter returnStatusParam = new SqlParameter("@ReturnStatus", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(returnStatusParam);
            cmd.ExecuteNonQuery();
            con.Close();

            Int32 returnStatus = (Int32)returnStatusParam.Value;

            return returnStatus;
        }
        public DataSet GetddlVoltageLevelForContractorIntimation(string ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetVoltageLevelForContractorIntimation", ID);
        }

        //Newinspection clubbing
        public DataSet GetVoltageLevelForSiteownerIntimation()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetVoltageLevelForSiteownerIntimation");
        }
        public DataTable GetApplicantCode(string Installations)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationTypeId", Installations);
        }
        public DataTable DeleteduplicateHistory(string IntimationId, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDuplicacy", IntimationId, CreatedBy);
        }
        public DataTable InsertPaymentHistory(string IntimationId, int count, int InstallationTypeId, decimal Amount, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PaymentHistory", IntimationId, count, InstallationTypeId, Amount, CreatedBy);
        }
        public DataTable DeletePaymentHistory(string IntimationId, int count, int InstallationTypeId, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DeletePaymentHistory", IntimationId, count, InstallationTypeId, CreatedBy);
        }
        public DataTable GetMaxValues(string CreatedBy, string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_MaxValues", CreatedBy, IntimationId);
        }
        public DataSet GetStaffAssignedforNewInspection(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ToGetAssignedOfficerinNew", IntimationId);
        }
        public DataSet UpdateInstallationHistory(string InstallationType, string IntimationId, string CreatedBy, int TestReportCount)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateInstallationHistory", InstallationType, IntimationId, CreatedBy, TestReportCount);
        }
        public DataTable GetPaymentHistory(string CreatedBy, string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPaymentHistory", CreatedBy, IntimationId);
        }
        public DataTable GetDocumentlistfornewInspection(string ApplicantType, int InstallationTypeID, string InspectionType, string PlantLocationRoofTop, string PlantLocationGroundMounted, int inspectionIdPrm)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentsForNewMultipleInspection", ApplicantType, InstallationTypeID, InspectionType, PlantLocationRoofTop, PlantLocationGroundMounted, inspectionIdPrm);
        }
        public DataTable GetDocumentlistforContractor(int Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentforContractor", Id);
        }

        public DataSet GetDetailsToViewTRinMultipleCaseNew(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewMultipleInspectionTR", InspectionId);
        }

        public DataSet getInstallationsForNew(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getInstallationTypeForLetter", Id);
        }
       

        //public DataSet GetSiteOwnerAdress_Industries(string id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOwnerAdress_Industries", id);
        //}

        //public DataSet GetPeriodicDetails_Industries(string adress, string id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsAdressWise_Industries", adress, id);
        //}

        //public DataSet GetWorkIntimationDataAtSiteOwner_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationDataBySiteOwner_Industries", Id);
        //}

        //public void IntimationDataInsertionBySiteowner_Industries(string SiteOwnerId, string ApplicantType, string ApplicantTypeCode, string ContractorType, string PowerUtility, string PowerUtilityWing, string ZoneName,
        //                          string CircleName, string DivisionName, string SubDivisionName, string NameOfOwner, string NameOfAgency, string ContactNo,
        //                          string Address, string District, string Pincode, string PremisesType, string OtherPremises, string VoltageLevel, string PANNumber,
        //                          string TypeOfInstallation2, string NumberOfInstallation2, string TypeOfInstallation3, string NumberOfInstallation3,
        //                          string Email, string Createdby, string SanctionLoad, string InspectionType, string TotalCapacity, string SanctionLoadValue, string SiteOwnerPassword, SqlTransaction transaction)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_WorkIntimationRegistrationBySiteOwner_Industries", transaction.Connection, transaction);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.AddWithValue("@Id", Id);
        //    cmd.Parameters.AddWithValue("@SiteOwnerId", SiteOwnerId);
        //    cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
        //    cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantTypeCode);
        //    cmd.Parameters.AddWithValue("@ContractorType", String.IsNullOrEmpty(ContractorType) ? DBNull.Value : (object)ContractorType);
        //    cmd.Parameters.AddWithValue("@PowerUtility", String.IsNullOrEmpty(PowerUtility) ? DBNull.Value : (object)PowerUtility);
        //    cmd.Parameters.AddWithValue("@PowerUtilityWing", String.IsNullOrEmpty(PowerUtilityWing) ? DBNull.Value : (object)PowerUtilityWing);
        //    cmd.Parameters.AddWithValue("@ZoneName", String.IsNullOrEmpty(ZoneName) ? DBNull.Value : (object)ZoneName);
        //    cmd.Parameters.AddWithValue("@CircleName", String.IsNullOrEmpty(CircleName) ? DBNull.Value : (object)CircleName);
        //    cmd.Parameters.AddWithValue("@DivisionName", String.IsNullOrEmpty(DivisionName) ? DBNull.Value : (object)DivisionName);
        //    cmd.Parameters.AddWithValue("@SubDivisionName", String.IsNullOrEmpty(SubDivisionName) ? DBNull.Value : (object)SubDivisionName);
        //    cmd.Parameters.AddWithValue("@NameOfOwner", String.IsNullOrEmpty(NameOfOwner) ? DBNull.Value : (object)NameOfOwner);
        //    cmd.Parameters.AddWithValue("@NameOfAgency", String.IsNullOrEmpty(NameOfAgency) ? DBNull.Value : (object)NameOfAgency);
        //    cmd.Parameters.AddWithValue("@ContactNo", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
        //    cmd.Parameters.AddWithValue("@Address", String.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
        //    cmd.Parameters.AddWithValue("@District", District == "Select" ? DBNull.Value : (object)District);
        //    cmd.Parameters.AddWithValue("@Pincode", String.IsNullOrEmpty(Pincode) ? DBNull.Value : (object)Pincode);
        //    cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
        //    cmd.Parameters.AddWithValue("@OtherPremises", String.IsNullOrEmpty(OtherPremises) ? DBNull.Value : (object)OtherPremises);
        //    cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
        //    cmd.Parameters.AddWithValue("@PANNumber", String.IsNullOrEmpty(PANNumber) ? DBNull.Value : (object)PANNumber);
        //    cmd.Parameters.AddWithValue("@TypeOfInstallation2", String.IsNullOrEmpty(TypeOfInstallation2) ? DBNull.Value : (object)TypeOfInstallation2);
        //    cmd.Parameters.AddWithValue("@NumberOfInstallation2", String.IsNullOrEmpty(NumberOfInstallation2) ? DBNull.Value : (object)NumberOfInstallation2);
        //    cmd.Parameters.AddWithValue("@TypeOfInstallation3", String.IsNullOrEmpty(TypeOfInstallation3) ? DBNull.Value : (object)TypeOfInstallation3);
        //    cmd.Parameters.AddWithValue("@NumberOfInstallation3", String.IsNullOrEmpty(NumberOfInstallation3) ? DBNull.Value : (object)NumberOfInstallation3);
        //    cmd.Parameters.AddWithValue("@Email", String.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
        //    cmd.Parameters.AddWithValue("@Createdby", String.IsNullOrEmpty(Createdby) ? DBNull.Value : (object)Createdby);
        //    cmd.Parameters.AddWithValue("@SanctionLoad", String.IsNullOrEmpty(SanctionLoad) ? DBNull.Value : (object)SanctionLoad);
        //    cmd.Parameters.AddWithValue("@InspectionType", String.IsNullOrEmpty(InspectionType) ? DBNull.Value : (object)InspectionType);
        //    cmd.Parameters.AddWithValue("@TotalCapacity", String.IsNullOrEmpty(TotalCapacity) ? DBNull.Value : (object)TotalCapacity);
        //    cmd.Parameters.AddWithValue("@SanctionLoadValue", String.IsNullOrEmpty(SanctionLoadValue) ? DBNull.Value : (object)SanctionLoadValue);
        //    cmd.Parameters.AddWithValue("@SiteOwnerPassword", String.IsNullOrEmpty(SiteOwnerPassword) ? DBNull.Value : (object)SiteOwnerPassword);

        //    outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
        //    outputParam.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(outputParam);
        //    cmd.ExecuteNonQuery();

        //    string registrationId = outputParam.Value.ToString();

        //}


        //public void AddInstallationsCreatedbySiteOwner_Industries(string IntimationId, string Typeofinstallation, int Noofinstallation, string CreatedBy, string TypeOfInspection, SqlTransaction transaction)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_InstallationsCountCreatedbySiteOwner_Industries", transaction.Connection, transaction);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
        //        cmd.Parameters.AddWithValue("@Typeofinstallation", Typeofinstallation);
        //        cmd.Parameters.AddWithValue("@Noofinstallation", Noofinstallation);
        //        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        //        cmd.Parameters.AddWithValue("@InspectionType", TypeOfInspection);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    { }
        //}


        //public DataSet GetddlDistrict_Industries()
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AreaCovered_Industries");
        //}

        //public DataSet GetddlPremises_Industries()
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Premises_Industries");
        //}

        public DataSet GetVoltageLevelForSiteownerIntimation_Industries()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetVoltageLevelForSiteownerIntimation_Industries");
        }

        public void InsertInspectionRenewalData_Industries(string IntimationId, string InspectionId, string InstallationType, string InstallationName,
string TestReportId, string TestReportCount, string InspectionDate, string InspectionDueDate,/* string DelayedDays,*/ string Voltage, string Capacity, string Address, string CompleteAdress,
string AdressDistrict, string OwnerName, string District, string Division, string CreatedBy, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertInspectionRenewalData_Industries", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@InspectionId", InspectionId);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@InstallationName", InstallationName);
                        cmd.Parameters.AddWithValue("@TestReportId", TestReportId);
                        cmd.Parameters.AddWithValue("@TestReportCount", TestReportCount);
                        cmd.Parameters.AddWithValue("@InspectionDate", String.IsNullOrEmpty(InspectionDate) ? DBNull.Value : (object)InspectionDate);
                        cmd.Parameters.AddWithValue("@InspectionDueDate", String.IsNullOrEmpty(InspectionDueDate) ? DBNull.Value : (object)InspectionDueDate);
                        //cmd.Parameters.AddWithValue("@InspectionDueDate", InspectionDueDate);
                        //cmd.Parameters.AddWithValue("@DelayedDays", DelayedDays);
                        cmd.Parameters.AddWithValue("@Voltage", Voltage);
                        if (string.IsNullOrWhiteSpace(Capacity))
                        {
                            cmd.Parameters.AddWithValue("@Capacity", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Capacity", Capacity);
                        }
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@CompleteAdress", CompleteAdress);
                        cmd.Parameters.AddWithValue("@AdressDistrict", AdressDistrict);
                        cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Division", Division);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        //public DataSet GetAddressToFilterCart_Industries(string CreatedBy)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressTofilterCart_Industries", CreatedBy);
        //}

        //public DataSet ShowDataToCart_Industries(string address, string CartID)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_GetCartData_Industries", address, CartID);
        //}


        //public DataTable Payment_Industries(string intimationId, string count, string installationtypeId, string InspectionType)
        //{
        //    DataTable result = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_Industries", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@IntimationId", intimationId);
        //        command.Parameters.AddWithValue("@Count", count);
        //        command.Parameters.AddWithValue("@InspectionType", InspectionType);
        //        command.Parameters.AddWithValue("@InstallationTypeID", installationtypeId);

        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(result);
        //    }

        //    return result;
        //}

        //public DataSet ToRemoveDataCart_Industries(int InspectionId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_ToRemoveDataFromCart_Industries", InspectionId);
        //}


        //public DataSet ToGetDatafromCart_Industries(string address, string CartId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ToGetDatafromCart_Industries", address, CartId);
        //}


        //public DataSet GetStaffAssigned_Industries(string CartId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ToGetAssignedOfficer_Industries", CartId);
        //}


        //public DataSet ToGetStaffIdforPeriodic_Industries(string Division, string Staff, string District)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffIdforPeriodic_Industries", Division, Staff, District);
        //}


        //public static int GetAffectedRowsCountByCartId_Industries(string cartId)
        //{
        //    int count = 0;

        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Sp_CheckRowAffected_Industries", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@CartId", cartId);
        //            con.Open();
        //            count = (int)cmd.ExecuteScalar();
        //        }
        //    }

        //    return count;
        //}

        //public DataSet GetDataForSingleInspection_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDataForSingleInspection_Industries", Id);
        //}


//        public void InsertInspectinData_Industries(string CartId, string TotalCapacity, string MaxVoltage, string InstallationType, string TestRportId,
//string IntimationId, string VoltageLevel, string ApplicantType, string District, string Division, string AssignTo, string PaymentMode, int TotalAmount, int status, string CreatedBy)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand("sp_InsertintoTempTable_Industries", con))
//                    {
//                        cmd.CommandType = CommandType.StoredProcedure;
//                        //cmd.Parameters.AddWithValue("@Id", Id);
//                        cmd.Parameters.AddWithValue("@CartId", CartId);
//                        cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
//                        cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
//                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
//                        cmd.Parameters.AddWithValue("@TestRportId", TestRportId);
//                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
//                        cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
//                        cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
//                        cmd.Parameters.AddWithValue("@District", District);
//                        cmd.Parameters.AddWithValue("@Division", Division);
//                        cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
//                        //cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
//                        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
//                        cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
//                        cmd.Parameters.AddWithValue("@status", status);
//                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
//                        //cmd.Parameters.AddWithValue("@Status", Status);
//                        con.Open();
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {

//            }
//        }


        //public DataTable WorkIntimationDataforSiteOwner_Industries(string Id, string searchText = null)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsDetailsForSiteOwner_Industries", Id, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        //}


        //public DataTable InstallationDataforSiteOwner_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationDetails_Industries", Id);
        //}


        public DataSet GetIntimationDetails_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationDetails_Industries", Id);
        }


        public int InsertGeneratingSetData_Existing_HavingPreviousReport_Industries(string IdUpdate, string Count, string IntimationId, string GeneratingSetCapacityType,
     string GeneratingSetCapacity, string SerialNumbrOfAcGenerator, string GeneratingSetType, string GeneratorVoltageLevel, string TypeOfPlant,
     string MakeType,
      string LastInspectionDate, string ApplicantType, string VoltageLevel, string District, string Division, string Inspectiontype,
     string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertGeneratingSetData_Existing_HavingPreviousReport_Industries");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            cmd.Parameters.AddWithValue("@Count", string.IsNullOrEmpty(Count) ? DBNull.Value : (object)Count);
            cmd.Parameters.AddWithValue("@IntimationId", string.IsNullOrEmpty(IntimationId) ? DBNull.Value : (object)IntimationId);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacityType", string.IsNullOrEmpty(GeneratingSetCapacityType) ? DBNull.Value : (object)GeneratingSetCapacityType);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacity", string.IsNullOrEmpty(GeneratingSetCapacity) ? DBNull.Value : (object)GeneratingSetCapacity);
            cmd.Parameters.AddWithValue("@SerialNumbrOfAcGenerator", string.IsNullOrEmpty(SerialNumbrOfAcGenerator) ? DBNull.Value : (object)SerialNumbrOfAcGenerator);
            cmd.Parameters.AddWithValue("@GeneratingSetType", GeneratingSetType == "Select" ? DBNull.Value : (object)GeneratingSetType);
            cmd.Parameters.AddWithValue("@GeneratorVoltageLevel", string.IsNullOrEmpty(GeneratorVoltageLevel) ? DBNull.Value : (object)GeneratorVoltageLevel);
            cmd.Parameters.AddWithValue("@TypeOfPlant", TypeOfPlant == "Select" ? DBNull.Value : (object)TypeOfPlant);
            cmd.Parameters.AddWithValue("@MakeType", MakeType);

            cmd.Parameters.AddWithValue("@LastInspectionDate", String.IsNullOrEmpty(LastInspectionDate) ? null : LastInspectionDate);
            cmd.Parameters.AddWithValue("@ApplicantType", String.IsNullOrEmpty(ApplicantType) ? null : ApplicantType);
            cmd.Parameters.AddWithValue("@VoltageLevel", String.IsNullOrEmpty(VoltageLevel) ? null : VoltageLevel);
            cmd.Parameters.AddWithValue("@District", String.IsNullOrEmpty(District) ? null : District);
            cmd.Parameters.AddWithValue("@Division", String.IsNullOrEmpty(Division) ? null : Division);
            cmd.Parameters.AddWithValue("@Inspectiontype", String.IsNullOrEmpty(Inspectiontype) ? null : Inspectiontype);

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter returnStatusParam = new SqlParameter("@ReturnStatus", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(returnStatusParam);
            cmd.ExecuteNonQuery();
            con.Close();

            Int32 returnStatus = (Int32)returnStatusParam.Value;

            return returnStatus;
        }



        //public void UpdateInstallations_Industries(string Id, string IntimationId)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_CheckTestReportHistory_Industries");
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //    cmd.Connection = con;
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //        con.Open();
        //    }

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Id ", Id);
        //    cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}


        //public DataSet GetddlPrimaryVotlage_Industries(string Volts)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PrimaryVoltage_Industries", Volts);
        //}


        //public DataSet GetddlSecondaryVotlage_Industries(string Volts)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SecondryVoltage_Industries", Volts);
        //}

        public int InsertSubstationData_Existing_HavingPreviousReport_Industries(string IdUpdate, string Count, string IntimationId, string TransformerSerialNumber, string TransformerCapacityType, string TransformerCapacity, string TranformerType,
string PrimaryVoltage, string SecondoryVoltage, string MakeType,
string LastInspectionDate, string ApplicantType, string VoltageLevel, string District, string Division, string Inspectiontype,
string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertSubstationTransformerData_Existing_HavingPreviousReport_Industries");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUpdate", String.IsNullOrEmpty(IdUpdate) ? null : IdUpdate);
            cmd.Parameters.AddWithValue("@Count", String.IsNullOrEmpty(Count) ? null : Count);
            cmd.Parameters.AddWithValue("@IntimationId", String.IsNullOrEmpty(IntimationId) ? null : IntimationId);
            cmd.Parameters.AddWithValue("@TransformerSerialNumber", String.IsNullOrEmpty(TransformerSerialNumber) ? null : TransformerSerialNumber);
            cmd.Parameters.AddWithValue("@TransformerCapacityType", String.IsNullOrEmpty(TransformerCapacityType) ? null : TransformerCapacityType);
            cmd.Parameters.AddWithValue("@TransformerCapacity", String.IsNullOrEmpty(TransformerCapacity) ? null : TransformerCapacity);
            cmd.Parameters.AddWithValue("@TranformerType", TranformerType == "Select" ? null : TranformerType);
            cmd.Parameters.AddWithValue("@PrimaryVoltage", PrimaryVoltage == "Select" ? null : PrimaryVoltage);
            cmd.Parameters.AddWithValue("@SecondoryVoltage", SecondoryVoltage == "Select" ? null : SecondoryVoltage);
            cmd.Parameters.AddWithValue("@MakeType", MakeType);

            cmd.Parameters.AddWithValue("@LastInspectionDate", String.IsNullOrEmpty(LastInspectionDate) ? null : LastInspectionDate);

            cmd.Parameters.AddWithValue("@ApplicantType", String.IsNullOrEmpty(ApplicantType) ? null : ApplicantType);
            cmd.Parameters.AddWithValue("@VoltageLevel", String.IsNullOrEmpty(VoltageLevel) ? null : VoltageLevel);
            cmd.Parameters.AddWithValue("@District", String.IsNullOrEmpty(District) ? null : District);
            cmd.Parameters.AddWithValue("@Division", String.IsNullOrEmpty(Division) ? null : Division);
            cmd.Parameters.AddWithValue("@Inspectiontype", String.IsNullOrEmpty(Inspectiontype) ? null : Inspectiontype);

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter returnStatusParam = new SqlParameter("@ReturnStatus", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(returnStatusParam);
            cmd.ExecuteNonQuery();
            con.Close();

            Int32 returnStatus = (Int32)returnStatusParam.Value;

            return returnStatus;
        }


        //public DataSet GetPeriodicType_Industries(string CartId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicType_Industries", CartId);
        //}

        //public DataSet GetDocumentforPeriodic_Industries(string CartId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentforPeriodic_Industries", CartId);
        //}

        //public DataSet GetPeriodicdataAfterCart_Industries(string CartId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicdataAfterCart_Industries", CartId);
        //}

        public string InsertPeriodicInspectionData_Industries(string TypeOfInspection, string CartId, string IntimationId, string ApplicantType,
string InstallationType, string VoltageLevel, string District, string Division,
string AssignTo, string PaymentMode, string TotalAmount, string TransactionId, string TransctionDate,
string CreatedBy, string TotalCapacity, string MaxVoltage, int InspectID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeriodicInspectionData_Industries", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfInspection", TypeOfInspection);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                    cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                    cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                    cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@Division", Division);
                    cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                    cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
                    cmd.Parameters.AddWithValue("@TransctionDate", TransctionDate);
                    cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
                    cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                    cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);

                    cmd.Parameters.AddWithValue("@InspectID", InspectID);
                    outputParam = new SqlParameter("@Ret_InspectionID", SqlDbType.NVarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string RetVal = cmd.Parameters["@Ret_InspectionID"].Value.ToString();
                    cmd.Parameters.Clear();
                    return RetVal;
                }

            }
        }


        public DataTable SiteOwnerInspectionData_Industries(string SiteOwnerId, string searchText = null)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistory_Industries", SiteOwnerId, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }

        //public DataSet InspectionData_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData_Industries", Id);
        //}


        //public DataSet GetDetailsToViewCart_Industries(string InspectionId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCart_Industries", InspectionId);
        //}


        //public DataSet ViewDocuments_Industries(string InspectionId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDocuments_Industries", InspectionId);
        //}

        //public DataSet GetTestReport_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Industries", Id);
        //}


        //public DataSet GetTestReportDataIfPeriodic_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodic_Industries", Id);
        //}

        //public DataSet ContractorRemarks_Industries(string ID, string TestRportId, string RemarkForContractor)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertRemarksForContractor_Industries", ID, TestRportId, RemarkForContractor);
        //}

        //public DataSet DetailstoPrintFormInspectionDetails_Industries(int ID)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDetailsforPrintForm_Industries", ID);
        //}

        //public DataSet GetAttachmentsDatainInspectionForm_Industries(string InspectionId)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachmentsinInspectionForm_Industries", InspectionId);
        //}


        //public DataSet PrintApprovalLetter_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApprovalCertificateForPreodic_Industries", Id);
        //}

        //public DataSet getInstallations_Industries(string Id)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getInstallationTypeForLetter_Industries", Id);
        //}

        public DataSet checkDistrict(string PanNumber, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDistrictSld_Industy", PanNumber, District);
        }

        public DataSet GetOwnerAdressForIndustry(string PANNumber, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getSiteAddressForIndustry", PANNumber, District);
        }


        //public DataSet UploadSldDocument(string SiteOwnerID, string Path, string Createdby, string SiteOwnerAddress, string OwnerName, string UserType, string District)
        //{
        //    return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_InsertSdlData", SiteOwnerID, Path, Createdby, SiteOwnerAddress, OwnerName, UserType, District);
        //}
        public DataTable SldHistory(string SiteOwnerId, string searchText = null)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ApproveSdlHistory", SiteOwnerId, String.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
        public DataTable SldHistoryForCei(string Id, string searchText = null)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ApproveSdlHistoryForAdmin", Id, String.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
        //neeraj induatry
        public DataSet checkInspection(string PanNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckInspection", PanNumber);
        }

 
        public DataSet TestReportData_Industry(string PANNumber, string District, string searchText = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSiteOwner_Industry", PANNumber, District, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
   
        public DataTable GetApplicantCodeIndustry(string Installations)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationTypeId_Industry", Installations);
        }
 
        public DataTable DeleteduplicateHistoryIndustry(string IntimationId, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDuplicacy_Industry", IntimationId, CreatedBy);
        }

        public DataTable Payment_Industry(string intimationId, string count, string installationtypeId, string InspectionType)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_Industry", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IntimationId", intimationId);
                command.Parameters.AddWithValue("@Count", count);
                command.Parameters.AddWithValue("@InspectionType", InspectionType);
                command.Parameters.AddWithValue("@InstallationTypeID", installationtypeId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }

        public DataTable InsertPaymentHistoryIndustry(string IntimationId, int count, int InstallationTypeId, decimal Amount, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PaymentHistory_Industrty", IntimationId, count, InstallationTypeId, Amount, CreatedBy);
        }
   
      public DataTable DeletePaymentHistoryIndustry(string IntimationId, int count, int InstallationTypeId, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DeletePaymentHistory_Industry", IntimationId, count, InstallationTypeId, CreatedBy);
        }
   
    public DataTable GetMaxValuesIndustry(string CreatedBy, string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_MaxValues_Industry", CreatedBy, IntimationId);
        }

 
   public DataSet GetStaffAssignedforNewInspectionIndustry(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ToGetAssignedOfficerinNew_Industry", IntimationId);
        }

   public DataSet ToGetStaffIdforPeriodicIndustry(string Division, string Staff, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffIdforPeriodic_Industry", Division, Staff, District);
        }

 
        public DataSet SiteOwnerInstallations_Industry(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationForSiteOwner_Industry", IntimationId);
        }



        public void InsertInspectionDataNewCodeIndustry(string InstallationTypeID, string ContactNo, string ApplicantTypeCode, string IntimationId, string Inspectiontype, string ApplicantType, string InstallationType,
        string VoltageLevel, string District, string Division, string PaymentMode, string DateOfSubmission, string InspectionRemarks, string CreatedBy,
        decimal TotalAmount, string para_Assigned, string transcationId, string TranscationDate, string ChallanAttachment, int InspectID, string KVA, string DemandNotice, int TotalCapacity, int MaxVoltage, int ServiceType, SqlTransaction transaction
)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionData_NewCodeForMultiple_Industry", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InstallationTypeID ", InstallationTypeID);

            cmd.Parameters.AddWithValue("@ContactNo ", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);

            //cmd.Parameters.AddWithValue("@TestRportId ", TestRportId);

            cmd.Parameters.AddWithValue("@ApplicantTypeCode ", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel ", VoltageLevel);

            //cmd.Parameters.AddWithValue("@LineLength ", String.IsNullOrEmpty(LineLength) ? DBNull.Value : (object)LineLength);
            //cmd.Parameters.AddWithValue("@TestReportCount ", TestReportCount);

            cmd.Parameters.AddWithValue("@District ", District);
            cmd.Parameters.AddWithValue("@Division ", Division);
            cmd.Parameters.AddWithValue("@PaymentMode ", PaymentMode);//
            DateTime SubmitionDate;
            if (DateTime.TryParse(DateOfSubmission, out SubmitionDate) && SubmitionDate != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", SubmitionDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateOfSubmission", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@InspectionRemarks ", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.Parameters.AddWithValue("@TransactionId ", transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@AssignTo", para_Assigned);
            cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            cmd.Parameters.AddWithValue("@ChallanAttachment", null);
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@SactionVoltage", KVA);
            cmd.Parameters.AddWithValue("@DemandDocument", DemandNotice);
            cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
            cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
            //outputParam = new SqlParameter("@GeneratedId", SqlDbType.NVarChar, 50);
            outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
        }

        public DataSet UpdateInstallationHistoryIndustry(string InstallationType, string IntimationId, string CreatedBy, int TestReportCount)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateInstallationHistoryForIndustry", InstallationType, IntimationId, CreatedBy, TestReportCount);
        }   
        public DataTable GetPaymentHistoryIndustry(string CreatedBy, string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPaymentHistory_Industry", CreatedBy, IntimationId);
        }
        public DataTable GetDocumentlistfornewInspectionIndustry(string ApplicantType, int InstallationTypeID, string InspectionType, string PlantLocationRoofTop, string PlantLocationGroundMounted, int inspectionIdPrm)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentsForNewMultipleInspection_Industry", ApplicantType, InstallationTypeID, InspectionType, PlantLocationRoofTop, PlantLocationGroundMounted, inspectionIdPrm);
        }

 
        public DataSet GetAttachmentsDatainInspectionForm(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachmentsinInspectionForm", InspectionId);
        }
 
        public DataSet DetailstoPrintFormInspectionDetails(int ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDetailsforPrintForm", ID);
        }

 
        public DataSet SiteOwnerInstallationsHistory_Industry(string IntimationId, string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationHistoryForSiteOwner_Industry", IntimationId, InspectionId);
        }
        public DataSet InspectionDataForIndustry(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData_Industry", Id);
        }
                    

        //ASLAM iNDUSTRY 4nOV
      

        public DataSet GetSiteOwnerAdress_Industries(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOwnerAdress_Industries", id);
        }


        public DataSet GetPeriodicDetails_Industries(string adress, string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsAdressWise_Industries", adress, id);
        }

        public DataSet ExistingInspectionData_Industry(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetExistingInspectionsForIndustry", PANNumber);
        }



        public void InsertInspectionRenewalData_Industries(string IntimationId, int InspectionId, string InstallationType, string InstallationName,
string TestReportId, string TestReportCount, string InspectionDate, string InspectionDueDate, string DelayedDays, string Voltage, string Capacity, string Address, string CompleteAdress,
string AdressDistrict, string OwnerName, string District, string Division, string CreatedBy, string Status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertInspectionRenewalData_Industries", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@InspectionId", InspectionId);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@InstallationName", InstallationName);
                        cmd.Parameters.AddWithValue("@TestReportId", TestReportId);
                        cmd.Parameters.AddWithValue("@TestReportCount", TestReportCount);
                        cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                        cmd.Parameters.AddWithValue("@InspectionDueDate", InspectionDueDate);
                        cmd.Parameters.AddWithValue("@DelayedDays", DelayedDays);
                        cmd.Parameters.AddWithValue("@Voltage", Voltage);
                        if (string.IsNullOrWhiteSpace(Capacity))
                        {
                            cmd.Parameters.AddWithValue("@Capacity", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Capacity", Capacity);
                        }
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@CompleteAdress", CompleteAdress);
                        cmd.Parameters.AddWithValue("@AdressDistrict", AdressDistrict);
                        cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Division", Division);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        public DataSet GetddlPremises_Industries()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Premises_Industries");
        }

        public DataSet GetddlDistrict_Industries()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AreaCovered_Industries");
        }

        public DataSet GetWorkIntimationDataAtSiteOwner_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationDataBySiteOwner_Industries", Id);
        }


        public void IntimationDataInsertionBySiteowner_Industries(string SiteOwnerId, string ApplicantType, string ApplicantTypeCode, string ContractorType, string PowerUtility, string PowerUtilityWing, string ZoneName,
                                  string CircleName, string DivisionName, string SubDivisionName, string NameOfOwner, string NameOfAgency, string ContactNo,
                                  string Address, string District, string Pincode, string PremisesType, string OtherPremises, string VoltageLevel, string PANNumber,
                                  string TypeOfInstallation2, string NumberOfInstallation2, string TypeOfInstallation3, string NumberOfInstallation3,
                                  string Email, string Createdby, string SanctionLoad, string InspectionType, string TotalCapacity, string SanctionLoadValue, string SiteOwnerPassword, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_WorkIntimationRegistrationBySiteOwner_Industries", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@SiteOwnerId", SiteOwnerId);
            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@ContractorType", String.IsNullOrEmpty(ContractorType) ? DBNull.Value : (object)ContractorType);
            cmd.Parameters.AddWithValue("@PowerUtility", String.IsNullOrEmpty(PowerUtility) ? DBNull.Value : (object)PowerUtility);
            cmd.Parameters.AddWithValue("@PowerUtilityWing", String.IsNullOrEmpty(PowerUtilityWing) ? DBNull.Value : (object)PowerUtilityWing);
            cmd.Parameters.AddWithValue("@ZoneName", String.IsNullOrEmpty(ZoneName) ? DBNull.Value : (object)ZoneName);
            cmd.Parameters.AddWithValue("@CircleName", String.IsNullOrEmpty(CircleName) ? DBNull.Value : (object)CircleName);
            cmd.Parameters.AddWithValue("@DivisionName", String.IsNullOrEmpty(DivisionName) ? DBNull.Value : (object)DivisionName);
            cmd.Parameters.AddWithValue("@SubDivisionName", String.IsNullOrEmpty(SubDivisionName) ? DBNull.Value : (object)SubDivisionName);
            cmd.Parameters.AddWithValue("@NameOfOwner", String.IsNullOrEmpty(NameOfOwner) ? DBNull.Value : (object)NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", String.IsNullOrEmpty(NameOfAgency) ? DBNull.Value : (object)NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@Address", String.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
            cmd.Parameters.AddWithValue("@District", District == "Select" ? DBNull.Value : (object)District);
            cmd.Parameters.AddWithValue("@Pincode", String.IsNullOrEmpty(Pincode) ? DBNull.Value : (object)Pincode);
            cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
            cmd.Parameters.AddWithValue("@OtherPremises", String.IsNullOrEmpty(OtherPremises) ? DBNull.Value : (object)OtherPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@PANNumber", String.IsNullOrEmpty(PANNumber) ? DBNull.Value : (object)PANNumber);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", String.IsNullOrEmpty(TypeOfInstallation2) ? DBNull.Value : (object)TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@NumberOfInstallation2", String.IsNullOrEmpty(NumberOfInstallation2) ? DBNull.Value : (object)NumberOfInstallation2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", String.IsNullOrEmpty(TypeOfInstallation3) ? DBNull.Value : (object)TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@NumberOfInstallation3", String.IsNullOrEmpty(NumberOfInstallation3) ? DBNull.Value : (object)NumberOfInstallation3);
            cmd.Parameters.AddWithValue("@Email", String.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
            cmd.Parameters.AddWithValue("@Createdby", String.IsNullOrEmpty(Createdby) ? DBNull.Value : (object)Createdby);
            cmd.Parameters.AddWithValue("@SanctionLoad", String.IsNullOrEmpty(SanctionLoad) ? DBNull.Value : (object)SanctionLoad);
            cmd.Parameters.AddWithValue("@InspectionType", String.IsNullOrEmpty(InspectionType) ? DBNull.Value : (object)InspectionType);
            cmd.Parameters.AddWithValue("@TotalCapacity", String.IsNullOrEmpty(TotalCapacity) ? DBNull.Value : (object)TotalCapacity);
            cmd.Parameters.AddWithValue("@SanctionLoadValue", String.IsNullOrEmpty(SanctionLoadValue) ? DBNull.Value : (object)SanctionLoadValue);
            cmd.Parameters.AddWithValue("@SiteOwnerPassword", String.IsNullOrEmpty(SiteOwnerPassword) ? DBNull.Value : (object)SiteOwnerPassword);

            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

            string registrationId = outputParam.Value.ToString();

        }


        public void AddInstallationsCreatedbySiteOwner_Industries(string IntimationId, string Typeofinstallation, int Noofinstallation, string CreatedBy, string TypeOfInspection, SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InstallationsCountCreatedbySiteOwner_Industries", transaction.Connection, transaction);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                cmd.Parameters.AddWithValue("@Typeofinstallation", Typeofinstallation);
                cmd.Parameters.AddWithValue("@Noofinstallation", Noofinstallation);
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.Parameters.AddWithValue("@InspectionType", TypeOfInspection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
        }

        public DataSet GetPeriodicRenualDataAtSiteOwner_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDataForPeriodicRenewal_Industry", Id);
        }
        public DataSet SiteOwnerExistingInstallations_Industries(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationforExistingInspection_Industries", IntimationId);
        }


        public DataSet GetData_Industries(string Inspectiontype, string IntimationId, string Count)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDataForInspection_Industries", Inspectiontype, IntimationId, Count);
        }


        public void InsertExistingInspectionData_Industries(string TestReportId, string IntimationId, string TestReportCount, string ApplicantType, string InstallationType, string VoltageLevel,
string District, string Division, string InspectionType, string CreatedBy,
string ApprovedDate, string ApproximateYears, string InspectionNewOrExist, string PreviousInspection)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_InsertExistingInspection_Industries";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TestRportId", TestReportId);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.Parameters.AddWithValue("@TestReportCount", TestReportCount);
            cmd.Parameters.AddWithValue("@ApplicantType", String.IsNullOrEmpty(ApplicantType) ? DBNull.Value : (object)ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Division", Division);
            cmd.Parameters.AddWithValue("@Inspectiontype", InspectionType);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@ApprovedDate", String.IsNullOrEmpty(ApprovedDate) ? DBNull.Value : (object)ApprovedDate);
            cmd.Parameters.AddWithValue("@ApproximateYears", ApproximateYears);
            cmd.Parameters.AddWithValue("@InspectionNewOrExist", InspectionNewOrExist);
            cmd.Parameters.AddWithValue("@PreviousInspectionDate", PreviousInspection);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataSet GetAddressToFilterCart_Industries(string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAdressTofilterCart_Industries", CreatedBy);
        }

        public DataSet ShowDataToCart_Industries(string address, string CartID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_GetCartData_Industries", address, CartID);
        }


        public DataTable Payment_Industries(string intimationId, string count, string installationtypeId, string InspectionType)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_Industries", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IntimationId", intimationId);
                command.Parameters.AddWithValue("@Count", count);
                command.Parameters.AddWithValue("@InspectionType", InspectionType);
                command.Parameters.AddWithValue("@InstallationTypeID", installationtypeId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }


        public DataSet ToRemoveDataCart_Industries(int InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_ToRemoveDataFromCart_Industries", InspectionId);
        }


        public DataSet ToGetDatafromCart_Industries(string address, string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ToGetDatafromCart_Industries", address, CartId);
        }


        public DataSet GetStaffAssigned_Industries(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ToGetAssignedOfficer_Industries", CartId);
        }


        public DataSet ToGetStaffIdforPeriodic_Industries(string Division, string Staff, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffIdforPeriodic_Industries", Division, Staff, District);
        }


        public DataSet GetDataForSingleInspection_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDataForSingleInspection_Industries", Id);
        }


        public void InsertInspectinData_Industries(string CartId, string TotalCapacity, string MaxVoltage, string InstallationType, string TestRportId,
string IntimationId, string VoltageLevel, string ApplicantType, string District, string Division, string AssignTo, string PaymentMode, int TotalAmount, int status, string CreatedBy)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertintoTempTable_Industries", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CartId", CartId);
                        cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                        cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@TestRportId", TestRportId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                        cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Division", Division);
                        cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                        //cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
                        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                        cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        //cmd.Parameters.AddWithValue("@Status", Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        public static int GetAffectedRowsCountByCartId_Industries(string cartId)
        {
            int count = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_CheckRowAffected_Industries", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    con.Open();
                    count = (int)cmd.ExecuteScalar();
                }
            }

            return count;
        }

        public DataSet GetPeriodicType_Industries(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicType_Industries", CartId);
        }

        public DataSet GetPeriodicdataAfterCart_Industries(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicdataAfterCart_Industries", CartId);
        }

        public DataSet GetDocumentforPeriodic_Industries(string CartId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentforPeriodic_Industries", CartId);
        }


        public string InsertPeriodicInspectionData_Industries(string TypeOfInspection, string CartId, string IntimationId, string ApplicantType,
        string InstallationType, string VoltageLevel, string District, string Division,
        string AssignTo, string PaymentMode, string TotalAmount, string TransactionId, string TransctionDate,
        string CreatedBy, string TotalCapacity, string MaxVoltage, int InspectID, SqlTransaction transaction)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeriodicInspectionData_Industries", transaction.Connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfInspection", TypeOfInspection);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                    cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                    cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                    cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@Division", Division);
                    cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                    cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
                    cmd.Parameters.AddWithValue("@TransctionDate", TransctionDate);
                    cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
                    cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                    cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);

                    cmd.Parameters.AddWithValue("@InspectID", InspectID);
                    outputParam = new SqlParameter("@Ret_InspectionID", SqlDbType.NVarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string RetVal = cmd.Parameters["@Ret_InspectionID"].Value.ToString();
                    cmd.Parameters.Clear();
                    return RetVal;
                }

            }
        }



        public DataTable SiteOwnerInspectionData_Industries(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistory_Industries", SiteOwnerId);
        }


        public DataSet GetTestReportDataIfPeriodic_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodic_Industries", Id);
        }

        public DataSet InspectionData_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData_Industries", Id);
        }

        public DataSet GetDetailsToViewCart_Industries(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCart_Industries", InspectionId);
        }

        public DataSet ViewDocuments_Industries(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDocuments_Industries", InspectionId);
        }

        public DataSet GetTestReport_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Industries", Id);
        }

        public DataSet ContractorRemarks_Industries(string ID, string TestRportId, string RemarkForContractor)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertRemarksForContractor_Industries", ID, TestRportId, RemarkForContractor);
        }


        public DataSet ContractorRemarksInPeriodic_Industries(string ID, string RemarkForContractor)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertRemarksForContractorINPeriodic_Industries", ID, RemarkForContractor);
        }       

        public DataSet GetAttachmentsDatainInspectionForm_Industries(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachmentsinInspectionForm_Industries", InspectionId);
        }
        public DataSet DetailstoPrintFormInspectionDetails_Industries(int ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDetailsforPrintForm_Industries", ID);
        }

        public DataSet PrintApprovalLetter_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApprovalCertificateForPreodic_Industries", Id);
        }

        public DataSet getInstallations_Industries(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getInstallationTypeForLetter_Industries", Id);
        }

        public DataTable WorkIntimationDataforSiteOwner_Industries(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsDetailsForSiteOwner_Industries", Id);
        }


        public DataTable InstallationDataforSiteOwner_Industries(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationDetails_Industries", Id);
        }

        public DataSet GetddlPrimaryVotlage_Industries(string Volts)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PrimaryVoltage_Industries", Volts);
        }

        public DataSet GetddlSecondaryVotlage_Industries(string Volts)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SecondryVoltage_Industries", Volts);
        }

        public int InsertSubstationData_Existing_HavingPreviousReport_Industries(string IdUpdate, string Count, string IntimationId, string TransformerSerialNumber, string TransformerCapacityType, string TransformerCapacity, string TranformerType,
string PrimaryVoltage, string SecondoryVoltage, string MakeType, string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertSubstationTransformerData_Existing_HavingPreviousReport_Industries");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUpdate", String.IsNullOrEmpty(IdUpdate) ? null : IdUpdate);
            cmd.Parameters.AddWithValue("@Count", String.IsNullOrEmpty(Count) ? null : Count);
            cmd.Parameters.AddWithValue("@IntimationId", String.IsNullOrEmpty(IntimationId) ? null : IntimationId);
            cmd.Parameters.AddWithValue("@TransformerSerialNumber", String.IsNullOrEmpty(TransformerSerialNumber) ? null : TransformerSerialNumber);
            cmd.Parameters.AddWithValue("@TransformerCapacityType", String.IsNullOrEmpty(TransformerCapacityType) ? null : TransformerCapacityType);
            cmd.Parameters.AddWithValue("@TransformerCapacity", String.IsNullOrEmpty(TransformerCapacity) ? null : TransformerCapacity);
            cmd.Parameters.AddWithValue("@TranformerType", TranformerType == "Select" ? null : TranformerType);
            cmd.Parameters.AddWithValue("@PrimaryVoltage", PrimaryVoltage == "Select" ? null : PrimaryVoltage);
            cmd.Parameters.AddWithValue("@SecondoryVoltage", SecondoryVoltage == "Select" ? null : SecondoryVoltage);
            cmd.Parameters.AddWithValue("@MakeType", MakeType);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter returnStatusParam = new SqlParameter("@ReturnStatus", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(returnStatusParam);
            cmd.ExecuteNonQuery();
            con.Close();

            Int32 returnStatus = (Int32)returnStatusParam.Value;

            return returnStatus;
        }


        public int InsertGeneratingSetData_Existing_HavingPreviousReport_Industries(string IdUpdate, string Count, string IntimationId, string GeneratingSetCapacityType, string GeneratingSetCapacity, string SerialNumbrOfAcGenerator, string GeneratingSetType, string GeneratorVoltageLevel, string TypeOfPlant, string MakeType, string CreatedBy)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertGeneratingSetData_Existing_HavingPreviousReport_Industries");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUpdate", IdUpdate);
            cmd.Parameters.AddWithValue("@Count", string.IsNullOrEmpty(Count) ? DBNull.Value : (object)Count);
            cmd.Parameters.AddWithValue("@IntimationId", string.IsNullOrEmpty(IntimationId) ? DBNull.Value : (object)IntimationId);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacityType", string.IsNullOrEmpty(GeneratingSetCapacityType) ? DBNull.Value : (object)GeneratingSetCapacityType);
            cmd.Parameters.AddWithValue("@GeneratingSetCapacity", string.IsNullOrEmpty(GeneratingSetCapacity) ? DBNull.Value : (object)GeneratingSetCapacity);
            cmd.Parameters.AddWithValue("@SerialNumbrOfAcGenerator", string.IsNullOrEmpty(SerialNumbrOfAcGenerator) ? DBNull.Value : (object)SerialNumbrOfAcGenerator);
            cmd.Parameters.AddWithValue("@GeneratingSetType", GeneratingSetType == "Select" ? DBNull.Value : (object)GeneratingSetType);
            cmd.Parameters.AddWithValue("@GeneratorVoltageLevel", string.IsNullOrEmpty(GeneratorVoltageLevel) ? DBNull.Value : (object)GeneratorVoltageLevel);
            cmd.Parameters.AddWithValue("@TypeOfPlant", TypeOfPlant == "Select" ? DBNull.Value : (object)TypeOfPlant);
            cmd.Parameters.AddWithValue("@MakeType", MakeType);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter returnStatusParam = new SqlParameter("@ReturnStatus", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(returnStatusParam);
            cmd.ExecuteNonQuery();
            con.Close();

            Int32 returnStatus = (Int32)returnStatusParam.Value;

            return returnStatus;
        }

        public void UpdateInstallations_Industries(string Id, string IntimationId)
        {
            SqlCommand cmd = new SqlCommand("sp_CheckTestReportHistory_Industries");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public DataSet ExistingInspectionData_Industries(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetExistingInspections_Industries", PANNumber);
        }

        public DataSet UpdateInspectionRejection(string ID, string StaffId, string RejctionReasonType, string ReasonForRejection)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InspectionRejection", ID, StaffId, RejctionReasonType, ReasonForRejection);
        }
        // 06-11-2024 Neeraj
        public DataTable SiteOwnerInspectionDataStatus(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionStatus_Industry", SiteOwnerId);
        }

        #region powerUtility
        public DataSet checkUtilityName(string UtilityName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckUtilityName", UtilityName);
        }
        public DataSet InsertInUtilityMaster(string UtilityName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertUtilityName", UtilityName);
        }
        public DataSet GetUtilityMaster()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPowerUtilityData");
        }
        public DataSet checkWingName(string WingName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckWingName", WingName);
        }
        public DataSet InsertInWingMaster(string WingName, string UtilityId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertInWingMaster", WingName, UtilityId);
        }
        public DataSet GetWingMaster(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetWingData", Id);
        }
        public DataSet checkZoneName(string ZoneName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckZoneName", ZoneName);
        }
        public DataSet InsertInZoneMaster(string ZoneName, string UtilityId, string WingId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertInZoneMaster", ZoneName, UtilityId, WingId);
        }
        public DataSet GetZoneMaster(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetZoneData", Id);
        }
        public DataSet checkCircleName(string CircleName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckCircleName", CircleName);
        }
        public DataSet InsertInCircleMaster(string CircleName, string UtilityId, string WingId, string ZoneId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertInCircleMaster", CircleName, UtilityId, WingId, ZoneId);
        }
        public DataSet GetCircleMaster(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetCircleData", Id);
        }
        public DataSet checkDivisionName(string DivisionName)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDivisionName", DivisionName);
        }
        public void InsertInDivisionMaster(string DivisionName, string UtilityId, string WingId, string ZoneId, string CircleId)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertDivisionInMaster");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DivisionName", DivisionName);
            cmd.Parameters.AddWithValue("@UtilityId", UtilityId);
            cmd.Parameters.AddWithValue("@WingId", WingId);
            cmd.Parameters.AddWithValue("@ZoneId", ZoneId);
            cmd.Parameters.AddWithValue("@CircleId", CircleId);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet GetDivisionMaster(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDivisionMasterData", Id);
        }
        public DataSet checkEmail(string Email)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getEmailFromSubDivision", Email);
        }
        public void InsertInSubDivisionMaster(string SubDivisionName, string Email, string PhoneNo, string UtilityId, string WingId, string ZoneId, string CircleId, string DivisionId, string UserId)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertSubDivisionInMaster");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SubDivision", SubDivisionName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Mobile", PhoneNo);
            cmd.Parameters.AddWithValue("@UtilityId", UtilityId);
            cmd.Parameters.AddWithValue("@WingId", WingId);
            cmd.Parameters.AddWithValue("@ZoneId", ZoneId);
            cmd.Parameters.AddWithValue("@CircleId", CircleId);
            cmd.Parameters.AddWithValue("@DivisionId", DivisionId);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet DdlForDivision()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDivisionName");
        }

        #endregion

        public DataSet TotalRequestInspectionForAdmin(string LoginId, string Division = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_TotalRequestInspectionForAdmin", LoginId, string.IsNullOrEmpty(Division) ? (object)DBNull.Value : Division);
        }
        public DataSet NeWRequestInspectionForAdmin(string LoginId, string Division = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_NewRequestReceivedForAdmin", LoginId, string.IsNullOrEmpty(Division) ? (object)DBNull.Value : Division);
        }
        public DataSet InProcessRequestInspectionForAdmin(string LoginId, string Division = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetProcessRequestForAdmin", LoginId, string.IsNullOrEmpty(Division) ? (object)DBNull.Value : Division);
        }
        public DataSet AcceptedOrRejectedRequestInspectionForAdmin(string LoginId, string Division = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_AcceptRejectInspectionForAdmin", LoginId, string.IsNullOrEmpty(Division) ? (object)DBNull.Value : Division);
        }

        public int ResetPasswordByAdmin(string UserId, string Password)
        {
            SqlCommand cmd = new SqlCommand("sp_updatePassword");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Password", Password);
            int Ad = cmd.ExecuteNonQuery();
            con.Close();
            return Ad;
        }
        public void ResetMessagethroughEmail(string Email, string Subject, string Message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("haryanacei@gmail.com");
            mailMessage.To.Add(Email);
            mailMessage.Subject = Subject;
            string body = $"Dear Customer,\n\n {Message}";
            mailMessage.Body = body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("haryanacei@gmail.com", "httnrdifrwgfnzrv");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
        public DataTable SearchSiteOwnerData(string searchText, string category)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetSearchSiteOwnerData", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchText", searchText);
                command.Parameters.AddWithValue("@category", category);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }

        public void updateReturnRemarksOnBasesOfTrDocuments(string ID, string IntimationId, string Rowid,
                             string ReasonForReturn, SqlTransaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InspectionReturnRemarksOnBasesOfTrDocuments", transaction.Connection, transaction))
                    //using (SqlCommand cmd = new SqlCommand("sp_InspectionReturnRemarksOnBasesOfTrDocuments", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        // cmd.Parameters.AddWithValue("@StaffId", StaffId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@Rowid", Rowid);
                        cmd.Parameters.AddWithValue("@ReasonForReturn ", ReasonForReturn);
                        //cmd.Parameters.AddWithValue("@ReturnedBasedOnDocumentValue ", ReturnedBasedOnDocumentValue);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public DataTable InspectionAccepted(string ID, string StaffId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InspectionAccepted", ID, StaffId);
        }

        public void updateReturnRemarksOnBasesOnChecklistDocuments(string ID, string Rowid, string ReasonForReturn, SqlTransaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InspectionReturnRemarksOnBasesOfChecklistDocuments", transaction.Connection, transaction))
                    //using (SqlCommand cmd = new SqlCommand("sp_InspectionReturnRemarksOnBasesOfChecklistDocuments", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        //cmd.Parameters.AddWithValue("@StaffId", StaffId);
                        cmd.Parameters.AddWithValue("@Rowid", Rowid);
                        cmd.Parameters.AddWithValue("@ReasonForReturn ", ReasonForReturn);

                        //cmd.Parameters.AddWithValue("@ReturnedBasedOnDocumentValue ", ReturnedBasedOnDocumentValue);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                { }
            }

        }
        //return inspection 9 nov 2024
        public DataSet SelectRemarksDocumentsattachedinTR(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GiveRemarksDocumentsattachedinTR", InspectionId);
        }
        public DataTable SiteOwnerReturnedInspection(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerReturnedInspection", SiteOwnerId);
        }

        public DataSet GetInspectionReport(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionReport", Id);
        }
        public DataSet ViewReturnDocuments(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOfficersReturnDocumentHistory", InspectionId);
        }
        public DataSet GetReturnedTestReport(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedTestReport", Id);
        }
        //public int UploadSldDocument_Industries(string SiteOwnerID, string Path, string Createdby, string SiteOwnerAddress, string OwnerName, string UserType, string District, string serviceid)
        //{
        //    // Prepare the output parameter
        //    SqlParameter outputParam = new SqlParameter("@InsertedSLD_ID", SqlDbType.Int)
        //    {
        //        Direction = ParameterDirection.Output
        //    };

        //    // Execute the stored procedure and pass the output parameter
        //    DBTask.ExecuteNonQuery(
        //        ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
        //        CommandType.StoredProcedure,
        //        "Sp_InsertSdlData_Industries",
        //        new SqlParameter("@SiteOwnerID", SiteOwnerID),
        //        new SqlParameter("@Path", Path),
        //        new SqlParameter("@Createdby", Createdby),
        //        new SqlParameter("@SiteOwnerAddress", SiteOwnerAddress),
        //        new SqlParameter("@OwnerName", OwnerName),
        //        new SqlParameter("@UserType", UserType),
        //        new SqlParameter("@District", District),
        //        new SqlParameter("@ServiceId", serviceid),
        //        outputParam  // Include the output parameter
        //    );

        //    // Retrieve the output parameter value
        //    int insertedSLD_ID = (int)outputParam.Value;

        //    // Return the inserted SLD_ID
        //    return insertedSLD_ID;
        //}
        public DataSet GetInspectionReport_Industry(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionReport_Industry", Id);
        }

       public DataSet GetDetailsToViewTRinMultipleCaseNew_Industry(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewMultipleInspectionTR_Industry", InspectionId);
        }

       public DataSet ViewDocuments_ForNewIndustry(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDocuments_ForNewIndustry", InspectionId);
        }
        public void UpdateReturnedInspectionReport(string InspectionID, string StaffId, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateReturnedInspectionReport", transaction.Connection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InspectionID ", InspectionID);
            cmd.Parameters.AddWithValue("@StaffId ", StaffId);
            cmd.ExecuteNonQuery();
        }
        public void InsertReturnedInspectionTestReportAttachments(string id, string InspectionID, string installaionInvoice,
                            string ManufacturingReport, string InstallationType, string CreatedBy, SqlTransaction transaction)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertReturnedInspectionTestReportAttachments", transaction.Connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@InspectionID", InspectionID);
                    cmd.Parameters.AddWithValue("@installaionInvoice", installaionInvoice);
                    cmd.Parameters.AddWithValue("@ManufacturingReport", ManufacturingReport);
                    cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                    cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception or handling it as needed.
                throw;
            }
        }
        public void UploadDocumentforReturnedInspection(string InspectionId, string InstallationType, string DocumentID,
                                   string DocSaveName, string FileName, string FilePath, string CreatedBy, SqlTransaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertInspectionAttachments", transaction.Connection, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InspectionId", InspectionId);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@DocumentID", DocumentID);
                        cmd.Parameters.AddWithValue("@DocSaveName", DocSaveName);
                        cmd.Parameters.AddWithValue("@FileName", FileName);
                        cmd.Parameters.AddWithValue("@FilePath", FilePath);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        //**
        public DataSet GetSubDivisionMaster(string UtilityId = null, string WingId = null, string ZoneId = null, string CircleId = null, string DivisionId = null, string searchText = null)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSubDivisionMasterData", string.IsNullOrEmpty(UtilityId) ? (object)DBNull.Value : UtilityId,
              string.IsNullOrEmpty(WingId) ? (object)DBNull.Value : WingId, string.IsNullOrEmpty(ZoneId) ? (object)DBNull.Value : ZoneId,
              string.IsNullOrEmpty(CircleId) ? (object)DBNull.Value : CircleId, string.IsNullOrEmpty(DivisionId) ? (object)DBNull.Value : DivisionId, string.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }
        //CreatedByNavneet 12-11-2024
        public DataTable InstallationComponentsforSiteOwner(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnComponentsForOfficer", Id);
        }
        public void UploadDocumentforReturnedInspection_Industry(string InspectionId, string InstallationType, string DocumentID,
                           string DocSaveName, string FileName, string FilePath, string CreatedBy, SqlTransaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertInspectionAttachments_Industry", transaction.Connection, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InspectionId", InspectionId);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@DocumentID", DocumentID);
                        cmd.Parameters.AddWithValue("@DocSaveName", DocSaveName);
                        cmd.Parameters.AddWithValue("@FileName", FileName);
                        cmd.Parameters.AddWithValue("@FilePath", FilePath);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public void InsertReturnedInspectionTestReportAttachments_Industry(string id, string InspectionID, string installaionInvoice,
                          string ManufacturingReport, string InstallationType, string CreatedBy, SqlTransaction transaction)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertReturnedInspectionTestReportAttachments_Industry", transaction.Connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@InspectionID", InspectionID);
                    cmd.Parameters.AddWithValue("@installaionInvoice", installaionInvoice);
                    cmd.Parameters.AddWithValue("@ManufacturingReport", ManufacturingReport);
                    cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                    cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception or handling it as needed.
                throw;
            }
        }
        public void UpdateReturnedInspectionReportIndustry(string InspectionID, string StaffId, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateReturnedInspectionReport_Industry", transaction.Connection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InspectionID ", InspectionID);
            cmd.Parameters.AddWithValue("@StaffId ", StaffId);
            cmd.ExecuteNonQuery();
        }
        //Periodic inspection date in testreport
        public DataSet GetIntimationDetails(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationDetails", Id);
        }
        //CreatedByNavneet 13-11-2024
        public void RejectMessagethroughEmail(string Email, string CcEmail, string Subject, string Message)
        {
            MailMessage mailMessage = new MailMessage();

            // Set the 'From' email address
            mailMessage.From = new MailAddress("haryanacei@gmail.com");

            // Set the 'To' recipient
            mailMessage.To.Add(Email);

            // Optionally, set the 'Cc' recipient
            if (!string.IsNullOrEmpty(CcEmail))
            {
                mailMessage.CC.Add(CcEmail);  // Add the CC recipient if provided
            }

            // Set the email subject
            mailMessage.Subject = Subject;

            // Set the email body
            string body = $"Dear Customer,\n\n{Message}";
            mailMessage.Body = body;

            // Set up the SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("haryanacei@gmail.com", "httnrdifrwgfnzrv");
            smtpClient.EnableSsl = true;

            // Send the email
            smtpClient.Send(mailMessage);
        }

        public DataSet GetEmails(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetEmails", Id);
        }
        public void UpdateStatusOfReturnedInspection(string ID, string StaffId, string ReturnedBasedOnDocumentValue, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateStatusOfReturnedInspection", transaction.Connection, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID ", ID);
            cmd.Parameters.AddWithValue("@StaffId ", StaffId);
            cmd.Parameters.AddWithValue("@ReturnedBasedOnDocumentValue ", ReturnedBasedOnDocumentValue);
            cmd.ExecuteNonQuery();
        }
        public DataSet getInstallationsForPeriodic(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getInstallationTypeLetterFor_Periodic", Id);
        }
        public DataSet GetEarthingData(string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetEarthingData", TestReportId);
        }

        public DataSet GetSiteOwnerTestReport(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerTestReport", Id);
        }

        public DataSet GetSiteOwnerAdress_Industries(string id, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOwnerAdress_Industries", id, District);
        }

        public DataSet ShowDataToCart_Industries(string address, string CartID, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_GetCartData_Industries", address, CartID, CreatedBy);
        }
        public void InsertInspectinData_Industries(string CartId, string TotalCapacity, string MaxVoltage, string InstallationType, string TestRportId,
string IntimationId, string VoltageLevel, string ApplicantType, string District, string Division, string AssignTo, string PaymentMode, int TotalAmount, int status, string CreatedBy, int ServiceType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertintoTempTable_Industries", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CartId", CartId);
                        cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
                        cmd.Parameters.AddWithValue("@MaxVoltage", MaxVoltage);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@TestRportId", TestRportId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
                        cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
                        cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Division", Division);
                        cmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                        //cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
                        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                        cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
                        //cmd.Parameters.AddWithValue("@Status", Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public string InsertPeriodicInspectionData_Industries(string TypeOfInspection,
      string CartId, string TransactionId, string TransctionDate, string CreatedBy, int InspectID, SqlTransaction transaction)

        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPeriodicInspectionData_Industries", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfInspection", TypeOfInspection);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@TransactionId ", TransactionId);
                    cmd.Parameters.AddWithValue("@TransactionDate", TransctionDate);
                    cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
                    cmd.Parameters.AddWithValue("@InspectID", InspectID);
                    outputParam = new SqlParameter("@Ret_InspectionID", SqlDbType.NVarChar, 500);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string RetVal = cmd.Parameters["@Ret_InspectionID"].Value.ToString();
                    cmd.Parameters.Clear();
                    return RetVal;
                }

            }
        }

        //Creted By Navneet for lift 

        public DataSet GetSupervisorData()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "GetSupervisorDetails");
        }
        public DataSet GetSupervisorDataatSiteOwner(string License)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSupervisorDetails", License);
        }

        public int InsertNewLiftData(string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent
, string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime DateofErection, string TypeofLift,string Make,string SerialNo, string TypeofLiftErected, string ContractSpeedofLiftMtrPrSec
, decimal ContractLoadofLiftInKg, string MaxPersonCapacitywithLiftOperator, decimal WeightofLiftCarwithContractLoadInKg, decimal WeightofCounterWeightInkg
, decimal DepthofPitInmm, decimal TravelDistanceofLiftInMtr, decimal NoofFloorsServedInMtr, decimal TotalHeadRoomInmm, string TypeOfControl, decimal NoofSuspensionRopes,
string DescrptionofSuspensionRopes, decimal SizeofSusspensionRopesInmm, decimal WeightofBeamInkg, decimal SizeofBeamInmm, string MakeMainBreaker,
string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker
, string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker
, string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int RedPhaseYellowPhaseInMohms, int RedPhaseBluePhaseInMohms
, int YellowPhaseBluePhaseInMohms, int RedPhaseEarthWireInMohms, int YellowPhaseEarthWireInMohms, int BluePhaseEarthWirenMohms, string NumberofEarthing
, string EarthingType1, decimal Valueinohms1, string EarthingType2, decimal Valueinohms2, string EarthingType3, decimal Valueinohms3, string EarthingType4,
decimal Valueinohms4, string EarthingType5
, decimal Valueinohms5, string EarthingType6, decimal Valueinohms6, string EarthingType7, decimal Valueinohms7, string EarthingType8, decimal Valueinohms8,
string EarthingType9, decimal Valueinohms9
, string EarthingType10, decimal Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime ContractorLicenseExpiryDate,
string SupervisorName, string SupervisorLicenseNumber, DateTime SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertLiftTestReportdata", count, IntimationId, NameandAddressofLocalAgent, NameofLocalAgent
, AddressofLocalAgent, ContactNoofLocalAgent, DateofErection, TypeofLift, Make, SerialNo,TypeofLiftErected, ContractSpeedofLiftMtrPrSec
, ContractLoadofLiftInKg, MaxPersonCapacitywithLiftOperator, WeightofLiftCarwithContractLoadInKg, WeightofCounterWeightInkg
, DepthofPitInmm, TravelDistanceofLiftInMtr, NoofFloorsServedInMtr, TotalHeadRoomInmm, TypeOfControl, NoofSuspensionRopes, DescrptionofSuspensionRopes
, SizeofSusspensionRopesInmm, WeightofBeamInkg, SizeofBeamInmm, MakeMainBreaker, TypeMainBreaker, PolesMainBreaker, CurrentRatingInAmps
, BreakingCapacityInKA, MakeRCCBMainBreaker, PolesRCCBMainBreaker, CurrentRCCBRatingInAmps, FaultRCCBCurrentRating, LoadMakeMainBreaker
, LoadTypeMainBreaker, LoadPolesMainBreaker, LoadCurrentRatingInAmps, LoadBreakingCapacityInKA, LoadMakeRCCBMainBreaker, LoadPolesRCCBMainBreaker
, LoadRCCBCurrentRatingInAmps, LoadRCCBFaultCurrentRating, ForWholeInstallation, NeutralandPhaseohms, EarthandPhasemohms, RedPhaseYellowPhaseInMohms, RedPhaseBluePhaseInMohms
, YellowPhaseBluePhaseInMohms, RedPhaseEarthWireInMohms, YellowPhaseEarthWireInMohms, BluePhaseEarthWirenMohms, NumberofEarthing
, EarthingType1, Valueinohms1, GetValue(EarthingType2), Valueinohms2, GetValue(EarthingType3), Valueinohms3, GetValue(EarthingType4), 
                Valueinohms4, GetValue(EarthingType5), Valueinohms5, GetValue(EarthingType6), Valueinohms6, GetValue(EarthingType7), 
                Valueinohms7, GetValue(EarthingType8), Valueinohms8, GetValue(EarthingType9), Valueinohms9, GetValue(EarthingType10), 
                Valueinohms10, CreatedBy, ContractorName, ContractorLicenseNumber, ContractorLicenseExpiryDate, SupervisorName, SupervisorLicenseNumber, SupervisorLicenseExpiryDate);
        }
        private object GetValue(object value)
        {
            if (value == null || value.ToString() == "0" || value.ToString() == "Select" || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return DBNull.Value;
            }
            return value;
        }

        public int InsertNewEscalatorData(string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent,
 string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime? DateofErection, string Make, string SerialNo, string TypeofEscalatorErected, string ContractSpeedofEscalatorMtrPrSec,
 decimal? ContractLoadofEscalatorInKg, string MaxPersonCapacitywithEscalatorOperator, decimal? WeightofEscalatorCarwithContractLoadInKg, decimal? WeightofCounterWeightInkg,
 decimal? DepthofPitInmm, decimal? TravelDistanceofEscalatorInMtr, decimal? NoofFloorsServedInMtr, decimal? TotalHeadRoomInmm, string TypeOfControl,
 string MakeMainBreaker, string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
 string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker,
 string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
 string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker,
 string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int? RedPhaseYellowPhaseInMohms, int? RedPhaseBluePhaseInMohms,
 int? YellowPhaseBluePhaseInMohms, int? RedPhaseEarthWireInMohms, int? YellowPhaseEarthWireInMohms, int? BluePhaseEarthWirenMohms, string NumberofEarthing,
 string EarthingType1, decimal? Valueinohms1, string EarthingType2, decimal? Valueinohms2, string EarthingType3, decimal? Valueinohms3, string EarthingType4,
 decimal? Valueinohms4, string EarthingType5,
 decimal? Valueinohms5, string EarthingType6, decimal? Valueinohms6, string EarthingType7, decimal? Valueinohms7, string EarthingType8, decimal? Valueinohms8,
 string EarthingType9, decimal? Valueinohms9,
 string EarthingType10, decimal? Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime? ContractorLicenseExpiryDate,
 string SupervisorName, string SupervisorLicenseNumber, DateTime? SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertEscalatorTestReportdata",
                GetValue(count), GetValue(IntimationId), GetValue(NameandAddressofLocalAgent), GetValue(NameofLocalAgent),
                GetValue(AddressofLocalAgent), GetValue(ContactNoofLocalAgent), GetValue(DateofErection), GetValue(Make), GetValue(SerialNo),
                GetValue(TypeofEscalatorErected), GetValue(ContractSpeedofEscalatorMtrPrSec), GetValue(ContractLoadofEscalatorInKg), GetValue(MaxPersonCapacitywithEscalatorOperator),
                GetValue(WeightofEscalatorCarwithContractLoadInKg), GetValue(WeightofCounterWeightInkg), GetValue(DepthofPitInmm), GetValue(TravelDistanceofEscalatorInMtr),
                GetValue(NoofFloorsServedInMtr), GetValue(TotalHeadRoomInmm), GetValue(TypeOfControl), GetValue(MakeMainBreaker), GetValue(TypeMainBreaker),
                GetValue(PolesMainBreaker), GetValue(CurrentRatingInAmps), GetValue(BreakingCapacityInKA), GetValue(MakeRCCBMainBreaker),
                GetValue(PolesRCCBMainBreaker), GetValue(CurrentRCCBRatingInAmps), GetValue(FaultRCCBCurrentRating), GetValue(LoadMakeMainBreaker),
                GetValue(LoadTypeMainBreaker), GetValue(LoadPolesMainBreaker), GetValue(LoadCurrentRatingInAmps), GetValue(LoadBreakingCapacityInKA),
                GetValue(LoadMakeRCCBMainBreaker), GetValue(LoadPolesRCCBMainBreaker), GetValue(LoadRCCBCurrentRatingInAmps), GetValue(LoadRCCBFaultCurrentRating),
                GetValue(ForWholeInstallation), GetValue(NeutralandPhaseohms), GetValue(EarthandPhasemohms), GetValue(RedPhaseYellowPhaseInMohms),
                GetValue(RedPhaseBluePhaseInMohms), GetValue(YellowPhaseBluePhaseInMohms), GetValue(RedPhaseEarthWireInMohms), GetValue(YellowPhaseEarthWireInMohms),
                GetValue(BluePhaseEarthWirenMohms), GetValue(NumberofEarthing), GetValue(EarthingType1), GetValue(Valueinohms1), GetValue(EarthingType2),
                GetValue(Valueinohms2), GetValue(EarthingType3), GetValue(Valueinohms3), GetValue(EarthingType4), GetValue(Valueinohms4), GetValue(EarthingType5),
                GetValue(Valueinohms5), GetValue(EarthingType6), GetValue(Valueinohms6), GetValue(EarthingType7), GetValue(Valueinohms7), GetValue(EarthingType8),
                GetValue(Valueinohms8), GetValue(EarthingType9), GetValue(Valueinohms9), GetValue(EarthingType10), GetValue(Valueinohms10), GetValue(CreatedBy),
                GetValue(ContractorName), GetValue(ContractorLicenseNumber), GetValue(ContractorLicenseExpiryDate), GetValue(SupervisorName),
                GetValue(SupervisorLicenseNumber), GetValue(SupervisorLicenseExpiryDate));
        }

        private object GetValue(string value)
        {
            return string.IsNullOrEmpty(value) ? DBNull.Value : (object)value;
        }
        public DataTable UpdateLiftTestReportHistory(string ID, string count, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_LiftTestReportApproval", ID, count, CreatedBy);
        }


        public DataSet GetSupervisorandContractor(string Person, string LicenseNo)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSuperVisorAndContractorDetails", Person, LicenseNo);
        }

        public DataTable GetEmailContractor(string LicenseValue)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetEmailContractor", LicenseValue);
        }

        public DataTable GetInstllationsforSitOwner(string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationsForSiteOwner", IntimationId);

        }
        public DataSet IntimationDataforSiteOwner(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftIntimationsForSiteOwner", UserId);
        }

        //////


        ////Neeraj
        public int UpdateSLD_Industry(string Id, string path, string RequestLetter, string SiteOwnerId, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateSdlData_Industry", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.Parameters.AddWithValue("@Path", path);
            cmd.Parameters.AddWithValue("@RequestLetter", RequestLetter);
            cmd.Parameters.AddWithValue("@SiteOwnerId", SiteOwnerId);

            int x = cmd.ExecuteNonQuery();
            return x;
            //return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_UpdateSdlData", Id, path, RequestLetter, SiteOwnerId, transaction);

        }

        public DataTable SldHistory_Industry(string SiteOwnerId, string searchText = null)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_ApproveSdlHistory_Industry", SiteOwnerId, String.IsNullOrEmpty(searchText) ? (object)DBNull.Value : searchText);
        }

        public int UploadSldDocument_Industries(string SiteOwnerID, string Path, string RequestLetter, string Createdby, string SiteOwnerAddress, string OwnerName, string UserType, string District, string serviceid)
        {
            // Prepare the output parameter
            SqlParameter outputParam = new SqlParameter("@InsertedSLD_ID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            // Execute the stored procedure and pass the output parameter
            DBTask.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                CommandType.StoredProcedure,
                "Sp_InsertSdlData_Industries",
                new SqlParameter("@SiteOwnerID", SiteOwnerID),
                new SqlParameter("@Path", Path),
                new SqlParameter("@RequestLetter", RequestLetter),
                new SqlParameter("@Createdby", Createdby),
                new SqlParameter("@SiteOwnerAddress", SiteOwnerAddress),
                new SqlParameter("@OwnerName", OwnerName),
                new SqlParameter("@UserType", UserType),
                new SqlParameter("@District", District),
                new SqlParameter("@ServiceId", serviceid),
                outputParam  // Include the output parameter
            );

            // Retrieve the output parameter value
            int insertedSLD_ID = (int)outputParam.Value;

            // Return the inserted SLD_ID
            return insertedSLD_ID;
        }
        public int UpdateSLD(string Id, string path, string RequestLetter, string SiteOwnerId, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateSdlData", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.Parameters.AddWithValue("@Path", path);
            cmd.Parameters.AddWithValue("@RequestLetter", RequestLetter);
            cmd.Parameters.AddWithValue("@SiteOwnerId", SiteOwnerId);

            int x = cmd.ExecuteNonQuery();
            return x;
            //return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_UpdateSdlData", Id, path, RequestLetter, SiteOwnerId, transaction);

        }

        public int UploadSldDocument(string SiteOwnerID, string Path, string RequestLetter, string Createdby, string SiteOwnerAddress, string OwnerName, string UserType, SqlTransaction transaction  )
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertSdlData", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SiteOwnerID ", SiteOwnerID);
            cmd.Parameters.AddWithValue("@Path ", Path);
            cmd.Parameters.AddWithValue("@RequestLetter ", RequestLetter);
            cmd.Parameters.AddWithValue("@Createdby ", Createdby);
            cmd.Parameters.AddWithValue("@SiteOwnerAddress ", SiteOwnerAddress);
            cmd.Parameters.AddWithValue("@OwnerName ", OwnerName);
            cmd.Parameters.AddWithValue("@UserType ", UserType);
            int x = cmd.ExecuteNonQuery();
            return x;
            //con.Close();

        }



        /////
        ///

        public DataSet ViewReturnDocumentsForPeriodic(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOfficersReturnDocumentHistoryForPeriodic", InspectionId);
        }
        //lift new inspection 4 dec        
        public DataTable Payment_Lift(string selectedTypeIds, int? LiftQaunatity, int? EscaltorQaunatity)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_LiftEscaltor_New", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InspectionType", "New");
                command.Parameters.AddWithValue("@InstallationTypeIds", selectedTypeIds);
                command.Parameters.AddWithValue("@QuantityLift", LiftQaunatity == 0 ? null : LiftQaunatity);
                command.Parameters.AddWithValue("@QuantityEscalator", EscaltorQaunatity == 0 ? null : EscaltorQaunatity);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }
        public DataSet SiteOwnerInstallations_Lift(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationForSiteOwner_Lift", IntimationId);
        }

        public DataSet SiteIntimations_forLift(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSiteOwner_Lift", PANNumber);
        }
        public void InsertInspectionDataNewCode_Lift(string ContactNo, string ApplicantTypeCode, string IntimationId, string ApplicantType, string InstallationType,
         string District, string Division, string PaymentMode, string InspectionRemarks, string CreatedBy,
         decimal TotalAmount, string para_Assigned, string transcationId, string TranscationDate, int InspectID,
         int ServiceType, SqlTransaction transaction
         )
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionData_NewCodeForMultiple_Lift", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactNo ", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode ", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            //cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@District ", District);
            cmd.Parameters.AddWithValue("@Division ", Division);
            cmd.Parameters.AddWithValue("@PaymentMode ", PaymentMode);
            cmd.Parameters.AddWithValue("@InspectionRemarks ", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.Parameters.AddWithValue("@TransactionId ", transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@AssignTo", para_Assigned);
            cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
            outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
        }
        public void InsertPaymentHistory_Lift(string IntimationId, int count, int InstallationTypeId, string CreatedBy)
        {
             DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "update_InstallationHistory_NewInspection", IntimationId, count, InstallationTypeId, CreatedBy);
        }
        //**End
        public DataTable GetDocumentsForLiftRenewal(string ApplicantType, int InstallationTypeID, string InspectionType, string InstallationType)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentsForLiftRenewal", ApplicantType, InstallationTypeID, InspectionType, InstallationType);
        }

        public DataSet GetApplicantTypeForLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetApplicantTypeForLift", Id);
        }
        public string InsertPeriodicLiftData(string InstallationType, string RegistrationNo, string PreviousChallanDate, string PreviousChallanUpload,  string LastApprovalDate, string ErectionDate, string Make,
   string SerialNo, string TypeOfLift, string TypeOfControl, string Capacity, Decimal Weight, string ApplicantDistrict, string SiteAddress, string CreatedBy, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertPeriodicLiftData", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
            cmd.Parameters.AddWithValue("@PreviousChallanDate", PreviousChallanDate);
            cmd.Parameters.AddWithValue("@PreviousChallanUpload", PreviousChallanUpload);
            //cmd.Parameters.AddWithValue("@MemoNo", MemoNo);
            cmd.Parameters.AddWithValue("@LastApprovalDate", LastApprovalDate); //MemoDate
            cmd.Parameters.AddWithValue("@ErectionDate", ErectionDate);
            cmd.Parameters.AddWithValue("@Make", Make);
            cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
            cmd.Parameters.AddWithValue("@TypeOfLift", TypeOfLift);
            cmd.Parameters.AddWithValue("@TypeOfControl", TypeOfControl);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@ApplicantDistrict", ApplicantDistrict);
            cmd.Parameters.AddWithValue("@SiteAddress", SiteAddress);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter outputParam = new SqlParameter("@GeneratedTestReportID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            // Execute the command
            cmd.ExecuteNonQuery();
            string TRID = cmd.Parameters["@GeneratedTestReportID"].Value.ToString();
            return TRID;
        }
        public void UploadDocumentforLiftPeriodic(string TRID, string RegistrationNo, string InstallationType, string DocumentID, string DocSaveName, string FileName, string FilePath, string CreatedBy, SqlTransaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertLiftPeriodicAttachments", transaction.Connection, transaction))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TestReportId", TRID);
                        cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@DocumentID", DocumentID);
                        cmd.Parameters.AddWithValue("@DocSaveName", DocSaveName);
                        cmd.Parameters.AddWithValue("@FileName", FileName);
                        cmd.Parameters.AddWithValue("@FilePath", FilePath);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        //con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public DataTable GetDataForLiftRenewal(string District, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetLiftRenewaldata", District, CreatedBy);
        }
        public DataSet GetDistrictForLiftRenewal(string SiteOwnerId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDistrictForLiftRenewal", SiteOwnerId);
        }

        public DataSet GetDetailsOfLiftRenewalReport(string RegistrationNo, string TestReportID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsOfLiftRenewalReport", RegistrationNo, TestReportID);
        }

        public DataTable GetDocumentOfLiftRenewalToShow(string TestReportId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentOfLiftRenewalToShow", TestReportId);
        }
        public DataTable GetDocumentforlift(string Applicanttype)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentsForLift", Applicanttype);
        }
        public DataTable InsertNewLiftAttachments(string InstallationType, string DocumentID, string DocSaveName, string FileName, string FilePath, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertLiftNewAttachments", InstallationType, int.Parse(DocumentID), DocSaveName, FileName, FilePath, CreatedBy);
        }
        //NaVNEET 5-12
        public DataSet GetRenewalLiftData(string Type, string RegistrationNo, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicRenewalData", Type, RegistrationNo, CreatedBy);
        }
        public DataTable UpdateLiftTestReportHistory(string Type, string ID, string count, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_LiftTestReportApproval", Type, ID, count, CreatedBy);
        }
        public DataTable GetAttachments(string TestReportId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachments", TestReportId);
        }

        public DataSet GetLiftTestReportModalData(string Type, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftEscalatorDataForSiteowner", Type, TestReportId);
        }
        ///
         //Neeraj 5-12
        public DataSet InspectionDataFor_Lift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDataForLift_Escelater", Id);
        }
        public DataSet getDataforLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDataForLift", Id);
        }

        public void InspectionFinalAction_Lift(string InspectionID, string StaffId, string AcceptedOrReReturn, string Reason, string MemoNo, string InspectionDate, SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InspectionApproveReject_Lift_Escelater", transaction.Connection, transaction);
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                //cmd.Connection = con;
                if (transaction.Connection.State == ConnectionState.Closed)
                {
                    transaction.Connection.Open();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", InspectionID);
                cmd.Parameters.AddWithValue("@StaffId", StaffId);
                cmd.Parameters.AddWithValue("@AcceptedOrRejected", AcceptedOrReReturn);
                cmd.Parameters.AddWithValue("@ReasonForRejection", Reason);
                cmd.Parameters.AddWithValue("@MemoNo", MemoNo);
                //cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                DateTime InsDate;
                if (DateTime.TryParse(InspectionDate, out InsDate) && InsDate != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@InspectionDate", DBNull.Value);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }
        public DataSet ViewReturnDocuments_Lift(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetOfficersReturnDocumentHistory_Lift", InspectionId);
        }
        public DataSet PrintDetailsFor_LiftCertificate(string InspectionId, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApproveCertificate_Lift_Escelator", InspectionId, TestReportId);
        }
        //

        //Aslam-06-12-2024
        public DataSet InspectionData_Lift_Escalator(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData_Lift_Escalator", Id);
        }

        public DataSet ViewDocuments_Lift_Escalator(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDocuments_Lift_Escalator", InspectionId);
        }



        public DataSet GetDetailsToViewTRinMultipleCaseNew_Lift_Escalator(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewMultipleInspectionTR_Lift_Escalator", InspectionId);
        }


        public DataSet GetTestReport_Lift_Escalator(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Lift_Escalator", Id);
        }


        public DataSet GetTestReportDataIfPeriodic_Lift_Escalator(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodic_Lift_Escalator", Id);
        }


        public void updateInspectionPeriodic_lift_Escalator(string InspectionID, string StaffId, string IntimatiomnId, string Installationtype,
 string AcceptedOrReReturn, string Reason, string ReasonType, string ReasonTypeValue)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InspectionReviewForPeriodic_Lift_Escalator", connection))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", InspectionID);
                        cmd.Parameters.AddWithValue("@StaffId", StaffId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimatiomnId);
                        //cmd.Parameters.AddWithValue("@count", count);
                        cmd.Parameters.AddWithValue("@Installationtype ", Installationtype);
                        cmd.Parameters.AddWithValue("@AcceptedOrReturn ", AcceptedOrReReturn);
                        cmd.Parameters.AddWithValue("@ReasonForRejection ", Reason);
                        cmd.Parameters.AddWithValue("@ReasonType ", ReasonType);
                        cmd.Parameters.AddWithValue("@ReasonTypeValue ", ReasonTypeValue);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    //throw;
                }
                finally
                {
                    connection.Close();
                }

            }

        }
        public DataSet UpdateInspectionRejection_Lift_Escalator(string ID, string StaffId, string RejctionReasonType, string ReasonForRejection)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InspectionRejection_Lift_Escalator", ID, StaffId, RejctionReasonType, ReasonForRejection);
        }

        public DataTable InspectionAccepted_Lift_Escalator(string ID, string StaffId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InspectionAccepted_Lift_Escalator", ID, StaffId);
        }

        public DataSet GetDetailsToViewCart_Lift_Escalator(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCart_Lift_Escalator", InspectionId);
        }



        //

        //Neeraj 06-12-2024

       

        public DataSet ApprovalData_Lift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DataForApproval_Lift", Id);
        }

        //
        //Gurmeet 09-12-2024
        public DataTable GetDocumentlistfornewInspection_Lift(string ApplicantType, int InstallationTypeID, string InspectionType, int inspectionIdPrm)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentsForNewMultipleInspection_Lift", ApplicantType, InstallationTypeID, InspectionType, inspectionIdPrm);
        }
        ///

      

       

        public DataTable CheckDuplicacyInLift(string RegistrationNo, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDuplicacyInLift", RegistrationNo, CreatedBy);
        }

        public void Update_LiftRenewalPeriodicInspection(string RegistrationNo, int InstallationTypeId, string CreatedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "update_LiftRenewal_PeriodicInspection", RegistrationNo, InstallationTypeId, CreatedBy);
        }

        public DataTable Payment_LiftPeriodic(string selectedTypeIds, int? LiftQaunatity, int? EscaltorQaunatity, int? LiftCountForPayment, int? EscalatorCountForPayment)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_LiftEscaltor_Periodic", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InspectionType", "Periodic");
                command.Parameters.AddWithValue("@InstallationTypeIds", selectedTypeIds);
                command.Parameters.AddWithValue("@QuantityLift", LiftQaunatity == 0 ? null : LiftQaunatity);
                command.Parameters.AddWithValue("@QuantityEscalator", EscaltorQaunatity == 0 ? null : EscaltorQaunatity);
                command.Parameters.AddWithValue("@LiftCountForPayment", LiftCountForPayment == 0 ? null : LiftCountForPayment);
                command.Parameters.AddWithValue("@EscalatorCountForPayment", EscalatorCountForPayment == 0 ? null : EscalatorCountForPayment);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }

        public DataTable GetDocumentforLiftPeriodicRenewal()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentforLiftPeriodicRenewal");
        }

        public DataTable Get_DocumentGridwithOutChallan()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Get_DocumentGridwithOutChallan");
        }
        public string InsertInspectionDataForPeriodic_LiftInspection(string ApplicantType, string InstallationType, string District, string Division,
 string PaymentMode, string InspectionRemarks, string CreatedBy, decimal TotalAmount, string para_Assigned,
 string transcationId, string TranscationDate, int InspectID, int ServiceType, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionDataForPeriodic_LiftInspection", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Division", Division);
            cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
            cmd.Parameters.AddWithValue("@InspectionRemarks", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@TransactionId", String.IsNullOrEmpty(transcationId) ? DBNull.Value : (object)transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@AssignTo", para_Assigned);
            //cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            if (String.IsNullOrEmpty(TranscationDate))
            {
                cmd.Parameters.AddWithValue("@TransctionDate", DBNull.Value);
            }
            else
            {
                DateTime transactionDateValue;
                if (DateTime.TryParse(TranscationDate, out transactionDateValue))
                {
                    cmd.Parameters.AddWithValue("@TransctionDate", transactionDateValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TransctionDate", DBNull.Value);
                }
            }
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);

            SqlParameter outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            // Execute the command
            cmd.ExecuteNonQuery();
            string k = cmd.Parameters["@GeneratedCombinedIdDetails"].Value.ToString();
            return k;

        }
        public DataSet GetDivisionByDistrict(string AreaCovered)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDivisionByDistrict", AreaCovered);
        }
        public DataSet TohandleUncheckedCheckbox(string RegistrationNo, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_TohandleUncheckedCheckbox", RegistrationNo, CreatedBy);
        }
        public void InsertPeriodicLiftData(string InstallationType, string RegistrationNo, string PreviousChallanDate, string PreviousChallanUpload, string LastApprovalDate, string ErectionDate, string Make,
 string SerialNo, string TypeOfLift, string TypeOfControl, string Capacity, string Weight, string ApplicantDistrict, string SiteAddress, string CreatedBy, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertPeriodicLiftData", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
            cmd.Parameters.AddWithValue("@PreviousChallanDate", PreviousChallanDate);
            cmd.Parameters.AddWithValue("@PreviousChallanUpload", PreviousChallanUpload);
            cmd.Parameters.AddWithValue("@LastApprovalDate", LastApprovalDate);
            cmd.Parameters.AddWithValue("@ErectionDate", ErectionDate);
            cmd.Parameters.AddWithValue("@Make", Make);
            cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
            cmd.Parameters.AddWithValue("@TypeOfLift", TypeOfLift);
            cmd.Parameters.AddWithValue("@TypeOfControl", TypeOfControl);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@ApplicantDistrict", ApplicantDistrict);
            cmd.Parameters.AddWithValue("@SiteAddress", SiteAddress);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.ExecuteNonQuery();
        }


        ////Aslam

        public List<Industry_Api_Post_DataformatModel> GetIndustry_OutgoingRequestFormat_Sld(int _inspectionIdparams, string _actionType, string _projectId = null, string _serviceId = null, string _PanNo = null)
        {
            List<Industry_Api_Post_DataformatModel> models = new List<Industry_Api_Post_DataformatModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_Industry_Create_OutgoingRequest_Format_Sld", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);
                    cmd.Parameters.AddWithValue("@ActionType", _actionType);
                    cmd.Parameters.AddWithValue("@ProjectId", (object)_projectId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ServiceId", (object)_serviceId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PanNo", (object)_PanNo ?? DBNull.Value);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Industry_Api_Post_DataformatModel model = new Industry_Api_Post_DataformatModel
                            {
                                PremisesType = reader["PremisesType"] != DBNull.Value ? reader["PremisesType"].ToString() : null,
                                InspectionId = Convert.ToInt32(reader["InspectionId"]),
                                InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
                                IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
                                ActionTaken = reader["ActionTaken"].ToString(),
                                CommentByUserLogin = reader["CommentByUserLogin"].ToString(),
                                CommentDate = Convert.ToDateTime(reader["CommentDate"]),
                                Comments = reader["Comments"].ToString(),
                                Id = reader["Id"].ToString(),
                                ProjectId = reader["ProjectId"].ToString(),
                                ServiceId = reader["ServiceId"].ToString()
                            };

                            models.Add(model);
                        }
                    }
                }
                connection.Close();
            }
            return models;
            //return null;
        }


        public List<Industry_Api_Post_DataformatModel> GetIndustry_OutgoingRequestFormat(int _inspectionIdparams, string _actionType, string _projectId = null, string _serviceId = null, string _PanNo = null)
        {
            List<Industry_Api_Post_DataformatModel> models = new List<Industry_Api_Post_DataformatModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_Industry_Create_OutgoingRequest_Format", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);
                    cmd.Parameters.AddWithValue("@ActionType", _actionType);
                    cmd.Parameters.AddWithValue("@ProjectId", (object)_projectId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ServiceId", (object)_serviceId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PanNo", (object)_PanNo ?? DBNull.Value);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Industry_Api_Post_DataformatModel model = new Industry_Api_Post_DataformatModel
                            {
                                PremisesType = reader["PremisesType"] != DBNull.Value ? reader["PremisesType"].ToString() : null,
                                InspectionId = Convert.ToInt32(reader["InspectionId"]),
                                InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
                                IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
                                ActionTaken = reader["ActionTaken"].ToString(),
                                CommentByUserLogin = reader["CommentByUserLogin"].ToString(),
                                CommentDate = Convert.ToDateTime(reader["CommentDate"]),
                                Comments = reader["Comments"].ToString(),
                                Id = reader["Id"].ToString(),
                                ProjectId = reader["ProjectId"].ToString(),
                                ServiceId = reader["ServiceId"].ToString()
                            };

                            models.Add(model);
                        }
                    }
                }
                connection.Close();
            }
            return models;
            //return null;
        }

        ///

        public DataSet GetSiteOwnerDataInPeriodicOfLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerDataInPeriodicOfLift", Id);
        }
        /////Neeraj = 12-12-2024

        
        
        public DataTable InstallationComponentsforLift(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataLift", Id);
        }
        ///
        //Aslam - 13-12-2024
        public DataSet GetSiteOwnerDataInPeriodicOfLift_AtOfficerEnd(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerDataInPeriodicOfLift_AtOfficerEnd", Id);
        }


        //

        public void Update_NewInspectionReturn_Lift_Escalator(string InspectionID, string StaffId, string IntimatiomnId, string Installationtype,
                                                     string AcceptedOrReReturn, string Reason, string ReasonType, string ReasonTypeValue)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_NewInspectionReturn_Lift_Escalator", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", InspectionID);
                        cmd.Parameters.AddWithValue("@StaffId", StaffId);
                        cmd.Parameters.AddWithValue("@IntimationId", IntimatiomnId);
                        cmd.Parameters.AddWithValue("@Installationtype ", Installationtype);
                        cmd.Parameters.AddWithValue("@AcceptedOrReturn ", AcceptedOrReReturn);
                        cmd.Parameters.AddWithValue("@ReasonForRejection ", Reason);
                        cmd.Parameters.AddWithValue("@ReasonType ", ReasonType);
                        cmd.Parameters.AddWithValue("@ReasonTypeValue ", ReasonTypeValue);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                { }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetTestReportLift_Return(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportLift_Return", Id);
        }

        public DataSet GetTestReportDataIfPeriodicLift_Return(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodicLift_Return", Id);
        }

        public DataSet GetTestReport_Lift_EscalatorIfReturned(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Lift_EscalatorIfReturned", Id);
        }
        //Navneet 18-12-24
        public void UpdateReturnLiftInspectionPeriodicStatus(int InspectionId)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateReturnPeriodicStatus", InspectionId);
        }

        public int InsertReturnedNewLiftData(string OldTestReportId, string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent
, string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime DateofErection, string TypeofLift, string Make, string SerialNo, string TypeofLiftErected, string ContractSpeedofLiftMtrPrSec
, decimal ContractLoadofLiftInKg, string MaxPersonCapacitywithLiftOperator, decimal WeightofLiftCarwithContractLoadInKg, decimal WeightofCounterWeightInkg
, decimal DepthofPitInmm, decimal TravelDistanceofLiftInMtr, decimal NoofFloorsServedInMtr, decimal TotalHeadRoomInmm, string TypeOfControl, decimal NoofSuspensionRopes,
string DescrptionofSuspensionRopes, decimal SizeofSusspensionRopesInmm, decimal WeightofBeamInkg, decimal SizeofBeamInmm, string MakeMainBreaker,
string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker
, string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker
, string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int RedPhaseYellowPhaseInMohms, int RedPhaseBluePhaseInMohms
, int YellowPhaseBluePhaseInMohms, int RedPhaseEarthWireInMohms, int YellowPhaseEarthWireInMohms, int BluePhaseEarthWirenMohms, string NumberofEarthing
, string EarthingType1, decimal Valueinohms1, string EarthingType2, decimal Valueinohms2, string EarthingType3, decimal Valueinohms3, string EarthingType4,
decimal Valueinohms4, string EarthingType5
, decimal Valueinohms5, string EarthingType6, decimal Valueinohms6, string EarthingType7, decimal Valueinohms7, string EarthingType8, decimal Valueinohms8,
string EarthingType9, decimal Valueinohms9
, string EarthingType10, decimal Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime ContractorLicenseExpiryDate,
string SupervisorName, string SupervisorLicenseNumber, DateTime SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertReturnedLiftTestReportdata", OldTestReportId, count, IntimationId, NameandAddressofLocalAgent, NameofLocalAgent
, AddressofLocalAgent, ContactNoofLocalAgent, DateofErection, TypeofLift, Make, SerialNo, TypeofLiftErected, ContractSpeedofLiftMtrPrSec
, ContractLoadofLiftInKg, MaxPersonCapacitywithLiftOperator, WeightofLiftCarwithContractLoadInKg, WeightofCounterWeightInkg
, DepthofPitInmm, TravelDistanceofLiftInMtr, NoofFloorsServedInMtr, TotalHeadRoomInmm, TypeOfControl, NoofSuspensionRopes, DescrptionofSuspensionRopes
, SizeofSusspensionRopesInmm, WeightofBeamInkg, SizeofBeamInmm, MakeMainBreaker, TypeMainBreaker, PolesMainBreaker, CurrentRatingInAmps
, BreakingCapacityInKA, MakeRCCBMainBreaker, PolesRCCBMainBreaker, CurrentRCCBRatingInAmps, FaultRCCBCurrentRating, LoadMakeMainBreaker
, LoadTypeMainBreaker, LoadPolesMainBreaker, LoadCurrentRatingInAmps, LoadBreakingCapacityInKA, LoadMakeRCCBMainBreaker, LoadPolesRCCBMainBreaker
, LoadRCCBCurrentRatingInAmps, LoadRCCBFaultCurrentRating, ForWholeInstallation, NeutralandPhaseohms, EarthandPhasemohms, RedPhaseYellowPhaseInMohms, RedPhaseBluePhaseInMohms
, YellowPhaseBluePhaseInMohms, RedPhaseEarthWireInMohms, YellowPhaseEarthWireInMohms, BluePhaseEarthWirenMohms, NumberofEarthing
, EarthingType1, Valueinohms1, GetValue(EarthingType2), Valueinohms2, GetValue(EarthingType3), Valueinohms3, GetValue(EarthingType4),
                Valueinohms4, GetValue(EarthingType5), Valueinohms5, GetValue(EarthingType6), Valueinohms6, GetValue(EarthingType7),
                Valueinohms7, GetValue(EarthingType8), Valueinohms8, GetValue(EarthingType9), Valueinohms9, GetValue(EarthingType10),
                Valueinohms10, CreatedBy, ContractorName, ContractorLicenseNumber, ContractorLicenseExpiryDate, SupervisorName, SupervisorLicenseNumber, SupervisorLicenseExpiryDate);
        }

        public DataTable CheckReturnValue(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckReturnValue", InspectionId);
        }
        public void UpdateReturnLiftInspection(int InspectionId, string TransactionId, DateTime TransactionDate, string InspectionRemarks, string ModifiedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateReturnLiftInspection", InspectionId, TransactionId, TransactionDate, InspectionRemarks, ModifiedBy);
        }
        public void UploadDocumentforLiftReturnedInspection(string InspectionId, string InstallationType, string DocumentID,
                                string DocSaveName, string FileName, string FilePath, string CreatedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertInspectionAttachments", InspectionId, InstallationType, DocumentID, DocSaveName, FileName, FilePath, CreatedBy);
        }

        public DataTable ReturnPayment_LiftPeriodic(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnInspectionPayment_LiftPeriodic", InspectionId);
        }
        public DataTable ReturnInstallations_Lift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftInstallationOfInspection", InspectionId);
        }

        public DataTable ReturnInstallations_LiftPeriodic(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftInstallationOfInspectionPeriodic", InspectionId);
        }

        public DataTable ReturnDocuments_Lift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedDocument", InspectionId);
        }
        public DataTable ReturnPayment_Lift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnInspectionPayment_Lift", InspectionId);
        }
        public int InsertReturnEscalatorData(string OldTestReportId, string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent
, string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime DateofErection, string Make, string SerialNo, string TypeofEscalatorErected, string ContractSpeedofEscalatorMtrPrSec
, decimal ContractLoadofEscalatorInKg, string MaxPersonCapacitywithEscalatorOperator, decimal WeightofEscalatorCarwithContractLoadInKg, decimal WeightofCounterWeightInkg
, decimal DepthofPitInmm, decimal TravelDistanceofEscalatorInMtr, decimal NoofFloorsServedInMtr, decimal TotalHeadRoomInmm, string TypeOfControl,
          string MakeMainBreaker,
string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker
, string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker
, string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int RedPhaseYellowPhaseInMohms, int RedPhaseBluePhaseInMohms
, int YellowPhaseBluePhaseInMohms, int RedPhaseEarthWireInMohms, int YellowPhaseEarthWireInMohms, int BluePhaseEarthWirenMohms, string NumberofEarthing
, string EarthingType1, decimal Valueinohms1, string EarthingType2, decimal Valueinohms2, string EarthingType3, decimal Valueinohms3, string EarthingType4,
decimal Valueinohms4, string EarthingType5
, decimal Valueinohms5, string EarthingType6, decimal Valueinohms6, string EarthingType7, decimal Valueinohms7, string EarthingType8, decimal Valueinohms8,
string EarthingType9, decimal Valueinohms9
, string EarthingType10, decimal Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime ContractorLicenseExpiryDate,
string SupervisorName, string SupervisorLicenseNumber, DateTime SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertReturnEscalatorTestReportdata", OldTestReportId, count, IntimationId, NameandAddressofLocalAgent, NameofLocalAgent
, GetValue(AddressofLocalAgent), GetValue(ContactNoofLocalAgent), GetValue(DateofErection), Make, SerialNo, TypeofEscalatorErected, ContractSpeedofEscalatorMtrPrSec
, GetValue(ContractLoadofEscalatorInKg), MaxPersonCapacitywithEscalatorOperator, GetValue(WeightofEscalatorCarwithContractLoadInKg), GetValue(WeightofCounterWeightInkg)
, DepthofPitInmm, GetValue(TravelDistanceofEscalatorInMtr), GetValue(NoofFloorsServedInMtr), GetValue(TotalHeadRoomInmm), TypeOfControl, MakeMainBreaker, TypeMainBreaker, PolesMainBreaker, CurrentRatingInAmps
, BreakingCapacityInKA, MakeRCCBMainBreaker, PolesRCCBMainBreaker, CurrentRCCBRatingInAmps, FaultRCCBCurrentRating, LoadMakeMainBreaker
, LoadTypeMainBreaker, LoadPolesMainBreaker, LoadCurrentRatingInAmps, LoadBreakingCapacityInKA, LoadMakeRCCBMainBreaker, LoadPolesRCCBMainBreaker
, LoadRCCBCurrentRatingInAmps, LoadRCCBFaultCurrentRating, ForWholeInstallation, GetValue(NeutralandPhaseohms), GetValue(EarthandPhasemohms), GetValue(RedPhaseYellowPhaseInMohms), GetValue(RedPhaseBluePhaseInMohms)
, GetValue(YellowPhaseBluePhaseInMohms), GetValue(RedPhaseEarthWireInMohms), GetValue(YellowPhaseEarthWireInMohms), GetValue(BluePhaseEarthWirenMohms), NumberofEarthing
, EarthingType1, Valueinohms1, GetValue(EarthingType2), Valueinohms2, GetValue(EarthingType3), Valueinohms3, GetValue(EarthingType4),
                Valueinohms4, GetValue(EarthingType5), Valueinohms5, GetValue(EarthingType6), Valueinohms6, GetValue(EarthingType7),
                Valueinohms7, GetValue(EarthingType8), Valueinohms8, GetValue(EarthingType9), Valueinohms9, GetValue(EarthingType10),
                Valueinohms10, CreatedBy, ContractorName, ContractorLicenseNumber, ContractorLicenseExpiryDate, SupervisorName, SupervisorLicenseNumber, SupervisorLicenseExpiryDate);
        }

        public DataTable InsertReturnPeriodicLiftData(string TestReportId, string InstallationType, string RegistrationNo, string PreviousChallanDate, string PreviousChallanUpload,  string LastApprovalDate, string ErectionDate, string Make,
  string SerialNo, string TypeOfLift, string TypeOfControl, string Capacity, Decimal Weight, string ApplicantDistrict, string SiteAddress, int InspectionID, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertPeriodicReturnData", TestReportId, InstallationType, RegistrationNo, PreviousChallanDate, PreviousChallanUpload, LastApprovalDate, ErectionDate, Make,
 SerialNo, TypeOfLift, TypeOfControl, Capacity, Weight, ApplicantDistrict, SiteAddress, InspectionID, CreatedBy);
        }

        public DataTable CheckPeridocReturnValue(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicCheckReturnValue", InspectionId);
        }
        ////
        ///

        public DataSet GetTestReportDataIfPeriodic_Lift_EscalatorIfReturned(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodic_Lift_EscalatorIfReturned", Id);
        }

        public DataSet ViewDocuments_ReturnedInspectionLift_Escalator(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedInspectionDocuments_Lift_Escalator", InspectionId);
        }
        public DataSet GetTestReportDataIfPeriodic_Lift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataForPerodic_Lift", Id);
        }
        public DataTable InstallationComponentsforLift_Return(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReportDataLift_Return", Id);
        }
        public DataSet GetDetailsToViewCart_Lift_Escalator_Return(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCart_Lift_Escalator_Return", InspectionId);
        }

        public DataSet ViewTRinMultipleCaseNewReturned_Lift_Escalator(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ViewTRinMultipleCaseNewReturned_Lift_Escalator", InspectionId);
        }

        public DataSet GetEodb_ServiceInformation_Data_Lift_Escalator_OnLoad()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_Lift_Escalator_EODB_ServiceInformation_CountCalculate");
        }

        public DataTable GetPeriodicTestReportHistory(string OldTestReportId,string TestReportId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicTestReportHistory", OldTestReportId, TestReportId);
        }
        public DataSet GetPeriodicViewTRReturned_Lift_Escalator(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicViewTRReturned_Lift_Escalator", InspectionId);
        }

        public DataTable GetReturnedInspectionData(int Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedInspectionData", Id);
        }

        public void UpdateReturnLiftInspection( string TestReportId)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateAttachmentStatus", TestReportId);
        }

        public DataTable CalculateRows(string Typeofinstallation, string IntimationId,string InspectionId, string Count )
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CalculateRows",  Typeofinstallation,   IntimationId, InspectionId, Count);
        }
      

        public DataTable PeriodicCalculateRows(string TestReportId, string InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicCalculateRows", TestReportId, InspectionId);
        }

        public DataSet PeriodicLiftDetailstoPrintFormInspectionDetails(int ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicLiftDetailstoPrintFormInspectionDetails", ID);
        }
        public void InstallationApproval_Lift(string InspectionID, string TestReportId, string InstallationType, string StaffId, string InspectionType, string RegistrationNo, DateTime ChallanDate, string Division, string Make, string LiftSrNo,
   string TypeOfLift, string TypeOfControl, string Capacity, string Weight, DateTime DateOfErection, DateTime LastApprovalDate, string SiteAddress, string District, string MemoNo, string Current_ChallanDate,
   SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_LiftInstallationApproved", transaction.Connection, transaction);

                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                //cmd.Connection = con;
                if (transaction.Connection.State == ConnectionState.Closed)
                {
                    transaction.Connection.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", InspectionID);
                cmd.Parameters.AddWithValue("@Lift_Escelator_Id", TestReportId);
                cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                cmd.Parameters.AddWithValue("@StaffId", StaffId);
                cmd.Parameters.AddWithValue("@InspectionType", InspectionType);
                cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);

                cmd.Parameters.AddWithValue("@Previous_ChallanDate", ChallanDate);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.Parameters.AddWithValue("@Make", Make);
                cmd.Parameters.AddWithValue("@LiftSrNo", LiftSrNo);
                cmd.Parameters.AddWithValue("@TypeOfLift", TypeOfLift);
                cmd.Parameters.AddWithValue("@TypeOfControl", TypeOfControl);
                cmd.Parameters.AddWithValue("@Capacity", Capacity);
                cmd.Parameters.AddWithValue("@Weight", Weight);
                cmd.Parameters.AddWithValue("@ErectionDate", DateOfErection);
                cmd.Parameters.AddWithValue("@LastApprovalDate", LastApprovalDate);
                cmd.Parameters.AddWithValue("@SiteAddress", SiteAddress);
                cmd.Parameters.AddWithValue("@District", District);
                cmd.Parameters.AddWithValue("@MemoNo", MemoNo);
                if (String.IsNullOrEmpty(Current_ChallanDate))
                {
                    cmd.Parameters.AddWithValue("@Current_ChallanDate", DBNull.Value);
                }
                else
                {
                    DateTime transactionDateValue;
                    if (DateTime.TryParse(Current_ChallanDate, out transactionDateValue))
                    {
                        cmd.Parameters.AddWithValue("@Current_ChallanDate", transactionDateValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Current_ChallanDate", DBNull.Value);
                    }
                }

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //throw;
            }
        }
        public void InstallationApproval_Lift_New(string InspectionID, string TestReportId, string InstallationType, string StaffId, string InspectionType, string RegistrationNo, string Division, string Make, string LiftSrNo,
 string TypeOfLift, string TypeOfControl, string Capacity, string Weight, DateTime DateOfErection, string SiteAddress, string District, DateTime Current_ChallanDate,
 SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_LiftInstallationApproved", transaction.Connection, transaction);

                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                //cmd.Connection = con;
                if (transaction.Connection.State == ConnectionState.Closed)
                {
                    transaction.Connection.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", InspectionID);
                cmd.Parameters.AddWithValue("@Lift_Escelator_Id", TestReportId);
                cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                cmd.Parameters.AddWithValue("@StaffId", StaffId);
                cmd.Parameters.AddWithValue("@InspectionType", InspectionType);
                cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.Parameters.AddWithValue("@Make", Make);
                cmd.Parameters.AddWithValue("@LiftSrNo", LiftSrNo);
                cmd.Parameters.AddWithValue("@TypeOfLift", TypeOfLift);
                cmd.Parameters.AddWithValue("@TypeOfControl", TypeOfControl);
                cmd.Parameters.AddWithValue("@Capacity", Capacity);
                cmd.Parameters.AddWithValue("@Weight", Weight);
                cmd.Parameters.AddWithValue("@ErectionDate", DateOfErection);

                cmd.Parameters.AddWithValue("@SiteAddress", SiteAddress);
                cmd.Parameters.AddWithValue("@District", District);
                cmd.Parameters.AddWithValue("@Current_ChallanDate", Current_ChallanDate);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        public void UploadDocumentforLiftReturnedInspectionLift(string InspectionId, string InstallationType, string DocumentID,
                               string DocSaveName, string FileName, string FilePath, string CreatedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertInspectionAttachmentsLift", InspectionId, InstallationType, DocumentID, DocSaveName, FileName, FilePath, CreatedBy);
        }

        public DataSet GetRenewalLiftDataGridOfAllREcords(string Type, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetRenewalLiftDataGridOfAllRecords", Type, CreatedBy);
        }

        public DataTable WorkIntimationDataForSearch(string LoginID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationProjectsWithoutSearch", LoginID);
        }
        public DataSet GetTestReport_Lift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Lift", Id);
        }

        public DataSet ToViewInspectionDetails(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDatails", InspectionId);
        }
        public DataSet ToViewInspectionDetails_InIndustry(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDatails_Industry", InspectionId);
        }
        //Neeraj 9-Jan
        public DataSet GetDistrictForSld(string id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "District_Sld", id);
        }

        //aslam10-Jan

        public DataSet GetDetailsByPanNumberIdLift_IndustryLift(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsByPanNumberIdLift_IndustryLift", PANNumber);
        }


        public void IntimationDataInsertion_New_LiftIndustry(string Id, string ContractorId, string ApplicantTypeCode, string PowerUtility, string PowerUtilityWing, string ZoneName,
 string CircleName, string DivisionName, string SubDivisionName,
 string ContractorType, string NameOfOwner, string NameOfAgency, string ContactNo, string Address, string District, string Pincode,
 string PremisesType, string OtherPremises, string VoltageLevel, string PANNumber, string TypeOfInstallation1, string NumberOfInstallation1, string TypeOfInstallation2, string NumberOfInstallation2,
 string TypeOfInstallation3, string NumberOfInstallation3,
 //string TypeOfInstallation4, string NumberOfInstallation4, string TypeOfInstallation5, string NumberOfInstallation5,
 //string TypeOfInstallation6, string NumberOfInstallation6, string TypeOfInstallation7, string NumberOfInstallation7, string TypeOfInstallation8, string NumberOfInstallation8,
 string Email, string WorkStartDate, string CompletionDate,
 string AnyWorkIssued, string CopyOfWorkOrder, string CompletionDateasPerOrder, string ApplicantType, string CreatedBy, string SanctionLoad, string InspectionType, string TotalCapacity,
 SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_WorkIntimationRegistration_LiftIndustry", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ContractorId", ContractorId);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode", ApplicantTypeCode);     //
            cmd.Parameters.AddWithValue("@ContractorType", ContractorType);
            cmd.Parameters.AddWithValue("@PowerUtility", PowerUtility == "Select" ? DBNull.Value : (object)PowerUtility);        //*
            cmd.Parameters.AddWithValue("@PowerUtilityWing", PowerUtilityWing == "Select" ? DBNull.Value : (object)PowerUtilityWing);//*
            cmd.Parameters.AddWithValue("@ZoneName", ZoneName == "Select" ? DBNull.Value : (object)ZoneName);
            cmd.Parameters.AddWithValue("@CircleName", CircleName == "Select" ? DBNull.Value : (object)CircleName);
            cmd.Parameters.AddWithValue("@DivisionName", DivisionName == "Select" ? DBNull.Value : (object)DivisionName);
            cmd.Parameters.AddWithValue("@SubDivisionName", SubDivisionName == "Select" ? DBNull.Value : (object)SubDivisionName);
            cmd.Parameters.AddWithValue("@NameOfOwner", String.IsNullOrEmpty(NameOfOwner) ? DBNull.Value : (object)NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", String.IsNullOrEmpty(NameOfAgency) ? DBNull.Value : (object)NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@Address", String.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
            cmd.Parameters.AddWithValue("@District", String.IsNullOrEmpty(District) ? DBNull.Value : (object)District);
            cmd.Parameters.AddWithValue("@Pincode", String.IsNullOrEmpty(Pincode) ? DBNull.Value : (object)Pincode);
            cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
            cmd.Parameters.AddWithValue("@OtherPremises", String.IsNullOrEmpty(OtherPremises) ? DBNull.Value : (object)OtherPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@PANNumber", String.IsNullOrEmpty(PANNumber) ? DBNull.Value : (object)PANNumber);
            cmd.Parameters.AddWithValue("@TypeOfInstallation1", TypeOfInstallation1);
            cmd.Parameters.AddWithValue("@NumberOfInstallation1", NumberOfInstallation1);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", String.IsNullOrEmpty(TypeOfInstallation2) ? DBNull.Value : (object)TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@NumberOfInstallation2", String.IsNullOrEmpty(NumberOfInstallation2) ? DBNull.Value : (object)NumberOfInstallation2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", String.IsNullOrEmpty(TypeOfInstallation3) ? DBNull.Value : (object)TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@NumberOfInstallation3", String.IsNullOrEmpty(NumberOfInstallation3) ? DBNull.Value : (object)NumberOfInstallation3);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation4", String.IsNullOrEmpty(TypeOfInstallation4) ? DBNull.Value : (object)TypeOfInstallation4);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation4", String.IsNullOrEmpty(NumberOfInstallation4) ? DBNull.Value : (object)NumberOfInstallation4);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation5", String.IsNullOrEmpty(TypeOfInstallation5) ? DBNull.Value : (object)TypeOfInstallation5);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation5", String.IsNullOrEmpty(NumberOfInstallation5) ? DBNull.Value : (object)NumberOfInstallation5);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation6", String.IsNullOrEmpty(TypeOfInstallation6) ? DBNull.Value : (object)TypeOfInstallation6);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation6", String.IsNullOrEmpty(NumberOfInstallation6) ? DBNull.Value : (object)NumberOfInstallation6);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation7", String.IsNullOrEmpty (TypeOfInstallation7) ? DBNull.Value : (object)TypeOfInstallation7);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation7", String.IsNullOrEmpty(NumberOfInstallation7) ? DBNull.Value : (object)NumberOfInstallation7);
            //cmd.Parameters.AddWithValue("@TypeOfInstallation8", String.IsNullOrEmpty(TypeOfInstallation8) ? DBNull.Value : (object)TypeOfInstallation8);
            //cmd.Parameters.AddWithValue("@NumberOfInstallation8", String.IsNullOrEmpty(NumberOfInstallation8) ? DBNull.Value : (object)NumberOfInstallation8);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@WorkStartDate", WorkStartDate);
            cmd.Parameters.AddWithValue("@CompletionDate", CompletionDate);
            cmd.Parameters.AddWithValue("@AnyWorkIssued", AnyWorkIssued);
            cmd.Parameters.AddWithValue("@CopyOfWorkOrder", String.IsNullOrEmpty(CopyOfWorkOrder) ? DBNull.Value : (object)CopyOfWorkOrder);
            //cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateasPerOrder);
            DateTime CompletionDateForOrder;
            if (DateTime.TryParse(CompletionDateasPerOrder, out CompletionDateForOrder) && CompletionDateForOrder != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateForOrder);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@SanctionLoad", SanctionLoad);
            cmd.Parameters.AddWithValue("@InspectionType", InspectionType);
            cmd.Parameters.AddWithValue("@TotalCapacity", TotalCapacity);
            outputParam = new SqlParameter("@RegistrationID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();

        }



        public void AddInstallations_New_IndustryLift(string IntimationId, string Typeofinstallation, int Noofinstallation, string CreatedBy, string TypeOfInspection, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InstallationsCount_New_IndustryLift", transaction.Connection, transaction);
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //    con.Open();
            //}
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            cmd.Parameters.AddWithValue("@Typeofinstallation", Typeofinstallation);
            cmd.Parameters.AddWithValue("@Noofinstallation", Noofinstallation);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@InspectionType", TypeOfInspection);
            cmd.ExecuteNonQuery();
            //con.Close();
        }


        public int InsertNewLiftData_New_IndustryLift(string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent
        , string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime DateofErection, string TypeofLift, string Make, string SerialNo, string TypeofLiftErected, string ContractSpeedofLiftMtrPrSec
        , decimal ContractLoadofLiftInKg, string MaxPersonCapacitywithLiftOperator, decimal WeightofLiftCarwithContractLoadInKg, decimal WeightofCounterWeightInkg
        , decimal DepthofPitInmm, decimal TravelDistanceofLiftInMtr, decimal NoofFloorsServedInMtr, decimal TotalHeadRoomInmm, string TypeOfControl, decimal NoofSuspensionRopes,
        string DescrptionofSuspensionRopes, decimal SizeofSusspensionRopesInmm, decimal WeightofBeamInkg, decimal SizeofBeamInmm, string MakeMainBreaker,
        string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
        string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker
        , string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
        string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker
        , string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int RedPhaseYellowPhaseInMohms, int RedPhaseBluePhaseInMohms
        , int YellowPhaseBluePhaseInMohms, int RedPhaseEarthWireInMohms, int YellowPhaseEarthWireInMohms, int BluePhaseEarthWirenMohms, string NumberofEarthing
        , string EarthingType1, decimal Valueinohms1, string EarthingType2, decimal Valueinohms2, string EarthingType3, decimal Valueinohms3, string EarthingType4,
        decimal Valueinohms4, string EarthingType5
        , decimal Valueinohms5, string EarthingType6, decimal Valueinohms6, string EarthingType7, decimal Valueinohms7, string EarthingType8, decimal Valueinohms8,
        string EarthingType9, decimal Valueinohms9
        , string EarthingType10, decimal Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime ContractorLicenseExpiryDate,
        string SupervisorName, string SupervisorLicenseNumber, DateTime SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertLiftTestReportdata_New_IndustryLift", count, IntimationId, NameandAddressofLocalAgent, NameofLocalAgent
    , AddressofLocalAgent, ContactNoofLocalAgent, DateofErection, TypeofLift, Make, SerialNo, TypeofLiftErected, ContractSpeedofLiftMtrPrSec
    , ContractLoadofLiftInKg, MaxPersonCapacitywithLiftOperator, WeightofLiftCarwithContractLoadInKg, WeightofCounterWeightInkg
    , DepthofPitInmm, TravelDistanceofLiftInMtr, NoofFloorsServedInMtr, TotalHeadRoomInmm, TypeOfControl, NoofSuspensionRopes, DescrptionofSuspensionRopes
    , SizeofSusspensionRopesInmm, WeightofBeamInkg, SizeofBeamInmm, MakeMainBreaker, TypeMainBreaker, PolesMainBreaker, CurrentRatingInAmps
    , BreakingCapacityInKA, MakeRCCBMainBreaker, PolesRCCBMainBreaker, CurrentRCCBRatingInAmps, FaultRCCBCurrentRating, LoadMakeMainBreaker
    , LoadTypeMainBreaker, LoadPolesMainBreaker, LoadCurrentRatingInAmps, LoadBreakingCapacityInKA, LoadMakeRCCBMainBreaker, LoadPolesRCCBMainBreaker
    , LoadRCCBCurrentRatingInAmps, LoadRCCBFaultCurrentRating, ForWholeInstallation, NeutralandPhaseohms, EarthandPhasemohms, RedPhaseYellowPhaseInMohms, RedPhaseBluePhaseInMohms
    , YellowPhaseBluePhaseInMohms, RedPhaseEarthWireInMohms, YellowPhaseEarthWireInMohms, BluePhaseEarthWirenMohms, NumberofEarthing
    , EarthingType1, Valueinohms1, GetValue(EarthingType2), Valueinohms2, GetValue(EarthingType3), Valueinohms3, GetValue(EarthingType4),
                Valueinohms4, GetValue(EarthingType5), Valueinohms5, GetValue(EarthingType6), Valueinohms6, GetValue(EarthingType7),
                Valueinohms7, GetValue(EarthingType8), Valueinohms8, GetValue(EarthingType9), Valueinohms9, GetValue(EarthingType10),
                Valueinohms10, CreatedBy, ContractorName, ContractorLicenseNumber, ContractorLicenseExpiryDate, SupervisorName, SupervisorLicenseNumber, SupervisorLicenseExpiryDate);
        }



        public int InsertReturnedNewLiftData_New_IndustryLift(string OldTestReportId, string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent
, string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime DateofErection, string TypeofLift, string Make, string SerialNo, string TypeofLiftErected, string ContractSpeedofLiftMtrPrSec
, decimal ContractLoadofLiftInKg, string MaxPersonCapacitywithLiftOperator, decimal WeightofLiftCarwithContractLoadInKg, decimal WeightofCounterWeightInkg
, decimal DepthofPitInmm, decimal TravelDistanceofLiftInMtr, decimal NoofFloorsServedInMtr, decimal TotalHeadRoomInmm, string TypeOfControl, decimal NoofSuspensionRopes,
string DescrptionofSuspensionRopes, decimal SizeofSusspensionRopesInmm, decimal WeightofBeamInkg, decimal SizeofBeamInmm, string MakeMainBreaker,
string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker
, string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker
, string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int RedPhaseYellowPhaseInMohms, int RedPhaseBluePhaseInMohms
, int YellowPhaseBluePhaseInMohms, int RedPhaseEarthWireInMohms, int YellowPhaseEarthWireInMohms, int BluePhaseEarthWirenMohms, string NumberofEarthing
, string EarthingType1, decimal Valueinohms1, string EarthingType2, decimal Valueinohms2, string EarthingType3, decimal Valueinohms3, string EarthingType4,
decimal Valueinohms4, string EarthingType5
, decimal Valueinohms5, string EarthingType6, decimal Valueinohms6, string EarthingType7, decimal Valueinohms7, string EarthingType8, decimal Valueinohms8,
string EarthingType9, decimal Valueinohms9
, string EarthingType10, decimal Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime ContractorLicenseExpiryDate,
string SupervisorName, string SupervisorLicenseNumber, DateTime SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertReturnedLiftTestReportdata_New_IndustryLift", OldTestReportId, count, IntimationId, NameandAddressofLocalAgent, NameofLocalAgent
, AddressofLocalAgent, ContactNoofLocalAgent, DateofErection, TypeofLift, Make, SerialNo, TypeofLiftErected, ContractSpeedofLiftMtrPrSec
, ContractLoadofLiftInKg, MaxPersonCapacitywithLiftOperator, WeightofLiftCarwithContractLoadInKg, WeightofCounterWeightInkg
, DepthofPitInmm, TravelDistanceofLiftInMtr, NoofFloorsServedInMtr, TotalHeadRoomInmm, TypeOfControl, NoofSuspensionRopes, DescrptionofSuspensionRopes
, SizeofSusspensionRopesInmm, WeightofBeamInkg, SizeofBeamInmm, MakeMainBreaker, TypeMainBreaker, PolesMainBreaker, CurrentRatingInAmps
, BreakingCapacityInKA, MakeRCCBMainBreaker, PolesRCCBMainBreaker, CurrentRCCBRatingInAmps, FaultRCCBCurrentRating, LoadMakeMainBreaker
, LoadTypeMainBreaker, LoadPolesMainBreaker, LoadCurrentRatingInAmps, LoadBreakingCapacityInKA, LoadMakeRCCBMainBreaker, LoadPolesRCCBMainBreaker
, LoadRCCBCurrentRatingInAmps, LoadRCCBFaultCurrentRating, ForWholeInstallation, NeutralandPhaseohms, EarthandPhasemohms, RedPhaseYellowPhaseInMohms, RedPhaseBluePhaseInMohms
, YellowPhaseBluePhaseInMohms, RedPhaseEarthWireInMohms, YellowPhaseEarthWireInMohms, BluePhaseEarthWirenMohms, NumberofEarthing
, EarthingType1, Valueinohms1, GetValue(EarthingType2), Valueinohms2, GetValue(EarthingType3), Valueinohms3, GetValue(EarthingType4),
                Valueinohms4, GetValue(EarthingType5), Valueinohms5, GetValue(EarthingType6), Valueinohms6, GetValue(EarthingType7),
                Valueinohms7, GetValue(EarthingType8), Valueinohms8, GetValue(EarthingType9), Valueinohms9, GetValue(EarthingType10),
                Valueinohms10, CreatedBy, ContractorName, ContractorLicenseNumber, ContractorLicenseExpiryDate, SupervisorName, SupervisorLicenseNumber, SupervisorLicenseExpiryDate);
        }



        public int InsertNewEscalatorData_New_IndustryLift(string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent,
string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime? DateofErection, string Make, string SerialNo, string TypeofEscalatorErected, string ContractSpeedofEscalatorMtrPrSec,
decimal? ContractLoadofEscalatorInKg, string MaxPersonCapacitywithEscalatorOperator, decimal? WeightofEscalatorCarwithContractLoadInKg, decimal? WeightofCounterWeightInkg,
decimal? DepthofPitInmm, decimal? TravelDistanceofEscalatorInMtr, decimal? NoofFloorsServedInMtr, decimal? TotalHeadRoomInmm, string TypeOfControl,
string MakeMainBreaker, string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker,
string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker,
string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int? RedPhaseYellowPhaseInMohms, int? RedPhaseBluePhaseInMohms,
int? YellowPhaseBluePhaseInMohms, int? RedPhaseEarthWireInMohms, int? YellowPhaseEarthWireInMohms, int? BluePhaseEarthWirenMohms, string NumberofEarthing,
string EarthingType1, decimal? Valueinohms1, string EarthingType2, decimal? Valueinohms2, string EarthingType3, decimal? Valueinohms3, string EarthingType4,
decimal? Valueinohms4, string EarthingType5,
decimal? Valueinohms5, string EarthingType6, decimal? Valueinohms6, string EarthingType7, decimal? Valueinohms7, string EarthingType8, decimal? Valueinohms8,
string EarthingType9, decimal? Valueinohms9,
string EarthingType10, decimal? Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime? ContractorLicenseExpiryDate,
string SupervisorName, string SupervisorLicenseNumber, DateTime? SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertEscalatorTestReportdata_New_IndustryLift",
                GetValue(count), GetValue(IntimationId), GetValue(NameandAddressofLocalAgent), GetValue(NameofLocalAgent),
                GetValue(AddressofLocalAgent), GetValue(ContactNoofLocalAgent), GetValue(DateofErection), GetValue(Make), GetValue(SerialNo),
                GetValue(TypeofEscalatorErected), GetValue(ContractSpeedofEscalatorMtrPrSec), GetValue(ContractLoadofEscalatorInKg), GetValue(MaxPersonCapacitywithEscalatorOperator),
                GetValue(WeightofEscalatorCarwithContractLoadInKg), GetValue(WeightofCounterWeightInkg), GetValue(DepthofPitInmm), GetValue(TravelDistanceofEscalatorInMtr),
                GetValue(NoofFloorsServedInMtr), GetValue(TotalHeadRoomInmm), GetValue(TypeOfControl), GetValue(MakeMainBreaker), GetValue(TypeMainBreaker),
                GetValue(PolesMainBreaker), GetValue(CurrentRatingInAmps), GetValue(BreakingCapacityInKA), GetValue(MakeRCCBMainBreaker),
                GetValue(PolesRCCBMainBreaker), GetValue(CurrentRCCBRatingInAmps), GetValue(FaultRCCBCurrentRating), GetValue(LoadMakeMainBreaker),
                GetValue(LoadTypeMainBreaker), GetValue(LoadPolesMainBreaker), GetValue(LoadCurrentRatingInAmps), GetValue(LoadBreakingCapacityInKA),
                GetValue(LoadMakeRCCBMainBreaker), GetValue(LoadPolesRCCBMainBreaker), GetValue(LoadRCCBCurrentRatingInAmps), GetValue(LoadRCCBFaultCurrentRating),
                GetValue(ForWholeInstallation), GetValue(NeutralandPhaseohms), GetValue(EarthandPhasemohms), GetValue(RedPhaseYellowPhaseInMohms),
                GetValue(RedPhaseBluePhaseInMohms), GetValue(YellowPhaseBluePhaseInMohms), GetValue(RedPhaseEarthWireInMohms), GetValue(YellowPhaseEarthWireInMohms),
                GetValue(BluePhaseEarthWirenMohms), GetValue(NumberofEarthing), GetValue(EarthingType1), GetValue(Valueinohms1), GetValue(EarthingType2),
                GetValue(Valueinohms2), GetValue(EarthingType3), GetValue(Valueinohms3), GetValue(EarthingType4), GetValue(Valueinohms4), GetValue(EarthingType5),
                GetValue(Valueinohms5), GetValue(EarthingType6), GetValue(Valueinohms6), GetValue(EarthingType7), GetValue(Valueinohms7), GetValue(EarthingType8),
                GetValue(Valueinohms8), GetValue(EarthingType9), GetValue(Valueinohms9), GetValue(EarthingType10), GetValue(Valueinohms10), GetValue(CreatedBy),
                GetValue(ContractorName), GetValue(ContractorLicenseNumber), GetValue(ContractorLicenseExpiryDate), GetValue(SupervisorName),
                GetValue(SupervisorLicenseNumber), GetValue(SupervisorLicenseExpiryDate));
        }



        public int InsertReturnEscalatorData_New_IndustryLift(string OldTestReportId, string count, string IntimationId, string NameandAddressofLocalAgent, string NameofLocalAgent
, string AddressofLocalAgent, string ContactNoofLocalAgent, DateTime DateofErection, string Make, string SerialNo, string TypeofEscalatorErected, string ContractSpeedofEscalatorMtrPrSec
, decimal ContractLoadofEscalatorInKg, string MaxPersonCapacitywithEscalatorOperator, decimal WeightofEscalatorCarwithContractLoadInKg, decimal WeightofCounterWeightInkg
, decimal DepthofPitInmm, decimal TravelDistanceofEscalatorInMtr, decimal NoofFloorsServedInMtr, decimal TotalHeadRoomInmm, string TypeOfControl,
          string MakeMainBreaker,
string TypeMainBreaker, string PolesMainBreaker, string CurrentRatingInAmps, string BreakingCapacityInKA, string MakeRCCBMainBreaker,
string PolesRCCBMainBreaker, string CurrentRCCBRatingInAmps, string FaultRCCBCurrentRating, string LoadMakeMainBreaker
, string LoadTypeMainBreaker, string LoadPolesMainBreaker, string LoadCurrentRatingInAmps, string LoadBreakingCapacityInKA,
string LoadMakeRCCBMainBreaker, string LoadPolesRCCBMainBreaker
, string LoadRCCBCurrentRatingInAmps, string LoadRCCBFaultCurrentRating, string ForWholeInstallation, string NeutralandPhaseohms, string EarthandPhasemohms, int RedPhaseYellowPhaseInMohms, int RedPhaseBluePhaseInMohms
, int YellowPhaseBluePhaseInMohms, int RedPhaseEarthWireInMohms, int YellowPhaseEarthWireInMohms, int BluePhaseEarthWirenMohms, string NumberofEarthing
, string EarthingType1, decimal Valueinohms1, string EarthingType2, decimal Valueinohms2, string EarthingType3, decimal Valueinohms3, string EarthingType4,
decimal Valueinohms4, string EarthingType5
, decimal Valueinohms5, string EarthingType6, decimal Valueinohms6, string EarthingType7, decimal Valueinohms7, string EarthingType8, decimal Valueinohms8,
string EarthingType9, decimal Valueinohms9
, string EarthingType10, decimal Valueinohms10, string CreatedBy, string ContractorName, string ContractorLicenseNumber, DateTime ContractorLicenseExpiryDate,
string SupervisorName, string SupervisorLicenseNumber, DateTime SupervisorLicenseExpiryDate)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(),
                "sp_InsertReturnEscalatorTestReportdata_New_IndustryLift", OldTestReportId, count, IntimationId, NameandAddressofLocalAgent, NameofLocalAgent
, GetValue(AddressofLocalAgent), GetValue(ContactNoofLocalAgent), GetValue(DateofErection), Make, SerialNo, TypeofEscalatorErected, ContractSpeedofEscalatorMtrPrSec
, GetValue(ContractLoadofEscalatorInKg), MaxPersonCapacitywithEscalatorOperator, GetValue(WeightofEscalatorCarwithContractLoadInKg), GetValue(WeightofCounterWeightInkg)
, DepthofPitInmm, GetValue(TravelDistanceofEscalatorInMtr), GetValue(NoofFloorsServedInMtr), GetValue(TotalHeadRoomInmm), TypeOfControl, MakeMainBreaker, TypeMainBreaker, PolesMainBreaker, CurrentRatingInAmps
, BreakingCapacityInKA, MakeRCCBMainBreaker, PolesRCCBMainBreaker, CurrentRCCBRatingInAmps, FaultRCCBCurrentRating, LoadMakeMainBreaker
, LoadTypeMainBreaker, LoadPolesMainBreaker, LoadCurrentRatingInAmps, LoadBreakingCapacityInKA, LoadMakeRCCBMainBreaker, LoadPolesRCCBMainBreaker
, LoadRCCBCurrentRatingInAmps, LoadRCCBFaultCurrentRating, ForWholeInstallation, GetValue(NeutralandPhaseohms), GetValue(EarthandPhasemohms), GetValue(RedPhaseYellowPhaseInMohms), GetValue(RedPhaseBluePhaseInMohms)
, GetValue(YellowPhaseBluePhaseInMohms), GetValue(RedPhaseEarthWireInMohms), GetValue(YellowPhaseEarthWireInMohms), GetValue(BluePhaseEarthWirenMohms), NumberofEarthing
, EarthingType1, Valueinohms1, GetValue(EarthingType2), Valueinohms2, GetValue(EarthingType3), Valueinohms3, GetValue(EarthingType4),
                Valueinohms4, GetValue(EarthingType5), Valueinohms5, GetValue(EarthingType6), Valueinohms6, GetValue(EarthingType7),
                Valueinohms7, GetValue(EarthingType8), Valueinohms8, GetValue(EarthingType9), Valueinohms9, GetValue(EarthingType10),
                Valueinohms10, CreatedBy, ContractorName, ContractorLicenseNumber, ContractorLicenseExpiryDate, SupervisorName, SupervisorLicenseNumber, SupervisorLicenseExpiryDate);
        }



        public void InsertInspectionDataNewCode_New_IndustryLift(string ContactNo, string ApplicantTypeCode, string IntimationId, string ApplicantType, string InstallationType,
 string District, string Division, string PaymentMode, string InspectionRemarks, string CreatedBy,
 decimal TotalAmount, string para_Assigned, string transcationId, string TranscationDate, int InspectID,
 int ServiceType, SqlTransaction transaction
 )
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionData_NewCodeForMultiple_New_IndustryLift", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactNo ", String.IsNullOrEmpty(ContactNo) ? DBNull.Value : (object)ContactNo);
            cmd.Parameters.AddWithValue("@ApplicantTypeCode ", ApplicantTypeCode);
            cmd.Parameters.AddWithValue("@IntimationId ", IntimationId);
            //cmd.Parameters.AddWithValue("@Inspectiontype ", Inspectiontype);
            cmd.Parameters.AddWithValue("@ApplicantType ", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType ", InstallationType);
            cmd.Parameters.AddWithValue("@District ", District);
            cmd.Parameters.AddWithValue("@Division ", Division);
            cmd.Parameters.AddWithValue("@PaymentMode ", PaymentMode);
            cmd.Parameters.AddWithValue("@InspectionRemarks ", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy ", CreatedBy);
            cmd.Parameters.AddWithValue("@TransactionId ", transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@AssignTo", para_Assigned);
            cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
            outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
        }



        public string InsertPeriodicLiftData_IndustryLift(string InstallationType, string RegistrationNo, string PreviousChallanDate, string PreviousChallanUpload, string LastApprovalDate, string ErectionDate, string Make,
string SerialNo, string TypeOfLift, string TypeOfControl, string Capacity, Decimal Weight, string ApplicantDistrict, string SiteAddress, string CreatedBy, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertPeriodicLiftData_IndustryLift", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
            cmd.Parameters.AddWithValue("@PreviousChallanDate", PreviousChallanDate);
            cmd.Parameters.AddWithValue("@PreviousChallanUpload", PreviousChallanUpload);
            cmd.Parameters.AddWithValue("@LastApprovalDate", LastApprovalDate);
            cmd.Parameters.AddWithValue("@ErectionDate", ErectionDate);
            cmd.Parameters.AddWithValue("@Make", Make);
            cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
            cmd.Parameters.AddWithValue("@TypeOfLift", TypeOfLift);
            cmd.Parameters.AddWithValue("@TypeOfControl", TypeOfControl);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@ApplicantDistrict", ApplicantDistrict);
            cmd.Parameters.AddWithValue("@SiteAddress", SiteAddress);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlParameter outputParam = new SqlParameter("@GeneratedTestReportID", SqlDbType.NVarChar, 50);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            // Execute the command
            cmd.ExecuteNonQuery();
            string TRID = cmd.Parameters["@GeneratedTestReportID"].Value.ToString();
            return TRID;
        }


        public DataTable InsertReturnPeriodicLiftData_IndustryLift(string TestReportId, string InstallationType, string RegistrationNo, string PreviousChallanDate, string PreviousChallanUpload, string LastApprovalDate, string ErectionDate, string Make,
string SerialNo, string TypeOfLift, string TypeOfControl, string Capacity, Decimal Weight, string ApplicantDistrict, string SiteAddress, int InspectionID, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertPeriodicReturnData_IndustryLift", TestReportId, InstallationType, RegistrationNo, PreviousChallanDate, PreviousChallanUpload, LastApprovalDate, ErectionDate, Make,
 SerialNo, TypeOfLift, TypeOfControl, Capacity, Weight, ApplicantDistrict, SiteAddress, InspectionID, CreatedBy);
        }




        public string InsertInspectionDataForPeriodic_LiftInspection_IndustryLift(string ApplicantType, string InstallationType, string District, string Division,
string PaymentMode, string InspectionRemarks, string CreatedBy, decimal TotalAmount, string para_Assigned,
string transcationId, string TranscationDate, int InspectID, int ServiceType, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertInspectionDataForPeriodic_LiftInspection_IndustryLift", transaction.Connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ApplicantType", ApplicantType);
            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@Division", Division);
            cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
            cmd.Parameters.AddWithValue("@InspectionRemarks", InspectionRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@TransactionId", String.IsNullOrEmpty(transcationId) ? DBNull.Value : (object)transcationId);
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            cmd.Parameters.AddWithValue("@AssignTo", para_Assigned);
            //cmd.Parameters.AddWithValue("@TransctionDate", TranscationDate);
            if (String.IsNullOrEmpty(TranscationDate))
            {
                cmd.Parameters.AddWithValue("@TransctionDate", DBNull.Value);
            }
            else
            {
                DateTime transactionDateValue;
                if (DateTime.TryParse(TranscationDate, out transactionDateValue))
                {
                    cmd.Parameters.AddWithValue("@TransctionDate", transactionDateValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TransctionDate", DBNull.Value);
                }
            }
            cmd.Parameters.AddWithValue("@InspectID", InspectID);
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);

            SqlParameter outputParam = new SqlParameter("@GeneratedCombinedIdDetails", SqlDbType.NVarChar, 500);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            // Execute the command
            cmd.ExecuteNonQuery();
            string k = cmd.Parameters["@GeneratedCombinedIdDetails"].Value.ToString();
            return k;

        }


        public DataSet IntimationDataforSiteOwner_IndustryLift(string UserId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftIntimationsForSiteOwner_IndustryLift", UserId);
        }


        public DataTable GetInstllationsforSitOwner_IndustryLift(string IntimationId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationsForSiteOwner_IndustryLift", IntimationId);
        }


        public DataTable InsertNewLiftAttachments_IndustryLift(string InstallationType, string DocumentID, string DocSaveName, string FileName, string FilePath, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertLiftNewAttachments_IndustryLift", InstallationType, int.Parse(DocumentID), DocSaveName, FileName, FilePath, CreatedBy);
        }


        public void UpdateReturnLiftInspection_IndustryLift(string TestReportId)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateAttachmentStatus_IndustryLift", TestReportId);
        }

        public DataTable GetDocumentforlift_IndustryLift(string Applicanttype)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentsForLift_IndustryLift", Applicanttype);
        }


        public void UpdateInstallations_IndustryLift(string Id, string IntimationId)
        {
            SqlCommand cmd = new SqlCommand("sp_CheckTestReportHistory_IndustryLift");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id ", Id);
            cmd.Parameters.AddWithValue("@IntimationId", IntimationId);
            cmd.ExecuteNonQuery();
            con.Close();

        }




        public DataSet SiteIntimations_forLift_IndustryLift(string PANNumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSiteOwner_Lift_IndustryLift", PANNumber);
        }


        public DataSet SiteOwnerInstallations_Lift_IndustryLift(string IntimationId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInstallationForSiteOwner_Lift_IndustryLift", IntimationId);
        }

        public DataTable DeleteduplicateHistory_IndustryLift(string IntimationId, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDuplicacy_IndustryLift", IntimationId, CreatedBy);
        }

        public void InsertPaymentHistory_Lift_IndustryLift(string IntimationId, int count, int InstallationTypeId, string CreatedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "update_InstallationHistory_NewInspection_IndustryLift", IntimationId, count, InstallationTypeId, CreatedBy);
        }


        public DataTable DeletePaymentHistory_IndustryLift(string IntimationId, int count, int InstallationTypeId, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DeletePaymentHistory_IndustryLift", IntimationId, count, InstallationTypeId, CreatedBy);
        }


        public DataTable GetDocumentlistfornewInspection_Lift_IndustryLift(string ApplicantType, int InstallationTypeID, string InspectionType, int inspectionIdPrm)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDocumentsForNewMultipleInspection_Lift_IndustryLift", ApplicantType, InstallationTypeID, InspectionType, inspectionIdPrm);
        }

        public DataTable Payment_Lift_IndustryLift(string selectedTypeIds, int? LiftQaunatity, int? EscaltorQaunatity)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_LiftEscaltor_New_IndustryLift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InspectionType", "New");
                command.Parameters.AddWithValue("@InstallationTypeIds", selectedTypeIds);
                command.Parameters.AddWithValue("@QuantityLift", LiftQaunatity == 0 ? null : LiftQaunatity);
                command.Parameters.AddWithValue("@QuantityEscalator", EscaltorQaunatity == 0 ? null : EscaltorQaunatity);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }


        public DataSet ToGetStaffIdforPeriodic_IndustryLift(string Division, string Staff, string District)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffIdforPeriodic_IndustryLift", Division, Staff, District);
        }

        public DataSet DetailstoPrintFormInspectionDetails_IndustryLift(int ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionDetailsforPrintForm_IndustryLift", ID);
        }


        public DataSet GetAttachmentsDatainInspectionForm_IndustryLift(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachmentsinInspectionForm_IndustryLift", InspectionId);
        }

        public DataTable SiteOwnerReturnedInspection_IndustryLift(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerReturnedInspection_IndustryLift", SiteOwnerId);
        }


        public DataTable ReturnPayment_Lift_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnInspectionPayment_Lift_IndustryLift", InspectionId);
        }

        public DataTable ReturnInstallations_Lift_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftInstallationOfInspection_IndustryLift", InspectionId);
        }

        public DataTable ReturnPayment_LiftPeriodic_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnInspectionPayment_LiftPeriodic_IndustryLift", InspectionId);
        }


        public DataTable ReturnInstallations_LiftPeriodic_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftInstallationOfInspectionPeriodic_IndustryLift", InspectionId);
        }


        public DataTable GetReturnedInspectionData_IndustryLift(int Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedInspectionData_IndustryLift", Id);
        }

        public DataTable ReturnDocuments_Lift_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedDocument_IndustryLift", InspectionId);
        }

        public DataTable CalculateRows_IndustryLift(string Typeofinstallation, string IntimationId, string InspectionId, string Count)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CalculateRows_IndustryLift", Typeofinstallation, IntimationId, InspectionId, Count);
        }

        public DataTable PeriodicCalculateRows_IndustryLift(string TestReportId, string InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicCalculateRows_IndustryLift", TestReportId, InspectionId);
        }

        public void UploadDocumentforLiftReturnedInspectionLift_IndustryLift(string InspectionId, string InstallationType, string DocumentID,
                       string DocSaveName, string FileName, string FilePath, string CreatedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InsertInspectionAttachmentsLift_IndustryLift", InspectionId, InstallationType, DocumentID, DocSaveName, FileName, FilePath, CreatedBy);
        }


        public DataTable CheckReturnValue_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckReturnValue_IndustryLift", InspectionId);
        }

        public DataTable CheckPeridocReturnValue_IndustryLift(int InspectionId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicCheckReturnValue_IndustryLift", InspectionId);
        }

        public void UpdateReturnLiftInspection_IndustryLift(int InspectionId, string TransactionId, DateTime TransactionDate, string InspectionRemarks, string ModifiedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateReturnLiftInspection_IndustryLift", InspectionId, TransactionId, TransactionDate, InspectionRemarks, ModifiedBy);
        }

        public void UpdateReturnLiftInspectionPeriodicStatus_IndustryLift(int InspectionId)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UpdateReturnPeriodicStatus_IndustryLift", InspectionId);
        }

        public DataTable SiteOwnerReturnedInspection_Periodic_IndustryLift(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerReturnedInspection_Periodic_IndustryLift", SiteOwnerId);
        }



        public DataSet GetRenewalLiftDataGridOfAllREcords_IndustryLift(string Type, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetRenewalLiftDataGridOfAllRecords_IndustryLift", Type, CreatedBy);
        }


        public DataTable GetDocumentsForLiftRenewal_IndustryLift(string ApplicantType, int InstallationTypeID, string InspectionType, string InstallationType)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentsForLiftRenewal_IndustryLift", ApplicantType, InstallationTypeID, InspectionType, InstallationType);
        }

        public void UploadDocumentforLiftPeriodic_IndustryLift(string TRID, string RegistrationNo, string InstallationType, string DocumentID, string DocSaveName, string FileName, string FilePath, string CreatedBy, SqlTransaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertLiftPeriodicAttachments_IndustryLift", transaction.Connection, transaction))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TestReportId", TRID);
                        cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                        cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                        cmd.Parameters.AddWithValue("@DocumentID", DocumentID);
                        cmd.Parameters.AddWithValue("@DocSaveName", DocSaveName);
                        cmd.Parameters.AddWithValue("@FileName", FileName);
                        cmd.Parameters.AddWithValue("@FilePath", FilePath);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        //con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        public DataSet GetRenewalLiftData_IndustryLift(string Type, string RegistrationNo, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetPeriodicRenewalData_IndustryLift", Type, RegistrationNo, CreatedBy);
        }


        public DataTable SiteOwnerInspectionData_IndustryLift(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistory_IndustryLift", SiteOwnerId);
        }

        public DataSet InspectionData_Lift_Escalator_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetInspectionData_Lift_Escalator_IndustryLift", Id);
        }


        public DataSet ViewDocuments_ReturnedInspectionLift_Escalator_IndustryLift(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetReturnedInspectionDocuments_Lift_Escalator_IndustryLift", InspectionId);
        }

        public DataSet GetDetailsToViewTRinMultipleCaseNew_IndustryLift(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewMultipleInspectionTR_IndustryLift", InspectionId);
        }


        public DataSet GetTestReport_Lift_Escalator_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetTestReport_Lift_Escalator_IndustryLift", Id);
        }


        public DataSet GetDetailsToViewCart_Lift_Escalator_IndustryLift(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsToViewCart_Lift_Escalator_IndustryLift", InspectionId);
        }


        public DataSet ApprovalData_Lift_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DataForApproval_Lift_IndustryLift", Id);
        }



        public DataTable SiteOwnerInspectionData_Periodic_IndustryLift(string SiteOwnerId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_SiteOwnerInspectionHistory_Periodic_IndustryLift", SiteOwnerId);
        }


        public DataSet PeriodicLiftDetailstoPrintFormInspectionDetails_IndustryLift(int ID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_PeriodicLiftDetailstoPrintFormInspectionDetails_IndustryLift", ID);
        }


        public DataSet GetAttachmentsDatainInspectionForm_Periodic_IndustryLift(string InspectionId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachmentsinInspectionForm_Periodic_IndustryLift", InspectionId);
        }


        public DataSet ApprovalData_Lift_Periodic_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DataForApproval_Lift_Periodic_IndustryLift", Id);
        }


        public DataSet TohandleUncheckedCheckbox_IndustryLift(string RegistrationNo, string CreatedBy)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "SP_TohandleUncheckedCheckbox", RegistrationNo, CreatedBy);
        }

        public DataTable CheckDuplicacyInLift_IndustryLift(string RegistrationNo, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_CheckDuplicacyInLift_IndustryLift", RegistrationNo, CreatedBy);
        }

        public void Update_LiftRenewalPeriodicInspection_IndustryLift(string RegistrationNo, int InstallationTypeId, string CreatedBy)
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "update_LiftRenewal_PeriodicInspection_IndustryLift", RegistrationNo, InstallationTypeId, CreatedBy);
        }


        public DataTable GetDocumentforLiftPeriodicRenewal_IndustryLift()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentforLiftPeriodicRenewal_IndustryLift");
        }


        public DataTable Payment_LiftPeriodic_IndustryLift(string selectedTypeIds, int? LiftQaunatity, int? EscaltorQaunatity, int? LiftCountForPayment, int? EscalatorCountForPayment)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Calculate_InspectionPayment_Amount_LiftEscaltor_Periodic_IndustryLift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InspectionType", "Periodic");
                command.Parameters.AddWithValue("@InstallationTypeIds", selectedTypeIds);
                command.Parameters.AddWithValue("@QuantityLift", LiftQaunatity == 0 ? null : LiftQaunatity);
                command.Parameters.AddWithValue("@QuantityEscalator", EscaltorQaunatity == 0 ? null : EscaltorQaunatity);
                command.Parameters.AddWithValue("@LiftCountForPayment", LiftCountForPayment == 0 ? null : LiftCountForPayment);
                command.Parameters.AddWithValue("@EscalatorCountForPayment", EscalatorCountForPayment == 0 ? null : EscalatorCountForPayment);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }

            return result;
        }



        public DataTable Get_DocumentGridwithOutChallan_IndustryLift()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Get_DocumentGridwithOutChallan_IndustryLift");
        }


        public DataSet GetDivisionByDistrict_IndustryLift(string AreaCovered)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetDivisionByDistrict_IndustryLift", AreaCovered);
        }


        public DataSet GetApplicantTypeForLift_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetApplicantTypeForLift_IndustryLift", Id);
        }



        public DataTable GetDataForLiftRenewal_IndustryLift(string District, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_GetLiftRenewaldata_IndustryLift", District, CreatedBy);
        }



        public DataTable UpdateLiftTestReportHistory_IndustryLift(string Type, string ID, string count, string CreatedBy)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_LiftTestReportApproval_IndustryLift", Type, ID, count, CreatedBy);
        }


        public DataSet GetLiftTestReportModalData_IndustryLift(string Type, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetLiftEscalatorDataForSiteowner_IndustryLift", Type, TestReportId);
        }

        public DataTable GetAttachments_IndustryLift(string TestReportId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetAttachments_IndustryLift", TestReportId);
        }


        public DataSet GetSiteOwnerDataInPeriodicOfLift_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerDataInPeriodicOfLift_IndustryLift", Id);
        }

        public DataSet GetDetailsOfLiftRenewalReport_IndustryLift(string RegistrationNo, string TestReportID)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDetailsOfLiftRenewalReport_IndustryLift", RegistrationNo, TestReportID);
        }


        public DataTable GetDocumentOfLiftRenewalToShow_IndustryLift(string TestReportId)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetDocumentOfLiftRenewalToShow_IndustryLift", TestReportId);
        }

        public DataSet GetSiteOwnerDataInPeriodicOfLift_AtOfficerEnd_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetSiteOwnerDataInPeriodicOfLift_AtOfficerEnd_IndustryLift", Id);
        }

        public DataSet PrintDetailsFor_LiftCertificate_IndustryLift(string InspectionId, string TestReportId)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_ApproveCertificate_Lift_Escelator_IndustryLift", InspectionId, TestReportId);
        }

        public DataSet getDataforLift_IndustryLift(string Id)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDataForLift_IndustryLift", Id);
        }
        //
    }
}


