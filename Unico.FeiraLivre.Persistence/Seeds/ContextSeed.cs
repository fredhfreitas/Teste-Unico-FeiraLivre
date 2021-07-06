using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Unico.FeiraLivre.Persistence.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //CreateRoles(modelBuilder);           

            MapUserRole(modelBuilder);
        }

        //private static void CreateRoles(ModelBuilder modelBuilder)
        //{
        //    List<IdentityRole> roles = DefaultRoles.IdentityRoleList();
        //    modelBuilder.Entity<IdentityRole>().HasData(roles);
        //}        

        private static void MapUserRole(ModelBuilder modelBuilder)
        {
            var identityUserRoles = MappingUserRole.IdentityUserRoleList();
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoles);
        }
    }
}
