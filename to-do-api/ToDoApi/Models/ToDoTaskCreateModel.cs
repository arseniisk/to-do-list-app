using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class ToDoTaskCreateModel
    {
        [Required]
        public string Description { get; set; }
    }
}
