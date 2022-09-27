using AdminHelper.models.entities;
using AdminHelper.Models.DbContexts;
using AdminHelper.Models.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdminHelper.Models.Repositories
{
    public class ActorRepository : EntityRepository<Actor>
    {
        public ActorRepository(AdminHelperDbContext context) : base(context)
        {
        }

        public override Actor? Read(int id)
        {
            var actor = _set.Find(id);
            if (actor == null)
            {
                return null;
            }
            return SetSalary(actor);
        }

        public override IEnumerable<Actor> Read()
        {
            var actors = _context.Actors.Include(actor => actor.Roles).ToList();
            var actorsWithSalary = actors.Select(actor => SetSalary(actor));
            return actorsWithSalary;
        }

        //Высчитывание зарплаты (аналогично коду в бд, который был представлен заранее)
        private Actor SetSalary(Actor actor)
        {
            var rates = CalcRates(actor);
            var allowances = CalcAllowances(actor);

            actor.Salary = rates + allowances;

            return actor;
        }
        private int CalcRates(Actor actor) => actor.Roles.Sum(role => role.Rate) ?? 0;
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
