namespace CSharpEgitimKampi301.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductDto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discriminator");
        }
    }
}
