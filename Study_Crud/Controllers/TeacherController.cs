using Microsoft.AspNetCore.Mvc;
using Study_Crud.Models.Entity;

namespace Study_Crud.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataDbContext _db;
        public TeacherController(DataDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var lists = _db.Teachers.ToList();
            return View(lists);

        }

        #region Teacher 


        [HttpGet]
        public IActionResult AddTeacher(int Id = 0)
        {
            Teacher model = new Teacher();
            if (Id != 0)
            {
                var searchTeacher = _db.Teachers.Find(Id);
                model.Id = searchTeacher.Id;
                model.FirstName = searchTeacher.FirstName;
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
        public IActionResult AddTeacher(Teacher model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var entity = new Teacher
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDay = model.BirthDay,
                        Position = model.Position,                        
                        SubjectId = model.SubjectId
                    };
                    _db.Teachers.Add(entity);
                    _db.SaveChanges();
                }
                else
                {
                    var entity = _db.Teachers.Find(model.Id);
                    if (entity == null)
                        return View("No content");
                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;
                    entity.BirthDay = model.BirthDay;
                    entity.Position = model.Position;                  
                    entity.SubjectId = model.SubjectId;
                    _db.Teachers.Update(entity);
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
        public IActionResult DeleteTeacher(int id)
        {
            try
            {
                var TeacherId = _db.Teachers.Find(id);
                _db.Teachers.Remove(TeacherId);
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
