using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study_Crud.Models.Entity;
using Study_Crud.Models.Interface;

namespace Study_Crud.Controllers
{
    public class SubjectController : Controller
    {
        private readonly DataDbContext _db;
        private readonly ISubjectService _subjectService;

        public SubjectController(DataDbContext db,
            ISubjectService subjectService
            )
        {
            _db = db;
            _subjectService = subjectService;
        }

        public IActionResult Index()
        {
            var lists = _subjectService.GetSubject();
            return View(lists);
        }
        /// <summary>
        /// Index for Subject
        /// </summary>
        /// <param name="SubjectSearch"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(string SubjectSearch)
        {
            ViewData["GetSubjectDetails"] = SubjectSearch;
            var Subjectquery = from x in _subjectService.GetSubject() select x;
            if (!String.IsNullOrEmpty(SubjectSearch))
            {
                Subjectquery = Subjectquery.Where(x => x.Name.Contains(SubjectSearch)||x.ClassName.Contains(SubjectSearch));
            }
            return View(Subjectquery.ToList());
        }
        /// <summary>
        /// AddSubject
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddSubject(int Id = 0)
        {
            Subject model = new Subject();
            var ClassList = _db.Classess.Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.ClassList = ClassList;
            if (Id != 0)
            {
                var searchSubject = _db.Subjects.Find(Id);
                model.Id = searchSubject.Id;
                model.Name = searchSubject.Name;
                model.ClassId = searchSubject.ClassId;
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

    }
}
