namespace Andriy.Mvc4Application1.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            this.AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            this.AlterColumn("dbo.Movies", "Rating", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.Movies", "Rating", c => c.String());
            this.AlterColumn("dbo.Movies", "Genre", c => c.String());
            this.AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
