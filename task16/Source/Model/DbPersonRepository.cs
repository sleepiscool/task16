using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Model
{
    /// <summary>
    ///     Репозиторий, в котором хранятся объекты класса Person, основанный на базе данных
    /// </summary>
    public class DbPersonRepository : IPersonRepository
    {
        /// <summary>
        ///     Строка подключения к базе данных, параметры которой берутся из app.config.
        /// </summary>
        private readonly string _connectionString = "server=localhost;uid=root;pwd=root;database=databasetask17;";

        /// <summary>
        ///     Добавляет указанного юзера в репозиторий.
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Person person)
        {
            using (var connection = new MySqlConnection(_connectionString))
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

        public IEnumerable<Person> GetPeopleList()
        {
            using (var connection = new MySqlConnection(_connectionString))
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

        public void DeletePerson(Person person)
        {
            using (var connection = new MySqlConnection(_connectionString))
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

                        context.People.Attach(person);
                        context.People.Remove(person);

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

        public void ChangePerson(Person person)
        {
            using (var connection = new MySqlConnection(_connectionString))
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

        public bool SearchPerson(Person person)
        {
            var people = GetPeopleList();
            return people.Any(person1 => person1 == person);
        }

        /// <summary>
        ///     Сохраняет внесенные в контекст изменения в базе данных.
        /// </summary>
        /// <param name="context">Контекст, в котором произошли изменения.</param>
        private static void SaveChanges(PersonDbContext context)
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