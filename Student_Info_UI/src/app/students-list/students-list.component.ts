import {Component, OnInit} from '@angular/core';
import {Student} from "../student.model";
import {StudentsService} from "../students.service";

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit{

  students: Student[] = [];

  constructor(private studentsService: StudentsService) {
  }

  ngOnInit(): void {
    this.studentsService.getAllStudentInfo().subscribe({
      next: (students) => {
        // @ts-ignore
        this.students = students.students;
      },
      error: (response) => {
        console.log(response);
      }
    });

  }

}
