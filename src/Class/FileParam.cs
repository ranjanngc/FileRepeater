using System;
using System.Collections.Generic;

namespace FileRepeater
{
    public class FileParam : IFileParam
    {
        public string SourceFile { get; set; }
        public string DestinationFile { get; set; }
        public string Replace { get; set; }
        public string ReplaceWith { get; set; }
        public string FileNameTemplate { get; set; }

        public bool Overwrite { get; set; }
        public int Repeat { get; set; }

        public void Parse(string[] args)
        {
            var param = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    if (!param.ContainsKey(args[i]))
                        param.Add(args[i], args.Length - 1 >= i + 1 ? args[i + 1] : "");
                    else
                        param[args[i]] = args[i + 1];
                }
                catch
                {
                    Console.WriteLine("e001: error parsing arguments");
                }
                i++;
            }
            if (!param.ContainsKey("--sourceFile"))
                param.Add("--sourceFile", "");
            if (!param.ContainsKey("--destination"))
                param.Add("--destination", "");
            if (!param.ContainsKey("--fileNameTemplate"))
                param.Add("--fileNameTemplate", null);
            if (!param.ContainsKey("--overwrite"))
                param.Add("--overwrite", "0");
            if (!param.ContainsKey("--repeat"))
                param.Add("--repeat", "1");
            if (!param.ContainsKey("--replace"))
                param.Add("--replace", null);
            if (!param.ContainsKey("--with"))
                param.Add("--with", null);

            SourceFile = param["--sourceFile"];
            DestinationFile = param["--destination"];
            Replace = param["--replace"];
            FileNameTemplate = param["--fileNameTemplate"];
            ReplaceWith = param["--with"];
            Overwrite = param["--overwrite"] == "1";
            int r = 1;
            Repeat = 1;
            if(Int32.TryParse(param["--repeat"], out r))
            {
                Repeat = r;
            }
        }
    }
}
