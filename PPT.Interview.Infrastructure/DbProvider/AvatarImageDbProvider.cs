using Microsoft.EntityFrameworkCore;
using PPT.Interview.Application.SeedWorks.DbProvider;

namespace PPT.Interview.Infrastructure.DbProvider;

/// <summary>
/// For description <see cref="IAvatarImageProvider"/>
/// </summary>
public class AvatarImageDbProvider : IAvatarImageDbProvider
{
    private readonly AppDbContext db;

    public AvatarImageDbProvider(AppDbContext db)
    {
        this.db = db;
    }
    /// <summary>
    /// For description <see cref="IAvatarImageProvider.GetById(int)"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<string?> GetById(int id, CancellationToken cancellationToken) => await db.Images.AsNoTracking().Where(x => x.Id == id).Select(x => x.Url).FirstOrDefaultAsync(cancellationToken);
}
