﻿using Data.Abstract;
using Data.Concrete.EntityFramework.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EfCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddCategoryProduct(int id, int pro)
        {
            var product = _context.Products.Find(pro);

            var category = _context.Categories.FirstOrDefault(a => a.Id == id);

            CategoryAndProduct newQuestCat = new CategoryAndProduct
            {
                Category = category,
                Product = product
            };
            await _context.Set<CategoryAndProduct>().AddAsync(newQuestCat);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> CategoryExists(string name)
        {
            var exist = await _context.Categories.FirstOrDefaultAsync(a => a.Name.Trim() == name.Trim());
            return exist;
        }

        public async Task<Category> CategoryExistsId(int id)
        {
            var exist = await _context.Categories.FirstOrDefaultAsync(a => a.Id == id);
            return exist;
        }

        public async Task Delete(Category category)
        {
            await Task.Run(() => { _context.Set<Category>().Remove(category); });
            _context.SaveChanges();
        }

        public async Task<List<Category>> GetAll()
        {
            var category = await _context.Categories.ToListAsync();
            return category;
        }

        public async Task<List<Category>> GetCategories(string searchTerm)
        {
            return await _context.Categories.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                            .Take(10)
                                            .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesId(int id)
        {
            return await _context.Categories.Where(a => a.Id == id).ToListAsync();
        }

        public  Task<Category> GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefaultAsync(q => q.Id == id);
            return category;
        }

        public Task<Category> Update(Category category, int id)
        {
            if (category == null)
            {
                throw new ArgumentNullException("item");
            }

            var item = _context.Categories.FirstOrDefaultAsync(q => q.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException("product");
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            return item;
        }
    }
}
