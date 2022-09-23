namespace Infrastructure.Services;
using System.Net;
using Dapper;
using Domain.Entities;
using Npgsql;
using Infrastructure.DataContext;


public class GroupServices
{
    private DataContext _context;

    public GroupServices(DataContext context)
    {
        _context = context;
    }



    public async Task<string> GetallfromGroup()
    {
        using (var connection = _context.CreateConnection())

        {
            try
            {
                var sql = "Select * from Group";
                var res = await connection.QueryAsync<GroupServices>(sql);

                return new string("Success");
            }
            catch (System.Exception)
            {
            }
            return new string("Error");

        }
    }



    public async Task<string> AddGroup(Group Group)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"INSERT INTO Group (GroupName,GroupDescription) VALUES ('{Group.GroupName}','{Group.GroupDescription}')";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");
            }

        }

    }



    public async Task<string> UpdateGroup(Group Group)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"UPDATE set  GroupName = '{Group.GroupName}', GroupDescription = '{Group.GroupDescription}' WHERE id = '{Group.Id}'; ";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");

            }


        }

    }



    public async Task<string> DeleteGroup(int id)
    {

        using (var connection = _context.CreateConnection())


            try
            {
                string sql = $"delete from Group where id ={id}";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {

                return new string("Error");
            }



    }

}