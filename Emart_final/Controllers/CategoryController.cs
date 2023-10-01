﻿using Emart_final.Models;
using Emart_final.Repository.Categoryfolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _repository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _repository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var addedCategory = await _repository.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = addedCategory.catmasterID }, addedCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.catmasterID)
            {
                return BadRequest();
            }

            var updatedCategory = await _repository.UpdateCategory(id, category);

            if (updatedCategory == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _repository.DeleteCategory(id);

            if (categoryToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("ByName/{categoryname}")]
        public async Task<ActionResult<Category>> GetCategoryByName(string categoryname)
        {
            var category = await _repository.GetCategoriesByCategoryByName(categoryname);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}
