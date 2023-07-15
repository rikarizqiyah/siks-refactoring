using System;
using Kemensos.Siks.UsulanDtks.Domain.Individu;

namespace Kemensos.Siks.UsulanDtks.Application.Commands.RegistrasiIndividu;

public class RegistrasiIndividuCommand
{
    private IIndividuRepository _individuRepository;

    public RegistrasiIndividuCommand(IIndividuRepository individuRepository)
    {
        _individuRepository = individuRepository;
    }

    public Individu Handle(RegistrasiIndividuRequest request)
    {
        //TODO: authorization check
        //TODO: request parameter validation
        
        var nik = new Nik(request.Nik);

        //check individu apakah exist
        var individu = _individuRepository.GetByNik(nik);

        if (individu != null) {
            throw new Exception("NIK telah terdaftar.");
        }

        DateTime tanggalLahir;

        var tanggalLahirValid = DateTime.TryParseExact(request.TanggalLahir, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out tanggalLahir);

        if (!tanggalLahirValid)
        {
            throw new Exception("Format tanggal lahir tidak valid");
        }

        //buat objek individu
  
        var alamat = new Alamat(
                request.Jalan,
                request.Kota,
                request.Provinsi,
                request.KodePos
            );

        var jenisKelamin = new JenisKelamin(request.JenisKelamin);

        var individuBaru = Individu.Register(
                nik,
                request.Nama,
                new TanggalLahir(tanggalLahir),
                jenisKelamin,
                alamat
            );

        //simpan individu baru
        _individuRepository.Save(individuBaru);

        return individuBaru;
    }
}

