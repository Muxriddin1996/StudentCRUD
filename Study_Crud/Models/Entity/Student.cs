using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Study_Crud.Models.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        [Required]
        public string Direction { get; set; }
        [Required]
        public int Cource { get; set; }
        [Required]
        [Column("Subject_id")]
        [ForeignKey("SubjectModel")]
        public int SubjectId { get; set; }
        [IgnoreDataMember]
        public virtual Subject SubjectModel { get; set; }

        public List<Teacher>? Teachers { get; set; }


    }
}
