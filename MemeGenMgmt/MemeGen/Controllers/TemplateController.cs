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
    public class TemplateController : Controller
    {
        private ITemplate _templateService;

        public TemplateController(ITemplate templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public IEnumerable<Template> GetTemplates()
        {
            return _templateService.Select();
        }

        [HttpGet("{userId}")]
        public Template GetUserById(int id)
        {
            return _templateService.SelectById(id);
        }

        [HttpPost]
        public IActionResult InsertTemplate([FromBody]Template template)
        {
            _templateService.Insert(template);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTemplate(int templateId)
        {
            if (_templateService.Delete(null, templateId))
                return Ok();
            return NotFound();
        }


        [HttpDelete]
        public IActionResult DeleteTemplate([FromBody]Template template)
        {
            if (_templateService.Delete(template))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateTemplate([FromBody] Template template, int templateId)
        {
            if (templateId == 0)
                templateId = -1;
            if (_templateService.Update(template, templateId))
                return Ok();
            return NotFound();
        }
    }
}
