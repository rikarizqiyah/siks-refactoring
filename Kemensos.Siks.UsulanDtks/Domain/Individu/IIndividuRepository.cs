using System;
namespace Kemensos.Siks.UsulanDtks.Domain.Individu;

public interface IIndividuRepository
{
    Individu? GetById(IndividuId id);
    Individu? GetByNik(Nik nik);
    void Save(Individu individu);
}

