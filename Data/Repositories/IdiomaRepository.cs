using Data.Data;
using Data.Repositories.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class IdiomaRepository : RepositoryBase<Idioma>, IIdiomaRepository
    {
        private readonly ApplicationDBContext _context;
        public IdiomaRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _context = dBContext;
        }
    }
}
