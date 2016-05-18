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
        private readonly string _connectionString = "server=localhost;uid=root;pwd=root;database=databasetask18;";

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

        public bool ExistPerson(Person person)
        {
            var people = GetPeopleList();
            return people.Any(person1 => person1 == person);
        }

        public IEnumerable<Person> SearchPerson(string surName, string name, string patronymic, string organization, string position, string email,
            string numberPhone)
        {
            var repository = new DbPersonRepository();
            var personSearch = new Person(surName, name, patronymic, organization,  position,  email,numberPhone);

            var peopleList = repository.GetPeopleList();

            var result = from person in peopleList
                where ((personSearch.SurName != "1"
                        ? person.SurName.Equals(personSearch.SurName)
                        : true)
                        &
                          (personSearch.Name != "1"
                            ? person.Name.Equals(personSearch.Patronymic)
                            : true)
                          &
                          (personSearch.Patronymic != "1"
                            ? person.Patronymic.Equals(personSearch.Patronymic)
                            : true)
                              &
                              (personSearch.Organization != "1"
                                ? person.Organization.Equals(personSearch.Organization)
                                : true)
                                  &
                                  (personSearch.Position != "1"
                                    ? person.Position.Equals(personSearch.Position)
                                    : true)
                                      &
                                      (personSearch.Email != "1"
                                        ? person.Email.Equals(personSearch.Email)
                                        : true)
                                          &
                                          (personSearch.NumberPhone != "1"
                                            ? person.NumberPhone.Equals(personSearch.NumberPhone)
                                            : true))
                select person;


            return result;
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