using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
    [Key] //ID will be the primary key of the table Category , Rider is smart when the attr contains id then without KEY will take it as primary.
    public int Id { get; set; }
    [Required] //name : not null its required.
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}