using Survey.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repositories.Interfaces
{
    public interface IRespondentRepository : IGenericRepository<Respondent>
    {
        Task<Respondent?> GetByUsernameAndPassword(string username, string password);
        Task<Respondent?> GetByUsername(string username);
    }
}
