using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGM.CQRS.Interface;
using MGM.CQRS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemeGen.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITag _tagService;

        public TagController(ITag tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            return _tagService.Select();
        }

        [HttpGet("{id}")]
        public Tag GettagByTag(int id)
        {
            return _tagService.SelectById(id);
        }

        [HttpPost]
        public IActionResult InsertTag([FromBody]Tag tag)
        {
            _tagService.Insert(tag);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTag(int tagId)
        {
            if (_tagService.Delete(null, tagId))
                return Ok();
            return NotFound();
        }


        [HttpDelete]
        public IActionResult DeleteTag([FromBody]Tag tag)
        {
            if (_tagService.Delete(tag))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        public IActionResult Updatetag([FromBody] Tag tag, int tagId)
        {
            if (tagId == 0)
                tagId = -1;
            if (_tagService.Update(tag, tagId))
                return Ok();
            return NotFound();
        }

    }
}
