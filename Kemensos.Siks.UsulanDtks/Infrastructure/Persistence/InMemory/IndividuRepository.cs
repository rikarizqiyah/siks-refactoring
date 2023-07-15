using System;
using Kemensos.Siks.UsulanDtks.Domain.Individu;

namespace Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;

public class IndividuRepository : IIndividuRepository
{
    private Dictionary<IndividuId, Individu> _listIndividu;

    public IndividuRepository()
    {
        _listIndividu = new Dictionary<IndividuId, Individu>();
    }

    public Individu? GetById(IndividuId id)
    {
        return _listIndividu[id];
    }

    public Individu? GetByNik(Nik nik)
    {
        var result = _listIndividu.Where(e => e.Value.Nik == nik).FirstOrDefault();

        return result.Value;
    }

    public void Save(Individu individu)
    {
        _listIndividu.Add(individu.Id, individu);
    }
}

