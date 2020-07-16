using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using vHotelAPI.Contracts;
using vHotelAPI.Models;

namespace vHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public CategoryController(IRepositoryWrapper repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _repository.Category.GetAllCategories();
                //_logger.LogInfo($"Returned all categories from database.");

                var categoriesResult = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return Ok(categoriesResult);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside GetAllCategories action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _repository.Category.GetCateogryById(id);
                if (category == null)
                {
                    //_logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    //_logger.LogInfo($"Returned category with id: {id}");

                    var categoryResult = _mapper.Map<CategoryDto>(category);
                    return Ok(categoryResult);
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError($"Something went wrong inside GetCategoryById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/product")]
        public IActionResult GetCategoryWithDetails(int id)
        {
            try
            {
                var category = _repository.Category.GetCategoryWithDetails(id);
                if (category == null)
                {
                    //_logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    //_logger.LogInfo($"Returned category with details for id: {id}");

                    var categoryResult = _mapper.Map<CategoryDto>(category);
                    return Ok(categoryResult);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside GetCategoryWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] NewCategoryDto category)
        {
            try
            {
                if (category == null)
                {
                    //_logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }

                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = _mapper.Map<Category>(category);

                _repository.Category.CreateCategory(categoryEntity);
                _repository.Save();

                var createdCategory = _mapper.Map<CategoryDto>(categoryEntity);

                return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside CreateCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto category)
        {
            try
            {
                if (category == null)
                {
                    //_logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }

                if (!ModelState.IsValid)
                {
                    //logger.LogError("Invalid category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = _repository.Category.GetCateogryById(id);
                if (categoryEntity == null)
                {
                    //_logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(category, categoryEntity);

                _repository.Category.UpdateCategory(categoryEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _repository.Category.GetCateogryById(id);
                if (category == null)
                {
                    //_logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repository.Product.ProductsByCategory(id).Any())               
                {
                    //_logger.LogError($"Cannot delete category with id: {id}. It has related accounts. Delete those product first");
                    return BadRequest("Cannot delete category. It has related products. Delete those products first");
                }

                _repository.Category.DeleteCategory(category);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
