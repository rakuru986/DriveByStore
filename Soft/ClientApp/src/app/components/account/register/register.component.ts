import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { passwordsMatchValidator } from 'src/app/helpers/passwordsMatchValidator'
import { AccountService } from 'src/app/services/account.service';
import { first } from 'rxjs/operators';
//import { AlertService } from 'src/app/services/alert.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],   
})

export class RegisterComponent implements OnInit {  

  registerForm: FormGroup;
  //loading = false;
  //submitted = false;

  constructor(
    private builder: FormBuilder,    
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    //private alertService: AlertService
    ) { }

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

        // reset alerts on submit
        //this.alertService.clear();

        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }
        console.log(this.registerForm.value);
        //this.loading = true;
        this.accountService.register(this.registerForm.value)
            .pipe(first())
            .subscribe({
                next: () => {
                    //this.alertService.success('Registration successful', { keepAfterRouteChange: true });
                    this.router.navigate(['../login'], { relativeTo: this.route });
                },
                error: error => {
                    //this.alertService.error(error);
                    //this.loading = false;
                }
            });
  }
}
