using Maxim_Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Persistence.Helper
{
    public static class FileManager
    {
        public static string Create(this IFormFile file,string envpath,string foldername,string filename)
        {
            if (filename.Length > 64)
            {
                filename = filename.Substring(filename.Length-64);
            }
            filename = Guid.NewGuid() + filename;
            string path=envpath+foldername+filename;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            } ;
            return filename;
        }
        public static void Delete(this ServiceSlider slider,string envpath,string foldername,string filename) 
        {
            string path = envpath + foldername + filename;
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
        public static string Update(this IFormFile file, string envpath, string foldername, string oldfilename,string newfilename)
        {
            string oldpath = envpath + foldername + oldfilename;
            FileInfo fileInfo = new FileInfo(oldpath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            if (newfilename.Length > 64)
            {
                newfilename = newfilename.Substring(newfilename.Length - 64);
            }
            newfilename = Guid.NewGuid() + newfilename;
            string newpath=envpath+foldername+newfilename;
            using(FileStream stream=new FileStream(newpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return newfilename;
        }

        public static bool Checker(this IFormFile file)
        {
            if(file.Length> 2097152)
            {
                return false;
            }
            if (!file.ContentType.Contains("image"))
            {
                return false;
            }
            return true;
        }
    }
}
