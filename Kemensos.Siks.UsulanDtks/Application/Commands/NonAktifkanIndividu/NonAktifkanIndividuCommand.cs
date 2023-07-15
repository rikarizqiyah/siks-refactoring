using System;
using Kemensos.Siks.UsulanDtks.Domain.Individu;

namespace Kemensos.Siks.UsulanDtks.Application.Commands.NonAktifkanIndividu;

public class NonAktifkanIndividuCommand
{
    private IIndividuRepository _individuRepository;

    public NonAktifkanIndividuCommand(IIndividuRepository individuRepository)
    {
        _individuRepository = individuRepository;
    }

    public void Handle(NonAktifkanIndividuRequest request)
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
            individu.NonAktifkan();
        }
        catch (Exception e)
        {
            throw e;
        }

        _individuRepository.Save(individu);
    }

}

