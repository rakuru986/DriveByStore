import { Component, OnInit, Input} from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service'
import { Product } from 'src/app/models/product.model';

@Component({
    selector:'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit{    

    //@Input() productItem: Product

    cartItems = [];

    cartTotal = 0

    constructor(private msg: MessengerService) { }

    ngOnInit(){
        this.msg.getMsg().subscribe((product: Product)=>{
            //console.log(product)
            this.addProductToCart(product)                                    
        })        
    }    

    handleRemoveProductFromCart(product: Product){
        //this.msg.sendMsg(this.productItem)

        let index = this.cartItems.indexOf(product, 0)

        this.cartItems.slice(index,1)
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
        
        // for(let i in this.cartItems){
        //     if(this.cartItems.length === 1){
        //         if(this.cartItems[i].qty === 1){
        //             this.cartItems = [];
        //             break;
        //         }    
                //this.cartItems.find(x=>x.productId == i).p
                

            let index = this.cartItems.indexOf(product.id, 0)

            this.cartItems.slice(index,1)
                ///console.log("sss")

                // if(this.cartItems[i].qty === 1){
                //     this.cartItems = [];
                //     break;
                // }       
                         
                // this.cartItems[i].qty--                
        //     }  
        // }
        this.calculateCartTotal();               
    }

    calculateCartTotal(){
        this.cartTotal = 0;
         this.cartItems.forEach(item => {
             this.cartTotal += (item.qty * item.price)
         })
    }
}
