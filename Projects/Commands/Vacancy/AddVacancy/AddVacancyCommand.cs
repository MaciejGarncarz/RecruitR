﻿using System;
using RecruitR.Domain.Projects.Enums;
using RecruitR.Infrastructure;

namespace RecruitR.Projects.Commands.Vacancy.AddVacancy
{
    public class AddVacancyCommand : ICommand
    {
        public Guid Id { get; }
        public Guid ProjectId { get;}
        public string Name { get;  }
        public string Description { get; }
        public VacancyStatus Status { get; }
        public DateTime ExpirationDate { get; }

        public AddVacancyCommand(Guid id, Guid projectId, string name, string description, VacancyStatus status, DateTime expirationDate)
        {
            Id = id;
            ProjectId = projectId;
            Name = name;
            Description = description;
            Status = status;
            ExpirationDate = expirationDate;
        }
    }
}