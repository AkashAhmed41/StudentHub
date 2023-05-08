import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Student} from "./student.model";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  private readonly baseUrl = "https://localhost:7293";

  constructor(private http: HttpClient) { }

  getAllStudentInfo(): Observable<Student[]> {
     return this.http.get<Student[]>(this.baseUrl+'/api/StudentInfo/GetAllStudentInfo');
  }

  addNewStudent(addStudentRequest: Student): Observable<Student>{
    addStudentRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Student>(this.baseUrl+'/api/StudentInfo/AddNewStudentInfo', addStudentRequest);
  }

  getStudentInfoById(id: string): Observable<Student>{
    return this.http.get<Student>(this.baseUrl+'/api/StudentInfo/GetStudentInfoById?Id=' + id);
  }

  updateStudentInfo(updateStudentInfoRequest: Student): Observable<Student>{
    return this.http.put<Student>(this.baseUrl+'/api/StudentInfo/UpdateStudentInfoById', updateStudentInfoRequest);
  }

  deleteStudentInfoById(id: string): Observable<Student> {
    return this.http.delete<Student>(this.baseUrl+'/api/StudentInfo/DeleteStudentInfoById?Id=' + id);
  }

}
