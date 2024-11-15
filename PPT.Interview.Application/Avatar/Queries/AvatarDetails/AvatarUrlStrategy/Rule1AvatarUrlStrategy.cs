using PPT.Interview.Application.SeedWorks;
using PPT.Interview.Application.SeedWorks.RestApiProvider;

namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;

public class Rule1AvatarUrlStrategy : IAvatarUrlStrategy
{
    private readonly IApplicationSettings settings;
    private readonly IAvatarImageRestApiProvider avatarImageRestApiProvider;

    public Rule1AvatarUrlStrategy(IApplicationSettings settings, IAvatarImageRestApiProvider avatarImageRestApiProvider)
    {
        this.settings = settings;
        this.avatarImageRestApiProvider = avatarImageRestApiProvider;
    }

    public async Task<(bool isMatch,string? url)> GetUrlAsync(string userIdentifier, CancellationToken cancellationToken)
    {
        string lastChar = userIdentifier[^1].ToString();
        bool isMatch = settings.Rule1.Contains(lastChar);
        string? url = null;
        if (isMatch)
            url = await avatarImageRestApiProvider.GetAvatarUrl(settings.Rule1Address.Replace("{lastDigitOfUserIdentifier}", lastChar), cancellationToken);

        return (isMatch, url);
    }
}
