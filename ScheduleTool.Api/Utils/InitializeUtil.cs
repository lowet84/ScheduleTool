using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleTool.Api.Utils
{
    public static class InitializeUtil
    {
        private const string InitDirectory = "initialized";

        public static bool IsInitialized(string id)
        {
            CreateInitDirectoryIfNotExists();
            return File.Exists(Path.Combine(InitDirectory, id));
        }

        public static void SetInitialized(string id)
        {
            CreateInitDirectoryIfNotExists();
            using (File.Create(Path.Combine(InitDirectory, id))) { }
        }

        private static void CreateInitDirectoryIfNotExists()
        {
            if (!Directory.Exists(InitDirectory))
            {
                Directory.CreateDirectory(InitDirectory);
            }
        }
    }
}
