namespace Andriy.Mvc4Application1.Areas.ToDoArea.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Andriy.Mvc4Application1.Areas.ToDoArea.Filters;
    using Andriy.Mvc4Application1.Areas.ToDoArea.Models;
    using Andriy.Mvc4Application1.Models;

    [Authorize]
    [ValidateHttpAntiForgeryToken]
    public class TodoController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();

        // PUT api/Todo/5
        public HttpResponseMessage PutTodoItem(int id, TodoItemDto todoItemDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            if (id != todoItemDto.TodoItemId)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            TodoItem todoItem = todoItemDto.ToEntity();
            TodoList todoList = this.db.TodoLists.Find(todoItem.TodoListId);
            if (todoList == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (todoList.UserId != this.User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            // Need to detach to avoid duplicate primary key exception when SaveChanges is called
            this.db.Entry(todoList).State = EntityState.Detached;
            this.db.Entry(todoItem).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Todo
        public HttpResponseMessage PostTodoItem(TodoItemDto todoItemDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            TodoList todoList = this.db.TodoLists.Find(todoItemDto.TodoListId);
            if (todoList == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (todoList.UserId != this.User.Identity.Name)
            {
                // Trying to add a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            TodoItem todoItem = todoItemDto.ToEntity();

            // Need to detach to avoid loop reference exception during JSON serialization
            this.db.Entry(todoList).State = EntityState.Detached;
            this.db.TodoItems.Add(todoItem);
            this.db.SaveChanges();
            todoItemDto.TodoItemId = todoItem.TodoItemId;

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, todoItemDto);
            response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = todoItemDto.TodoItemId }));
            return response;
        }

        // DELETE api/Todo/5
        public HttpResponseMessage DeleteTodoItem(int id)
        {
            TodoItem todoItem = this.db.TodoItems.Find(id);
            if (todoItem == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (this.db.Entry(todoItem.TodoList).Entity.UserId != this.User.Identity.Name)
            {
                // Trying to delete a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            TodoItemDto todoItemDto = new TodoItemDto(todoItem);
            this.db.TodoItems.Remove(todoItem);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, todoItemDto);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}