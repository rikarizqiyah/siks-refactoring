using Kemensos.Siks.UsulanDtks.Domain.Individu;

namespace Kemensos.Siks.UsulanDtks.Domain.Pkh;

public interface IPkhRepository
{
  bool IsValidCategory(string category);
  decimal GetAssistanceAmount(string category);
  Pkh? GetById(PkhId id);
  Pkh? GetByNoKk(NoKk noKk);
  Pkh? DtksGetByNik(Nik nik);
  void Save(Pkh pkh);
}