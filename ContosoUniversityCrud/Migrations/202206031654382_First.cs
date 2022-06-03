namespace ContosoUniversityCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                        Student_ID = c.Long(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_ID)
                .Index(t => t.CourseID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Apellido = c.String(nullable: false, maxLength: 60),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TipoStudent",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Modalidad = c.String(),
                        Jornada = c.String(),
                        ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Student", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoStudent", "ID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "Student_ID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropIndex("dbo.TipoStudent", new[] { "ID" });
            DropIndex("dbo.Enrollment", new[] { "Student_ID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropTable("dbo.TipoStudent");
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Course");
        }
    }
}
