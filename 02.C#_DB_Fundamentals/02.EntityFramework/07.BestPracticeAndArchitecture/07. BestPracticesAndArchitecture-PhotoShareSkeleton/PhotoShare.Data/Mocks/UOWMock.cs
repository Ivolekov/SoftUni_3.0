using PhotoShare.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Models;

namespace PhotoShare.Data.Mocks
{
    public class UOWMock : IUnitOfWork
    {
        private IRepository<AlbumRole> albumRoles;
        private IRepository<Album> albums;
        private IRepository<Picture> pictures;
        private IRepository<Tag> tags;
        private IRepository<Town> towns;
        private IRepository<User> users;

        public IRepository<AlbumRole> AlbumRoles
        {
            get
            {
                return this.albumRoles ?? (this.albumRoles = new MockRepository<AlbumRole>());
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.albums ?? (this.albums = new MockRepository<Album>());
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.pictures ?? (this.pictures = new MockRepository<Picture>());
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.tags ?? (this.tags = new MockRepository<Tag>());
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.towns ?? (this.towns = new MockRepository<Town>());
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.users ?? (this.users = new MockRepository<User>());
            }
        }
         
        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
