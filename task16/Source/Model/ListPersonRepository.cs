using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Model
{
    /// <summary>
    ///     Репозиторий, в котором хранятся объекты класса User, основанный на List.
    /// </summary>
    public class ListPersonRepository : IPersonRepository
    {
        /// <summary>
        ///     Список пользователей, хранящихся в репозитории.
        /// </summary>
        private readonly List<Person> _people;

        /// <summary>
        ///     Id последнего добавленного пользователя.
        /// </summary>
        private int _lastId;

        /// <summary>
        ///     Создаёт новый репозиторий пользователей.
        /// </summary>
        public ListPersonRepository()
        {
            _people = new List<Person>();
        }

        /// <summary>
        ///     Возвращает все объекты класса User, хранящиеся в репозитории.
        /// </summary>
        /// <returns>Все объекты класса User, хранящиеся в репозитории.</returns>
        public IEnumerable<Person> GetPeopleList()
        {
            return new List<Person>(_people);
        }

        /// <summary>
        ///     Обновляет поля указанный объект класса Person.
        /// </summary>
        /// <param name="Person">Объект класса Person, поля которого нужно обновить.</param>
        /// <param name="person"></param>
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

        public IEnumerable<Person> SearchPerson(string surName, string name, string patronymic, string organization, string position, string email,
            string numberPhone)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Удаляет из репозитория указанный объект класса User.
        /// </summary>
        /// <param name="person"></param>
        public void DeletePerson(Person person)
        {
            var peopleFromList = _people.SingleOrDefault(u => u.Id == person.Id);

            if (peopleFromList == null)
                return;

            _people.Remove(peopleFromList);
        }

        /// <summary>
        ///     Добавляет указанного юзера в репозиторий.
        /// </summary>
        /// <param name="person">Добавляемый объекта класса User.</param>
        public void AddPerson(Person person)
        {
            if (person.Id == 0)
                person.Id = ++_lastId;

            if (_people.Any(u => u.Id == person.Id))
                return;

            _people.Add(person);
        }

        /// <summary>
        ///     Возвращает объект класса User с заданным id, если он существует.
        /// </summary>
        /// <param name="id">id искомого объекта класса User.</param>
        /// <returns>Объект класса User с заданным id. Если такого нет то null.</returns>
        public Person GetPerson(int id)
        {
            var singleOrDefault = _people.SingleOrDefault(s => s.Id == id);
            if (singleOrDefault == null)
                return null;

            return (Person) singleOrDefault.Clone();
        }
    }
}