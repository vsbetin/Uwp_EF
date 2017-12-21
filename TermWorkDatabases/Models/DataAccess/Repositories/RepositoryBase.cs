using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    abstract class RepositoryBase
    {
        private static ProductAccountingDbContext _context;
        protected ProductAccountingDbContext Context
        {
            get
            {
                return _context;
            }
        }

        static RepositoryBase()
        {
            _context = new ProductAccountingDbContext();
        }
    }
}
