namespace PPT.Interview.Application.SeedWorks.RestApiProvider;
/// <summary>
/// Retrieve data from remote service(rest service)
/// </summary>
public interface IAvatarImageRestApiProvider
{
    /// <summary>
    /// Retrieve an url of images table by url address from third party
    /// </summary>
    /// <param name="url">full address</param>
    /// <param name="cancellation"></param>
    /// <returns>Retrieve image url</returns>
    Task<string?> GetAvatarUrl(string url, CancellationToken cancellation);
}
