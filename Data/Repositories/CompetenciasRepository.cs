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
   public class CompetenciasRepository : RepositoryBase<Competencia>, ICompetenciasRepository
{
    private readonly ApplicationDBContext _context;
    public CompetenciasRepository(ApplicationDBContext dBContext): base(dBContext) 
    {
        _context = dBContext;
    }
}
}
