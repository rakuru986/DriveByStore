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
            this.addProductToCart(product)                                    
        })        
    }    

    removeProductFromCart(product, index){        
        for ( let i in this.cartItems) {            
            if ( this.cartItems[i] === product)
             {
                if ( product.qty > 1){ 
                    this.cartItems[i].qty--
                }
                else if (product.qty === 1){
                    this.cartItems[i].qty--
                    this.cartItems.splice(index, 1)                    
                }
            }
        }
        this.calculateCartTotal();
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
    
    calculateCartTotal(){
        this.cartTotal = 0;
         this.cartItems.forEach(item => {
             this.cartTotal += (item.qty * item.price)
         })
    }
}
