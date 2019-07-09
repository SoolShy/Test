namespace DAL {
    public class Database {
        public DataTable Query (string strSql) {
            string connstr = ConfigurationManager.connectionStrings["connstr"].ToString ();
            SqlConnection conn = new SqlConnection (connstr);
            SqlDataAdapter da = new SqlDataAdapter (strSql, conn);
            DataSet ds = new DataSet ();
            da.Fill (ds);
            return ds.Tables[0];
        }
        public string ExeSQL (string strSql) {
            string connstr = ConfigurationManager.connectionStrings["connstr"].ToString ();
            SqlConnection conn = new SqlConnection (connstr);
            SqlCommand cmd = new SqlCommand(strSql,conn);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            conn.Close();
            return "OK";
        }
    }
}