using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace FileRepeater
{
    public class FileCopier
    {
        public async Task ProcessFileAsync(IFileParam _fileParam)
        {
            if (!string.IsNullOrEmpty(_fileParam.SourceFile))
            {
                var sourceFile = _fileParam.SourceFile;
                FileInfo fInfo = new FileInfo(sourceFile);
                if (fInfo.Exists)
                {
                    if (!string.IsNullOrEmpty(_fileParam.DestinationFile))
                    {
                        var defaultFileTemplat      = fInfo.Name.Replace(fInfo.Extension, "") + "{0}" + fInfo.Extension;
                        _fileParam.FileNameTemplate = _fileParam.FileNameTemplate ?? defaultFileTemplat;
                        

                        List<Task> Workers = new List<Task>();

                        string content = "";
                        if (!string.IsNullOrEmpty(_fileParam.Replace))
                        {
                            content = File.ReadAllText(sourceFile);
                        }

                        for (int i = 0; i < _fileParam.Repeat; i++)
                        {
                            var fReplacer = new FileReplacer(_fileParam, content, i + 1);
                            Workers.Add(CopyAsync(fReplacer));
                        }

                        await Task.WhenAll(Workers);
                    }
                }
                else
                {
                    Console.WriteLine($"err02:file does not exists {fInfo.FullName}");
                }
            }
        }

        private async Task CopyAsync(IFileReplacer _fcp)
        {
            await _fcp.ProcessCopy();
        }
    }
}
