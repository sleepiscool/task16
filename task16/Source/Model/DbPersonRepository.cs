using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Model
{
    public class DbPersonRepository : IPersonRepository
    {
        private static readonly string _connectionString = "server=localhost;uid=root;pwd=root;database=databasetask16;";

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
        /// <summary>
        /// Очищение базы данных
        /// </summary>
        public void ClearDataBase()
        {
            using (var connection = new MySqlConnection(_connectionString))
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