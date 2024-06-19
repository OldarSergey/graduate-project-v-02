using GraduateProjectAPI.DTO.KnowledgeBase;
using GraduateProjectAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseController : ControllerBase
    {

        private readonly IKnowledgeBase _service;

        public KnowledgeBaseController(IKnowledgeBase service)
        {
            _service = service;
        }

        [HttpGet]
        public  IActionResult GetListGroups()
        {
            var result = _service.GettingTreeGroups();
            return Ok(result);
        }

        [HttpGet("{idGroup}")]
        public IActionResult GettingArticlesGroup(int idGroup)
        {
            var result = _service.GettingArticlesGroup(idGroup);
            return Ok(result);
        }

        [HttpGet("paper/{KeyItems}")]
        public IActionResult GetContentPaper(int KeyItems)
        {
            var result = _service.GetContentPaper(KeyItems);
            return Ok(result);
        }
    }
}
