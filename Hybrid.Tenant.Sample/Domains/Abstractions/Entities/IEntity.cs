using FluentValidation.Results;

namespace Hybrid.Tenant.Sample.Domains.Abstractions.Entities;

public interface IEntity
{
    bool IsDeleted { get; }

    bool IsValid { get; }

    public IEnumerable<ValidationFailure> Errors { get; }
}