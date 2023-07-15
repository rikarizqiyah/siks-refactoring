using System;
namespace Kemensos.Siks.UsulanDtks.Domain.Individu;

public class TanggalLahir
{
    private const int MIN_USIA = 0;
    private const int MAKS_USIA = 200;
    private const int BATAS_BAWAH_USIA_LANSIA = 60;
    private const int BATAS_BAWAH_USIA_DINI = 0;
    private const int BATAS_ATAS_USIA_DINI = 6;

    private DateTime _tanggalLahir;
    private int _usia;

    public TanggalLahir(DateTime value)
    {
        _tanggalLahir = value;
        _usia = hitungUsia(_tanggalLahir);
    }

    public DateTime GetValue() {
        return _tanggalLahir;
    }

    private int hitungUsia(DateTime tanggalLahir)
    {
        DateTime currentDate = DateTime.Now; // Current date

        int age = currentDate.Year - tanggalLahir.Year;

        // Check if the birth date hasn't occurred yet this year
        if (currentDate.Month < tanggalLahir.Month || (currentDate.Month == tanggalLahir.Month && currentDate.Day < tanggalLahir.Day))
        {
            age--;
        }

        return age;
    }

    public int Usia()
    {
        return _usia;
    }

    public int UsiaKetika(DateTime tanggalTertentu)
    {
        int age;

        age = tanggalTertentu.Year - _tanggalLahir.Year;

        if (age > 0)
        {
            age -= Convert.ToInt32(tanggalTertentu.Date < _tanggalLahir.Date.AddYears(age));
        }
        else
        {
            age = 0;
        }

        return age;
    }

    public bool Equals(TanggalLahir other)
    {
        if (_tanggalLahir == other._tanggalLahir) {
            return true;
        }

        return false;
    }

    public bool IsUsiaDini()
    {
        if (Usia() >= BATAS_BAWAH_USIA_DINI && Usia() <= BATAS_ATAS_USIA_DINI)
        {
            return true;
        }

        return false;
    }

    public bool IsUsiaLansia()
    {
        if (Usia() >= BATAS_BAWAH_USIA_LANSIA)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return _tanggalLahir.ToString("dd-MM-yyyy");
    }



}

