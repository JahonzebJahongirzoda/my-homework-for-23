namespace Infrastructure.Services;
using System.Net;
using Dapper;
using Domain.Entities;
using Npgsql;
using Infrastructure.DataContext;


public class MentorServices
{
    private DataContext _context;

    public MentorServices(DataContext context)
    {
        _context = context;
    }



    public async Task<string> GetallfromMentor()
    {
        using (var connection = _context.CreateConnection())

        {
            try
            {
                var sql = "Select * from Mentor";
                var res = await connection.QueryAsync<MentorServices>(sql);

                return new string("Success");
            }
            catch (System.Exception)
            {
            }
            return new string("Error");

        }
    }



    public async Task<string> AddMentor(Mentor Mentor)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"INSERT INTO Mentor (FirstName,LastName,Email,Phone,Address,City) VALUES ('{Mentor.FirstName}','{Mentor.LastName}','{Mentor.Email}','{Mentor.Phone}','{Mentor.Address}','{Mentor.City}')";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");
            }

        }

    }



    public async Task<string> UpdateMentor(Mentor Mentor)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"UPDATE set  FirstName = '{Mentor.FirstName}', LastName = '{Mentor.LastName}', Email = '{Mentor.Email}', Address = '{Mentor.Address}', Phone = '{Mentor.Phone}', City = '{Mentor.City}' WHERE id = '{Mentor.Id}'; ";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");

            }


        }

    }



    public async Task<string> DeleteMentor(int id)
    {

        using (var connection = _context.CreateConnection())


            try
            {
                string sql = $"delete from Mentor where id ={id}";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {

                return new string("Error");
            }



    }

}