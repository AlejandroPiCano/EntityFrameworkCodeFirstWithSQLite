using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoItems.Domain
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();

        Task RollbackAsync();

    }
}
