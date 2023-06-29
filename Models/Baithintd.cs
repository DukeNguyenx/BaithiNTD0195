using System.ComponentModel.DataAnnotations;

namespace BaithiNTD0195.Models;

public class Baithintd
{
    [Key]
    public string? ID { get; set; }
    public string? FullName { get; set; }

    public string? Number { get; set; }

}