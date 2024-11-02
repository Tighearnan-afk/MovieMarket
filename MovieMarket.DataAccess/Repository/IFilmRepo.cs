using MovieMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
    public interface IFilmRepo : IRepository<Film>
    {
        public void Update(Film film);
        Film GetFilmDirector(int id);
    }
}
