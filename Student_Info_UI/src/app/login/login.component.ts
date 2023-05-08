import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  loginFrom !: FormGroup;

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.loginFrom = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

}
