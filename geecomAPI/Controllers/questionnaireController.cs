using geecomAPI.business;
using geecomAPI.businessInterface;
using geecomAPI.data;
using geecomAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace geecomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class questionnaireController : ControllerBase
    {

       private Iquestionnaire _iquestionnaire;


        public questionnaireController(Iquestionnaire iquestionnaire)
        {
            _iquestionnaire = iquestionnaire;
        }


        // GET: api/<questionnaireController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<questionnaireController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<questionnaireController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<questionnaireController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<questionnaireController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        [HttpGet]
        [Route("/api/LoadQuestionnior")]
        // [ValidateModelState]
        // [SwaggerOperation("SearchOrder")]
        // [SwaggerResponse(statusCode: 200, type: typeof(OrderResponse), description: "No error, operation successful.")]
        // [Authorize]
        public virtual IActionResult LoadQuestionnior([FromHeader(Name = "X-Request-Context-Data")] string apiContext, [FromQuery][Required()] int orgID, [FromQuery][Required()] int questionSetID, [FromQuery][Required()] string userID)
        {
            try
            {
                //questionniorBL objBL = new questionniorBL();
                
                questionniorResponseModel res = _iquestionnaire.GetQuestionnior(orgID, questionSetID, userID);
                if (res != null)
                {
                    return StatusCode(200, standardResponse.GetInstance(responseStatus.Success, string.Empty, res));
                }
                else
                    return StatusCode(200, standardResponse.GetInstance(responseStatus.Success, ResponseMessage.No_Records_Found, null));
            }
            catch (Exception ex)
            {
                //Logger.Error("SearchOrder() - Exception occurred : " + ex.ToString());
            }
            return StatusCode(500, standardResponse.GetInstance(responseStatus.Failed, ResponseMessage.Internal_Exception, null));
        }


    }
}
