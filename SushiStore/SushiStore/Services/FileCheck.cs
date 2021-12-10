using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Services
{
    public static class FileCheck
    {
        public static bool CheckFileType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static bool CheckFileSize(this IFormFile file, int kb)
        {
            return file.Length / 1024 > kb;
        }

        public async static Task<string> SaveFileAsync(this IFormFile file, string root, string folder)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid().ToString() + "_" + file.FileName;
            string resultPath = Path.Combine(root, folder, fileName);

            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public static void DeleteFile(string fileName, string root, string folder)
        {
            string resultPath = Path.Combine(root, folder, fileName);

            bool isExist = System.IO.File.Exists(resultPath);
            if (isExist)
            {
                System.IO.File.Delete(resultPath);
            }
        }
    }
}
