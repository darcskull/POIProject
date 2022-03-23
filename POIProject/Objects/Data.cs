using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIProject.Objects
{
   public class Data
    {
        // Променете D:\uni\6семестър\POIProject\POIProject\POIProject\dataBase\DatabaseQuestions.mdf с пътя на локалната ви база
        public const string connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename= D:\uni\6семестър\POIProject\POIProject\POIProject\dataBase\DatabaseQuestions.mdf; Integrated Security=True;";
        public SqlConnection conn = new SqlConnection(connString);
    }
}
