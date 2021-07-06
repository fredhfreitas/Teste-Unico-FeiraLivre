using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Unico.FeiraLivre.Persistence.Seeds
{
    public static class ContextSeed
    {
        //TODO: Verificar, talvez não seja necessário pela importação do csv
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //CreateFeira(modelBuilder);            
        }        
    }
}
