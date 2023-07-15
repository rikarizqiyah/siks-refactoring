using System;
namespace Kemensos.Siks.UsulanDtks.Domain.Gudang;

public interface IGudangRepository
{
  Gudang? GetById(GudangId id);
  void Save(Gudang gundang);
}