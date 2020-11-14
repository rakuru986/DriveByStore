import { Component } from '@angular/core';

import { ProductService } from 'src/app/services/product.service';
import { AccountService } from 'src/app/services/account.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  user: User;

  constructor(private productService: ProductService, private accountservice: AccountService) {
    this.accountservice.user.subscribe(x=>this.user = x);

  }
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }  

  logout(){
    this.accountservice.logout();
  }
}
