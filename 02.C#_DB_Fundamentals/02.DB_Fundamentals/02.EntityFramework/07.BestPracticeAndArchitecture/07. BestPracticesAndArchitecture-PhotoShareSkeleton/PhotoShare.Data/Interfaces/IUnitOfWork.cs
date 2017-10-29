using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Album> Albums { get; }

        IRepository<User> Users { get; }

        IRepository<Picture> Pictures { get; }

        IRepository<Tag> Tags { get; }

        IRepository<AlbumRole> AlbumRoles { get; }

        IRepository<Town> Towns { get; }

        void Commit();
    }
}
