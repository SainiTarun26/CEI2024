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
          #region Insert Line Data
        public void InsertLineData(string SanctionLoadContractDemad, string LineVoltage, string LineLength, string LineType, string NoOfCircuit,
            string Conductortype, string NumberofPoleTower, string ConductorSize, string GroundWireSize, string NmbrofRailwayCrossing, 
            string NmbrofRoadCrossing, string NmbrofRiverCanalCrossing, string NmbrofPowerLineCrossing, string NmbrofEarthing, string EarthingType1, 
            string Valueinohms1, string EarthingType2, string Valueinohms2, string EarthingType3, string Valueinohms3, string EarthingType4, string Valueinohms4, string EarthingType5, string Valueinohms5, string
EarthingType6, string Valueinohms6, string EarthingType7, string Valueinohms7, string EarthingType8, string Valueinohms8, string EarthingType9, string Valueinohms9, string EarthingType10, string
Valueinohms10, string EarthingType11, string Valueinohms11, string EarthingType12, string Valueinohms12, string EarthingType13, string Valueinohms13, string EarthingType14, string Valueinohms14, string
EarthingType15, string Valueinohms15, string NoofPoleTowerForOverheadCable, string CableSize, string RailwayCrossingNoForOC, string RoadCrossingNoForOC,
            string RiverCanalCrossingNoForOC, string PowerLineCrossingNoForOc, string RedPhaseEarthWire, string YellowPhaseEarth, 
            string BluePhaseEarthWire, string RedPhaseYellowPhase, string RedPhaseBluePhase, string BluePhaseYellowPhase, string PhasewireNeutralwire,
            string PhasewireEarth, string NeutralwireEarth, string TypeofCable, string SizeofCable, string Cablelaidin, 
            string RedPhaseEarthWirefor440orAbove, string YellowPhaseEarthWire440orAbove, string BluePhaseEarthWire440orAbove, 
            string RedPhaseYellowPhase440orAbove, string RedPhaseBluePhase440orAbove, string BluePhaseYellowPhase440orAbove, 
            string PhasewireNeutralwire220OrAbove, string PhasewireEarth220OrAbove, string NeutralwireEarth220OrAbove
)
        {            SqlCommand cmd = new SqlCommand("sp_InserLineData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con.Open();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SanctionLoadContractDemad", SanctionLoadContractDemad);
            cmd.Parameters.AddWithValue("@LineVoltage", LineVoltage);
            cmd.Parameters.AddWithValue("@LineLength", LineLength);
            cmd.Parameters.AddWithValue("@LineType", LineType);
            cmd.Parameters.AddWithValue("@NoOfCircuit", NoOfCircuit);
            cmd.Parameters.AddWithValue("@Conductortype", Conductortype);
            cmd.Parameters.AddWithValue("@NumberofPoleTower", NumberofPoleTower);
            cmd.Parameters.AddWithValue("@ConductorSize", ConductorSize);
            cmd.Parameters.AddWithValue("@GroundWireSize", GroundWireSize);
            cmd.Parameters.AddWithValue("@NmbrofRailwayCrossing", NmbrofRailwayCrossing);
            cmd.Parameters.AddWithValue("@NmbrofRoadCrossing", NmbrofRoadCrossing);
            cmd.Parameters.AddWithValue("@NmbrofRiverCanalCrossing", NmbrofRiverCanalCrossing);
            cmd.Parameters.AddWithValue("@NmbrofPowerLineCrossing", NmbrofPowerLineCrossing);
            cmd.Parameters.AddWithValue("@NmbrofEarthing", NmbrofEarthing);
            cmd.Parameters.AddWithValue("@EarthingType1", EarthingType1);
            cmd.Parameters.AddWithValue("@Valueinohms1", Valueinohms1);
            cmd.Parameters.AddWithValue("@EarthingType2", EarthingType2);
            cmd.Parameters.AddWithValue("@Valueinohms2", Valueinohms2);
            cmd.Parameters.AddWithValue("@EarthingType3", EarthingType3);
            cmd.Parameters.AddWithValue("@Valueinohms3", Valueinohms3);
            cmd.Parameters.AddWithValue("@EarthingType4", EarthingType4);
            cmd.Parameters.AddWithValue("@Valueinohms4", Valueinohms4);
            cmd.Parameters.AddWithValue("@EarthingType5", EarthingType5);
            cmd.Parameters.AddWithValue("@Valueinohms5", Valueinohms5);
            cmd.Parameters.AddWithValue("@EarthingType6", EarthingType6);
            cmd.Parameters.AddWithValue("@Valueinohms6", Valueinohms6);
            cmd.Parameters.AddWithValue("@EarthingType7", EarthingType7);
            cmd.Parameters.AddWithValue("@Valueinohms7", Valueinohms7);
            cmd.Parameters.AddWithValue("@EarthingType8", EarthingType8);
            cmd.Parameters.AddWithValue("@Valueinohms8", Valueinohms8);
            cmd.Parameters.AddWithValue("@EarthingType9", EarthingType9);
            cmd.Parameters.AddWithValue("@Valueinohms9", Valueinohms9);
            cmd.Parameters.AddWithValue("@EarthingType10", EarthingType10);
            cmd.Parameters.AddWithValue("@Valueinohms10", Valueinohms10);
            cmd.Parameters.AddWithValue("@EarthingType11", EarthingType11);
            cmd.Parameters.AddWithValue("@Valueinohms11", Valueinohms11);
            cmd.Parameters.AddWithValue("@EarthingType12", EarthingType12);
            cmd.Parameters.AddWithValue("@Valueinohms12", Valueinohms12);
            cmd.Parameters.AddWithValue("@EarthingType13", EarthingType13);
            cmd.Parameters.AddWithValue("@Valueinohms13", Valueinohms13);
            cmd.Parameters.AddWithValue("@EarthingType14", EarthingType14);
            cmd.Parameters.AddWithValue("@Valueinohms14", Valueinohms15);
            cmd.Parameters.AddWithValue("@EarthingType15", EarthingType15);
            cmd.Parameters.AddWithValue("@Valueinohms15", Valueinohms15);
            cmd.Parameters.AddWithValue("@NoofPoleTowerForOverheadCable", NoofPoleTowerForOverheadCable);
            cmd.Parameters.AddWithValue("@CableSize", CableSize);
            cmd.Parameters.AddWithValue("@RailwayCrossingNoForOC", RailwayCrossingNoForOC);
            cmd.Parameters.AddWithValue("@RoadCrossingNoForOC", RoadCrossingNoForOC);
            cmd.Parameters.AddWithValue("@RiverCanalCrossingNoForOC", RiverCanalCrossingNoForOC);
            cmd.Parameters.AddWithValue("@PowerLineCrossingNoForOc", PowerLineCrossingNoForOc);
            cmd.Parameters.AddWithValue("@RedPhaseEarthWire", RedPhaseEarthWire);
            cmd.Parameters.AddWithValue("@YellowPhaseEarth", YellowPhaseEarth);
            cmd.Parameters.AddWithValue("@BluePhaseEarthWire", BluePhaseEarthWire);
            cmd.Parameters.AddWithValue("@RedPhaseYellowPhase", RedPhaseYellowPhase);
            cmd.Parameters.AddWithValue("@RedPhaseBluePhase", RedPhaseBluePhase);
            cmd.Parameters.AddWithValue("@BluePhaseYellowPhase", BluePhaseYellowPhase);
            cmd.Parameters.AddWithValue("@PhasewireNeutralwire", PhasewireNeutralwire);
            cmd.Parameters.AddWithValue("@PhasewireEarth", PhasewireEarth);
            cmd.Parameters.AddWithValue("@NeutralwireEarth", NeutralwireEarth);
            cmd.Parameters.AddWithValue("@TypeofCable", TypeofCable);
            cmd.Parameters.AddWithValue("@SizeofCable", SizeofCable);
            cmd.Parameters.AddWithValue("@Cablelaidin", Cablelaidin);
            cmd.Parameters.AddWithValue("@RedPhaseEarthWirefor440orAbove", RedPhaseEarthWirefor440orAbove);
            cmd.Parameters.AddWithValue("@YellowPhaseEarthWire440orAbove", YellowPhaseEarthWire440orAbove);
            cmd.Parameters.AddWithValue("@BluePhaseEarthWire440orAbove", BluePhaseEarthWire440orAbove);
            cmd.Parameters.AddWithValue("@RedPhaseYellowPhase440orAbove", RedPhaseYellowPhase440orAbove);
            cmd.Parameters.AddWithValue("@RedPhaseBluePhase440orAbove", RedPhaseBluePhase440orAbove);
            cmd.Parameters.AddWithValue("@BluePhaseYellowPhase440orAbove", BluePhaseYellowPhase440orAbove);
            cmd.Parameters.AddWithValue("@PhasewireNeutralwire220OrAbove", PhasewireNeutralwire220OrAbove);
            cmd.Parameters.AddWithValue("@PhasewireEarth220OrAbove", PhasewireEarth220OrAbove);
            cmd.Parameters.AddWithValue("@NeutralwireEarth220OrAbove", NeutralwireEarth220OrAbove);
            

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
        public DataSet GetddlEarthingSubstation()
        {
            return DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["DBConnection"].ToString(), "sp_EarthingSubstation");
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