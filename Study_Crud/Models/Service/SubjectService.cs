using Study_Crud.Models.Entity;
using Study_Crud.Models.Interface;
using Study_Crud.Models.ViewModel;

namespace Study_Crud.Models.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly DataDbContext _db;

        public SubjectService(DataDbContext db)
        {
            _db = db;
        }
        public IEnumerable<SubjectViewModel> GetSubject()
        {
            List<SubjectViewModel> result = new List<SubjectViewModel>();
            var List = _db.Subjects.ToList();
            foreach (var item in List)
            {
                SubjectViewModel model = new SubjectViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.ClassName = _db.Classess.Find(item.ClassId).Name;
                result.Add(model);
            }
            return result;
        }
    }
}
