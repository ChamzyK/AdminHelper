using AdminHelper.models.entities;
using AdminHelper.Models.DbContexts;
using AdminHelper.Views.EntitiesViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace AdminHelper.Models.Repositories
{
    public class ActorRepository : IRepository<Actor>
    {
        private readonly AdminHelperDbContext _context;
        private readonly DbSet<Actor> _set;

        public ActorRepository(AdminHelperDbContext context)
        {
            _context = context;
            _set = context.Set<Actor>();
        }

        public void Create(Actor entity) => _set.Add(entity);

        public void Delete(Actor entity) => _set.Remove(entity);

        public Actor? Read(int id)
        {
            var actor = _set.Find(id);
            if (actor == null)
            {
                return null;
            }
            return SetSalary(actor);
        }

        public ObservableCollection<Actor> Read()
        {
            var actors = _context.Actors.Include(actor => actor.Roles).ToList();
            var actorsWithSalary = actors.Select(actor => SetSalary(actor));
            return new ObservableCollection<Actor>(actorsWithSalary);
        }

        public void SaveChanges() => _context.SaveChanges();

        public Actor Update(Actor entity) => _set.Update(entity).Entity;

        private Actor SetSalary(Actor actor)
        {
            var rates = CalcRates(actor);
            var allowances = CalcAllowances(actor);

            actor.Salary = rates + allowances;

            return actor;
        }

        private static int CalcRates(Actor actor) => actor.Roles.Sum(role => role.Rate) ?? 0;
        private int CalcAllowances(Actor actor)
        {
            var allowances = 0;

            foreach (var role in actor.Roles)
            {
                allowances += _context.SpectacleFullnessDbSet
                    .Where(sf => sf.SpectacleIdNavigation!.Roles.Contains(role))
                    .Sum(sf => sf.FullnessIdNavigation!.Allowance);
            }

            return allowances;
        }
    }
}
