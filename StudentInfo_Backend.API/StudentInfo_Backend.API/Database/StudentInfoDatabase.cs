using MongoDB.Driver;
using StudentInfo_Backend.API.Models;

namespace StudentInfo_Backend.API.Database
{
    public class StudentInfoDatabase : IStudentInfoDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<StudentInfo> _mongoCollection;

        public StudentInfoDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var _database = _mongoClient.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);
            _mongoCollection = _database.GetCollection<StudentInfo>(_configuration["DatabaseSettings:CollectionName"]);
        }

        public async Task<AddNewStudentInfoResponse> AddNewStudentInfo(StudentInfo studentInfoRequest)
        {
            AddNewStudentInfoResponse response = new AddNewStudentInfoResponse();
            response.IsSuccessful = true;
            response.Message = "Information successfully stored.";

            try
            {
                studentInfoRequest.Id = Guid.NewGuid();

                await _mongoCollection.InsertOneAsync(studentInfoRequest);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<GetAllStudentInfoResponse> GetAllStudentInfo()
        {
            GetAllStudentInfoResponse response = new GetAllStudentInfoResponse();
            response.IsSuccessful = true;
            response.Message = "Data Retrived Successfully";

            try
            {
                response.Students = new List<StudentInfo>();
                response.Students = await _mongoCollection.Find(x => true).ToListAsync();
                if (response.Students.Count == 0)
                {
                    response.Message = "No Data was Found!!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<StudentInfo> GetStudentInfoById(Guid Id)
        {
            StudentInfo studentInfo = new StudentInfo();
            try
            {
                studentInfo = await _mongoCollection.Find(x => (x.Id == Id)).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return studentInfo;
        }

        public async Task<StudentInfo> UpdateStudentInfoById(StudentInfo updateStudentInfoRequest)
        {
            StudentInfo updatedStudentInfoResponse = new StudentInfo();
            try
            {
                updatedStudentInfoResponse = await GetStudentInfoById(updateStudentInfoRequest.Id);

                await _mongoCollection.ReplaceOneAsync(x => (x.Id == updateStudentInfoRequest.Id),
                    updateStudentInfoRequest);
                updatedStudentInfoResponse.Name = updateStudentInfoRequest.Name;
                updatedStudentInfoResponse.Department = updateStudentInfoRequest.Department;
                updatedStudentInfoResponse.Email = updateStudentInfoRequest.Email;
                updatedStudentInfoResponse.Phone = updateStudentInfoRequest.Phone;
                updatedStudentInfoResponse.Income = updateStudentInfoRequest.Income;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return updatedStudentInfoResponse;
        }

        public async Task<StudentInfo> DeleteStudentInfoById(Guid Id)
        {
            StudentInfo response = new StudentInfo();
            try
            {
                response = await GetStudentInfoById(Id);
                await _mongoCollection.DeleteOneAsync(x => x.Id == response.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return response;
        }
    }
}
