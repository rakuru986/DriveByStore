import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service'


@Component({ templateUrl: 'cars.component.html' })
export class CarsComponent implements OnInit{

    ngOnInit(){
        
    }
    /*car1: Products = {
        id: 1,
        productType: 1,
        name: "Audi A8",
        manufactorer: "Audi",
        price: 12000,
        image: "assets/images/artur.jpeg",
        description: "Heas töökorras 2008a Audi A8 v12 turbomootoriga."
    }
    car2: Products = {
        id: 2,
        productType: 1,
        name: "Škoda Superb",
        manufactorer: "Škoda",
        price: 8000,
        image: "assets/images/kristen.jpg",
        description: "Avariiline 2014a Škoda Superb 1.2 bensiinimootoriga."
    }
    car3: Products = {
        id: 3,
        productType: 1,
        name: "Citröen C4",
        manufactorer: "Citröen",
        price: 69000,
        image: "assets/images/kuru.jpg",
        description: "Suurepärases korras 2008a Citröen C4 2.0 220kw neljasilindrise turbomootoriga. Eelmine omanik Sebastian Loeb."
    }  
    cars: any = [this.car1, this.car2, this.car3];
    */
}


