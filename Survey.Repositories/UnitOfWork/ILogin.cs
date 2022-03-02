using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Repositories;
using Survey.Repositories.Interfaces;

namespace Survey.Repositories.UnitOfWork
{
    public interface ILogin
    {
        IRespondentRepository Respondent { get; }

        Task CompleteAsync();
        void Dispose();
    }
}
