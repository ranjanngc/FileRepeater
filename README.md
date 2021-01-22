# FileRepeater
Small utility to copy a file as many time as you wish. Optionally you can replace text to the copied file.

## Synopsis

```
FileRepeater 
  --sourcefile [source file path]
  --destination [destination folder path]
  --repeat [Nuber of time file to be copied]
  [--fileNameTemplate [myfile{0}]]
  [--overwrite [0/1]]
  [--replace [string to replace is copied file]]
  [--with [string template to replace]]
```

## Example
```
FileRepeater --sourcefile my\source\file\to\copy --destination my\destination\folder --repeat 2 --replace stringToReplace --with stringToReplaceWith
```

--sourcefile  : Full file path to copy

--destination : Path to the folder to create new file

--repeat      : Number of file to create
-- filenameTemplate : File name template. E.g. "NewFile{0}". In this {0} will be replaced with file number. For example if we are copying file 2 times the template will result in new file name as "NewFile1" and "NewFile2". Extension will be used from source file.

-- overwrite : Pass 1 to overwitre if file exists

-- replace  : string to replace

-- with     : string to replace with. It can be template with {0} to be replaced with file number.
