using Microsoft.Extensions.Logging;
using Survey.Data;
using Survey.Data.Models;
using Survey.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repositories.UnitOfWork
{
    public class Login : ILogin, IDisposable
    {
        private readonly SurveyContext _context;
        private readonly ILogger _logger;

        public IRespondentRepository Respondent { get; private set; }

        public Login(SurveyContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Respondent = new RespondentRepository(context, _logger);
        }        

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
