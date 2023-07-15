using System;
using Kemensos.Siks.UsulanDtks.Domain.Individu;

namespace Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.SqlServer;

public class IndividuRepository : IIndividuRepository
{
    public IndividuRepository()
    {
    }

    public Individu? GetById(IndividuId id)
    {
        throw new NotImplementedException();
    }

    public Individu? GetByNik(Nik nik)
    {
        throw new NotImplementedException();
    }

    public void Save(Individu individu)
    {
        throw new NotImplementedException();
    }
}

