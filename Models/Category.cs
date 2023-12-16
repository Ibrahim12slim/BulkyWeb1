using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
    [Key] //ID will be the primary key of the table Category , Rider is smart when the attr contains id then without KEY will take it as primary.
    public int Id { get; set; }
    [Required] //name : not null its required.
    [DisplayName("Category Name")]
    [MaxLength(20)]
    public string Name { get; set; }
    
    [Required]
    [DisplayName("Display Order")]
    [Range(1,100)]
    public int DisplayOrder { get; set; }
}