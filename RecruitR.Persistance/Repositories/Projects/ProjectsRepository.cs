using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitR.Domain.Projects;

namespace RecruitR.Persistence.Repositories.Projects
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly RecruitDbContext _context;

        public ProjectsRepository(RecruitDbContext context)
        {
            _context = context;
        }

        public async Task Add(Project project)
            => await _context.Projects.AddAsync(project);

        public void Delete(Project project)
            => _context.Projects.Remove(project);

        public void Update(Project project)
            => _context.Projects.Update(project);

        public async Task<Project> Get(Guid id)
            => await _context.Projects.FindAsync(id);

        public async Task<IEnumerable<Project>> GetAll()
            => await _context.Projects.ToListAsync();

        public Task SaveChanges()
            => _context.SaveChangesAsync();
    }
}