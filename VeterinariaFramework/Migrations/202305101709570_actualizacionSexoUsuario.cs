namespace VeterinariaFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class actualizacionSexoUsuario : DbMigration
    {
        public override void Up()
        {
            // Eliminar el campo 'Sexo' si existe
            DropColumn("dbo.Usuarios", "Sexo");

            // Volver a agregar el campo 'Sexo' según la definición de la clase 'Usuario'
            AddColumn("dbo.Usuarios", "Sexo", c => c.String(nullable: false, maxLength: 1));
        }

        public override void Down()
        {
            // Eliminar el campo 'Sexo'
            DropColumn("dbo.Usuarios", "Sexo");
        }
    }
}
