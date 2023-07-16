using Kemensos.Siks.UsulanDtks.Domain.Pkh;

namespace Kemensos.Siks.UsulanDtks.Application.Commands.PkhListIndividu;

public class PkhListIndividuCommand
{
  private IIndividuDataRepository _individuDataRepository;

  public PkhListIndividuCommand(IIndividuDataRepository individuDataRepository)
  {
    _individuDataRepository = individuDataRepository;
  }

  public List<PersonDto> GetAllPersons()
  {
    // Lakukan validasi kategori dengan data statis di domain atau sumber lainnya
    var persons = _individuDataRepository.GetPersons().Values
        .Select(p => new PersonDto
        {
          Id = p.Id,
          NoKk = p.NoKk,
          Nik = p.Nik,
          Name = p.Name,
          Age = p.Age,
          Status = p.Status,
          Kategori = p.Kategori
        })
        .ToList();
    return persons;
  }
}