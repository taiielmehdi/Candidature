using Candidature.Data.Contexts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidature.Business.Repositories
{
    public class BaseRepository
    {
        private readonly CandidatureContext _context;
        
        public BaseRepository(CandidatureContext context)
        {
            _context = context;
        }

        public async Task<byte[]> GetBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
