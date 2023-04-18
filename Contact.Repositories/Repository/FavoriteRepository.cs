using Contact.Entities;
using Contact.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact.Repositories
{  
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        private readonly SqlDbContext _db;
        public FavoriteRepository(SqlDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Favorite favorite)
        {

            var objFromDb = _db.Favorites.FirstOrDefault(s => s.Id == favorite.Id);
            if (objFromDb != null)
            {

                objFromDb.PersonId = favorite.PersonId;

            }
        }


    }
}
