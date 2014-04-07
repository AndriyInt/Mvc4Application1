namespace Andriy.Mvc4Application1.Areas.ToDoArea.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Andriy.Mvc4Application1.Areas.ToDoArea.Filters;
    using Andriy.Mvc4Application1.Areas.ToDoArea.Models;
    using Andriy.Mvc4Application1.Models;

    [Authorize]
    public class TodoListController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();

        // GET api/TodoList
        public IEnumerable<TodoListDto> GetTodoLists()
        {
            return this.db.TodoLists.Include("Todos")
                .Where(u => u.UserId == this.User.Identity.Name)
                .OrderByDescending(u => u.TodoListId)
                .AsEnumerable()
                .Select(todoList => new TodoListDto(todoList));
        }

        // GET api/TodoList/5
        public TodoListDto GetTodoList(int id)
        {
            TodoList todoList = this.db.TodoLists.Find(id);
            if (todoList == null)
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            if (todoList.UserId != this.User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }

            return new TodoListDto(todoList);
        }

        // PUT api/TodoList/5
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage PutTodoList(int id, TodoListDto todoListDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            if (id != todoListDto.TodoListId)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            TodoList todoList = todoListDto.ToEntity();
            if (this.db.Entry(todoList).Entity.UserId != this.User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            this.db.Entry(todoList).State = EntityState.Modified;

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

        // POST api/TodoList
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage PostTodoList(TodoListDto todoListDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            todoListDto.UserId = this.User.Identity.Name;
            TodoList todoList = todoListDto.ToEntity();
            this.db.TodoLists.Add(todoList);
            this.db.SaveChanges();
            todoListDto.TodoListId = todoList.TodoListId;

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, todoListDto);
            response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = todoListDto.TodoListId }));
            return response;
        }

        // DELETE api/TodoList/5
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage DeleteTodoList(int id)
        {
            TodoList todoList = this.db.TodoLists.Find(id);
            if (todoList == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (this.db.Entry(todoList).Entity.UserId != this.User.Identity.Name)
            {
                // Trying to delete a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            TodoListDto todoListDto = new TodoListDto(todoList);
            this.db.TodoLists.Remove(todoList);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, todoListDto);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}