using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0500._80
{
    class A588 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class FileSystem
        {
            private readonly Directory _root = new Directory { Name = "/" };

            public FileSystem()
            {

            }

            private Directory GetDirectory(string[] names, int length, bool createIfNotExist)
            {
                var dir = _root;
                for (int i = 0; i < length; i++)
                {
                    string name = names[i];
                    if (!dir.Dirs.TryGetValue(name, out var child))
                    {
                        if (createIfNotExist)
                        {
                            child = new Directory { Name = name };
                            dir.Dirs.Add(name, child);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    dir = child;
                }
                return dir;
            }

            public IList<string> Ls(string path)
            {
                var names = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
                List<string> items = new List<string>();
                Directory dir = null;
                if (names.Length == 0)
                {
                    dir = _root;
                    items.AddRange(dir.Dirs.Keys);
                    items.AddRange(dir.Files.Keys);
                    items.Sort();
                }
                else
                {
                    dir = GetDirectory(names, names.Length - 1, false);
                    if (dir == null)
                    {
                        return items;
                    }
                    if (dir.Files.TryGetValue(names[names.Length - 1], out var file))
                    {
                        items.Add(file.Name);
                    }
                    else if (dir.Dirs.TryGetValue(names[names.Length - 1], out dir))
                    {
                        items.AddRange(dir.Dirs.Keys);
                        items.AddRange(dir.Files.Keys);
                        items.Sort();
                    }
                }
                return items;
            }

            public void Mkdir(string path)
            {
                var names = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
                GetDirectory(names, names.Length, true);
            }

            public void AddContentToFile(string filePath, string content)
            {
                var names = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var dir = GetDirectory(names, names.Length - 1, false);
                if (dir == null)
                {
                    return;
                }
                if (dir.Files.TryGetValue(names[names.Length - 1], out var file))
                {
                    file.Content = $"{file.Content}{content}";
                }
                else
                {
                    dir.Files.Add(names[names.Length - 1], new File { Name = names[names.Length - 1], Content = content });
                }
            }

            public string ReadContentFromFile(string filePath)
            {
                var names = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var dir = GetDirectory(names, names.Length - 1, false);
                if (dir != null && dir.Files.TryGetValue(names[names.Length - 1], out var file))
                {
                    return file.Content;
                }
                return string.Empty;
            }


            private class Directory
            {
                public string Name { get; set; }
                public Dictionary<string, Directory> Dirs { get; set; } = new Dictionary<string, Directory>();
                public Dictionary<string, File> Files { get; set; } = new Dictionary<string, File>();
            }

            private class File
            {
                public string Name { get; set; }
                public string Content { get; set; }
            }
        }

    }
}
