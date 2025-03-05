namespace CodeKompakt.CLI;

public static class ParameterValidator
{
    public static bool Validate(Options options, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (options.Help || options.Version)
            return true;

        if (string.IsNullOrWhiteSpace(options.Config) && (string.IsNullOrWhiteSpace(options.Directory) || string.IsNullOrWhiteSpace(options.Output)))
        {
            errorMessage = "Either a configuration file or a directory and output file must be specified.";
            return false;
        }

        return true;
    }
}
