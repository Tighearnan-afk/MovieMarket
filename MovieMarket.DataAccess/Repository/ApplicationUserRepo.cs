using MovieMarket.DataAccess.DataAccess;
using MovieMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
	public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
	{
		private readonly AppDBContext _dbContext;
		public ApplicationUserRepo(AppDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public ApplicationUser Get(string s)
		{
			if (s == "")
				return null;
			else
				return _dbContext.ApplicationUsers.Where(u => u.Id == s).FirstOrDefault();
		}	
	}
}
