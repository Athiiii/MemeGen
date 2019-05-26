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
    public class TemplateTagController : Controller
    {
        private readonly ITemplateTag _templateTagService;

        public TemplateTagController(ITemplateTag templateTagService)
        {
            _templateTagService = templateTagService;
        }

        [HttpGet]
        public IEnumerable<Templatetag> GetTemplateTags()
        {
            return _templateTagService.Select();
        }

        [HttpPost]
        public IActionResult InsertTemplateTag([FromBody]Templatetag template)
        {
            _templateTagService.Insert(template);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTemplateTag([FromBody]Templatetag templateTag)
        {
            if (_templateTagService.Delete(templateTag))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateTemplateTag([FromBody]Templatetag templatetag)
        {
            if (_templateTagService.Update(templatetag))
                return Ok();
            return NotFound();
        }
    }
}
