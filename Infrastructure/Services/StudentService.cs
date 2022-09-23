namespace Infrastructure.Services;
using System.Net;
using Dapper;
using Domain.Entities;
using Npgsql;
using Infrastructure.DataContext;


public class StudentServices
{
    private DataContext _context;

    public StudentServices(DataContext context)
    {
        _context = context;
    }



    public async Task<string> GetallfromStudent()
    {
        using (var connection = _context.CreateConnection())

        {
            try
            {
                var sql = "Select * from Student";
                var res = await connection.QueryAsync<StudentServices>(sql);

                return new string("Success");
            }
            catch (System.Exception)
            {
            }
            return new string("Error");

        }
    }



    public async Task<string> AddStudent(Student Student)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"INSERT INTO Student (FirstName,LastName,Email,Phone,Address,City) VALUES ('{Student.FirstName}','{Student.LastName}','{Student.Email}','{Student.Phone}','{Student.Address}','{Student.City}')";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");
            }

        }

    }



    public async Task<string> UpdateStudent(Student Student)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"UPDATE set  FirstName = '{Student.FirstName}', LastName = '{Student.LastName}', Email = '{Student.Email}', Address = '{Student.Address}', Phone = '{Student.Phone}', City = '{Student.City}' WHERE id = '{Student.Id}'; ";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");

            }


        }

    }



    public async Task<string> DeleteStudent(int id)
    {

        using (var connection = _context.CreateConnection())


            try
            {
                string sql = $"delete from Student where id ={id}";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {

                return new string("Error");
            }



    }

}