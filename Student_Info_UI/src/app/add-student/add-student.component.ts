import {Component, OnInit} from '@angular/core';
import {Student} from "../student.model";
import {StudentsService} from "../students.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit{

  addStudentRequest: Student = {
    id: '',
    name: '',
    email: '',
    phone: '',
    department: '',
    income: 0

  }

  constructor( private studentsService: StudentsService,
               private router: Router) {
  }

  ngOnInit(): void {
  }

  addNewStudent() {
    this.studentsService.addNewStudent(this.addStudentRequest).subscribe({
      next: () => {
        this.router.navigate(['students']);
      }
    });
  }
}
