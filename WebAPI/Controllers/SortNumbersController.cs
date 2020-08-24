using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SortNumbersController : ControllerBase
    {
        private readonly ILogger<SortNumbersController> _logger;
        public static readonly string FILES_DIRECTORY = "results";

        public SortNumbersController(ILogger<SortNumbersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Post(string input)
        {
            List<int> data;

            try
            {
                data = input.Split(' ').Select(z=>int.Parse(z)).ToList();
            }catch(Exception)
            {
                goto ReturnError;
            }

            data.BubbleSort();

            if (!Directory.Exists(FILES_DIRECTORY))
                Directory.CreateDirectory(FILES_DIRECTORY);

            try
            {
                string filename;
                do
                {
                    filename = $"result_{DateTime.Now.Ticks}.txt";
                } while (System.IO.File.Exists(Path.Combine(FILES_DIRECTORY, filename)));

                using (StreamWriter writer = new StreamWriter(Path.Combine(FILES_DIRECTORY, filename)))
                {
                    writer.Write(String.Join(" ", data.ToArray()));
                }
            }catch(Exception)
            {
                goto ReturnError;
            }

            return new JsonResult(new { status="success"});

            ReturnError:
                return new JsonResult(new { status = "error" });
        }
    }
}
