using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoklenSodigerLight
{
    public class SQLServerManager
    {
        public static void BackupDataBase(string databse,string filename)
        {
            DbHelperSQL.ExecuteSql(string.Format("use master BACKUP DATABASE [{0}] TO DISK = '{1}' WITH FORMAT",databse,filename));
        }

        public static void RestoreDataBase(string database,string filename)
        {
            DbHelperSQL.ExecuteSql(string.Format("use master Alter Database [{0}] SET SINGLE_USER With ROLLBACK IMMEDIATE RESTORE DATABASE [{0}] FROM DISK = '{1}' Alter Database [{0}] SET MULTI_USER", database, filename));
        }
    }
}
