namespace PPT.Interview.Application.SeedWorks;

/// <summary>
/// Application settings for rules and relevant addresses for avatar upload
/// </summary>
public interface IApplicationSettings
{
    List<string> Rule1 { get; }
    List<string> Rule2 { get; }
    string Rule3 { get; }
    string Rule4 { get; }
    string Rule1Address { get; }
    string Rule3Address { get; }
    string Rule4Address { get; }
    string Rule5Address { get; }
}
