using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;


namespace FriendOrganizer.DataAccess.Connection
{
    class Connection
    {
        public void CreateDB()
        {
            File.Delete("Test.sdf");
            string connString = "Data Source='Test.sdf'; LCID=1033;   Password='123456'; Encrypt = TRUE;";
        }

    }
}
