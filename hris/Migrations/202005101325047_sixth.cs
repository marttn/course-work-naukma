namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RemainingDaysOffs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    EmployeeId = c.Int(nullable: false),
                    VacationDays = c.Short(nullable: false, defaultValue: 20),
                    SickLeaveDays = c.Short(nullable: false, defaultValue: 10),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EmployeeId);
            AddForeignKey("dbo.RemainingDaysOffs", "EmployeeId", "dbo.AspNetUsers", "UserId");

        }

        public override void Down()
        {
            DropForeignKey("dbo.RemainingDaysOffs", "Employee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RemainingDaysOffs", new[] { "Employee_Id" });
            DropTable("dbo.RemainingDaysOffs");
        }
    }
}
