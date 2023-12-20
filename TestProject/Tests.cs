using System.Net.Http.Headers;
using Kurss.Infrastructure;
using Kurss.Domain;
using Microsoft.EntityFrameworkCore;
using Kurss.Infrastructure.Repositorys;

namespace TestProject
{
    public class Test
    { 
        private readonly Context _context;
        public Test()
        {
            var contexOptions = new DbContextOptionsBuilder<Context>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test")
                .Options;

            _context = new Context(contexOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var person1 = new Person("Valia", "abc@mail.ru");
            person1.AddPasport(new Pasport("M2", 2026, 123412, "Russian", true));
            person1.AddPasport(new Pasport("M1", 2023, 123124, "USA", true));
            person1.AddSertificate(new Sertificate("1c", "www.123.ru", "sertf1c", true));

            person1.AddSertificate(new Sertificate("3c", "www.321.ru", "sertf3c", true));

            _context.Persons.Add(person1);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
          
        public PersonRepository PersonRepository
        {
            get
            {
                return new PersonRepository(_context);
            }
        }
        
    }

[Fact]
public void VoidTest()
{
    var testHelper = new Test();
    var personRepository = testHelper.PersonRepository;

    Assert.Equal(1, 1);
}

[Fact]
public void TestAdd()
{

    var testHelper = new Test();
    var personRepository = testHelper.PersonRepository;
    var person = new Person("Ivan","1234") ;

    personRepository.AddAsync(person).Wait();

    personRepository.ChangeTrackerClear();

        Assert.True(personRepository.GetAllAsync().Result.Count == 2);
    Assert.Equal("Valia", personRepository.GetByNameAsync("Valia").Result.Name) ;
    Assert.Equal("Ivan", personRepository.GetByNameAsync("Ivan").Result.Name);
    Assert.Equal("abc@mail.ru", personRepository.GetByNameAsync("Valia").Result.Email);

}

[Fact]
public void TestUpdateAdd()
{
    var testHelper = new Test();
    var personRepository = testHelper.PersonRepository;
    var person = personRepository.GetByNameAsync("Valia").Result;

    personRepository.ChangeTrackerClear();
    person.Name = "Valia 12";

        var newSert = new Sertificate("2c", "123", "3c", true);
    person.AddSertificate(newSert) ;

    personRepository.UpdateAsync(person).Wait();

    Assert.Equal("Valia 12", personRepository.GetByNameAsync("Valia 12").Result.Name);

}