using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViajaNetFullStackSr.DataComunication;
using ViajaNetFullStackSr.Domain.Interfaces.Services;

namespace ViajaNetFullStackSr.Api.Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Fields

        readonly IWriteLogService _service;

        #endregion

        #region Constructor

        public ValuesController(IWriteLogService service)
        {
            _service = service;
        }

        #endregion

        #region Methods

        [HttpPost, Route("save")]
        public async Task<ActionResult> Save([FromBody] LogDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                model.Id = Guid.NewGuid();

                _service.Insert(model);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
         
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        #endregion
    }
}
