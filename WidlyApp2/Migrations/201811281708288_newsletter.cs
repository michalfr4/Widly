namespace WidlyApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsNewsletterSubscriptionActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsNewsletterSubscriptionActive");
        }
    }
}
