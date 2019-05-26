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
    public class MemeController : Controller
    {
        private readonly IMeme _memeService;

        public MemeController(IMeme memeService)
        {
            _memeService = memeService;
        }

        [HttpGet]
        public IEnumerable<Meme> GetMemes()
        {
            return _memeService.Select();
        }

        [HttpGet("{userId}")]
        public IEnumerable<Meme> GetUserById(int userId)
        {
            return _memeService.SelectByUser(userId);
        }

        [HttpPost]
        public IActionResult InsertMeme([FromBody]Meme meme)
        {
            _memeService.Insert(meme);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMeme(int memeId)
        {
            if (_memeService.Delete(null, memeId))
                return Ok();
            return NotFound();
        }


        [HttpDelete]
        public IActionResult DeleteMeme([FromBody]Meme meme)
        {
            if (_memeService.Delete(meme))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateMeme([FromBody] Meme meme, int memeId)
        {
            if (memeId == 0)
                memeId = -1;
            if (_memeService.Update(meme, memeId))
                return Ok();
            return NotFound();
        }
    }
}
