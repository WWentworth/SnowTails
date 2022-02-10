using SnowTails.Data;
using SnowTails.Models.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Services
{
    public class DogService
    {
        private readonly Guid _userId;

        public DogService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateDog(DogCreate model)
        {
            var entity =
                new Dog()
                {
                    OwnerId = _userId,
                    DogName = model.DogName,
                    Sex = model.Sex,
                    Age = model.Age,
                    Fixed = model.Fixed,
                    Information = model.Information,
                    LocationId = model.LocationId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DogListItem> GetDogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Dogs
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new DogListItem
                        {
                            DogId = e.DogId,
                            DogName = e.DogName,
                            Sex = e.Sex,
                            Age = e.Age,
                            LocationName = e.Location.LocationName
                        });
                return query.ToArray();
            }
        }
        public DogDetail GetDogById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dogs
                    .Single(e => e.DogId == id && e.OwnerId == _userId);
                return
                    new DogDetail
                    {
                        DogId = entity.DogId,
                        DogName = entity.DogName,
                        Sex = entity.Sex,
                        Age = entity.Age,
                        Fixed = entity.Fixed,
                        Information = entity.Information,
                        LocationName = entity.Location.LocationName,
                        AdopterName = entity.Adopter.AdopterName
                    };
            }
        }
        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dogs
                    .Single(e => e.DogId == model.DogId && e.OwnerId == _userId);

                entity.DogName = model.DogName;
                entity.Sex = model.Sex;
                entity.Age = model.Age;
                entity.Fixed = model.Fixed;
                entity.Information = model.Information;
                entity.LocationName = model.LocationName;
                entity.AdopterId = model.AdopterName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDog(int DogId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dogs
                    .Single(e => e.DogId == DogId && e.OwnerId == _userId);
                ctx.Dogs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
