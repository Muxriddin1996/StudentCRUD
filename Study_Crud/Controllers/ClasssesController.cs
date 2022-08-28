using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study_Crud.Models.Entity;

namespace Study_Crud.Controllers
{
    public class ClasssesController : Controller
    {
        private readonly DataDbContext _db;
        public ClasssesController(DataDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var lists = _db.Classess.ToList();
            return View(lists);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string ClassesSearch)
        {
            ViewData["GetClassesDetails"] = ClassesSearch;
            var Classesquery = from x in _db.Classess select x;
            if (!String.IsNullOrEmpty(ClassesSearch))
            {
                Classesquery = Classesquery.Where(x => x.Name.Contains(ClassesSearch));
            }
            return View(await Classesquery.AsNoTracking().ToListAsync());
        }

       

        #region Classes 


        [HttpGet]
        public IActionResult AddClasses(int Id = 0)
        {
            Classes model = new Classes();
            if (Id != 0)
            {
                var searchClasses = _db.Classess.Find(Id);
                model.Id = searchClasses.Id;
                model.Name = searchClasses.Name;
                model.Capasity = searchClasses.Capasity;
                model.class_nomer = searchClasses.class_nomer;
            }
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[CustomAuthorize(Permission.ReferenceEdit)]
        public IActionResult AddClasses(Classes model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var entity = new Classes
                    {
                        Name = model.Name,
                        Capasity = model.Capasity,
                        class_nomer = model.class_nomer                       
                    };
                    _db.Classess.Add(entity);
                    _db.SaveChanges();
                }
                else
                {
                    var entity = _db.Classess.Find(model.Id);
                    if (entity == null)
                        return View("No content");
                    entity.Name = model.Name;
                    entity.Capasity = model.Capasity;
                    entity.class_nomer = model.class_nomer;
                   
                    _db.Classess.Update(entity);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");

                
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[CustomAuthorize(Permission.ReferenceEdit)]
        public IActionResult DeleteClasses(int id)
        {
            try
            {
                var ClassesId = _db.Classess.Find(id);
                _db.Classess.Remove(ClassesId);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion
    }
}
