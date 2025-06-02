using Lab11_GabrielCcama.Application.DTOs;
using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Roles.Queries;

public class GetRolesQuery : IRequest<IEnumerable<RoleDto>> { }

internal sealed class GetRolesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRolesQuery, 
    IEnumerable<RoleDto>>
{
    public async Task<IEnumerable<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await unitOfWork.Repository<Role>().GetAllAsync();

        var result = roles.Select(r => new RoleDto()
        {
            RoleId = r.RoleId,
            RoleName = r.RoleName
        });
        
        return result;
    }
}