using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using ParkingSystem.Areas.PMS_User.Models;

namespace ParkingSystem.DAL
{
    public class SEC_DALBase
    {
        #region Method: dbo_PR_PMS_User_SelectByPK
        public DataTable dbo_PR_PMS_User_SelectByPK(string ConnStr, int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PMS_User_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_PMS_User_ SelectByUserNamePassword
        public DataTable PR_PMS_User_SelectByUserNamePassword(string ConnStr, string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PMS_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
        }
            catch (Exception ex)
            {
                return null;
            }
}
        #endregion

        #region Method: dbo_PR_PMS_User_Insert
        public decimal? dbo_PR_PMS_User_Insert(string ConnStr, PMS_UserModel modelPMS_User)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PMS_User_Insert");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, modelPMS_User.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, modelPMS_User.Password);
                sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.VarChar, modelPMS_User.FirstName);
                sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.VarChar, modelPMS_User.LastName);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, modelPMS_User.Email);
                //sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, PhotoPath);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, modelPMS_User.CreationDate);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, modelPMS_User.ModificationDate);

                var vResult = sqlDB.ExecuteScalar(dbCMD);
                if (vResult == null)
                    return null;

                return (decimal)Convert.ChangeType(vResult, vResult.GetType());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
