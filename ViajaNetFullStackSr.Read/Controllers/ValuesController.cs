using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViajaNetFullStackSr.DataComunication;
using ViajaNetFullStackSr.Domain.Interfaces.Services;

namespace ViajaNetFullStackSr.Read.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Fields

        readonly IReadLogService _service;

        #endregion

        #region Constructor

        public ValuesController(IReadLogService service)
        {
            _service = service;
        }

        #endregion

        #region Methods

        [HttpPost, Route("GetByFilter")]
        public async Task<ActionResult> GetByFilter([FromBody] IpPageNameFilter filter)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var list = _service.GetByFilter(filter.Ip, filter.PageName);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value11", "value22" };
        }

        #endregion
    }
}
