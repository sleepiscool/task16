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
        public void SearchPersonTest()
        {
            var person = new Person
            {
                Name = "Vasy",
                SurName = "Andreev",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            };

            var repository = new DbPersonRepository();
            repository.AddPerson(person);
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
            repository.AddPerson(new Person
            {
                Id = 0,
                Name = "Leha",
                SurName = "Andreev",
                Patronymic = "Anatolbevich",
                Position = "Engineer",
                Organization = "ikci",
                Email = "denis007_1996@mail.ru",
                NumberPhone = "89652793643"
            });
            var personListWithParametrs = repository.SearchPerson("", "Andreev", "", "", "", "", "");
            foreach (var temp in personListWithParametrs)
                Assert.IsTrue(temp.SurName.Equals("Andreev"));

            Assert.IsTrue(repository.ExistPerson(person));
            repository.DeletePerson(person);
            Assert.IsFalse(repository.ExistPerson(person));
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
            Assert.IsFalse(person1.GetHashCode() == person2.GetHashCode());
            Assert.IsFalse((Person) person1.Clone() != person2);
            var temp = new List();
            Assert.IsFalse(person1.Equals(temp));
        }
    }
}