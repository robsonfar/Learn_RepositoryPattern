using Microsoft.AspNetCore.Mvc;
using Learn_RepositoryPattern.DataAccess.Data;
using Learn_RepositoryPattern.Model;
using Learn_RepositoryPattern.DataAccess.Repository.IRepository;
using Learn_RepositoryPattern.DataAccess.Repository;

namespace Learn_RepositoryPattern.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ProductType> productTypeList = _unitOfWork.ProductTypeRepository.GetAll().ToList();

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
                obj = _unitOfWork.ProductTypeRepository.Get(o => o.Id == id);
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            ProductType? obj = _unitOfWork.ProductTypeRepository.Get(o => o.Id == id);

            _unitOfWork.ProductTypeRepository.Remove(obj);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ProductType obj)
        {
            if (obj.Id == 0)
            {
                _unitOfWork.ProductTypeRepository.Add(obj);
            }
            else
            {
                ProductType? updObj = _unitOfWork.ProductTypeRepository.Get(o => o.Id == obj.Id);

                updObj.Name = obj.Name;

                _unitOfWork.ProductTypeRepository.Update(updObj);
            }

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
