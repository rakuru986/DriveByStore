import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/product.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  //TODO: Products from API
  products: Product[] = [
    new Product(1, 1, "audi a8", "audi", 100, "assets/images/artur.jpeg", "uus audi a8 :)"),
    new Product(1, 2, "audi a7", "audi", 200, "assets/images/artur.jpeg", "uus audi a7 :)"),
    new Product(1, 3, "audi a6", "audi", 300, "assets/images/artur.jpeg", "uus audi a6 :)"),
    new Product(1, 4, "audi a5", "audi", 400, "assets/images/artur.jpeg", "uus audi a5 :)"),
    new Product(1, 5, "audi a4", "audi", 500, "assets/images/artur.jpeg", "uus audi a4 :)"),
    new Product(1, 6, "audi a3", "audi", 600, "assets/images/artur.jpeg", "uus audi a3 :)"),
    new Product(1, 7, "audi a2", "audi", 700, "assets/images/artur.jpeg", "uus audi a2 :)")
  ]

  constructor() { }

  getProducts(): Product[]{
    //TODO: Populate products from an API and return Observable
    return this.products
  }
}
