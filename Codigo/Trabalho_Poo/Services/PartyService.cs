using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_POO.Entities.Enums;

namespace FestaECia.Services
{
	public class PartyService
	{
		public static CategoryType DefineType(string type)
		{
			if (type.ToLower().Equals("premier"))
			{
				return CategoryType.Premier;
			}
			else if (type.ToLower().Equals("luxo"))
			{
				return CategoryType.Luxo;
			}
			else if (type.ToLower().Equals("standard"))
			{
				return CategoryType.Standard;
			}
			else
			{
				throw new ArgumentException("This type does not exist in our database");
			}
		}
	}
}
