using PPT.Interview.Application.SeedWorks;
using PPT.Interview.Application.SeedWorks.DbProvider;

namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;

internal class Rule2AvatarUrlStrategy : IAvatarUrlStrategy
{
    private readonly IApplicationSettings settings;
    private readonly IAvatarImageDbProvider provider;

    public Rule2AvatarUrlStrategy(IApplicationSettings settings, IAvatarImageDbProvider provider)
    {
        this.settings = settings;
        this.provider = provider;
    }

    public async Task<(bool isMatch,string? url)> GetUrlAsync(string userIdentifier, CancellationToken cancellationToken)
    {
        string lastChar = userIdentifier[^1].ToString();
        bool isMatch = settings.Rule2.Contains(lastChar);
        string? url = null;
        if (isMatch)
            url = await provider.GetById(Convert.ToInt32(lastChar), cancellationToken);
        return (isMatch, url);
    }

}
