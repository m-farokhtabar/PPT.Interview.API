using PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;
using PPT.Interview.Application.SeedWorks;
using Moq;
using PPT.Interview.Application.SeedWorks.RestApiProvider;

namespace PPT.Interview.Test;

public class RetrieveAvatarImagesTests
{
    [Fact]
    public async Task If_LastCharOfTheIdIsSixToNine_ShouldReturnTrue()
    {
        const string userIdentifier = "!#aeo128";
        var mockSetting = new Mock<IApplicationSettings>();
        mockSetting.Setup(x => x.Rule1Address).Returns("https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{lastDigitOfUserIdentifier}");
        mockSetting.Setup(settings => settings.Rule1).Returns(["6", "7", "8", "9"]);
        var mockRest = new Mock<IAvatarImageRestApiProvider>();
        mockRest.Setup(x => x.GetAvatarUrl("Rest Url", CancellationToken.None)).ReturnsAsync("Avatar Url");

        
        Rule1AvatarUrlStrategy rule = new(mockSetting.Object, mockRest.Object);
        (bool isMatch, string? url) result = await rule.GetUrlAsync(userIdentifier, CancellationToken.None);
        
        
        Assert.True(result.isMatch);
    }
}