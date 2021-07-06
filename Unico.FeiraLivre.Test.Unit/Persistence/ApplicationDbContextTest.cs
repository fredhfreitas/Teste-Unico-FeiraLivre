using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Persistence;

namespace Unico.FeiraLivre.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertFeiraIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            var feira = new Feira();
            context.Feira.Add(feira);
            Assert.AreEqual(EntityState.Added, context.Entry(feira).State);
        }
    }
}
