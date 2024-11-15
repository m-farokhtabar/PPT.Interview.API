namespace PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy
{
    internal interface IAvatarUrlStrategy
    {
        Task<(bool isMatch, string? url)> GetUrlAsync(string userIdentifier, CancellationToken cancellationToken);
    }
}
