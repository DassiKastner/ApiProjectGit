using System.Data;
using EX2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace EX2.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        string _connect;
        public AttachmentRepository(IConfiguration configuration)
        {
            _connect = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable addAttachment(string AttachName, string AttachPath, string UploadDate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connect))
            {
                using (SqlCommand command = new SqlCommand("Add_Attachment",connection))
                {
                    connection.Open();
                    command.CommandText = "Add_Attachment";
                    command.CommandType = CommandType.StoredProcedure;

                    //SqlParameter name = new SqlParameter("@AttachName", AttachName);
                    //SqlParameter path = new SqlParameter("@AttachPath", AttachPath);
                    //SqlParameter date = new SqlParameter("@UploadDate", UploadDate);

                    //command.Parameters.Add(name);
                    //command.Parameters.Add(path);
                    //command.Parameters.Add(date);
                    command.Parameters.AddWithValue("@AttachName", AttachName);
                    command.Parameters.AddWithValue("@AttachPath", AttachPath);
                    command.Parameters.AddWithValue("@UploadDate", UploadDate);
                    int rowsAffact = command.ExecuteNonQuery();

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public IEnumerable<Attachment> getByProject(int id)
        {
            return null;
        }
        //public DataTable getByProject(int id)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(_connect))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.CommandText = "Add_Attachment";
        //            command.CommandType = CommandType.StoredProcedure;


        //            //SqlParameter name = new SqlParameter("@AttachName", attachment.AttachName);
        //            //SqlParameter path = new SqlParameter("@AttachPath", attachment.AttachPath);
        //            //SqlParameter date = new SqlParameter("@UploadDate", attachment.UploadDate);

        //            //command.Parameters.Add(name);
        //            //command.Parameters.Add(path);
        //            //command.Parameters.Add(date);
        //            //connection.Open();

        //            using (SqlDataAdapter da = new SqlDataAdapter())
        //            {
        //                da.Fill(dt);
        //            }
        //        }
        //    }
        //    return dt;
        //}

    }
}
