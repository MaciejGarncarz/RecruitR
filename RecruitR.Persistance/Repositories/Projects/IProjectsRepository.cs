using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitR.Domain.Projects;

namespace RecruitR.Persistence.Repositories.Projects
{
    public interface IProjectsRepository
    {
        Task Add(Project project);
        void Delete(Project project);
        void Update(Project project);
        Task<Project> Get(Guid id);
        Task<IEnumerable<Project>> GetAll();
        Task SaveChanges();
    }
}