using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._1100._60
{
    class A1166 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class FileSystem
        {
            private readonly FileSystemInfo _root = new FileSystemInfo();

            public FileSystem()
            {

            }

            public bool CreatePath(string path, int value)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return false;
                }
                string[] paths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
                if (paths.Length == 0)
                {
                    return false;
                }
                var fsInfo = GetFSInfo(paths, paths.Length - 1);
                if(fsInfo == null)
                {
                    return false;
                }
                if (fsInfo.Children.TryGetValue(paths.Last(), out var info))
                {
                    return false;
                }
                else
                {
                    info = new FileSystemInfo { Value = value };
                    fsInfo.Children.Add(paths.Last(), info);
                }
                return true;
            }

            private FileSystemInfo GetFSInfo(string[] paths, int length)
            {
                var fsInfo = _root;
                for (int i = 0; i < length; i++)
                {
                    if (!fsInfo.Children.TryGetValue(paths[i], out var child))
                    {
                        return null;
                    }
                    fsInfo = child;
                }
                return fsInfo;
            }

            public int Get(string path)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return -1;
                }
                string[] paths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
                if (paths.Length == 0)
                {
                    return -1;
                }
                var fsInfo = GetFSInfo(paths, paths.Length);
                if (fsInfo != null)
                {
                    return fsInfo.Value;
                }
                return -1;
            }

            public class FileSystemInfo
            {
                public Dictionary<string, FileSystemInfo> Children { get; } = new Dictionary<string, FileSystemInfo>();
                public int Value { get; set; }
            }
        }
    }
}
