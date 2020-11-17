import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private builder: FormBuilder) { }

  ngOnInit() {   
    this.buildForm();
  }

  buildForm(){
    this.loginForm = this.builder.group({      
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      remember: false
    })
  }

  login(){
    console.log(this.loginForm.value)
  }
}
