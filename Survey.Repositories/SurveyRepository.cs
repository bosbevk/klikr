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
    public class SurveyRepository : GenericRepository<Data.Models.Survey>, ISurveyRepository
    {
        public SurveyRepository(SurveyContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Data.Models.Survey>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(SurveyRepository));
                return new List<Data.Models.Survey>();
            }
        }
        public override async Task<bool> Update(Data.Models.Survey entity)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existing == null)
                    return await Add(entity);

                existing.Name = entity.Name; 
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(SurveyRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(SurveyRepository));
                return false;
            }
        }
    }

}
