using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Participants;

namespace WebAPI.Controllers.Participants
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        private readonly ParticipantsContext _context;

        public UploadFilesController (ParticipantsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            long size = file.Length;

            var filePath = Path.GetTempFileName();
            var sFile = new Document();

            if (file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {                   
                    await file.CopyToAsync(stream);
                    sFile.File = stream.ToArray();
                    sFile.FileName = file.FileName;
                    sFile.Type = file.ContentType;
                    _context.Documents.Add(sFile);
                    await _context.SaveChangesAsync();
                }
            }

            return Ok(sFile);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile ([FromRoute] int id)
        {
            var file =  await _context.Documents.FindAsync(id);
            
            var dataStream = new MemoryStream(file.File);
            return File(dataStream, file.Type, file.FileName);
        }
    }
}