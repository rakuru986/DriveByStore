import { Injectable } from '@angular/core';
import { Subject } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  subject = new Subject()

  products:[]

  totalPrice:number

  setProducts(productsList){
    this.products=productsList
  }

  getProducts(){
    return this.products;
  }

  setTotal(total){
    this.totalPrice = total
  }

  getTotal(){
    return this.totalPrice;
  }

  constructor() { }

  sendMsg(product){
    //console.log(product)
    this.subject.next(product) //triggering an event
  }

  getMsg(){
    return this.subject.asObservable() 
  }
}
