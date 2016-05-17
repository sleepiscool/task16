﻿using System.Linq;
using Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ModelTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DbRepositoryChangePersonTest()
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

        }
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
            Assert.IsTrue(repository.SearchPerson(person));
            repository.DeletePerson(person);
            Assert.IsFalse(repository.SearchPerson(person));
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

            peopleList.DeletePerson(person);

            var personFromList = peopleList.GetPeopleList();

            Assert.That(personFromList.All(u => u != person), Is.True);
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

            var newPerson = (Person)person.Clone();

            newPerson.Name = "Evgeniy";

            peopleList.ChangePerson(newPerson);

            Assert.IsTrue(newPerson.Equals(personFromList.First()));

            newPerson.Id = 213;
            newPerson.Name = "Vasya";
            peopleList.ChangePerson(newPerson);

            Assert.That(peopleList.GetPerson(213), Is.EqualTo(null));
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
        }
    }

}