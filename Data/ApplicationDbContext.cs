using AuthApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            : base(options)
        {
            
        }

        //added set to scafold users
        public DbSet<ApplicationUser> AppDbUserList { get; set; }
       
        public DbSet<WelcomeForm> WelcomeFormDBList { get; set; }

        public DbSet<MpoxCase> MpoxCaseDBList { get; set; }

        public DbSet<DiphtheriaCase> DiphtheriaDBList { get; set; }

        public DbSet<MeaslesCase> MeaslesDBList { get; set; }

        public DbSet<ChikungunyaCase> ChikungunyaDBList { get; set; }






        //on config ---New
        public static string CONNSTRING = @"Data Source=.\Data\SQlLiteDatabase.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /// var configuration = new ConfigurationBuilder()
            ///     .SetBasePath(Directory.GetCurrentDirectory())
            ///     .AddJsonFile("appsettings.json")
            ///     .Build();
            /// var connectionString = configuration.GetConnectionString("litedb");

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(CONNSTRING); //CONNSTRING 
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });



        
            Guid SUPER_ADMIN_ID = Guid.NewGuid();
            Guid SUPER_ADMIN_ROLE_ID = Guid.NewGuid();
            //seed SUPER admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = SUPER_ADMIN_ROLE_ID.ToString(),
                ConcurrencyStamp = SUPER_ADMIN_ROLE_ID.ToString()
            });


            //admin
            Guid ADMIN_ID = Guid.NewGuid();
            Guid ADMIN_ROLE_ID = Guid.NewGuid();
            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID.ToString(),
                ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
            });


            //moderator
            Guid MODERATOR_ID = Guid.NewGuid();
            Guid MODERATOR_ROLE_ID = Guid.NewGuid();
            //seed moderator role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Moderator",
                NormalizedName = "MODERATOR",
                Id = MODERATOR_ROLE_ID.ToString(),
                ConcurrencyStamp = MODERATOR_ROLE_ID.ToString()
            });

            // Basic
            Guid BASIC_ID = Guid.NewGuid();
            Guid BASIC_ROLE_ID = Guid.NewGuid();
            //seed basic role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Basic",
                NormalizedName = "BASIC",
                Id = BASIC_ROLE_ID.ToString(),
                ConcurrencyStamp = BASIC_ROLE_ID.ToString()
            });







            //Seed superuser
            var appUser = new ApplicationUser
            {
                Id = SUPER_ADMIN_ID.ToString(),
                Email = "superuser@mail.com",
                EmailConfirmed = true,
                FirstName = "super",
                LastName = "adminuser",
                UserName = "superuser@mail.com",
             NormalizedUserName = "SUPERUSER@MAIL.COM"
            };

            ///SuperAdminPassKey : change password in appsettings.json
            ///  var configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();              
            //string passkey = configuration.GetConnectionString("SuperAdminPassKey");


            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "mypassword_1234!t"); //hardcoded bad use code above
            //appUser.PasswordHash = ph.HashPassword(appUser, passkey);

            //seed user
            builder.Entity<ApplicationUser>().HasData(appUser);
            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = SUPER_ADMIN_ROLE_ID.ToString(),
                UserId = SUPER_ADMIN_ID.ToString()
            });




        }
    }
}
