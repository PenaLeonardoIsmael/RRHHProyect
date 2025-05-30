using Data.Data;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            CandidatosRepository = new CandidatosRepository(_context);
            CapacitacionsRepository = new CapacitacionsRepository(_context);
            CompetenciasRepository = new CompetenciasRepository(_context);
            IdiomaRepository = new IdiomaRepository(_context);
            IPuestosRepository = new PuestosRepository(_context);
        }

        public ICandidatosRepository CandidatosRepository { get; private set; }

        public ICapacitacionsRepository CapacitacionsRepository { get; private set; }

        public ICompetenciasRepository CompetenciasRepository { get; private set; }

        public IIdiomaRepository IdiomaRepository { get; private set; }

        public IPuestosRepository IPuestosRepository { get; private set; }
    }
}
