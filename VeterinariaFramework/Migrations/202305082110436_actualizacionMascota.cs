namespace VeterinariaFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionMascota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mascotas", "Sexo", c => c.Int(nullable: false, defaultValue: 0));
            Sql("UPDATE dbo.Mascotas SET Sexo = 0");
            AlterColumn("dbo.Mascotas", "Sexo", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Mascotas", "Sexo");
        }
    }
}
