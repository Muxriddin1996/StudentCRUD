using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study_Crud.Models.Entity;
using Study_Crud.Models.Interface;

namespace Study_Crud.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataDbContext _db;
        private readonly IStudentService _studentService;

        public StudentController(DataDbContext db,
            IStudentService studentService)
        {
            _db = db;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var lists = _studentService.GetStudent();
            return View(lists);
           
        }

        [HttpPost]
        public async Task<ActionResult> Index(string StudentSearch)
        {
            ViewData["GetClientDetails"] = StudentSearch;
            var Studentquery = from x in _db.Students select x;
            if (!String.IsNullOrEmpty(StudentSearch))
            {
                Studentquery = _db.Students.Where(x => x.FirstName.Contains(StudentSearch) || x.LastName.Contains(StudentSearch));
            }
            return View(await Studentquery.AsNoTracking().ToListAsync());
        }


        #region Student 
        [HttpGet]
        public IActionResult AddStudent(int Id = 0)
        {
            Student model = new Student();
            if (Id != 0)
            {
                var searchstudent = _db.Students.Find(Id);
                model.Id = searchstudent.Id;                
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
        public IActionResult AddStudent(Student model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var entity = new Student
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDay = model.BirthDay,
                        Direction = model.Direction,
                        Cource = model.Cource,
                        SubjectId = model.SubjectId
                    };
                    _db.Students.Add(entity);
                    _db.SaveChanges();
                }
                else
                {
                    var entity = _db.Students.Find(model.Id);
                    if (entity == null)
                        return View("No content");
                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;
                    entity.BirthDay = model.BirthDay;
                    entity.Direction = model.Direction;
                    entity.Cource = model.Cource;
                    entity.SubjectId = model.SubjectId;
                    _db.Students.Update(entity);
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
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var studentId = _db.Students.Find(id);
                _db.Students.Remove(studentId);
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
