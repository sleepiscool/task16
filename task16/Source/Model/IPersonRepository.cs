using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public interface IPersonRepository
    {
        /// <summary>
        /// возвращает все объекты класса Person из бд
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> GetPeopleList();
        /// <summary>
        /// добавляет обьекты класса Person в бд
        /// </summary>
        /// <param name="person"></param>
        void AddPerson(Person person);
        /// <summary>
        /// удаляет обьект класса Person из бд
        /// </summary>
        /// <param name="person"></param>
        void DeletePerson(Person person);
        /// <summary>
        /// изменяет обьект класса Person в бд
        /// </summary>
        /// <param name="person"></param>
        void ChangePerson(Person person);
        /// <summary>
        /// Проверяет существует ли данный обьект Person В дб
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        bool ExistPerson(Person person);
        /// <summary>
        /// возвращает все обьекты класса Person в дб, которые удовлетворяют данным параметрам
        /// </summary>
        /// <param name="surName">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="organization">Организация</param>
        /// <param name="position">Должность</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="numberPhone">номер телефона</param>
        /// <returns></returns>
        IEnumerable<Person> SearchPerson(string surName, string name, string patronymic, string organization, string position, string email,
            string numberPhone);
    }
}