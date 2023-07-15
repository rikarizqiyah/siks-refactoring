using Kemensos.Siks.UsulanDtks.Domain.Individu;
using Kemensos.Siks.UsulanDtks.Domain.Pkh;

namespace Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;

public class PkhRepository : IPkhRepository
{
  public bool IsValidCategory(string category)
  {
    // Lakukan validasi kategori dengan data statis di domain atau sumber lainnya
    // Misalnya, memeriksa kategori di dalam database
    // Anda dapat menambahkan logika pengaksesan data yang sesuai di sini
    return category == "Kategori1" || category == "Kategori2";
  }

  public decimal GetAssistanceAmount(string category)
  {
    // Dapatkan nominal uang bantuan berdasarkan kategori dari data statis atau sumber lainnya
    // Misalnya, mengambil nilai dari database berdasarkan kategori
    // Anda dapat menambahkan logika pengaksesan data yang sesuai di sini
    if (category == "Kategori1")
      return 1000;
    else if (category == "Kategori2")
      return 2000;
    else
      return 0;
  }
  private Dictionary<PkhId, Pkh> _listPkh;

  public PkhRepository()
  {
    _listPkh = new Dictionary<PkhId, Pkh>();
  }

  public Pkh? GetById(PkhId id)
  {
    return _listPkh[id];
  }

  public Pkh? GetByNoKk(NoKk noKk)
  {
    var result = _listPkh.Where(e => e.Value.NoKk == noKk).FirstOrDefault();

    return result.Value;
  }

  public Pkh? DtksGetByNik(Nik nik)
  {
    var result = _listPkh.Where(e => e.Value.Nik == nik).FirstOrDefault();

    return result.Value;
  }

  public void Save(Pkh pkh)
  {
    _listPkh.Add(pkh.Id, pkh);
  }
}