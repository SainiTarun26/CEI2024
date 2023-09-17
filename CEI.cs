using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Globalization;
using CEI_PRoject.Admin;
using System.Xml.Linq;

namespace CEI_PRoject
{
    public class CEI
    {
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
            cmd.ExecuteNonQuery();
            int k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
            cmd.Dispose();
            con.Close();
            return k;
        }
        #endregion
        #region Insert Intimtion Data
        public void IntimationDataInsertion(string ContractorId, string ContractorType, string NameOfOwner, string NameOfAgency, string ContactNo, string Address, string Pincode,
string PremisesType, string OtherPremises, string VoltageLevel, string TypeOfInstallation1, string NumberOfInstallation1, string TypeOfInstallation2,string NumberOfInstallation2,
string TypeOfInstallation3, string NumberOfInstallation3, string TypeOfInstallation4, string NumberOfInstallation4, string TypeOfInstallation5, string NumberOfInstallation5, 
string TypeOfInstallation6, string NumberOfInstallation6,string TypeOfInstallation7, string NumberOfInstallation7, string TypeOfInstallation8, string NumberOfInstallation8,
string Email, string WorkStartDate, string CompletionDate,
string AnyWorkIssued, string CopyOfWorkOrder, string CompletionDateasPerOrder, string CreatedBy)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sqlProc = "sp_WorkIntimationRegistration";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //AdvNo = (string)ViewState["AdvNo"];
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlProc;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ContractorId", ContractorId);
            cmd.Parameters.AddWithValue("@ContractorType", ContractorType);
            cmd.Parameters.AddWithValue("@NameOfOwner", NameOfOwner);
            cmd.Parameters.AddWithValue("@NameOfAgency", NameOfAgency);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Pincode", Pincode);
            cmd.Parameters.AddWithValue("@PremisesType", PremisesType);
            cmd.Parameters.AddWithValue("@OtherPremises", OtherPremises);
            cmd.Parameters.AddWithValue("@VoltageLevel", VoltageLevel);
            cmd.Parameters.AddWithValue("@TypeOfInstallation1", TypeOfInstallation1);
            cmd.Parameters.AddWithValue("@NumberOfInstallation1", NumberOfInstallation1);
            cmd.Parameters.AddWithValue("@TypeOfInstallation2", TypeOfInstallation2);
            cmd.Parameters.AddWithValue("@NumberOfInstallation2", NumberOfInstallation2);
            cmd.Parameters.AddWithValue("@TypeOfInstallation3", TypeOfInstallation3);
            cmd.Parameters.AddWithValue("@NumberOfInstallation3", NumberOfInstallation3);
            cmd.Parameters.AddWithValue("@TypeOfInstallation4", TypeOfInstallation4);
            cmd.Parameters.AddWithValue("@NumberOfInstallation4", NumberOfInstallation4);
            cmd.Parameters.AddWithValue("@TypeOfInstallation5", TypeOfInstallation5);
            cmd.Parameters.AddWithValue("@NumberOfInstallation5", NumberOfInstallation5);
            cmd.Parameters.AddWithValue("@TypeOfInstallation6", TypeOfInstallation6);
            cmd.Parameters.AddWithValue("@NumberOfInstallation6", NumberOfInstallation6);
            cmd.Parameters.AddWithValue("@TypeOfInstallation7", TypeOfInstallation7);
            cmd.Parameters.AddWithValue("@NumberOfInstallation7", NumberOfInstallation7);
            cmd.Parameters.AddWithValue("@TypeOfInstallation8", TypeOfInstallation8);
            cmd.Parameters.AddWithValue("@NumberOfInstallation8", NumberOfInstallation8);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@WorkStartDate", WorkStartDate);
            cmd.Parameters.AddWithValue("@CompletionDate", CompletionDate);
            cmd.Parameters.AddWithValue("@AnyWorkIssued", AnyWorkIssued);
            cmd.Parameters.AddWithValue("@CopyOfWorkOrder", CopyOfWorkOrder);
            cmd.Parameters.AddWithValue("@CompletionDateasPerOrder", CompletionDateasPerOrder);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
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
        #endregion
        #region Insert Supervisor Data
        public void InserSupervisorData(string REID, string Name, string Age, string FatherName, string Address, string District, string State, string PinCode, string PhoneNo,
      string Qualification, string Email, string CertificateOld, string CertificateNew, string DateofIntialissue, string DateofExpiry,
      string DateofRenewal, string votagelevel, string voltageWithEffect, string AnyContractor, string AttachedContractorld,
    string CreatedBy, string UserId, string IPAddress)
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

