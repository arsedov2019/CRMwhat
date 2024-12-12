using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить продукт по его идентификатору.
        /// </summary>
        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Получить все продукты.
        /// </summary>
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        /// <summary>
        /// Добавить новый продукт.
        /// </summary>
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновить данные о продукте.
        /// </summary>
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удалить продукт из базы данных.
        /// </summary>
        public void Delete(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
