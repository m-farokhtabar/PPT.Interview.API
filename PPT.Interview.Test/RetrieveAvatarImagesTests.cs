using PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;
using PPT.Interview.Application.SeedWorks;
using Moq;
using PPT.Interview.Application.SeedWorks.RestApiProvider;
using PPT.Interview.Application.SeedWorks.DbProvider;

namespace PPT.Interview.Test;

public class RetrieveAvatarImagesTests
{
    [Fact]
    public async Task If_LastCharOfTheIdIsSixToNine_ShouldReturnTrue()
    {
        const string userIdentifier = "12aeo128";
        var mockSetting = new Mock<IApplicationSettings>();
        mockSetting.Setup(x => x.Rule1Address).Returns("https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{lastDigitOfUserIdentifier}");
        mockSetting.Setup(x => x.Rule1).Returns(["6", "7", "8", "9"]);
        var mockRest = new Mock<IAvatarImageRestApiProvider>();
        mockRest.Setup(x => x.GetAvatarUrl("Rest Url", CancellationToken.None)).ReturnsAsync("Avatar Url");

        
        Rule1AvatarUrlStrategy rule = new(mockSetting.Object, mockRest.Object);
        (bool isMatch, string? url) result = await rule.GetUrlAsync(userIdentifier, CancellationToken.None);
        
        
        Assert.True(result.isMatch);
    }
    [Fact]
    public async Task If_ContainsOneVowelChar_ShouldReturnTrue()
    {
        const string userIdentifier = "!#223ae";
        var mockSetting = new Mock<IApplicationSettings>();
        mockSetting.Setup(x => x.Rule3Address).Returns("https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150");
        mockSetting.Setup(x => x.Rule3).Returns("[aeiou]");

        Rule3AvatarUrlStrategy rule = new(mockSetting.Object);
        (bool isMatch, string? url) result = await rule.GetUrlAsync(userIdentifier, CancellationToken.None);


        Assert.True(result.isMatch);
    }
    [Fact]
    public async Task If_ContainsANonAlphanumericChar_ShouldReturnTrue()
    {
        const string userIdentifier = "asda!sd#";
        var mockSetting = new Mock<IApplicationSettings>();
        mockSetting.Setup(x => x.Rule4Address).Returns("https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150");
        mockSetting.Setup(x => x.Rule4).Returns("[^a-zA-Z0-9]");

        Rule4AvatarUrlStrategy rule = new(mockSetting.Object);
        (bool isMatch, string? url) result = await rule.GetUrlAsync(userIdentifier, CancellationToken.None);


        Assert.True(result.isMatch);
    }
    [Fact]
    public async Task If_LastCharOfTheIdIsOneToFive_ShouldReturnTrue()
    {
        const string userIdentifier = "asda!sd4";
        var mockSetting = new Mock<IApplicationSettings>();        
        mockSetting.Setup(x => x.Rule2).Returns(["1", "2", "3", "4", "5"]);

        var mockDb = new Mock<IAvatarImageDbProvider>();
        mockDb.Setup(x => x.GetById(1, CancellationToken.None)).ReturnsAsync("Avatar Url");



        Rule2AvatarUrlStrategy rule = new(mockSetting.Object, mockDb.Object);
        (bool isMatch, string? url) result = await rule.GetUrlAsync(userIdentifier, CancellationToken.None);


        Assert.True(result.isMatch);
    }
}