namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Archives",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.Binary(nullable: false),
                        Size = c.Int(nullable: false),
                        OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.Archives", "OwnerId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Archives", "OwnerId", "dbo.CourseModules", "Id");
                
            
            CreateTable(
                "dbo.CourseCompletions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        OnboardingCourseId = c.Int(nullable: false),
                        PercentCompleted = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.OnboardingCourses", t => t.OnboardingCourseId)
                .Index(t => t.EmployeeId)
                .Index(t => t.OnboardingCourseId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                        TelNum = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        HiringDate = c.DateTime(nullable: false),
                        HousesPerWeek = c.Short(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.DaysOffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AmountOfDays = c.Short(nullable: false),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequiredSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        MinReqYears = c.Double(nullable: false),
                        MaxReqYears = c.Double(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Years = c.Double(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.TimeTrackers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalHours = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ClientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OnboardingCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OnboardingCourseId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OnboardingCourses", t => t.OnboardingCourseId)
                .Index(t => t.OnboardingCourseId);
            
            CreateTable(
                "dbo.EmpDayOffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Discriminator = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AmountOfDays = c.Short(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CourseModules", "OnboardingCourseId", "dbo.OnboardingCourses");
            DropForeignKey("dbo.CourseCompletions", "OnboardingCourseId", "dbo.OnboardingCourses");
            DropForeignKey("dbo.TimeTrackers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TimeTrackers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Skills", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.RequiredSkills", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.DaysOffs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CourseCompletions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CourseModules", new[] { "OnboardingCourseId" });
            DropIndex("dbo.TimeTrackers", new[] { "EmployeeId" });
            DropIndex("dbo.TimeTrackers", new[] { "ProjectId" });
            DropIndex("dbo.Skills", new[] { "EmployeeId" });
            DropIndex("dbo.RequiredSkills", new[] { "PositionId" });
            DropIndex("dbo.DaysOffs", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.CourseCompletions", new[] { "OnboardingCourseId" });
            DropIndex("dbo.CourseCompletions", new[] { "EmployeeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EmpDayOffs");
            DropTable("dbo.CourseModules");
            DropTable("dbo.OnboardingCourses");
            DropTable("dbo.Projects");
            DropTable("dbo.TimeTrackers");
            DropTable("dbo.Skills");
            DropTable("dbo.RequiredSkills");
            DropTable("dbo.Positions");
            DropTable("dbo.DaysOffs");
            DropTable("dbo.Employees");
            DropTable("dbo.CourseCompletions");
            DropTable("dbo.Archives");
        }
    }
}
