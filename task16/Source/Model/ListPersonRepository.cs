using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Model
{
    public class ListPersonRepository : IPersonRepository
    {
        private readonly List<Person> _people;

        private int _lastId;

        public ListPersonRepository()
        {
            _people = new List<Person>();
        }

        public IEnumerable<Person> GetPeopleList()
        {
            return new List<Person>(_people);
        }

        public void ChangePerson(Person person)
        {
            var peopleFromList = _people.SingleOrDefault(u => u.Id == person.Id);

            if (peopleFromList == null)
                return;

            peopleFromList.Name = person.Name;
            peopleFromList.SurName = person.SurName;
            peopleFromList.Patronymic = person.Patronymic;
            peopleFromList.Position = person.Position;
            peopleFromList.Organization = person.Organization;
            peopleFromList.NumberPhone = person.NumberPhone;
            peopleFromList.Email = person.Email;
        }

        public bool ExistPerson(Person person)
        {
            return _people.Any(person1 => person1 == person);
        }

        public IEnumerable<Person> SearchPerson(string surName, string name, string patronymic, string organization, string position,
            string email, string numberPhone)
        {
            var result = from person in _people
                         where (name == " ") || person.Name.Equals(name)
                         && ((surName == " ") || person.SurName.Equals(surName))
                         && ((patronymic == " ") || person.Patronymic.Equals(patronymic))
                         && ((organization == " ") || person.Organization.Equals(organization))
                         && ((position == " ") || person.Position.Equals(position))
                         && ((email == " ") || person.Email.Equals(email))
                         && ((numberPhone == " ") || person.NumberPhone.Equals(numberPhone))
                         select person;


            return result;
        }


        public void DeletePerson(Person person)
        {
            var peopleFromList = _people.SingleOrDefault(u => u.Id == person.Id);

            if (peopleFromList == null)
                return;

            _people.Remove(peopleFromList);
        }

        public void AddPerson(Person person)
        {
            if (person.Id == 0)
                person.Id = ++_lastId;

            if (_people.Any(u => u.Id == person.Id))
                return;

            _people.Add(person);
        }

        public Person GetPerson(int id)
        {
            var singleOrDefault = _people.SingleOrDefault(s => s.Id == id);
            if (singleOrDefault == null)
                return null;

            return (Person) singleOrDefault.Clone();
        }
    }
}