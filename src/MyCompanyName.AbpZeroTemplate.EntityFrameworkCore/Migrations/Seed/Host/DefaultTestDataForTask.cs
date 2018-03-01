using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class DefaultTestDataForTask
    {
        private readonly AbpZeroTemplateDbContext _context;

        private static readonly List<SimpleTask> _tasks;

        public DefaultTestDataForTask(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        static DefaultTestDataForTask()
        {
            _tasks = new List<SimpleTask>()
            {
                new SimpleTask("Learning ABP deom", "Learning how to use abp framework to build a MPA application."),
                new SimpleTask("Make Lunch", "Cook 2 dishs")
            };
        }

        public void Create()
        {
            foreach (var task in _tasks)
            {
                if (_context.SimpleTasks.FirstOrDefault(t => t.Title == task.Title) == null)
                {
                    _context.SimpleTasks.Add(task);
                }
                _context.SaveChanges();
            }
        }

    }
}
