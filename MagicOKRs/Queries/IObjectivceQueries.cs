using System;
namespace MagicOKRs.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MagicOKRs.Controllers;


    // interface for Objectives db queries using dapper micro ORM - https://dapper-tutorial.net/

    public interface IObjectiveQueries
    {
        //Task<Incidence> Get7DayIncidence(string Landkreis);
        Task<Objective> GetObjective(Guid id);
    }
}
