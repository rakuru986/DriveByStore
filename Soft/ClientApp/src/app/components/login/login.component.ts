import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private builder: FormBuilder, private accountService: AccountService) { }

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
    this.accountService.login(this.loginForm.controls.email.value, this.loginForm.controls.password.value);
  }  
}
