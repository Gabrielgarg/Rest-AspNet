using RestAspNetApi.Models;

namespace RestAspNetApi.Services.Inplementations {
    public interface IpersonService {
        Person Create(Person person);
        Person FindById(long id);

        List<Person> FindAll();
        Person Update(Person person);

        void Delete(long id);

    }
}
