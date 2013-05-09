using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentRND.Lib
{
	public class Person : IPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		public List<Address> Addresses { get; set; }
	}

	

	public class Address : IAddress
	{
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
	}



	public interface IPersonFactory
	{
		IPersonFactory Initialize();
		IPersonFactory AddFirstName(string firstName);
		IPersonFactory AddLastName(string lastName);
		IPersonFactory AddMiddleName(string middleName);
		IPerson Create();
	}

	public interface IPerson
	{
		string FirstName { get; set; }
		string LastName { get; set; }
		string MiddleName { get; set; }
		List<IAddress> Addresses { get; set; }
	}

	public interface IAddress
	{
		string AddressLine1 { get; set; }
		string AddressLine2 { get; set; }
		string City { get; set; }
		string State { get; set; }
		string ZipCode { get; set; }
	}

}
