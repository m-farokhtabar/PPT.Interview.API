using MediatR;
using PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;
using PPT.Interview.Application.SeedWorks;

namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails;
/// <summary>
/// 
/// </summary>
internal class AvatarQueryHandler : IRequestHandler<AvatarQuery, string?>
{
    private readonly IApplicationSettings settings;
    private readonly IEnumerable<IAvatarUrlStrategy> avatarUrlStrategies;

    public AvatarQueryHandler(IApplicationSettings settings, IEnumerable<IAvatarUrlStrategy> avatarUrlStrategies)
    {
        this.settings = settings;
        this.avatarUrlStrategies = avatarUrlStrategies;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<string?> Handle(AvatarQuery request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.userIdentifier))
        {
            foreach (var item in avatarUrlStrategies)
            {
                (bool isMatch, string? url) = await item.GetUrlAsync(request.userIdentifier, cancellationToken);
                if (isMatch)
                    return url;
            }
        }        
        return settings.Rule5Address;
    }
}
