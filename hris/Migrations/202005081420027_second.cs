namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Employees", newName: "Employess");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseCompletions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DaysOffs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Skills", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TimeTrackers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Archives", "OwnerId", "dbo.Employees");
            DropForeignKey("dbo.Archives", "OwnerId", "dbo.CourseModules");
            DropIndex("dbo.CourseCompletions", new[] { "EmployeeId" });
            DropIndex("dbo.DaysOffs", new[] { "EmployeeId" });
            DropIndex("dbo.Skills", new[] { "EmployeeId" });
            DropIndex("dbo.TimeTrackers", new[] { "EmployeeId" });
            DropIndex("dbo.Archives", new[] { "OwnerId" });
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "Id");
            AddColumn("dbo.Employees", "Id", c => c.String(nullable: false, maxLength: 128));
           // AddColumn("dbo.CourseCompletions", "Employee_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "PasswordHash", c => c.String());
            AddColumn("dbo.Employees", "SecurityStamp", c => c.String());
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String());
            AddColumn("dbo.Employees", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Employees", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 256));
            AddPrimaryKey("dbo.Employees",new[]{ "Id" });
            CreateIndex("dbo.Employees", "UserId", true);
            CreateIndex("dbo.CourseCompletions", "EmployeeId");
            CreateIndex("dbo.DaysOffs", "EmployeeId");
            CreateIndex("dbo.Skills", "EmployeeId");
            CreateIndex("dbo.TimeTrackers", "EmployeeId");
            CreateIndex("dbo.Archives", new[] { "OwnerId" });
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Employees", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Employees", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Employees", "Id");
            AddForeignKey("dbo.CourseCompletions", "EmployeeId", "dbo.Employees", "UserId");
            AddForeignKey("dbo.DaysOffs", "EmployeeId", "dbo.Employees", "UserId");
            AddForeignKey("dbo.Skills", "EmployeeId", "dbo.Employees", "UserId");
            AddForeignKey("dbo.TimeTrackers", "EmployeeId", "dbo.Employees", "UserId");
            AddForeignKey("dbo.Archives", "OwnerId", "dbo.Employees", "UserId");
            AddForeignKey("dbo.Archives", "OwnerId", "dbo.CourseModules", "Id");
            DropTable("dbo.AspNetUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TimeTrackers", "Employee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skills", "Employee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DaysOffs", "Employee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseCompletions", "Employee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TimeTrackers", new[] { "Employee_Id" });
            DropIndex("dbo.Skills", new[] { "Employee_Id" });
            DropIndex("dbo.DaysOffs", new[] { "Employee_Id" });
            DropIndex("dbo.CourseCompletions", new[] { "Employee_Id" });
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.TimeTrackers", "Employee_Id");
            DropColumn("dbo.Skills", "Employee_Id");
            DropColumn("dbo.DaysOffs", "Employee_Id");
            DropColumn("dbo.AspNetUsers", "UserName");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "SecurityStamp");
            DropColumn("dbo.AspNetUsers", "PasswordHash");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.CourseCompletions", "Employee_Id");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            CreateIndex("dbo.TimeTrackers", "EmployeeId");
            CreateIndex("dbo.Skills", "EmployeeId");
            CreateIndex("dbo.DaysOffs", "EmployeeId");
            CreateIndex("dbo.CourseCompletions", "EmployeeId");
            AddForeignKey("dbo.TimeTrackers", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Skills", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.DaysOffs", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.CourseCompletions", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.AspNetUsers", newName: "Employees");
        }
    }
}
