using PPT.Interview.Application.SeedWorks.RestApiProvider;
using System.Net.Http.Json;

namespace PPT.Interview.Infrastructure.RestApiProvider;

/// <summary>
/// For Description <see cref="IAvatarImageRestApiProvider"/>
/// </summary>
public class AvatarImageRestApiProvider : IAvatarImageRestApiProvider
{
    /// <summary>
    /// For Description <see cref="IAvatarImageRestApiProvider.GetAvatarUrl(string, CancellationToken)"/>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<string?> GetAvatarUrl(string url, CancellationToken cancellation)
    {
        string? urlResult = null;
        try
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<ImageDto>(url, cancellationToken: cancellation);
            urlResult =  result?.Url;
        }
        catch
        {

        }
        return urlResult;
    }
}
