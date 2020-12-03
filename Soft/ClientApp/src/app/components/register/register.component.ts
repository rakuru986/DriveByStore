import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { AccountService } from 'src/app/services/account.service'

import { passwordsMatchValidator } from 'src/app/helpers/passwordsMatchValidator'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],   
})

export class RegisterComponent implements OnInit {  

  registerForm: FormGroup;  

  constructor(private builder: FormBuilder, private accountService: AccountService) { }

  ngOnInit() {   
    this.buildForm();
  }

  buildForm(){
    this.registerForm = this.builder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber:['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ''
    }, {
      validators: passwordsMatchValidator
    })    
  }

  register(){
    this.accountService.register(this.registerForm.value)
  }

}
