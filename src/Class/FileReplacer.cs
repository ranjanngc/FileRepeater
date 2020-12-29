using System;
using System.Threading.Tasks;
using System.IO;

namespace FileRepeater
{
    public class FileReplacer : IFileReplacer
    {
        public IFileParam Param { get; set; }
        public int Index { get; set; }
        public string Content { get; set; }
        public FileReplacer(IFileParam _fileParam, string _content, int _index)
        {
            Param = _fileParam;
            Content = _content;
            Index = _index;
        }
        public void ReplaceContent()
        {
            Content = Content.Replace(Param.Replace, string.Format(Param.ReplaceWith, Index));
        }

        public async Task ProcessCopy()
        {
            if (String.IsNullOrEmpty(Param.Replace))
            {
                await CopyAsync();
            }
            else
            {
                ReplaceContent();
                await WriteAsync();
            }
        }

        async Task CopyAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var destFile = Path.Combine(Param.DestinationFile, string.Format(Param.FileNameTemplate, Index));
                File.Copy(Param.SourceFile, destFile, Param.Overwrite);
            });
        }

        async Task WriteAsync()
        {
            var destFile = Path.Combine(Param.DestinationFile, string.Format(Param.FileNameTemplate, Index));
            await File.WriteAllTextAsync(destFile, Content);
        }
    }
}
