using Microsoft.EntityFrameworkCore;

namespace PPT.Interview.Infrastructure.Data.Model;

public class ImageModel
{    
    public int Id { get; set; }
    public string? Url { get; set; }
}
