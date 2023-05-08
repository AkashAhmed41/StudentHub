import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {StudentsListComponent} from "./students-list/students-list.component";
import {AddStudentComponent} from "./add-student/add-student.component";
import {EditStudentComponent} from "./edit-student/edit-student.component";
import {LoginComponent} from "./login/login.component";
import {RegisterComponent} from "./register/register.component";

const routes: Routes = [
  { path: '', component: StudentsListComponent},
  { path: 'students', component: StudentsListComponent},
  { path: 'students/add', component: AddStudentComponent},
  { path: 'students/edit/:id', component: EditStudentComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
