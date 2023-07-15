using Kemensos.Siks.UsulanDtks.Domain.Gudang;

namespace Kemensos.Siks.UsulanDtks.Application.Commands.TambahkanGudang;

public class TambahkanGudangCommand
{
  private IGudangRepository _gudangRepository;

  public TambahkanGudangCommand(IGudangRepository gudangRepository)
  {
    _gudangRepository = gudangRepository;
  }

  public Gudang Handle(TambahkanGudangRequest request)
  {
    //TODO: authorization check
    //TODO: request parameter validation
    
    var gudangBaru = Gudang.Add(
            request.Nama
        );

    //simpan gudang baru
    _gudangRepository.Save(gudangBaru);

    return gudangBaru;
  }
}