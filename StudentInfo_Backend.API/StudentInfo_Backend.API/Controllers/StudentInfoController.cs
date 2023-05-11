using Microsoft.AspNetCore.Mvc;
using StudentInfo_Backend.API.Database;
using StudentInfo_Backend.API.Models;

namespace StudentInfo_Backend.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        private readonly IStudentInfoDatabase _studentInfoDatabase;

        public StudentInfoController(IStudentInfoDatabase studentInfoDatabase)
        {
            _studentInfoDatabase = studentInfoDatabase;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudentInfo(StudentInfo studentInfoRequest)
        {
            AddNewStudentInfoResponse response = new AddNewStudentInfoResponse();

            try
            {
                response = await _studentInfoDatabase.AddNewStudentInfo(studentInfoRequest);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentInfo()
        {
            GetAllStudentInfoResponse response = new GetAllStudentInfoResponse();

            try
            {
                response = await _studentInfoDatabase.GetAllStudentInfo();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentInfoById([FromQuery] Guid Id)
        {
            StudentInfo response = new StudentInfo();

            try
            {
                response = await _studentInfoDatabase.GetStudentInfoById(Id);

                if (response == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentInfoById(StudentInfo updateStudentInfoRequest)
        {
            StudentInfo response = new StudentInfo();

            try
            {
                response = await _studentInfoDatabase.UpdateStudentInfoById(updateStudentInfoRequest);

                if (response == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentInfoById(Guid Id)
        {
            StudentInfo response = new StudentInfo();

            try
            {
                response = await _studentInfoDatabase.DeleteStudentInfoById(Id);

                if (response == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return Ok(response);
        }
    }
}
