
namespace FileRepeater
{
    public interface IFileParam
    {
        string SourceFile { get; set; }
        string DestinationFile { get; set; }
        string Replace { get; set; }
        string ReplaceWith { get; set; }
        string FileNameTemplate { get; set; }
        int Repeat { get; set; }
        bool Overwrite { get; set; }
        void Parse(string[] arge);
    }
}
