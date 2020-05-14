namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "AspNetUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Employees");
        }
    }
}
