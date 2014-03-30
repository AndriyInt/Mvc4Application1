namespace Andriy.Mvc4Application1.Areas.ToDoArea.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Todo list entity
    /// </summary>
    public class TodoList
    {
        public int TodoListId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<TodoItem> Todos { get; set; }
    }
}