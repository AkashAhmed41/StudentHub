import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StudentsService} from "../students.service";
import {Student} from "../student.model";

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit{

  updatedStudentInfo: Student = {
    id: '',
    name: '',
    email: '',
    phone: '',
    department: '',
    income: 0
  }

  constructor(private route: ActivatedRoute,
              private studentsService: StudentsService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id){
          this.studentsService.getStudentInfoById(id).subscribe({
            next: (response) => {
              this.updatedStudentInfo = response;
            }
          });
        }
      }
    })
  }

  updateStudentInfo() {
    this.studentsService.updateStudentInfo(this.updatedStudentInfo).subscribe({
      next: (response) => {
        console.log(response);
        this.router.navigate(['students']);
      }
    });
  }

  deleteStudentInfo(id: string) {
    this.studentsService.deleteStudentInfoById(id).subscribe({
      next: (response) => {
        this.router.navigate(['students']);
      }
    })
  }
}
