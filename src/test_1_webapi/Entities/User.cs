using System;
using System.Collections.Generic;
using System.Linq;

namespace test_1_webapi_Domain.Entities
{
    public class User : IEntity
    {
        protected readonly int _id;
        protected readonly IList<Album> _albums = new List<Album>();
        protected string _name;
        protected string _email;
        protected DateTime? _date;

        protected internal User(int id, string name, string email, DateTime? date = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            _id = id;
            _name = name;
            _email = email;
            _date = date;

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

        public string Email
        {
            get
            {
                return _email;
            }
        }

        public DateTime? Date
        {
            get
            {
                return _date;
            }
        }

        public void AddAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _albums.Add(album);
        }

        public void DeleteAlbum(Album album)
        {
            _albums.Remove(album);
        }

        public IEnumerable<Album> Albums
        {
            get
            {
                return _albums.AsEnumerable();
            }
        }
    }
}
