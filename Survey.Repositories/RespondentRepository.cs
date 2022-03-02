using Survey.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Repositories.Interfaces;
using Survey.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Survey.Repositories
{
    public class RespondentRepository : GenericRepository<Respondent>, IRespondentRepository
    {
        public RespondentRepository(SurveyContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Respondent>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(RespondentRepository));
                return new List<Respondent>();
            }
        }
        public override async Task<bool> Update(Respondent entity)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existing == null)
                    return await Add(entity);

                existing.Firstname = entity.Firstname;
                existing.Lastname = entity.Lastname;
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(RespondentRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(RespondentRepository));
                return false;
            }
        }

        public Task<Respondent?> GetByUsernameAndPassword(string username, string password)
        {
            var item = dbSet.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
            return item;
        }

        public Task<Respondent?> GetByUsername(string username)
        {
            var item = dbSet.SingleOrDefaultAsync(x => x.Username == username);
            return item;
        }
    }

}
