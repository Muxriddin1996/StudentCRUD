using Study_Crud.Models.Entity;
using Study_Crud.Models.Interface;
using Study_Crud.Models.ViewModel;

namespace Study_Crud.Models.Service
{
    public class StudentService : IStudentService
    {
        private readonly DataDbContext _db;
        public StudentService(DataDbContext db)
        {
            _db = db;
        }

        public IEnumerable<StudentViewModel> GetStudent()
        {
            List<StudentViewModel>  result=new List<StudentViewModel>();
            var studentList = _db.Students.ToList();
            foreach (var student in studentList)
            {
                StudentViewModel model = new StudentViewModel();
                model.Id = student.Id;
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.BirthDay = student.BirthDay;
                model.Direction = student.Direction;
                model.Cource = student.Cource;
                model.SubjectName = _db.Subjects.Find(student.SubjectId).Name;
                result.Add(model);
            }
            return result;
        }
    }
}
