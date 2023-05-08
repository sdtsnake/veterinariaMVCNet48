namespace VeterinariaFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class actualizacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Sexo", c => c.String(nullable: false, maxLength: 1));
        }

        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Sexo");
        }
    }
}
