namespace Andriy.Mvc4Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDoArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        TodoItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        TodoListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TodoItemId)
                .ForeignKey("dbo.TodoLists", t => t.TodoListId, cascadeDelete: true)
                .Index(t => t.TodoListId);
            
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        TodoListId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TodoListId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TodoItems", new[] { "TodoListId" });
            DropForeignKey("dbo.TodoItems", "TodoListId", "dbo.TodoLists");
            DropTable("dbo.TodoLists");
            DropTable("dbo.TodoItems");
        }
    }
}
