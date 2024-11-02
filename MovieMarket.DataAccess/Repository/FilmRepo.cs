using Microsoft.EntityFrameworkCore;
using MovieMarket.DataAccess.DataAccess;
using MovieMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
    public class FilmRepo : Repository<Film>, IFilmRepo
    {
        private readonly AppDBContext _dbContext;
        public FilmRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

		public void Update(Film film)
		{
            var filmFromDB = _dbContext.Films.FirstOrDefault(filmFromDB => filmFromDB.Id == film.Id);
            filmFromDB.Name = film.Name;
            filmFromDB.DirectorId = film.DirectorId;
            if(film.Image != null) 
            { 
                filmFromDB.Image = film.Image;
            }
		}

        public Film GetFilmDirector(int id)
        {
			var film = _dbContext.Films.Include(d => d.Director).FirstOrDefault(f =>f.Id == id);
            return film;
		}
	}
}
