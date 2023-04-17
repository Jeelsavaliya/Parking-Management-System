using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ParkingSystem.BAL;
using System.Data.Common;
using System.Data;
using ParkingSystem.Areas.PMS_VehicleCategory.Models;
using ParkingSystem.Areas.PMS_Vehicle.Models;
using ParkingSystem.Areas.PMS_SlotArea.Models;
using ParkingSystem.Areas.PMS_BookingSlot.Models;

namespace ParkingSystem.DAL
{
    public class PMS_DALBase : DALHelper
    {

        #region PR_PMS_VehicleCategory_SelectAll
        public DataTable PR_PMS_VehicleCategory_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_VehicleCategory_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region PR_PMS_VehicleCategory_Insert
        public DataTable PR_PMS_VehicleCategory_Insert(PMS_VehicleCategoryModel modelPMS_VehicleCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_VehicleCategory_Insert");

                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.NVarChar, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.NVarChar, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "VehicleCategory", SqlDbType.NVarChar, modelPMS_VehicleCategory.VehicleCategory);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region PR_PMS_VehicleCategory_SelectByPK
        public DataTable PR_PMS_VehicleCategory_SelectByPK(int? VehicleCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_VehicleCategory_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.Int, VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_VehicleCategory_UpdateByPK
        public DataTable PR_PMS_VehicleCategory_UpdateByPK(PMS_VehicleCategoryModel modelPMS_VehicleCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_VehicleCategory_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.NVarChar, modelPMS_VehicleCategory.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.NVarChar, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "VehicleCategory", SqlDbType.NVarChar, modelPMS_VehicleCategory.VehicleCategory);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_PMS_VehicleCategory_DeleteByPK

        public DataTable PR_PMS_VehicleCategory_DeleteByPK(int VehicleCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_VehicleCategory_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.Int, VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }

        #endregion

        #region PR_PMS_Vehicle_SelectAll
        public DataTable PR_PMS_Vehicle_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_Vehicle_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
               return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_PMS_Vehicle_Insert

        public DataTable PR_PMS_Vehicle_Insert(PMS_VehicleModel modelPMS_Vehicle)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_Vehicle_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "VehicleCompany", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleCompany);
                sqlDB.AddInParameter(dbCMD, "VehicleModel", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleModel);
                sqlDB.AddInParameter(dbCMD, "VehicleNumber", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleNumber);
                sqlDB.AddInParameter(dbCMD, "OwnerName", SqlDbType.NVarChar, modelPMS_Vehicle.OwnerName);
                sqlDB.AddInParameter(dbCMD, "OwnerMobileNo", SqlDbType.NVarChar, modelPMS_Vehicle.OwnerMobileNo);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_Vehicle_SelectByPK
        public DataTable PR_PMS_Vehicle_SelectByPK(int? VehicleID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_Vehicle_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "VehicleID", SqlDbType.Int, VehicleID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_Vehicle_UpdateByPK
        public DataTable PR_PMS_Vehicle_UpdateByPK(PMS_VehicleModel modelPMS_Vehicle)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_Vehicle_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "VehicleID", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.Int, modelPMS_Vehicle.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "VehicleCompany", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleCompany);
                sqlDB.AddInParameter(dbCMD, "VehicleModel", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleModel);
                sqlDB.AddInParameter(dbCMD, "VehicleNumber", SqlDbType.NVarChar, modelPMS_Vehicle.VehicleNumber);
                sqlDB.AddInParameter(dbCMD, "OwnerName", SqlDbType.NVarChar, modelPMS_Vehicle.OwnerName);
                sqlDB.AddInParameter(dbCMD, "OwnerMobileNo", SqlDbType.NVarChar, modelPMS_Vehicle.OwnerMobileNo);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_Vehicle_DeleteByPK

        public DataTable PR_PMS_Vehicle_DeleteByPK(int VehicleID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_Vehicle_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "VehicleID", SqlDbType.Int, VehicleID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }

        #endregion

        #region PR_PMS_SlotArea_SelectAll
        public DataTable PR_PMS_SlotArea_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_SlotArea_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_PMS_SlotArea_Insert

