using PPT.Interview.Application.SeedWorks;

namespace PPT.Interview.API.StartupConfig;

/// <summary>
/// For description <see cref="IApplicationSettings"/>
/// </summary>
public class ApplicationSettings : IApplicationSettings
{
    public List<string> Rule1 { get; set; } = [];
    public List<string> Rule2 { get; set; } = [];
    public string Rule3 { get; set; } = string.Empty;
    public string Rule4 { get; set; } = string.Empty;
    public string Rule1Address { get; set; } = string.Empty;
    public string Rule3Address { get; set; } = string.Empty;
    public string Rule4Address { get; set; } = string.Empty;
    public string Rule5Address { get; set; } = string.Empty;
}
