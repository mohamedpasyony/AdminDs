using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebApplication2.BL.Helper
{
    public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile FileUrl , string FolderPath)
        {
            String FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderPath;

            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

            string FinalPath=Path.Combine(FilePath , FileName);

            using (var stream = new FileStream(FinalPath, mode:FileMode.Create))
            {
                FileUrl.CopyTo(stream);

            }

            return FileName;
        }
        public static void DeleteFile(String FolderName , String RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/"+ FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName);
            }
        }
    }
}
