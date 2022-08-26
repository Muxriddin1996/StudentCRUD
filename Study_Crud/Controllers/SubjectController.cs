using Microsoft.AspNetCore.Mvc;
using Study_Crud.Models.Entity;

namespace Study_Crud.Controllers
{
    public class SubjectController : Controller
    {
        private readonly DataDbContext _db;
        public SubjectController(DataDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var lists = _db.Subjects.ToList();
            return View(lists);
        }
        #region Subject


        [HttpGet]
        public IActionResult AddSubject(int Id = 0)
        {
            Subject model = new Subject();
            if (Id != 0)
            {
                var searchSubject = _db.Subjects.Find(Id);
                model.Id = searchSubject.Id;
                model.Name = searchSubject.Name;
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
        public IActionResult AddSubject(Subject model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var entity = new Subject
                    {
                        Name = model.Name,
                        ClassId = model.ClassId                        
                    };
                    _db.Subjects.Add(entity);
                    _db.SaveChanges();
                }
                else
                {
                    var entity = _db.Subjects.Find(model.Id);
                    if (entity == null)
                        return View("No content");
                    entity.Name = model.Name;
                    entity.ClassId = model.ClassId;
                    
                    _db.Subjects.Update(entity);
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
        public IActionResult DeleteSubject(int id)
        {
            try
            {
                var studentId = _db.Subjects.Find(id);
                _db.Subjects.Remove(studentId);
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
