using PPT.Interview.Application.SeedWorks;
using System.Text.RegularExpressions;

namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;

internal class Rule4AvatarUrlStrategy : IAvatarUrlStrategy
{
    private readonly IApplicationSettings settings;

    public Rule4AvatarUrlStrategy(IApplicationSettings settings)
    {
        this.settings = settings;
    }

    public Task<(bool isMatch,string? url)> GetUrlAsync(string userIdentifier, CancellationToken cancellationToken)
    {
        string? url = null;
        bool isMatch = Regex.IsMatch(userIdentifier, settings.Rule4, RegexOptions.IgnoreCase);
        if (isMatch)
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random rnd = new(seed);
            url = settings.Rule4Address.Replace("{randomNumber}", rnd.Next(1, 6).ToString());
        }
        return Task.FromResult((isMatch, url));
    }

}
