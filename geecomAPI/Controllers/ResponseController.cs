using geecomAPI.businessInterface;
using geecomAPI.data;
using geecomAPI.dbUtilites;
using geecomAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace geecomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private Iresponse _iresponse;
        public ResponseController(Iresponse iresponse)
        {
            _iresponse = iresponse;
        }


        // GET: api/<ResponseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {


            DbHandler dbh = new DbHandler();
            dbh.OpenConnection();

            return new string[] { "value1", "value2"};
        }

        // GET api/<ResponseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ResponseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ResponseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ResponseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpPost]
        [Route("/api/AddNewResponse")]
        
        //[SwaggerOperation("AddNewClosingAgent")]
        //[SwaggerResponse(statusCode: 200, type: typeof(bool), description: "No error, operation successful")]
        //[Authorize]
        public virtual IActionResult AddNewResponse([FromBody] farmerQuestionResponse body)
        {
            try
            {
                bool status = false;
                status = _iresponse.SaveQuestionniorResponse(body);
                if (status)
                {
                    return StatusCode(200, standardResponse.GetInstance(responseStatus.Success, responseMessage.Add_Closing_Agent, loanStatus));
                }
                else
                    return StatusCode(200, standardResponse.GetInstance(responseStatus.Success, responseMessage.Add_Closing_Agent_Fail, null));
            }
            catch (Exception ex)
            {
                //Logger.Error("AddNewWiredAccount() - Exception occurred : " + ex.ToString());
            }
            return StatusCode(500, standardResponse.GetInstance(responseStatus.Failed, responseMessage.Internal_Exception, null));
        }

    }
}
