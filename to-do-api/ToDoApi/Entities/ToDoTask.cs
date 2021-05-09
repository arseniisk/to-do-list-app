using System;

namespace ToDoApi.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
