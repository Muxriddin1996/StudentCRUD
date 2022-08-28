using Study_Crud.Models.Entity;
using Study_Crud.Models.Interface;
using Study_Crud.Models.ViewModel;

namespace Study_Crud.Models.Service
{
    public class TeacherService: ITeacherService
    {
        private readonly DataDbContext _db;
        public TeacherService(DataDbContext db)
        {
            _db = db;
        }
        public IEnumerable<TeacherViewModel> GetTeacher()
        {
            List<TeacherViewModel> result = new List<TeacherViewModel>();
            var teacherList = _db.Teachers.ToList();
            foreach (var teacher in teacherList)
            {

                TeacherViewModel model = new TeacherViewModel();
                model.Id = teacher.Id;
                model.FirstName = teacher.FirstName;
                model.LastName = teacher.LastName;
                model.BirthDay = teacher.BirthDay;
                model.Position = teacher.Position;
                model.SubjectName = _db.Subjects.Find(teacher.SubjectId).Name;
                result.Add(model);
            }
            return result;
        }
    }
}