        public DataTable PR_PMS_SlotArea_Insert(PMS_SlotAreaModel modelPMS_SlotArea)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_SlotArea_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.NVarChar, modelPMS_SlotArea.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "BuildingName", SqlDbType.NVarChar, modelPMS_SlotArea.BuildingName);
                sqlDB.AddInParameter(dbCMD, "Floor", SqlDbType.NVarChar, modelPMS_SlotArea.Floor);
                sqlDB.AddInParameter(dbCMD, "SlotAreaName", SqlDbType.NVarChar, modelPMS_SlotArea.SlotAreaName);
                sqlDB.AddInParameter(dbCMD, "SlotAreaCode", SqlDbType.NVarChar, modelPMS_SlotArea.SlotAreaCode);
                sqlDB.AddInParameter(dbCMD, "SlotAreaSize", SqlDbType.NVarChar, modelPMS_SlotArea.SlotAreaSize);
                sqlDB.AddInParameter(dbCMD, "Status", SqlDbType.NVarChar, modelPMS_SlotArea.Status);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_SlotArea_SelectByPK
        public DataTable PR_PMS_SlotArea_SelectByPK(int? SlotAreaID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_SlotArea_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "SlotAreaID", SqlDbType.Int, SlotAreaID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_SlotArea_UpdateByPK
        public DataTable PR_PMS_SlotArea_UpdateByPK(PMS_SlotAreaModel modelPMS_SlotArea)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_SlotArea_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "SlotAreaID", SqlDbType.Int, modelPMS_SlotArea.SlotAreaID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.NVarChar, modelPMS_SlotArea.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "BuildingName", SqlDbType.NVarChar, modelPMS_SlotArea.BuildingName);
                sqlDB.AddInParameter(dbCMD, "Floor", SqlDbType.NVarChar, modelPMS_SlotArea.Floor);
                sqlDB.AddInParameter(dbCMD, "SlotAreaName", SqlDbType.NVarChar, modelPMS_SlotArea.SlotAreaName);
                sqlDB.AddInParameter(dbCMD, "SlotAreaCode", SqlDbType.NVarChar, modelPMS_SlotArea.SlotAreaCode);
                sqlDB.AddInParameter(dbCMD, "SlotAreaSize", SqlDbType.NVarChar, modelPMS_SlotArea.SlotAreaSize);
                sqlDB.AddInParameter(dbCMD, "Status", SqlDbType.NVarChar, modelPMS_SlotArea.Status);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_SlotArea_DeleteByPK

        public DataTable PR_PMS_SlotArea_DeleteByPK(int SlotAreaID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_SlotArea_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "SlotAreaID", SqlDbType.Int, SlotAreaID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }

        #endregion

        #region PR_PMS_BookingSlot_SelectAll
        public DataTable PR_PMS_BookingSlot_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_BookingSlot_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region PR_PMS_BookingSlot_DeleteByPK

        public DataTable PR_PMS_BookingSlot_DeleteByPK(int SlotID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_BookingSlot_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "SlotID", SqlDbType.Int, SlotID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }

        #endregion

        #region PR_PMS_BookingSlot_Insert

        public DataTable PR_PMS_BookingSlot_Insert(PMS_BookingSlotModel modelPMS_BookingSlot)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_BookingSlot_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "SlotAreaID", SqlDbType.NVarChar, modelPMS_BookingSlot.SlotAreaID);
                sqlDB.AddInParameter(dbCMD, "VehicleID", SqlDbType.NVarChar, modelPMS_BookingSlot.VehicleID);
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.NVarChar, modelPMS_BookingSlot.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "Status", SqlDbType.NVarChar, modelPMS_BookingSlot.Status);
                sqlDB.AddInParameter(dbCMD, "BookingDate", SqlDbType.Date, modelPMS_BookingSlot.BookingDate);
                sqlDB.AddInParameter(dbCMD, "EntryTime", SqlDbType.DateTime, modelPMS_BookingSlot.EntryTime);
                sqlDB.AddInParameter(dbCMD, "ExitTime", SqlDbType.DateTime, modelPMS_BookingSlot.ExitTime);
                sqlDB.AddInParameter(dbCMD, "Remark", SqlDbType.NVarChar, modelPMS_BookingSlot.Remark);
                sqlDB.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelPMS_BookingSlot.Amount);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_PMS_BookingSlot_UpdateByPK
        public DataTable PR_PMS_BookingSlot_UpdateByPK(PMS_BookingSlotModel modelPMS_BookingSlot)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_BookingSlot_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "SlotID", SqlDbType.NVarChar, modelPMS_BookingSlot.SlotID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "SlotAreaID", SqlDbType.NVarChar, modelPMS_BookingSlot.SlotAreaID);
                sqlDB.AddInParameter(dbCMD, "VehicleID", SqlDbType.NVarChar, modelPMS_BookingSlot.VehicleID);
                sqlDB.AddInParameter(dbCMD, "VehicleCategoryID", SqlDbType.NVarChar, modelPMS_BookingSlot.VehicleCategoryID);
                sqlDB.AddInParameter(dbCMD, "Status", SqlDbType.NVarChar, modelPMS_BookingSlot.Status);
                sqlDB.AddInParameter(dbCMD, "BookingDate", SqlDbType.Date, modelPMS_BookingSlot.BookingDate);
                sqlDB.AddInParameter(dbCMD, "EntryTime", SqlDbType.DateTime, modelPMS_BookingSlot.EntryTime);
                sqlDB.AddInParameter(dbCMD, "ExitTime", SqlDbType.DateTime, modelPMS_BookingSlot.ExitTime);
                sqlDB.AddInParameter(dbCMD, "Remark", SqlDbType.NVarChar, modelPMS_BookingSlot.Remark);
                sqlDB.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelPMS_BookingSlot.Amount);
                sqlDB.AddInParameter(dbCMD, "Status", SqlDbType.NVarChar, modelPMS_BookingSlot.Status);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_PMS_BookingSlot_SelectByPK
        public DataTable PR_PMS_BookingSlot_SelectByPK(int? SlotID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_BookingSlot_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "SlotID", SqlDbType.Int, SlotID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

    }
}
