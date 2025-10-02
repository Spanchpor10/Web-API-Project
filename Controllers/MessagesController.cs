using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.SqlClient;
using WebApi_2.Models;
using System.Data;
using System.Configuration;

namespace WebApi_2.Controllers
{
    public class MessagesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table= new DataTable();
            string query = @"
                           select MsgID,MsgBody from dbo.Messages";
            using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["MessagesDBC"].ConnectionString))
            using (var cmd=new SqlCommand(query, con))
                using (var da=new SqlDataAdapter(cmd))
            {
                cmd.CommandType= CommandType.Text;
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


    }
}
