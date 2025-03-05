namespace CodeKompakt.CLI.Tests;

[TestFixture]
public class ParameterValidatorTests
{
    [Test]
    public void Validate_HelpIsTrue_ReturnsTrue()
    {
        // Arrange
        var options = new Options
        {
            Help = true
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsTrue(result, "Expected validation to succeed if Help is set to true.");
        Assert.IsEmpty(errorMessage, "No error message should be returned when Help is true.");
    }

    [Test]
    public void Validate_VersionIsTrue_ReturnsTrue()
    {
        // Arrange
        var options = new Options
        {
            Version = true
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsTrue(result, "Expected validation to succeed if Version is set to true.");
        Assert.IsEmpty(errorMessage, "No error message should be returned when Version is true.");
    }

    [Test]
    public void Validate_ConfigIsNotEmpty_ReturnsTrue()
    {
        // Arrange
        var options = new Options
        {
            Config = "someConfigFile.config",
            Directory = null,
            Output = null
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsTrue(result, "Expected validation to succeed if a config file is provided.");
        Assert.IsEmpty(errorMessage, "No error message should be returned when Config is specified.");
    }

    [Test]
    public void Validate_NoConfig_DirectoryAndOutputAreSet_ReturnsTrue()
    {
        // Arrange
        var options = new Options
        {
            Directory = @"C:\Projects\MyApp",
            Output = "output.txt"
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsTrue(result, "Expected validation to succeed if both Directory and Output are provided.");
        Assert.IsEmpty(errorMessage, "No error message should be returned when Directory and Output are specified.");
    }

    [Test]
    public void Validate_NoConfig_NoDirectory_ReturnsFalse()
    {
        // Arrange
        var options = new Options
        {
            Directory = "",
            Output = "output.txt"
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsFalse(result, "Expected validation to fail if Directory is missing and no config is provided.");
        StringAssert.Contains("Either a configuration file or a directory", errorMessage,
            "The error message should indicate that Directory and Output or Config must be specified.");
    }

    [Test]
    public void Validate_NoConfig_NoOutput_ReturnsFalse()
    {
        // Arrange
        var options = new Options
        {
            Directory = @"C:\Projects\MyApp",
            Output = ""
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsFalse(result, "Expected validation to fail if Output is missing and no config is provided.");
        StringAssert.Contains("Either a configuration file or a directory", errorMessage,
            "The error message should indicate that Directory and Output or Config must be specified.");
    }

    [Test]
    public void Validate_NoConfig_NoDirectoryAndNoOutput_ReturnsFalse()
    {
        // Arrange
        var options = new Options
        {
            Directory = "",
            Output = ""
        };

        // Act
        var result = ParameterValidator.Validate(options, out string errorMessage);

        // Assert
        Assert.IsFalse(result, "Expected validation to fail if both Directory and Output are missing and no config is provided.");
        StringAssert.Contains("Either a configuration file or a directory", errorMessage,
            "The error message should indicate that Directory and Output or Config must be specified.");
    }
}