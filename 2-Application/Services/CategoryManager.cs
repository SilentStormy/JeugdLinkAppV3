using Core.Entities;
using Core.Repositories;
using JeugdLinkBLL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.Services
{
    public class CategoryManager : ICategoryservice
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryManager> _logger;

        public CategoryManager(ICategoryRepository categoryRepository, ILogger<CategoryManager> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                _logger.LogInformation("Fetching all the categories");
                return _categoryRepository.GetAll();
            }
            catch(Exception ex) 
            {
                _logger.LogError($"An error occured while fetching categories: {ex.Message}");
                throw;
            }
        }
    }
}
