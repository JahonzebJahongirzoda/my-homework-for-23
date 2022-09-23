namespace Infrastructure.Services;
using System.Net;
using Dapper;
using Npgsql;
using Domain.Entities;
using Infrastructure.DataContext;


public class CourseServices
{
    private DataContext _context;

    public CourseServices(DataContext context)
    {
        _context = context;
    }



    public async Task<string> GetallfromCourse()
    {
        using (var connection = _context.CreateConnection())

        {
            try
            {
                var sql = "Select * from Course";
                var res = await connection.QueryAsync<CourseServices>(sql);

                return new string("Success");
            }
            catch (System.Exception)
            {
            }
            return new string("Error");

        }
    }



    public async Task<string> AddCourse(Course Course)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"INSERT INTO Course (CourseName,CourseDescription,Fee,Duration,StartDate,EndDate,StudentLimit) VALUES ('{Course.CourseName}','{Course.CourseDescription}','{Course.Fee}','{Course.Duration}','{Course.StartDate}','{Course.EndDate}','{Course.StudentLimit}')";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");
            }

        }

    }



    public async Task<string> UpdateCourse(Course Course)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"UPDATE set  CourseName = '{Course.CourseName}', CourseDescription = '{Course.CourseDescription}', Fee = '{Course.Fee}', Duration = '{Course.Duration}', StartDate = '{Course.StartDate}', EndDate = '{Course.EndDate}', StudentLimit = '{Course.StudentLimit}' WHERE id = '{Course.Id}'; ";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");

            }


        }

    }



    public async Task<string> DeleteCourse(int id)
    {

        using (var connection = _context.CreateConnection())


            try
            {
                string sql = $"delete from Course where id ={id}";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {

                return new string("Error");
            }



    }

}

