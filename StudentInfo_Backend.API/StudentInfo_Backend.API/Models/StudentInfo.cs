using MongoDB.Bson;

namespace StudentInfo_Backend.API.Models
{
    public class StudentInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public long Income { get; set; }

    }

    public class AddNewStudentInfoResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }

    public class GetAllStudentInfoResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public List<StudentInfo> Students { get; set; }
    }
}