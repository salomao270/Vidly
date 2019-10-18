namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4cf74af1-c316-4c35-af8e-f9999dc13a40', N'admin@vidly.com', 0, N'AMMGKY1TdIOPO3gHX0i+znc3GjmawcX2uXXh5v0lcY0GqHu/aKwkVmre/qTWaiK7oQ==', N'9e6add1e-22c4-465b-823c-206fc3e8ed75', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd05653d1-c48c-49df-9b73-36253a4593b3', N'guest@vidly.com', 0, N'ACNjwmV9/U5q84RKIt7HwvTB6H9PPOmP2nRbP0fKCjVrBf4D1hZYRSVXhGnn3WjNcg==', N'7bcb13b8-a2e1-4668-bbbf-205c78d5f38e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'887948fc-1476-4f71-9016-bb76909bb10a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4cf74af1-c316-4c35-af8e-f9999dc13a40', N'887948fc-1476-4f71-9016-bb76909bb10a')
");
        }
        
        public override void Down()
        {
        }
    }
}
