using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RecruitR.Persistence.ConnectionFactory;
using RecruitR.Projects.Dtos;

namespace RecruitR.Projects.Queries.Vacancies.GetVacancies
{
    public class GetVacanciesQueryHandler : IRequestHandler<GetVacanciesQuery, IEnumerable<VacancyDto>>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetVacanciesQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<IEnumerable<VacancyDto>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();

            const string sql = @"
                SELECT 
                        id, 
                        name, 
                        description,
                        status, 
                        ""expirationDate"" 
                FROM public.""Vacancy""
                WHERE ""ProjectId"" = @ProjectId";

            var vacancies = connection.QueryAsync<VacancyDto>(sql, new { ProjectId = request.ProjectId});

            return vacancies;
        }
    }
}