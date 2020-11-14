import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { AccountService } from 'src/app/services/account.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

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
    this.loginForm = this.builder.group({      
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      remember: false
    })
  }

  login(){
    //this.submitted = true;

        // reset alerts on submit
        //this.alertService.clear();

        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }

        //this.loading = true;
        this.accountService.login(this.loginForm.controls.email.value, this.loginForm.controls.password.value)
            .pipe(first())
            .subscribe({
                next: () => {
                    // get return url from query parameters or default to home page
                    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
                    this.router.navigateByUrl(returnUrl);
                },
                error: error => {
                    // this.alertService.error(error);
                    // this.loading = false;
                }
            });
  }
}
