﻿
using System;
using RecruitR.Domain.Projects.Enums;
using Type = RecruitR.Domain.Projects.Enums.Type;

namespace RecruitR.Projects.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool RecruitingStatus { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
    }
}