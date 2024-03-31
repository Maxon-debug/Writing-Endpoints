using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using TraineeMaxon.Model;

namespace TraineeMaxon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private ResponseDto _response;

        public TraineeController()
        {
            _response = new ResponseDto();
        }
       // Adding Static Trainee
        private static List<Trainee> trainees = new List<Trainee>()
        {
             new Trainee()
        {
            Name = "Maxon",
            Email = "maxon678841@gmail.com",
            PhoneNumber = "1234567890"

        },
             new Trainee()
             {
                 Name = "Wanjeru",
                 Email = "maxon3940@gmail.com",
                 PhoneNumber ="07380384894"

             }
        };
        
        [HttpGet]
        //Using the get mwthod to retrive the All trainees
         public ActionResult<ResponseDto>getAllTrainees()
        {
            _response.Result = trainees;
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpGet("guid")]
        public ActionResult<ResponseDto>getTrainee(Guid guid)
        {
            var trainee =trainees.Find(x=>x.Id == guid);
            if(trainee == null)
            {
                _response.Result = "trainee not found";
                _response.StatusCode=System.Net.HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            else
            {
                return Ok(_response);
            }

        }
        [HttpPost]
        public ActionResult<ResponseDto>addTrainee(AddTraineeDto newTrainee)
        {
            var newTraine = new Trainee()
            {
                Name = newTrainee.Name,
                Email = newTrainee.Email,
                PhoneNumber = newTrainee.PhoneNumber,
            };
            trainees.Add(newTraine);
            return Created($"api/trainee/(newTraine.Id)", _response);
        }
        [HttpDelete("guid")]
        public ActionResult<ResponseDto> DeleteTrainee(Guid guid)
        {
            var trainee = trainees.Find(x => x.Id == guid);
            if (trainee != null)
            {
                trainees.Remove(trainee);
               
                return NotFound(_response);
            }
            else
            {
                return NotFound(_response);
            }
            
        }
    }
}
