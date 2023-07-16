using static Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory.IndividuData;

namespace Kemensos.Siks.UsulanDtks.Domain.Pkh;

public interface IIndividuDataRepository
{
  Dictionary<int, Person> GetPersons();
}