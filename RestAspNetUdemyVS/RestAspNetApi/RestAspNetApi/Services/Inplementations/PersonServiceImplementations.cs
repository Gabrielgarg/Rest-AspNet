using RestAspNetApi.Models;

namespace RestAspNetApi.Services.Inplementations;

public class PersonServiceImplementations : IpersonService
{
    private volatile int count;  
    
    public Person Create(Person person)
    {
        return person;
    }

    public Person FindById(long id)
    {
        return new Person
        {
            id = 1,
            first_name = "eai",
            last_name = "blz?",
            address = "uberlandia",
            gender = "male"
        };
    }

    public List<Person> FindAll()
    {
        List<Person> persons = new List<Person>();
        for (int i = 0; i < 8; i++)
        {
            Person person = MockPerson(i);
            persons.Add(person);
        }
        return persons;
    }

    public Person Update(Person person)
    {
        return person;
    }

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }

    private Person MockPerson(int i)
    {
        return new Person
        {
            id = IncrementAndGet(),
            first_name = "teste" + i,
            last_name = "teste2?" + i,
            address = "teste3" + i,
            gender = "teste4" + i
        };
    }

    private long IncrementAndGet()
    {
        return Interlocked.Increment(ref count);
    }
}