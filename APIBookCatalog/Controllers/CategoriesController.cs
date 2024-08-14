using APIBookCatalog.DTOs;
using APIBookCatalog.Models;
using APIBookCatalog.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBookCatalog.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CategoriesController(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoryDTO>> Get ()
    {
        var categories = _uof.CategoryRepository.GetAll();

        if(categories is null)
            return NotFound("No categories were found.");

        var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}")]
    public ActionResult<CategoryDTO> Get (int id)
    {
        var category = _uof.CategoryRepository.Get(c => c.Id == id);

        if (category is null)
            return NotFound("Category not found.");

        var categoryDto = _mapper.Map<CategoryDTO>(category);

        return Ok(categoryDto);
    }

    [HttpPost]
    public ActionResult<CategoryDTO> Post(CategoryDTO categoryDto)
    {
        if (categoryDto is null)
            return BadRequest("Invalid data.");

        var category = _mapper.Map<Category>(categoryDto);

        var newCategory = _uof.CategoryRepository.Create(category);
        _uof.Commit();

        var newCategoryDto = _mapper.Map<CategoryDTO>(newCategory);

        return new CreatedAtRouteResult(new { id = newCategoryDto.Id }, newCategoryDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CategoryDTO> Put(int id, CategoryDTO categoryDto)
    {
        if (id != categoryDto.Id)
            return BadRequest("Invalid Id.");

        var category = _mapper.Map<Category>(categoryDto);

        var updatedCategory = _uof.CategoryRepository.Update(category);
        _uof.Commit();

        var updatedCategoryDto = _mapper.Map<CategoryDTO>(updatedCategory);

        return Ok(updatedCategoryDto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoryDTO> Delete(int id)
    {
        var category = _uof.CategoryRepository.Get(c => c.Id == id);

        if (category is null)
            return NotFound("Category not found.");

        var deletedCategory = _uof.CategoryRepository.Delete(category);
        _uof.Commit();

        var deletedCategoryDto = _mapper.Map<CategoryDTO>(deletedCategory);

        return Ok(deletedCategoryDto);
    }

}
