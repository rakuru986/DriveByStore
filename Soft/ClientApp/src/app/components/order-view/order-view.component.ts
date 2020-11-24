//import { Observable } from 'rxjs/Observable';
import { ActivatedRoute } from '@angular/router';
//import { OrderService } from 'src/app/services/order.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MessengerService } from 'src/app/services/messenger.service';
import { Product } from 'src/app/models/product.model';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.css']
})

export class OrderViewComponent implements OnInit {

  orderForm: FormGroup;

  orderProducts:any[]

  orderTotalPrice:number  

  constructor(private builder: FormBuilder, private msg: MessengerService, private orderService: OrderService) { }

  ngOnInit(): void {
    this.buildForm();
    // this.msg.getMsg().subscribe((productList: any)=>{
    //   this.orderProducts = productList;
    //   console.log(this.orderProducts);
    // })    
    this.orderProducts=this.msg.getProducts();
    this.orderTotalPrice=this.msg.getTotal();
    //console.log(this.orderProducts);
  } 

  

  buildForm(){
    this.orderForm = this.builder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      address: ['', [Validators.required]],
      city: ['', [Validators.required]],
      zip: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]]
    })
  }

  order(){
    console.log(this.orderProducts)
    console.log(this.orderForm.value)
    this.orderService.placeOrder(this.orderForm.value, this.orderProducts, this.orderTotalPrice)
  }

}
