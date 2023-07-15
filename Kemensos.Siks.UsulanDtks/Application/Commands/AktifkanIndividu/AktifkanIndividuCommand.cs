using System;
using Kemensos.Siks.UsulanDtks.Domain.Individu;

namespace Kemensos.Siks.UsulanDtks.Application.Commands.AktifkanIndividu;

public class AktifkanIndividuCommand
{
    private IIndividuRepository _individuRepository;

    public AktifkanIndividuCommand(IIndividuRepository individuRepository)
    {
        _individuRepository = individuRepository;
    }

    public void Handle(AktifkanIndividuRequest request)
    {
        //TODO: authorization check
        //TODO: request parameter validation

        var individuId = new IndividuId(request.IndividuId);

        var individu = _individuRepository.GetById(individuId);

        if (individu == null)
        {
            throw new Exception("Individu tidak ditemukan");
        }

        try
        {
            individu.Aktifkan();
        }
        catch (Exception e)
        {
            throw e;
        }

        _individuRepository.Save(individu);
    }

}

