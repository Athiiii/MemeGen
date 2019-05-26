using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGM.CQRS.Interface;
using MGM.CQRS.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemeGen.Controllers
{
    [Route("api/[controller]")]
    public class MemeTagController : Controller
    {
        private readonly IMemeTag _memeTagService;

        public MemeTagController(IMemeTag memeTagService)
        {
            _memeTagService = memeTagService;
        }

        [HttpGet]
        public IEnumerable<Memetag> GetMemeTags()
        {
            return _memeTagService.Select();
        }

        [HttpPost]
        public IActionResult InsertMemeTag([FromBody]Memetag meme)
        {
            _memeTagService.Insert(meme);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMemeTag([FromBody]Memetag memeTag)
        {
            if (_memeTagService.Delete(memeTag))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateMemeTag([FromBody]Memetag memetag)
        {
            if (_memeTagService.Update(memetag))
                return Ok();
            return NotFound();
        }
    }
}
