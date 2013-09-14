namespace Andriy.Mvc4Application1.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddRating : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Movies", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Movies", "Rating");
        }
    }
}
