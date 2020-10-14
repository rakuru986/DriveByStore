import { Component } from '@angular/core';
import { IProducts } from '../app.component';

@Component({ templateUrl: 'cars.component.html' })
export class CarsComponent {}


var Cars  = [car1, car2, car3];

var car1:IProducts ={
    name: "Audi A8",
    manufactorer: "Audi",
    price: 12000,
    picture: "sss",
    description: "Heas töökorras 2008a Audi A8 v12 turbomootoriga."
}  
var car2:IProducts ={
    name: "Škoda Superb",
    manufactorer: "Škoda",
    price: 8000,
    picture: "ddd",
    description: "Avariiline 2014a Škoda Superb 1.2 bensiinimootoriga."
}  
var car3:IProducts ={
    name: "Citröen C4",
    manufactorer: "Citröen",
    price: 69000,
    picture: "aaa",
    description: "Suurepärases korras 2008a Citröen C4 2.0 220kw neljasilindrise turbomootoriga. Eelmine omanik Sebastian Loeb."
}  

