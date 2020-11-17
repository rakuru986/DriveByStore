import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { passwordsMatchValidator } from 'src/app/helpers/passwordsMatchValidator'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],   
})

export class RegisterComponent implements OnInit {  

  registerForm: FormGroup;

  constructor(private builder: FormBuilder) { }

  ngOnInit() {   
    this.buildForm();
  }

  buildForm(){
    this.registerForm = this.builder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ''
    }, {
      validators: passwordsMatchValidator
    })
  }

  register(){
    console.log(this.registerForm)
  }
}
