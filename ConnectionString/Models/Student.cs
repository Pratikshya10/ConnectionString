using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnectionString.Models
{
    public class Student
    {
        public string StuId { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Duration { get; set; }

        public SqlConnection connection()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["nareshitconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionstring);
            return con;
        }
        public List<Student> GetStudentsDetails() 
        {
            var con = connection();
            List<Student>StudList = new List<Student>();
            var query = "select * from StudentInfo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                StudList.Add(
                    new Student
                    {
                        StuId = Convert.ToString(dr["StuId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Course = Convert.ToString(dr["Course"]),
                        Duration = Convert.ToString(dr["Duration"])
                    });
            }
            return StudList;
        }
    }
}