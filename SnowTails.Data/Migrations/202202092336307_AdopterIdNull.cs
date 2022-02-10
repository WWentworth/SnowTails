namespace SnowTails.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdopterIdNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dog", "AdopterId", "dbo.Adopter");
            DropIndex("dbo.Dog", new[] { "AdopterId" });
            AlterColumn("dbo.Dog", "AdopterId", c => c.Int());
            CreateIndex("dbo.Dog", "AdopterId");
            AddForeignKey("dbo.Dog", "AdopterId", "dbo.Adopter", "AdopterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dog", "AdopterId", "dbo.Adopter");
            DropIndex("dbo.Dog", new[] { "AdopterId" });
            AlterColumn("dbo.Dog", "AdopterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dog", "AdopterId");
            AddForeignKey("dbo.Dog", "AdopterId", "dbo.Adopter", "AdopterId", cascadeDelete: true);
        }
    }
}
