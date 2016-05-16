using System.Linq;
using Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ModelTests
{
    [TestFixture]
    public class Tests
    {

        private readonly Person _person = new Person  {
                Name = "Denis",
                SurName = "Andreev",
                Patronymic = "Vasiliyvich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };

        [Test]
        public void AddUserToRepository()
        {
            var repository = new DbPersonRepository();

            repository.AddPerson(_person);

            var people = repository.GetPeopleList();

            var userInDb = people.FirstOrDefault(u => u == _person);

            Assert.That(userInDb, Is.Not.Null);

            var sameUsers = repository.GetPeopleList().Where(u => u == _person);

            foreach (var personClone in sameUsers)
                repository.DeletePerson(personClone);

            people = repository.GetPeopleList();

            Assert.That(people.All(u => u != _person), Is.True);
        }

        [Test]
        public void SearchPersonTest()
        {
            var repository = new DbPersonRepository();
            repository.AddPerson(new Person{
                Id = 0,
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            });
            repository.AddPerson(_person);
            Assert.IsTrue(repository.SearchPerson(_person));
            repository.DeletePerson(_person);
            Assert.IsFalse(repository.SearchPerson(_person));
        }
        [Test]
        public void DeleteUserFromList()
        {
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(_person);

            peopleList.DeletePerson(_person);

            var personFromList = peopleList.GetPeopleList();

            Assert.That(personFromList.All(u => u != _person), Is.True);
        }

        [Test]
        public void GetUserFromList()
        {
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(_person);

            var peopleFromList = peopleList.GetPeopleList();

            var fromList = peopleFromList as Person[] ?? peopleFromList.ToArray();
            var personid = fromList.First().Id;

            var userWithNecessaryId = peopleList.GetPerson(personid);


            Assert.IsTrue(fromList.First().Equals(userWithNecessaryId));
        }

        [Test]
        public void UpdateUserInList()
        {
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(_person);

            var personFromList = peopleList.GetPeopleList();

            var newUser = (Person) _person.Clone();

            newUser.Name = "Semen";

            peopleList.ChangePerson(newUser);

            Assert.IsTrue(newUser.Equals(personFromList.First()));

            newUser.Id = 213;
            newUser.Name = "Vasya";
            peopleList.ChangePerson(newUser);

            Assert.That(peopleList.GetPerson(213), Is.EqualTo(null));
        }
    }
}