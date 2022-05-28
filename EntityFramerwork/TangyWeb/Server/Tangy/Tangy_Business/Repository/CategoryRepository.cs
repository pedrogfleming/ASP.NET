using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        //dependency Injection
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public CategoryDTO Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            //The created date is not populated with the mapping, so we do it manually
            obj.CreatedDate = DateTime.Now;
            #region Without automapper
            //Category category = new Category()
            //{
            //    Name = objDTO.Name,
            //    Id = objDTO.Id,
            //    CreatedDate = DateTime.Now
            //};
            #endregion
            ////Aggregate the category obj to the database
            var addedObj = _db.Categories.Add(obj);
            //The save confirm the changes in the db, its obligatory to perform changes in db
            _db.SaveChanges();
            #region Without AutoMapper
            //return new CategoryDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name
            //};
            #endregion
            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (obj is not null)
            {
                _db.Categories.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            var obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (obj is not null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var objFromDb = _db.Categories.FirstOrDefault(c => c.Id == objDTO.Id);
            if(objFromDb is not null)
            {
                objFromDb.Name =  objDTO.Name;
                _db.Categories.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category,CategoryDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
