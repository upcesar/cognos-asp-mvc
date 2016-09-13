namespace cognossystem_testes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cargo = c.Int(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(),
                        Status = c.Int(nullable: false),
                        Data_Inclusao = c.DateTime(nullable: false),
                        Data_Ultima_alteracao = c.DateTime(nullable: false),
                        Empresas_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empresas", t => t.Empresas_ID)
                .Index(t => t.Empresas_ID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Site = c.String(),
                        Status = c.Int(nullable: false),
                        Data_Inclusao = c.DateTime(nullable: false),
                        Data_Ultima_alteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contatos", "Empresas_ID", "dbo.Empresas");
            DropIndex("dbo.Contatos", new[] { "Empresas_ID" });
            DropTable("dbo.Empresas");
            DropTable("dbo.Contatos");
        }
    }
}
