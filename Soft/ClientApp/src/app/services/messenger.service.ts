import { Injectable } from '@angular/core';
import { Subject } from 'rxjs'
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  subject = new Subject()

  removedSubject = new Subject()

  products:[]

  totalPrice:number

  removedProducts = []

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

  sendRemoveMsg(product){
    // this.removedProducts = []
    // this.removedProducts.push(product);
    this.removedSubject.next(product);
  }

  getRemoveMsg(){
    return this.removedSubject.asObservable()
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