            cmd.Parameters.AddWithValue("@REID", REID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@FatherName", FatherName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@PinCode", PinCode);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CertificateOld", CertificateOld);
            cmd.Parameters.AddWithValue("@CertificateNew", CertificateNew);
            cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            cmd.Parameters.AddWithValue("@votagelevel", votagelevel);
            cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect);
            cmd.Parameters.AddWithValue("@AnyContractor", AnyContractor);
            cmd.Parameters.AddWithValue("@AttachedContractorld", AttachedContractorld);
            cmd.Parameters.AddWithValue("@Category", "Supervisor");
            cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
            cmd.Parameters.AddWithValue("@UserId", UserId);

            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Wireman Data
        public void InserWireManData(string REID, string Name, string Age, string FatherName, string Address, string District, string State, string PinCode, string PhoneNo,
      string Qualification, string Email, string CertificateOld, string CertificateNew, string DateofIntialissue, string DateofExpiry,
      string DateofRenewal, string AnyContractor, string AttachedContractorld,
    string CreatedBy, string UserId, string IPAddress)
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

            cmd.Parameters.AddWithValue("@REID", REID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@FatherName", FatherName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@PinCode", PinCode);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CertificateOld", CertificateOld);
            cmd.Parameters.AddWithValue("@CertificateNew", CertificateNew);
            cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            cmd.Parameters.AddWithValue("@AnyContractor", AnyContractor);
            cmd.Parameters.AddWithValue("@AttachedContractorld", AttachedContractorld);
            cmd.Parameters.AddWithValue("@Category", "Wireman");
            cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
            cmd.Parameters.AddWithValue("@UserId", UserId);

            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region Insert Contractor Data
        public void InsertContractorData(string ContractorID, string UserId, string Name, string FatherName, string FirmName, string GSTNumber, string RegisteredOffice,
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
            cmd.Parameters.AddWithValue("@ContractorID", ContractorID);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@FatherName", FatherName);
            cmd.Parameters.AddWithValue("@FirmName", FirmName);
            cmd.Parameters.AddWithValue("@GSTNumber", GSTNumber);
            cmd.Parameters.AddWithValue("@RegisteredOffice", RegisteredOffice);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Districtoffirm", Districtoffirm);
            cmd.Parameters.AddWithValue("@PinCode", PinCode);
            cmd.Parameters.AddWithValue("@BranchOffice", BranchOffice);
            cmd.Parameters.AddWithValue("@BranchState", BranchState);
            cmd.Parameters.AddWithValue("@BranchDistrictoffirm", BranchDistrictoffirm);
            cmd.Parameters.AddWithValue("@BranchPinCode", BranchPinCode);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue);
            cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal);
            cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry);
            cmd.Parameters.AddWithValue("@votagelevel", votagelevel);
            cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect);
            cmd.Parameters.AddWithValue("@LicenceOld", LicenceOld);
            cmd.Parameters.AddWithValue("@LicenceNew", LicenceNew);
            cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

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
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_getDistrictForDropdownState",  State);
        }
        #endregion
        public DataSet GetddlPremises()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_Premises");
        } 
        public DataSet GetddlAssignedWorkForSupervisor()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_WorkDetail");
        }
        public DataSet GetddlInstallationType()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_InstallatioType");
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


        public DataTable GetContractorDataforgrid(string loginType, string ID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetContractorData", loginType, ID);
        }

        public DataTable GetWiremanorSuperwiserData(string category, string loginType, string ID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetWiremanorSuperwiserData", category,loginType, ID);
        } 
        public DataTable WorkIntimationData(string LoginID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationProjects", LoginID);
        }
        public DataTable GetStaffAssignedToContractor(string ID)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetStaffAssignedtoContractor", ID);
        }
        public DataSet GetddlVoltageForLine()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_LineVoltage");
        }
        public DataTable WorkIntimationDataforAdmin()
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_WorkIntimationProjectsforAdmin");
        } 
        public DataTable WorkIntimationDataforSupervisor(string Id)
        {
            return DBTask.ExecuteDataTable(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_GetIntimationsForSupervisor", Id);
        }
        public int SetDataInStaffAssined(string REID, string projectId, string AssignBy)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_setDataInStaffAssined", REID, projectId, AssignBy);
        }
        public int updateUserRegistration(int registrationId)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "Sp_updateUserRegistration", registrationId);
        }

        public int UserDocuments(string REID, string flpPhotourl8,string flpPhotourl, string flpPhotourl1, string flpPhotourl2, string flpPhotourl3, string flpPhotourl4, string flpPhotourl5,string flpPhotourl9, string flpPhotourl6, string flpPhotourl7)
        {
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_UserDocuments", REID, flpPhotourl8,flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl9, flpPhotourl6, flpPhotourl7);
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
            return DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_DropUserRegistration" , registrationId);
        }

        public DataSet checkGSTexist(string GSTnumber)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_checkGST", GSTnumber);
        }

        public DataSet checkLicenceexist(string LicenceNew, string LicenceOld)
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_checkLicence", LicenceNew, LicenceOld);
        }
    }
}