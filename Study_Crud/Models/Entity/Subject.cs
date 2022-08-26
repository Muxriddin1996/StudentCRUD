using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Study_Crud.Models.Entity
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column("class_id")]
        [ForeignKey("ClassModel")]
        public int ClassId { get; set; }
        [IgnoreDataMember]
        public virtual Classes ClassModel { get; set; }


    }
}
