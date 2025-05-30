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
    public class CandidatosRepository : RepositoryBase<Candidato>, ICandidatosRepository
    {
        private readonly ApplicationDBContext _context;
        public CandidatosRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _context = dBContext;
        }
    }
}
