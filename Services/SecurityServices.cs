using System.Collections.Generic;
using System.Linq;
using WEBSITE2023.Models;

namespace WEBSITE2023.Services
{
	public class SecurityService
	{
		
		UserDAO userDAO = new UserDAO();

		public SecurityService() 
		{
			
		}
		public bool IsValid(UserModel user)
		{
			return userDAO.FindUserByNameAndPassword(user);
			// return true if found in the list
			
		}
	}
}
