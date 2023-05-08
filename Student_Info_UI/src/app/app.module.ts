import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentsListComponent } from './students-list/students-list.component';
import {HttpClientModule} from "@angular/common/http";
import { AddStudentComponent } from './add-student/add-student.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { EditStudentComponent } from './edit-student/edit-student.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentsListComponent,
    AddStudentComponent,
    EditStudentComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
