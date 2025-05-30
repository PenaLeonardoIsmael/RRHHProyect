using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICandidatosRepository CandidatosRepository { get; }
        ICapacitacionsRepository CapacitacionsRepository { get; }
        ICompetenciasRepository CompetenciasRepository { get; }
        IIdiomaRepository IdiomaRepository { get; }
        IPuestosRepository IPuestosRepository { get; }

    }
}
