using System;

namespace Homework_09
{
    public class BotFile
    {
        public int Id { get; set; }
        public String Path { get; set; }
        public String Name => System.IO.Path.GetFileName(Path);

        public BotFile(int id, string path)
        {
            this.Id = id;
            this.Path = path;
        }

    }
}