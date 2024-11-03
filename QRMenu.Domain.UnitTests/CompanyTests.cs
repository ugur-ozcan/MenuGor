// QRMenu.Domain.UnitTests/CompanyTests.cs
using QRMenu.Domain.Entities;
using Xunit;

namespace QRMenu.Domain.UnitTests;

public class CompanyTests
{
    [Fact]
    public void CreateCompany_WithValidData_ShouldInitializeCollections()
    {
        // Arrange & Act
        var company = new Company
        {
            Name = "Test Company",
            Code = "test-company",
            Email = "test@company.com"
        };

        // Assert
        Assert.NotNull(company.Branches);
        Assert.NotNull(company.SocialMediaLinks);
        Assert.Empty(company.Branches);
        Assert.Empty(company.SocialMediaLinks);
    }

    [Fact]
    public void AddBranch_ToCompany_ShouldIncreaseCount()
    {
        // Arrange
        var company = new Company();
        var branch = new Branch
        {
            Name = "Test Branch",
            Code = "test-branch"
        };

        // Act
        company.Branches.Add(branch);

        // Assert
        Assert.Single(company.Branches);
        Assert.Contains(branch, company.Branches);
    }
}