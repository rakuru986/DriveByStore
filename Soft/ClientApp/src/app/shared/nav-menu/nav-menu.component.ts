import { Component } from '@angular/core';

import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  user: User;

  constructor(private accountService: AccountService){
    this.accountService.user.subscribe(x => this.user = x);
  }

  logout() {
    this.accountService.logout();
}
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }  
}
