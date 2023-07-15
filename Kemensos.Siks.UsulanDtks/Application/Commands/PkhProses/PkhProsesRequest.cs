namespace Kemensos.Siks.UsulanDtks.Application.Commands.PkhProses;

public record PkhProsesRequest(
    string Nama,
    string NoKk,
    string Nik,
    string TanggalLahir,
    string JenisKelamin,
    string Jalan,
    string Kota,
    string Provinsi,
    string KodePos,
    decimal Pendapatan,
    int JumlahTanggungan
);