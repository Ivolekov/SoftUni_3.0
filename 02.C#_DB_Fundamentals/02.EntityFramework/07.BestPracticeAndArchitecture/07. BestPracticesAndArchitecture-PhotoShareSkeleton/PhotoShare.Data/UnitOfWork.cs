using PhotoShare.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Models;

namespace PhotoShare.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotoShareContext context;

        public UnitOfWork()
        {
            this.context = new PhotoShareContext();
        }

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
                return this.albumRoles ?? (this.albumRoles = new Repository<AlbumRole>(this.context.AlbumRoles));
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.albums ?? (this.albums = new Repository<Album>(this.context.Albums));
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.pictures ?? (this.pictures = new Repository<Picture>(this.context.Pictures));
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.tags ?? (this.tags = new Repository<Tag>(this.context.Tags));
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.towns ?? (this.towns = new Repository<Town>(this.context.Towns));
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.users ?? (this.users = new Repository<User>(this.context.Users));
            }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
