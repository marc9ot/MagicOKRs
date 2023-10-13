namespace MagicOKRs.Queries
{
    using Dapper;
    using Npgsql;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;
    using MagicOKRs.Controllers;
    using System;

    public class ObjectiveQueries : IObjectiveQueries
    {
        //private string _connectionString = string.Empty;
        private readonly IConfiguration _configuration;

        public ObjectiveQueries(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal static List<Objective> GetObjectives()
        {
            throw new NotImplementedException();
        }

        /*public async Task<Objective> Get7DayIncidence(string district)
        {
            var constr = _configuration.GetConnectionString("PostgresConnection");
            using var connection = new NpgsqlConnection(constr);
            connection.Open();

            var result = await connection.QueryAsync<dynamic>(
               @"select objectid, gen as district, cases7_per_100k as casses7per100k
               from public.rki_incidence
               where gen=@district", new { district }
                );

            if (result.AsList().Count == 0)
                throw new KeyNotFoundException();

            return result;
        }*/


        public Task<Objective> GetObjective(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
