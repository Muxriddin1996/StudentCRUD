using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Study_Crud.Models.Entity
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }        
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        public int Capasity { get; set; }
        [Required]
        public int class_nomer { get; set; }
    }
}
