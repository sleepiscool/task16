using System;

namespace Model
{
    public class Person : ICloneable
    {
        /// <summary>
        /// Конструктор объекта класса Person
        /// </summary>
        /// <param name="surName">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="organization">Организация</param>
        /// <param name="position">Должность</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="numberPhone">номер телефона</param>
        public Person(string surName, string name, string patronymic, string organization, string position, string email,
            string numberPhone)
        {
            SurName = surName;
            Name = name;
            Patronymic = patronymic;
            Organization = organization;
            Position = position;
            Email = email;
            NumberPhone = numberPhone;
        }
        /// <summary>
        /// Конструктор без параметров класса Person
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Индефикатор объекта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Фамилия 
        /// </summary>
        public string SurName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Оргаанизация
        /// </summary>
        public string Organization { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string NumberPhone { get; set; }
        /// <summary>
        /// Возвращает копию данного Person
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Person
            {
                Id = Id,
                SurName = SurName,
                Name = Name,
                Patronymic = Patronymic,
                Organization = Organization,
                Position = Position,
                Email = Email,
                NumberPhone = NumberPhone
            };
        }
        /// <summary>
        /// Сравнивает объекты
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Person other)
        {
            return Id == other.Id && string.Equals(SurName.ToLower(), other.SurName.ToLower()) && string.Equals(Name.ToLower(), other.Name.ToLower())
                   && string.Equals(Patronymic.ToLower(), other.Patronymic.ToLower()) && string.Equals(Organization, other.Organization)
                   && string.Equals(Position, other.Position) && string.Equals(Email, other.Email)
                   && string.Equals(NumberPhone, other.NumberPhone);
        }
        /// <summary>
        /// Переопределения оператора =
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }
        /// <summary>
        /// Переопределение оператора !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
        /// <summary>
        /// Сравнивает объекты
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Person) obj);
        }
    }
}