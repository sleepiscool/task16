using System.Collections;
using System.Linq;
using Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ModelTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddUserToRepository()
        {
            var repository = new DbPersonRepository();
            var person1 = new Person
            {
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person2 = new Person
            {
                Name = "Denis",
                SurName = "Andreev",
                Patronymic = "Ahmdeinov",
                Position = "Engineer",
                Organization = "ikci",
                Email = "den1sqaappkk@mail.ru",
                NumberPhone = "89818226401"
            };
            repository.AddPerson(person1);
            repository.ChangePerson(person1);

            var people = repository.GetPeopleList();
            var enumerable = people as Person[] ?? people.ToArray();

            Assert.IsNull(enumerable.FirstOrDefault(u => u == person2));
            Assert.IsNotNull(enumerable.FirstOrDefault(u => u == person1));

            var samePeople = repository.GetPeopleList().Where(u => u == person1);

            foreach (var personClone in samePeople)
                repository.DeletePerson(personClone);

            people = repository.GetPeopleList();

            Assert.That(people.All(u => u != person1), Is.True);
        }
        
        [Test]
        public void DeleteUserFromList()
        {
            var person = new Person
            {
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(person);
            Assert.IsTrue(peopleList.ExistPerson(person));
            peopleList.DeletePerson(person);
            var personFromList = peopleList.GetPeopleList();

            Assert.That(personFromList.All(u => u != person), Is.True);
        }

        [Test]
        public void GetPersonInList()
        {
            var person = new Person
            {
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(person);

            Assert.That(peopleList.GetPerson(1), Is.EqualTo(person));
            Assert.IsNotNull(peopleList.SearchPerson(" ", "Vasy", " ", " ", " ", " ", " "));
        }

        [Test]
        public void GetUserFromList()
        {
            var person = new Person
            {
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(person);

            var peopleFromList = peopleList.GetPeopleList();
            var fromList = peopleFromList as Person[] ?? peopleFromList.ToArray();
            var personid = fromList.First().Id;
            var personWithNecessaryId = peopleList.GetPerson(personid);

            Assert.IsTrue(fromList.First().Equals(personWithNecessaryId));
        }

        [Test]
        public void SearchPersonTest()
        {
            var person = new Person
            {
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var repository = new DbPersonRepository();
            repository.AddPerson(new Person
            {
                Id = 0,
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            });
            repository.AddPerson(person);
            Assert.IsTrue(repository.ExistPerson(person));
            repository.DeletePerson(person);
            Assert.IsFalse(repository.ExistPerson(person));
        }

        [Test]
        public void SearchWithParametres()
        {
            var repository = new DbPersonRepository();
            var person1 = new Person
            {
                SurName = "Pupkin",
                Name = "Vasy",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person2 = new Person
            {
                SurName = "Pupkin",
                Name = "Evgen",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person3 = new Person
            {
                SurName = "Pupkin",
                Name = "Denis",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person4 = new Person
            {
                SurName = "Pupkin",
                Name = "Vova",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person5 = new Person
            {
                SurName = "Pupkin",
                Name = "Semen",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person6 = new Person
            {
                SurName = "123",
                Name = "Leha",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person7 = new Person
            {
                SurName = "Andreev",
                Name = "Denis",
                Patronymic = "Anatolbevich",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var person8 = new Person
            {
                SurName = "Andreev",
                Name = "Denis",
                Patronymic = "asd",
                Organization = "ikci",
                Position = "Engineer",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };

            repository.AddPerson(person1);
            repository.AddPerson(person2);
            repository.AddPerson(person3);
            repository.AddPerson(person4);
            repository.AddPerson(person5);
            repository.AddPerson(person6);
            repository.AddPerson(person7);
            repository.AddPerson(person8);

            var people = repository.SearchPerson("Andreev", "Denis", "asd", " ", " ", " ", " ");
            Assert.IsNotNull(people);

            foreach (var person in people)
                Assert.IsTrue(person.Name.Equals("Denis") && person.SurName.Equals("Andreev") &&
                              person.Patronymic.Equals("asd"));

            repository.ClearDataBase();
            Assert.IsEmpty((ICollection) repository.GetPeopleList());
        }

        [Test]
        public void TestPerson()
        {
            var person1 = new Person
            {
                Name = "Vasya",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "888888888",
                Organization = "greenDay",
                Patronymic = "asdasd",
                Position = "na4",
                SurName = "Vasil"
            };
            var person2 = new Person("Vasil", "Vasya", "asdasd", "greenDay", "na4", "denis007_1996@mail.ru", "888888888");
            Assert.IsTrue(person1.GetHashCode() == person2.GetHashCode());
            var temp = new List();
            Assert.IsFalse(person1.Equals(temp));
        }

        [Test]
        public void UpdateUserInList()
        {
            var person = new Person
            {
                Name = "Vasy",
                SurName = "Pupkin",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };
            var peopleList = new ListPersonRepository();

            peopleList.AddPerson(person);

            var personFromList = peopleList.GetPeopleList();
            var newPerson = (Person) person.Clone();

            newPerson.Name = "Evgeniy";

            peopleList.ChangePerson(newPerson);

            Assert.IsTrue(newPerson.Equals(personFromList.First()));

            newPerson.Id = 213;
            newPerson.Name = "Vasya";
            peopleList.ChangePerson(newPerson);

            Assert.That(peopleList.GetPerson(213), Is.EqualTo(null));
        }
    }
}