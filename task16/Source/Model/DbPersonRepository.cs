using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Model
{
    public class DbPersonRepository : IPersonRepository
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["LocalPersonDatabase"].ConnectionString;

        static DbPersonRepository()
        {
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["LocalPersonDatabase"].ConnectionString;
            }
            catch (Exception)
            {
                //  
            }
        }

        /// <summary>
        /// добавление экземпляра класса Person в бд
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Person person)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                using (var contextDb = new PersonDbContext(connection, false))
                {
                    contextDb.Database.CreateIfNotExists();
                }

                connection.Open();

                var transaction = connection.BeginTransaction();

                try
                {
                    using (var context = new PersonDbContext(connection, false))
                    {
                        context.Database.UseTransaction(transaction);

                        context.People.Add(person);

                        SaveChanges(context);
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        /// <summary>
        ///     Получает всех обьектов класса Person из бд
        /// </summary>
        /// <returns>people</returns>
        public IEnumerable<Person> GetPeopleList()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                using (var contextDb = new PersonDbContext(connection, false))
                {
                    contextDb.Database.CreateIfNotExists();
                }

                connection.Open();

                var transaction = connection.BeginTransaction();

                IEnumerable<Person> people;

                try
                {
                    using (var context = new PersonDbContext(connection, false))
                    {
                        context.Database.UseTransaction(transaction);

                        people = context.People.ToArray();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return people;
            }
        }
        /// <summary>
        /// Возвращает объект класса Person с заданным id, если он существует.
        /// </summary>
        /// <param name="id">id искомого объекта класса Person.</param>
        /// <returns>Объект класса Person с заданным id. Если такого нет то null.</returns>
        public Person GetPerson(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    using (var contextDb = new PersonDbContext(connection, false))
                    {
                        contextDb.Database.CreateIfNotExists();
                    }

                    connection.Open();

                    var transaction = connection.BeginTransaction();

                    Person person;

                    try
                    {
                        using (var context = new PersonDbContext(connection, false))
                        {

                            context.Database.UseTransaction(transaction);

                            person = context.People.SingleOrDefault(u => u.Id == id);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }

                    return person;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Пользователь с таким ID не найден!");
                return null;
            }
        }
        /// <summary>
        ///     удаляет экземпляр класса Person из бд
        /// </summary>
        /// <param name="person"></param>
        public void DeletePerson(Person person)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    using (var contextDb = new PersonDbContext(connection, false))
                    {
                        contextDb.Database.CreateIfNotExists();
                    }

                    connection.Open();

                    var transaction = connection.BeginTransaction();

                    try
                    {
                        using (var context = new PersonDbContext(connection, false))
                        {

                            context.Database.UseTransaction(transaction);

                            context.Entry(person).State = EntityState.Deleted;

                            SaveChanges(context);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("asdas");
            }
        }

        /// <summary>
        ///     Изменяет параметры пользователя в бд
        /// </summary>
        /// <param name="person"></param>
        public void ChangePerson(Person person)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                using (var contextDb = new PersonDbContext(connection, false))
                {
                    contextDb.Database.CreateIfNotExists();
                }

                connection.Open();

                var transaction = connection.BeginTransaction();

                try
                {
                    using (var context = new PersonDbContext(connection, false))
                    {
                        context.Database.UseTransaction(transaction);

                        context.Entry(person).State = EntityState.Modified;

                        SaveChanges(context);
                    }
                    
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }

        /// <summary>
        ///     Проверка на наличие пользователя в бд
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool ExistPerson(Person person)
        {
            var people = GetPeopleList();
            return people.Any(person1 => person1 == person);
        }

        public IEnumerable<Person> SearchPerson(string surName, string name, string patronymic, string organization,
            string position, string email,
            string numberPhone)
        {
            var repository = new DbPersonRepository();

            var peopleList = repository.GetPeopleList();

            
            var result = from person in peopleList
                where ((surName != ""
                            ? person.SurName.Equals(surName)
                            : true)
                        &
                          (name != ""
                            ? person.Name.Equals(name)
                            : true)
                        &
                        (patronymic != ""
                            ? person.Patronymic.Equals(patronymic)
                            : true)
                        &
                        (organization != ""
                            ? person.Organization.Equals(organization)
                            : true)
                        &
                        (position != ""
                            ? person.Position.Equals(position)
                            : true)
                        &
                        (email != ""
                            ? person.Email.Equals(email)
                            : true)
                        &
                        (numberPhone != ""
                            ? person.NumberPhone.Equals(numberPhone)
                            : true))
                    select person;
            return result;
        }

        /// <summary>
        /// Очищение базы данных
        /// </summary>
        public void ClearDataBase()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    const string sql = "DELETE FROM people";

                    connection.Open();

                    var cmd = new MySqlCommand(sql, connection);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        ///     Сохраняет внесенные в контекст изменения в базе данных.
        /// </summary>
        /// <param name="context">Контекст, в котором произошли изменения.</param>
        private static void SaveChanges(DbContext context)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.Single().Reload();
                }
            } while (saveFailed);
        }
    }
}