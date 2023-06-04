using BCommerce.Admin.Models;
using BCommerce.Application.Data;
using BCommerce.Application.Services;
using BCommerce.Core.DomainClasses;
using BCommerce.Core.DTO;
using BCommerce.Insfrastructure.Data;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace BCommerce.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IApplicationDbContext applicationDbContext;
        public CategoryController(IApplicationDbContext applicationDbContext)
        {

            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult List()
        {
            return View();
        }

        public async Task<IActionResult> GetCategories(DataSourceLoadOptions loadOptions)
        {

            var data = applicationDbContext.Categories.Select(t => new CategoryModel
            {
                Id = t.Id,
                Name = t.Name,
                MainCategoryId = t.MainCategoryId
            });

            var resultData = await DataSourceLoader.LoadAsync(data, loadOptions);

            return Json(resultData);

        }


        [HttpGet]
        public object MainCategoryList(DataSourceLoadOptions loadOptions)
        {

            var model = applicationDbContext.MainCategories;

            return DataSourceLoader.Load(model, loadOptions);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(string values)
        {
            var model = JsonConvert.DeserializeObject<CategoryModel>(values);
            var addedCategory = new Category()
            {
                Name = model.Name,
                MainCategoryId = model.MainCategoryId

            };

            await applicationDbContext.Categories.AddAsync(addedCategory);
            applicationDbContext.Save();


            return Json(addedCategory);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int key, string values)
        {
            var updatedCategory =
                await applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Id == key);


            if (updatedCategory is null) return BadRequest();

            JsonConvert.PopulateObject(values, updatedCategory);

            applicationDbContext.Categories.Update(updatedCategory);

            applicationDbContext.Save();

            return Json(updatedCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int key)
        {
            var deletedCategory =
                await applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Id == key);

            if (deletedCategory is null) return BadRequest();

            applicationDbContext.Categories.Remove(deletedCategory);
        
            applicationDbContext.Save();

            return Json(Result.Success());
        }
    }
}
