namespace Study_Crud.Models.ViewModel
{
    public class StudentViewModel
    {
       
        public int Id { get; set; }
       
        public string FirstName { get; set; }=String.Empty;
       
        public string LastName { get; set; } = String.Empty;

        public DateTime BirthDay { get; set; }
      
        public string Direction { get; set; } = String.Empty;

        public int Cource { get; set; }
       
        public string SubjectName { get; set; } = String.Empty;

        //public string TeacherName { get; set; } = String.Empty;

    }
}
