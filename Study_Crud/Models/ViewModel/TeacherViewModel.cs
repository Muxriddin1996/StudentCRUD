namespace Study_Crud.Models.ViewModel
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public DateTime BirthDay { get; set; }

        public string Position { get; set; } = String.Empty;

        public string SubjectName { get; set; } = String.Empty;

    }
}
