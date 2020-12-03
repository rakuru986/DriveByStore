import { Component, OnInit} from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service'
import { Product } from 'src/app/models/product.model';
import { LocalStorageService } from 'src/app/services/localStorage.service';

@Component({
    selector:'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit{    

    cartItems = []
    
    cartTotal = 0

    constructor(private msg: MessengerService, private localStorageService: LocalStorageService) { }


    

    ngOnInit(){

        this.cartItems = this.localStorageService.get('product')
        this.msg.getMsg().subscribe((product: Product)=>{            
            this.addProductToCart(product)                                    
        })
        
    }    

    // persist(key: string, value: any)
    // {
    //     this.localStorageService.set(key, value);
    // }

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
                this.localStorageService.remove('product', this.cartItems);
            }
        }
        this.calculateCartTotal();
    }

    addProductToCart(product: Product) {

      let productExists = false;

        for (let i in this.cartItems) {
            if (this.cartItems[i].productId === product.id) {
              this.cartItems[i].qty++;
              productExists = true;
              break;
            }
          }

        if (!productExists) {
          this.cartItems.push({
            productId: product.id,
            productName: product.name,
            qty: 1,
            price: product.price
          });
          this.localStorageService.set('product', this.cartItems);
        } 
        this.calculateCartTotal(); 
    }    
    
    calculateCartTotal(){
        this.cartTotal = 0;
        this.cartItems.forEach(item => {
          this.cartTotal += (item.qty * item.price);
        });
    }

    handleOrder(){
        // this.msg.sendMsg(this.cartItems)
        this.msg.setProducts(this.cartItems);
        this.msg.setTotal(this.cartTotal);
    }
}
