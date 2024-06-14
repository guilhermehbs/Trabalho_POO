﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_POO.Entities;

namespace FestaECia.Entities
{
	public class CompanyParty : Party
	{
		public CompanyParty() { }

		public CompanyParty(DateTime date, int guestNumber, Space space, string type, Dictionary<string, int> drinkQuantity)
			: base(date, guestNumber, space, type)
		{
		}
	}
}
