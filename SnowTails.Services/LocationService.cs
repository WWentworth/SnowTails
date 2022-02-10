using SnowTails.Data;
using SnowTails.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    OwnerId = _userId,
                    LocationName = model.LocationName,
                    LocationCity = model.LocationCity,
                    LocationAddress = model.LocationAddress,
                    LocationPhone = model.LocationPhone
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new LocationListItem
                        {
                            LocationId = e.LocationId,
                            LocationName = e.LocationName,
                            LocationCity = e.LocationCity,
                            LocationAddress = e.LocationAddress,
                            LocationPhone = e.LocationPhone
                        });
                return query.ToArray();
            }
        }
        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == id && e.OwnerId == _userId);
                return
                    new LocationDetail
                    {
                        LocationId = entity.LocationId,
                        LocationName = entity.LocationName,
                        LocationCity = entity.LocationCity,
                        LocationAddress = entity.LocationAddress,
                        LocationPhone = entity.LocationPhone
                    };
            }
        }
        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == model.LocationId && e.OwnerId == _userId);

                entity.LocationName = model.LocationName;
                entity.LocationCity = model.LocationCity;
                entity.LocationAddress = model.LocationAddress;
                entity.LocationPhone = model.LocationPhone;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLocation(int LocationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == LocationId && e.OwnerId == _userId);
                ctx.Locations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
