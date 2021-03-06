﻿using System;
using RecruitR.Domain.Projects.Enums;
using RecruitR.Infrastructure;
using Type = RecruitR.Domain.Projects.Enums.Type;

namespace RecruitR.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public bool RecruitingStatus { get; }
        public Type Type { get; }
        public Category Category { get; }

        public CreateProjectCommand(Guid id, string name, string description, bool recruitingStatus, Type type, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            RecruitingStatus = recruitingStatus;
            Type = type;
            Category = category;
        }
    }
}