namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Archives", "Description");
            DropColumn("dbo.Archives", "Contents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Archives", "Contents", c => c.String(nullable: false));
            AddColumn("dbo.Archives", "Description", c => c.String(nullable: false));
        }
    }
}
