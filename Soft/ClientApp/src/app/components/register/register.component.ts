import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],   
})

export class RegisterComponent implements OnInit {

  model: any 

  constructor() { }

  ngOnInit() {
  }

  register(){    
    //console.log(this.model)
    this.modelList.push(this.model)
    console.log(this.modelList)
  }

  modelList: any [] = []

}
