using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeopleList();
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void ChangePerson(Person person);
        bool SearchPerson(Person person);
    }
}