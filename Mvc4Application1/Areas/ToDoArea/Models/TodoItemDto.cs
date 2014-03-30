namespace Andriy.Mvc4Application1.Areas.ToDoArea.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TodoItemDto
    {
        /// <summary>
        /// Data transfer object for <see cref="TodoItem"/>
        /// </summary>
        public TodoItemDto() { }

        public TodoItemDto(TodoItem item)
        {
            this.TodoItemId = item.TodoItemId;
            this.Title = item.Title;
            this.IsDone = item.IsDone;
            this.TodoListId = item.TodoListId;
        }

        [Key]
        public int TodoItemId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public int TodoListId { get; set; }

        public TodoItem ToEntity()
        {
            return new TodoItem
            {
                TodoItemId = this.TodoItemId,
                Title = this.Title,
                IsDone = this.IsDone,
                TodoListId = this.TodoListId
            };
        }
    }
}
