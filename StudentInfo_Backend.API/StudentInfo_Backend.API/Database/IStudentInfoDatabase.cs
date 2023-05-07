using StudentInfo_Backend.API.Models;

namespace StudentInfo_Backend.API.Database
{
    public interface IStudentInfoDatabase
    {
        public Task<AddNewStudentInfoResponse> AddNewStudentInfo(StudentInfo studentInfoRequest);
        public Task<GetAllStudentInfoResponse> GetAllStudentInfo();
        public Task<StudentInfo> GetStudentInfoById(Guid Id);
        public Task<StudentInfo> UpdateStudentInfoById(StudentInfo updateStudentInfoRequest);
        public Task<StudentInfo> DeleteStudentInfoById(Guid Id);
    }
}
