# ConvertToUtf8
Simple tool for the Windows commandline to convert files encoded int UTF-16 to UTF-8. There is no detection of the actual encoding of the input file.

Based on the code provided by Jon Skeet in this answer on StackOverflow: [http://stackoverflow.com/a/265444/571213](http://stackoverflow.com/a/265444/571213).

## Usage

### Convert a single file

    ConvertToUtf8.exe <input file> <output file>

Note that `<input file>` and `<output file>` have to be different (no in-place conversion).

### Convert all files in folder (in-place)

    ConvertToUtf8.exe <folder>

This form converts all files in the specified folder to UTF-8. **Do not apply twice** (see warning below).

## WARNING - Known Issue

Currently, the tool assumes input files to be UTF-16. Processing UTF-8 files with this tool will give corrupted input.

Thus, especially applying the tool twice will destroy the file content.

Use on your own risk.