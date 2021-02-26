using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MySqlConnector;

namespace UploadFile.API.Services
{
    public class DBService
    {
        public Int64 UploadRecordingDBSave(CallDetails callDetails)
        {
            Int64 Count = 0;

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "softgame.mysql.database.azure.com",
                UserID = "softgame",
                Password = "Game@1234",
                //Database = "softgamedb",
                Database = "softgamedb_fileUpload",
                SslMode = MySqlSslMode.VerifyCA
                //,SslCa = "D:\\rnd\\react\\CRUD.ASPCore.Reactjs\\dbTool\\DigiCertGlobalRootCA.crt.pem",
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {

                conn.Open();


                using (var command = conn.CreateCommand())
                {
                    // command.CommandText = string.Format("SELECT count(*) FROM user_login where user_id='{0}' and password='{1}'", "softgameuserid", "softgameuserpwd");

                    //Count = (System.Int64)command.ExecuteScalar();
                    /*
                     Recording_id serial PRIMARY KEY	
,CallerId varchar(100),
FileName varchar(100),
CallDuration varchar(100),
StartTime  TimeStamp,
EndTime  TimeStamp,
CurrentDate date,
MobileNumbers varchar(100),
Caller varchar(100),
Callee varchar(100),
DeviceId varchar(100)
                     */

                    command.CommandText = @"INSERT INTO Recording (CallerId,FileName,CallDuration,StartTime,EndTime,CurrentDate,MobileNumbers,Caller,Callee,DeviceId) 
                        VALUES (@CallerId, @FileName,@CallDuration,@StartTime,@EndTime,@CurrentDate,@MobileNumbers,@Caller,@Callee,@DeviceId);";
                    command.Parameters.AddWithValue("@CallerId", callDetails.CallerId);
                    command.Parameters.AddWithValue("@FileName", callDetails.FileName);
                    command.Parameters.AddWithValue("@CallDuration", callDetails.CallDuration);
                    command.Parameters.AddWithValue("@StartTime", callDetails.StartDateTime);
                    command.Parameters.AddWithValue("@EndTime", callDetails.EndDateTime);
                    command.Parameters.AddWithValue("@CurrentDate", callDetails.CurrentDateTime);
                    command.Parameters.AddWithValue("@MobileNumbers", callDetails.MobileNumbers);
                    command.Parameters.AddWithValue("@Caller", callDetails.CallerId);
                    command.Parameters.AddWithValue("@Callee", callDetails.CalleeId);
                    command.Parameters.AddWithValue("@DeviceId", callDetails.DeviceId);


                    Count = command.ExecuteNonQuery();

                }
            }

            return Count;
        }
    }
}
