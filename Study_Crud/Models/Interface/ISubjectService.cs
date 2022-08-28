using Study_Crud.Models.Entity;
using Study_Crud.Models.ViewModel;

namespace Study_Crud.Models.Interface
{
    public interface ISubjectService
    {
        IEnumerable<SubjectViewModel> GetSubject();
    }
}
