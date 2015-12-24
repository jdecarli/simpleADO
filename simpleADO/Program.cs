namespace simpleADO
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    class Program
    {
        private static string _connstr = ConfigurationManager.ConnectionStrings["ConnectionToTest"].ToString(); 

        static void Main(string[] args)
        {
            //check
            if (string.IsNullOrEmpty(_connstr))
                throw new Exception("'ConnectionToTest' connection string is empty on the app.config");


            Console.WriteLine("ConnectionString: {0}", _connstr);
            Console.WriteLine();

            Console.WriteLine(Connect());
            Console.WriteLine();

            Console.WriteLine("done");
            Console.ReadKey();
        }

        /// <summary>
        /// Basic Connection to "ConnectionToTest" connectionstring in the App.Config
        /// </summary>
        /// <returns>Acknowledge</returns>
        private static string Connect()
        {
            //ConnectionStrings arguments
            //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring(v=vs.110).aspx
            var result = "something happened";

            try
            {
                using (var conn = new SqlConnection(_connstr))
                {
                    conn.Open();

                    result = string.Format("Connection ok - State: {0}", conn.State.ToString());
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }
    }
}