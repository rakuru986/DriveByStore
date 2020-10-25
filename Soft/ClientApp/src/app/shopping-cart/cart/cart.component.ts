import { Component, OnInit} from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service'
import { Product } from 'src/app/models/product.model';

@Component({
    selector:'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit{    

    cartItems = [];

    cartTotal = 0

    constructor(private msg: MessengerService) { }

    ngOnInit(){
        this.msg.getMsg().subscribe((product: Product)=>{
            //console.log(product)
            this.addProductToCart(product)            
        })        
    }

    addProductToCart(product: Product){

        let productExists = false

        for (let i in this.cartItems) {
            if (this.cartItems[i].productId === product.id) {
              this.cartItems[i].qty++
              productExists = true
              break;
            }
          }

        if (!productExists) {
            this.cartItems.push({
                productId: product.id,
                productName: product.name,
                qty: 1,
                price: product.price
            })            
        } 
        this.calculateCartTotal(); 
    }    

    removeProductFromCart(product: Product){        
        
        for(let i in this.cartItems){
            if(this.cartItems.length === 1){
                if(this.cartItems[i].qty === 1){
                    this.cartItems = [];
                    break;
                }                
                ///console.log("sss")

                // if(this.cartItems[i].qty === 1){
                //     this.cartItems = [];
                //     break;
                // }       
                         
                // this.cartItems[i].qty--                
            }  
        }
        this.calculateCartTotal();               
    }

    calculateCartTotal(){
        this.cartTotal = 0;
         this.cartItems.forEach(item => {
             this.cartTotal += (item.qty * item.price)
         })
    }
}
