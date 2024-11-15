using MediatR;
using PPT.Interview.Application.SeedWorks;
using System.Text.RegularExpressions;

namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;

public class Rule3AvatarUrlStrategy : IAvatarUrlStrategy
{
    private readonly IApplicationSettings settings;

    public Rule3AvatarUrlStrategy(IApplicationSettings settings)
    {
        this.settings = settings;
    }

    public Task<(bool isMatch,string? url)> GetUrlAsync(string userIdentifier, CancellationToken cancellationToken)
    {        
        bool isMatch = Regex.IsMatch(userIdentifier, settings.Rule3, RegexOptions.IgnoreCase);
        return Task.FromResult((isMatch, isMatch ? settings.Rule3Address : null));
    }

}
