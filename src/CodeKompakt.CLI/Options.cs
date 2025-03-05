using CommandLine;

namespace CodeKompakt.CLI;

public class Options
{
    [Option('d', "directory", Required = false, HelpText = "Path to the project directory. Required if no configuration file is specified via --config.")]
    public string? Directory { get; set; }

    [Option('o', "output", Required = false, HelpText = "Name of the output file. Required if no configuration file is specified via --config.")]
    public string? Output { get; set; }

    [Option('x', "exclude-extensions", Required = false, HelpText = "List of file extensions to exclude, separated by commas.")]
    public string? ExcludeExtensions { get; set; }

    [Option('e', "exclude-dirs", Required = false, HelpText = "List of directories to exclude, separated by commas.")]
    public string? ExcludeDirs { get; set; }

    [Option('f', "exclude-files", Required = false, HelpText = "List of files to exclude, separated by commas.")]
    public string? ExcludeFiles { get; set; }

    [Option('c', "config", Required = false, HelpText = "Path to a configuration file containing all necessary parameter options.")]
    public string? Config { get; set; }

    [Option('h', "help", Required = false, HelpText = "Displays a help overview for the available parameters.")]
    public bool Help { get; set; }

    [Option('v', "version", Required = false, HelpText = "Displays the application's version information.")]
    public bool Version { get; set; }
}