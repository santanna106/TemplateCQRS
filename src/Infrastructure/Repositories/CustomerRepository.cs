using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly AppDbContext db;
        public CustomerRepository(AppDbContext context)
        {
            db = context;
        }
        public async Task<Customer> GetById(int id)
        {
            return await db.Customers.FindAsync(id);
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await db.Customers.ToListAsync();
        }
        public async Task<Customer> GetByEmail(string email)
        {
            return await db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }
        public void Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        public void Update(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }
        public void Remove(Customer customer)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
