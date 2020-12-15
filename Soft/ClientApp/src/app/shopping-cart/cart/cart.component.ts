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
        if(localStorage.getItem('product') === null)
        {
          this.localStorageService.set('product', [])
        }
        this.cartItems = this.localStorageService.get('product')
        this.calculateCartTotal();
        
        this.msg.getMsg().subscribe((product: Product)=>{            
            this.addProductToCart(product)                                    
        })

        // this.msg.getRemoveMsg().subscribe((product: Product)=>{
        //   this.addProductBackToStock(product)
        // })   
    }   
    
    // addProductBackToStock(product: Product){
    //   product.stock += 1;
    // }

    removeProductFromCart(product, index){

      this.msg.sendRemoveMsg(product);      

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
