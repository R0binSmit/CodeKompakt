using CommandLine;

namespace CodeKompakt.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                var isOptionsValid = ParameterValidator.Validate(options, out string? errorMessage);

                if (!isOptionsValid)
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    if (options.Help)
                        Console.WriteLine("Help requested.");
                    if (options.Version)
                        Console.WriteLine("Version requested.");
                    if (string.IsNullOrWhiteSpace(options.Config) && (string.IsNullOrWhiteSpace(options.Directory) || string.IsNullOrWhiteSpace(options.Output)))
                        Console.WriteLine("Either a configuration file or a directory and output file must be specified.");
                    if (!string.IsNullOrWhiteSpace(options.Config) && (!string.IsNullOrWhiteSpace(options.Directory) || !string.IsNullOrWhiteSpace(options.Output)))
                        Console.WriteLine("Either a configuration file or a directory and output file must be specified, not both.");
                    if (!string.IsNullOrWhiteSpace(options.ExcludeExtensions) && options.ExcludeExtensions.Contains(","))
                        Console.WriteLine("The exclude-extensions parameter must not contain commas.");
                    if (!string.IsNullOrWhiteSpace(options.ExcludeDirs) && options.ExcludeDirs.Contains(","))
                        Console.WriteLine("The exclude-dirs parameter must not contain commas.");
                    if (!string.IsNullOrWhiteSpace(options.ExcludeFiles) && options.ExcludeFiles.Contains(","))
                        Console.WriteLine("The exclude-files parameter must not contain commas.");
                }
            });
    }
}