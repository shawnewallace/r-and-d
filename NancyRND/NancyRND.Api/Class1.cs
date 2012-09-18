using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using NancyRND.Lib;

namespace NancyRND.Api
{
	public class BookModule : NancyModule
	{
		public BookModule() : base("/books")
		{
			Get["/"] = parameters => DoSomething();
			Get["/get/{id}"] = parameters => GetById(parameters.id);
			Post["/new"] = parameters =>
			{
			  var model = this.Bind<Book>();
			  return Response.AsJson(CreateBook(model), HttpStatusCode.Created);
			};
			Delete["/destroy/{id}"] = parameters =>
			{
			  DeleteById(parameters.id);
			  return HttpStatusCode.OK;
			};
		}

		private void DeleteById(int id)
		{
			using (var db = new BookContext())
			{
				var model = db.Books.FirstOrDefault(b => b.Id == id);
				db.Books.Remove(model);
				db.SaveChanges();
			}
		}

		private Book GetById(int id)
		{
			using (var db = new BookContext())
			{
				return db.Books.FirstOrDefault(b => b.Id == id);
			}
		}

		private Book CreateBook(Book model)
		{
			using (var db = new BookContext())
			{
				model = db.Books.Add(model);
				db.SaveChanges();
				return model;
			}
		}

		private List<Book> DoSomething()
		{
			using (var db = new BookContext())
			{
				return db.Books.Select(b => b).ToList();
			}
		}
	}
}
