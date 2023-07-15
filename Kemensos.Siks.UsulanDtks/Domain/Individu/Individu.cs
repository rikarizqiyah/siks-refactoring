using System;
namespace Kemensos.Siks.UsulanDtks.Domain.Individu;

public class Individu
{
    private const bool STATUS_HIDUP_DEFAULT = true;
    private const bool STATUS_AKTIF_DEFAULT = true;

    public IndividuId Id { get; }
    public Nik Nik { get; }
    public string Nama { get; }
    public TanggalLahir TanggalLahir { get; }
    public JenisKelamin JenisKelamin { get; }
    public Alamat Alamat { get; }
    public bool Aktif { get; private set; }
    public StatusHidup StatusHidup { get; private set; }

    public Individu(
        IndividuId id,
        Nik nik,
        string nama,
        TanggalLahir tanggalLahir,
        JenisKelamin jenisKelamin,
        Alamat alamat,
        bool aktif,
        StatusHidup statusHidup)
    {
        //TODO: validate input parameter
        if (string.IsNullOrEmpty(nama))
        {
            throw new Exception("Nama tidak boleh kosong");
        }

        this.Id = id;
        this.Nik = nik;
        this.Nama = nama;
        this.TanggalLahir = tanggalLahir;
        this.JenisKelamin = jenisKelamin;
        this.StatusHidup = statusHidup;
        this.Alamat = alamat;
        this.Aktif = aktif;
        this.StatusHidup = statusHidup;
    }

    //factory method
    public static Individu Register(
        Nik nik,
        string nama,
        TanggalLahir tanggalLahir,
        JenisKelamin jenisKelamin,
        Alamat alamat)
    {
        var id = new IndividuId(Guid.NewGuid());

        return new Individu(
                id,
                nik,
                nama,
                tanggalLahir,
                jenisKelamin,
                alamat,
                STATUS_AKTIF_DEFAULT,
                new StatusHidup(STATUS_HIDUP_DEFAULT)
            );
    }

    public void Aktifkan() {

        if (Aktif)
        {
            throw new Exception("Tidak dapat mengaktifkan individu dengan status sudah aktif");
        }

        if (!StatusHidup.Value && !Aktif)
        {
            throw new Exception("Tidak dapat mengaktifkan individu dengan status meninggal");
        }

        Aktif = true;
    }

    public void NonAktifkan()
    {
        if (!Aktif)
        {
            throw new Exception("Tidak dapat menonaktifkan individu yang sudah non-aktif");
        }

        Aktif = false;
    }

    public void SetMeninggal()
    {
        if (!StatusHidup.Value)
        {
            throw new Exception("Tidak dapat set meninggal individu yang sudah meninggal");
        }

        StatusHidup = new StatusHidup(false);
    }

    public void SetHidupKembali()
    {
        if (StatusHidup.Value)
        {
            throw new Exception("Tidak dapat set hidup individu yang sudah hidup");
        }

        StatusHidup = new StatusHidup(true);
    }
}

