namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Archives", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Archives", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Archives", "Contents", c => c.String(nullable: false));
            DropColumn("dbo.Archives", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Archives", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.Archives", "Contents");
            DropColumn("dbo.Archives", "Description");
            DropColumn("dbo.Archives", "Title");
        }
    }
}
