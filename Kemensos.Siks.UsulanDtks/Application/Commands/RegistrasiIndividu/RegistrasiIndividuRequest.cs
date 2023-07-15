namespace Kemensos.Siks.UsulanDtks.Application.Commands.RegistrasiIndividu;

public record RegistrasiIndividuRequest(
    string Nama,
    string Nik,
    string TanggalLahir,
    string JenisKelamin,
    string Jalan,
    string Kota,
    string Provinsi,
    string KodePos
);