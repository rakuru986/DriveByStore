import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';

import { AccountService } from 'src/app/services/account.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  user: User;
  title = 'app';

  constructor(private productService: ProductService, private accountService: AccountService) {

    this.accountService.user.subscribe(x=>this.user=x);
  }

  ngOnInit() {
    this.productService.fetchProducts();
  }

  logout(){
    this.accountService.logout();
  }

}
