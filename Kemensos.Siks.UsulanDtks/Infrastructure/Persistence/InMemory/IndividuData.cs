namespace Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;

public static class IndividuData
{
  //public static List<string> ValidCategories = new List<string>
  //  {
  //      "Category1",
  //      "Category2",
  //      "Category3"
  //  };
  public class Person
  {
    public int Id { get; set; }
    public string NoKk { get; set; }
    public string Nik { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Status { get; set; }
    public string Kategori { get; set; }
  }
  public static Dictionary<int, Person> ListIndividu = new Dictionary<int, Person>
    {
        { 
          1,
          new Person {
            Id = 1,
            NoKk = "3173053012299919",
            Nik = "3173054708959999",
            Name = "Bunga",
            Age = 20,
            Status = "Aktif",
            Kategori = "Hamil"

          }
      },
        { 
          2,
          new Person { 
            Id = 2,
            NoKk = "3173053012299911",
            Nik = "3173054708959991",
            Name = "Mei", 
            Age = 2, 
            Status = "Tidak Aktif",
            Kategori = "AUD"
          } 
        }
    };
}
