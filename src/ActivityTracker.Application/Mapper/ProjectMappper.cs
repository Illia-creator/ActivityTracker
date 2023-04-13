using ActivityTracker.Application.Dto.ProjectDto;
using ActivityTracker.Domain.Entities;
using Mapster;

namespace ActivityTracker.Application.Mapper
{
    public class ProjectMappper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProjectDto, Project>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<UpdateProjectDto, Project>()
                .RequireDestinationMemberSource(true);
        }
    }
}
