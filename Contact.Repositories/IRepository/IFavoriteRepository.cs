
using Contact.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Repositories
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        void Update(Favorite favorite);
    }
}