namespace CSharpEgitimKampi301.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProductDto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
