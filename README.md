## Short Description
**CodeKompakt** is a C# console application that consolidates all source code files from a specified project directory into a single file. Before the actual source code, all folders and directory structures are also described textually. As a result, **CodeKompakt** is ideal for bundling source code, project structure, and other metadata in one file. This consolidated file can then be used as input for Large Language Models (LLMs).

## Main Features
- **Recursive Merging**  
  - Recursively scans the specified directory.  
  - Reads all relevant files and combines them into a single file.

- **Textual Meta-Information**  
  - Describes the directory structure (path, folder names, file names).

- **Exclusion Rules**  
  - Allows excluding certain file extensions (e.g., `*.exe`, `*.dll`).  
  - Permits ignoring specific directories or individual files.  
  - Exclusion rules can be grouped in a file to simplify parameter configuration.

## Summary
This project consolidates all essential project information—both structure and source code—into a single file. The result is a compact data package that can be easily processed by LLMs.  
Offering it as a console application with freely configurable settings also simplifies integration into existing workflows or build processes.
