using System;
using ToDoApi.Entities;

namespace ToDoApi.Models
{
    public class ToDoTaskReadModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ToDoTaskReadModel(ToDoTask task)
        {
            Id = task.Id;
            Description = task.Description;
            CreatedAt = task.CreatedAt;
        }
    }
}
