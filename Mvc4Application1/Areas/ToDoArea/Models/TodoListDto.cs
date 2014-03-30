namespace Andriy.Mvc4Application1.Areas.ToDoArea.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data transfer object for <see cref="TodoList"/>
    /// </summary>
    public class TodoListDto
    {
        public TodoListDto() { }

        public TodoListDto(TodoList todoList)
        {
            this.TodoListId = todoList.TodoListId;
            this.UserId = todoList.UserId;
            this.Title = todoList.Title;
            this.Todos = new List<TodoItemDto>();
            foreach (TodoItem item in todoList.Todos)
            {
                this.Todos.Add(new TodoItemDto(item));
            }
        }

        [Key]
        public int TodoListId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<TodoItemDto> Todos { get; set; }

        public TodoList ToEntity()
        {
            TodoList todo = new TodoList
            {
                Title = this.Title,
                TodoListId = this.TodoListId,
                UserId = this.UserId,
                Todos = new List<TodoItem>()
            };
            foreach (TodoItemDto item in this.Todos)
            {
                todo.Todos.Add(item.ToEntity());
            }

            return todo;
        }
    }
}