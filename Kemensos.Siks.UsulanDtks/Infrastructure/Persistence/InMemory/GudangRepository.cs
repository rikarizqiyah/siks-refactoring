using Kemensos.Siks.UsulanDtks.Domain.Gudang;

namespace Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;

public class GudangRepository : IGudangRepository
{
  private Dictionary<GudangId, Gudang> _listGudang;

  public GudangRepository()
  {
    _listGudang = new Dictionary<GudangId, Gudang>();
  }

  public Gudang? GetById(GudangId id)
  {
    return _listGudang[id];
  }

  public void Save(Gudang gudang)
  {
    _listGudang.Add(gudang.Id, gudang);
  }
}