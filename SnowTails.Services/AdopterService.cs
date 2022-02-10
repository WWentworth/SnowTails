using SnowTails.Data;
using SnowTails.Models.Adopter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Services
{
    public class AdopterService
    {
        private readonly Guid _userId;

        public AdopterService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAdopter(AdopterCreate model)
        {
            var entity = new Adopter()
                {
                    OwnerId = _userId,
                    AdopterName = model.AdopterName,
                    AdopterAddress = model.AdopterAddress,
                    AdopterPhone = model.AdopterPhone,
                    OtherPets = model.OtherPets,
                    FencedYard = model.FencedYard
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adopters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AdopterListItem> GetAdopters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Adopters
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new AdopterListItem
                        {
                            AdopterId = e.AdopterId,
                            AdopterName = e.AdopterName,
                            AdopterAddress = e.AdopterAddress,
                            AdopterPhone = e.AdopterPhone
                        });
                return query.ToArray();
            }
        }
        public AdopterDetail GetAdopterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Adopters
                    .Single(e => e.AdopterId == id && e.OwnerId == _userId);
                return
                    new AdopterDetail
                    {
                        AdopterId = entity.AdopterId,
                        AdopterName = entity.AdopterName,
                        AdopterAddress = entity.AdopterAddress,
                        AdopterPhone = entity.AdopterPhone
                    };
            }
        }
        public bool UpdateAdopter(AdopterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Adopters
                    .Single(e => e.AdopterId == model.AdopterId && e.OwnerId == _userId);

                entity.AdopterName = model.AdopterName;
                entity.AdopterAddress = model.AdopterAddress;
                entity.AdopterPhone = model.AdopterPhone;
                entity.OtherPets = model.OtherPets;
                entity.FencedYard = model.FencedYard;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAdopter(int AdopterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Adopters
                    .Single(e => e.AdopterId == AdopterId && e.OwnerId == _userId);
                ctx.Adopters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
