using RepositoryPattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Book> Books { get; }

        int Complete();
    }
}

