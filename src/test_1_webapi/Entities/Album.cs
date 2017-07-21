using System;

namespace test_1_webapi_Domain.Entities
{
    public class Album : IEntity
    {
        protected readonly int _id;
        protected readonly DateTime _createdDate;
        protected string _name;

        protected internal Album(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _id = id;
            _name = name;
            _createdDate = DateTime.UtcNow;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
        }

    }
}
