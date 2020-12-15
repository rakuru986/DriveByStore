import { isPlatformWorkerApp } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { MessengerService } from 'src/app/services/messenger.service'

@Component({
    selector:'app-product-item',
    templateUrl: './product-item.component.html',
    styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit{

    @Input() productItem: Product

    constructor(private msg: MessengerService) { }

    enoughStock: boolean = true;

    ngOnInit() { 
        
    }   

    handleAddToCart(){
        this.productItem.stock -= 1;
        if(this.productItem.stock > -1){
            if(this.productItem.stock === 0){
                this.enoughStock = false;
                this.msg.sendMsg(this.productItem);
            }
            else{
                this.enoughStock = true;
                this.msg.sendMsg(this.productItem);
            }            
        }        
    }
}
