using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly1.Dtos;
using Vidly1.Models;

namespace Vidly1.Controllers.Api
{
	public class CustomersApiController : ApiController
    {
		private ApplicationDbContext _context;

		public CustomersApiController()
		{
			_context = new ApplicationDbContext();
		}

		//Get /api/Customers
		public IEnumerable<CustomerDto> GetCustomers()
		{
			return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>	);
		}

		//Get /api/Customers/1
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}

		//post/api/Customer
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();


			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;
			return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
		}

		//PUT/api/ Customer/1
		[HttpPut]
		public void UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);


			Mapper.Map(customerDto, customerInDb);

			_ = _context.SaveChanges();
		}

		//delete /api/customer/1
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();

		}
	}
}
