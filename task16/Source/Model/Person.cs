using System;

namespace Model
{
    public class Person : ICloneable
    {
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

        public Person()
        {
        }

        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }

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

        protected bool Equals(Person other)
        {
            return Id == other.Id && string.Equals(SurName, other.SurName) && string.Equals(Name, other.Name)
                   && string.Equals(Patronymic, other.Patronymic) && string.Equals(Organization, other.Organization)
                   && string.Equals(Position, other.Position) && string.Equals(Email, other.Email)
                   && string.Equals(NumberPhone, other.NumberPhone);
        }

        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (SurName != null ? SurName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Patronymic != null ? Patronymic.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Organization != null ? Organization.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (NumberPhone != null ? NumberPhone.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Person) obj);
        }
    }
}