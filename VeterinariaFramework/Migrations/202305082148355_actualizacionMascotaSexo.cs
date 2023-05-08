namespace VeterinariaFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionMascotaSexo : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Mascotas ADD Sexo_new NVARCHAR(1) NOT NULL DEFAULT ''");

            Sql("UPDATE Mascotas SET Sexo_new = Sexo");

            DropColumn("dbo.Mascotas", "Sexo");

            RenameColumn("dbo.Mascotas", "Sexo_new", "Sexo");
        }

        public override void Down()
        {
            Sql("ALTER TABLE Mascotas ADD Sexo_new CHAR(1) NOT NULL DEFAULT 'M'");

            Sql("UPDATE Mascotas SET Sexo_new = LEFT(Sexo, 1)");

            DropColumn("dbo.Mascotas", "Sexo");

            RenameColumn("dbo.Mascotas", "Sexo_new", "Sexo");
        }
    }
}
