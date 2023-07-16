using Kemensos.Siks.UsulanDtks.Domain.Pkh;
using static Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory.IndividuData;

namespace Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;

public class IndividuDataRepository : IIndividuDataRepository
{
  public Dictionary<int, Person> GetPersons()
  {
    return ListIndividu;
  }
}