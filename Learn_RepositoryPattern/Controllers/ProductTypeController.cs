using Microsoft.AspNetCore.Mvc;
using Learn_RepositoryPattern.DataAccess.Data;
using Learn_RepositoryPattern.Model;
using Learn_RepositoryPattern.DataAccess.Repository.IRepository;
using Learn_RepositoryPattern.DataAccess.Repository;

namespace Learn_RepositoryPattern.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeRepository _repository;

        public ProductTypeController(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<ProductType> productTypeList = _repository.GetAll().ToList();

            return View(productTypeList);
        }

        public IActionResult Create()
        {
            return View("Edit");
        }

        public IActionResult Edit(int? id)
        {
            ProductType? obj;

            if (id == null)
            {
                obj = new ProductType();
            }
            else
            {
                obj = _repository.Get(o => o.Id == id);
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            ProductType? obj = _repository.Get(o => o.Id == id);

            _repository.Remove(obj);

            _repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ProductType obj)
        {
            if (obj.Id == 0)
            {
                _repository.Add(obj);
            }
            else
            {
                ProductType? updObj = _repository.Get(o => o.Id == obj.Id);

                updObj.Name = obj.Name;

                _repository.Update(updObj);
            }

            _repository.Save();

            return RedirectToAction("Index");
        }
    }
}
