﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Domain.Projects;
using RecruitR.Persistence.Repositories.Projects;

namespace RecruitR.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IProjectsRepository _repository;
        public CreateProjectCommandHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = Project.CreateProject(
                    request.Id,
                    request.Description,
                    request.RecruitingStatus,
                    request.Name,
                    request.Type,
                    request.Category
            );

            await _repository.Add(project);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}