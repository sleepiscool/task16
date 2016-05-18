using System;
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
        bool ExistPerson(Person person);
        IEnumerable<Person> SearchPerson(string surName, string name, string patronymic, string organization, string position, string email,
            string numberPhone);
    }
}