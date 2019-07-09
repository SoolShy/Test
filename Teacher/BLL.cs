using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class  Stu
    {
        #region 所有学生信息
        public DataTable GetStuList()
        {
            string strSql = "select * from Stu";
            DAL.Database DAL = new DAL.Database();
            return DAL.Query(strSql.ToString());
        }
        #endregion

        #region 添加学生信息
        public string Insert(string stuNo, string stuName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from Stu where StuNo='{0}',stuNo");
            DAL.Database dal = new DAL.Database();
            DataTable dt = dal.Query(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return "学生编号已占用";
            }
            strSql.Clear();
            strSql.AppendFormat("select IsNull(max(Id),0) from Stu");
            DataTable dt_Id = dal.Query(strSql.ToString());
            int Id = 1;
            if(dt_Id.Rows.Count > 0)
            {
                Id = int.Parse(dt_Id.Rows[0][0].ToString())+1;
            }
            strSql.Clear();
            strSql.AppendFormat("insert into Stu(Id,stuNo,stuName) values('{0}'，'{1}','{2}')",Id,stuNo,stuName);
            return dal.ExeSQL(strSql.ToString());
        }
        #endregion
    }
}
