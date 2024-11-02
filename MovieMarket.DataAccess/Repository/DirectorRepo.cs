using MovieMarket.DataAccess.DataAccess;
using MovieMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
	public class DirectorRepo : Repository<Director>, IDirectorRepo
	{
		private readonly AppDBContext _dbContext;
		public DirectorRepo(AppDBContext dbContext) : base(dbContext) 
		{ 
			_dbContext = dbContext;
		}
	}
}
