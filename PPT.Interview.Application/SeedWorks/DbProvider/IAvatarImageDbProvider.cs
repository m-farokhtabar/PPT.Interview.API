namespace PPT.Interview.Application.SeedWorks.DbProvider;
/// <summary>
/// Retrieve data from Images table
/// </summary>
public interface IAvatarImageDbProvider
{
    /// <summary>
    /// Retrieve an url of images table by identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retrieve image url</returns>
    public Task<string?> GetById(int id, CancellationToken cancellationToken);
}
