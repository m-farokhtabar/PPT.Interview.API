using MediatR;

namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails;

/// <summary>
/// Get Avatar based on user identifier
/// </summary>
public record AvatarQuery(string? userIdentifier) : IRequest<string?>;
