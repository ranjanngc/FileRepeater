using System.Threading.Tasks;

namespace FileRepeater
{
    public interface IFileReplacer
    {
        IFileParam Param { get; set; }
        int Index { get; set; }

        void ReplaceContent();

        Task ProcessCopy();        
    }
}
