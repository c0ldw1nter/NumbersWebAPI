using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestFileController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            string recentFile = GetMostRecentResultFile();
            if (recentFile == null) 
                return new JsonResult(new { status="error", message="No files found."});

            string result = "";
            try
            {
                using(StreamReader sr=new StreamReader(recentFile))
                {
                    result=sr.ReadToEnd();
                }
            }catch(Exception)
            {
                return new JsonResult(new { status = "error", message = "File could not be read." });
            }

            return new JsonResult(new { status = "success", message =result});
        }

        string GetMostRecentResultFile()
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(SortNumbersController.FILES_DIRECTORY, "result_*.txt");
            }catch(Exception)
            {
                return null;
            }
            if (files.Length == 0) return null;

            DateTime mostRecent = DateTime.MinValue;
            string file="";
            foreach(var f in files)
            {
                DateTime fileTime = System.IO.File.GetLastWriteTime(f);
                if (fileTime>mostRecent)
                {
                    file = f;
                    mostRecent = fileTime;
                }
            }
            return file;
        }
    }
}
