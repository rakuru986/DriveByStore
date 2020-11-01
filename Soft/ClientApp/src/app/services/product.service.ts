import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/product.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  //TODO: Products from API
  products: Product[] = [
    new Product(1, 1, "audi a8", "audi", 92000, "assets/images/artur.jpeg", "uus audi a8 :)"),
    new Product(1, 2, "audi a7", "audi", 87000, "assets/images/artur.jpeg", "uus audi a7 :)"),
    new Product(6, 3, "STANLEY F10", "STANLEY", 20, "assets/images/artur.jpeg", "uhiuus STANLEY KRUVIKEERAJA F10"),
    new Product(6, 4, "STANLEY K18", "STANLEY", 30, "assets/images/artur.jpeg", "uhiuus STANLEY KRUVIKEERAJA F18"),
    new Product(2, 5, "Kawasaki Z400", "Kawasaki", 15000, "assets/images/artur.jpeg", "tutikas Kawasaki Z400 mootorratas :)"),
    new Product(2, 6, "Kawasaki KX450", "Kawasaki", 17000, "assets/images/artur.jpeg", "tutikas Kawasaki KX450 mootorratas =]"),
    new Product(3, 7, "Merida R3", "Merida", 800, "assets/images/artur.jpeg", "uus jalgratas Merida R3 :)"),
    new Product(3, 7, "Merida T7", "Merida", 700, "assets/images/artur.jpeg", "uus jalgratas Merida T7 =')"),
    new Product(4, 7, "Vans TH3", "Vans", 250, "assets/images/artur.jpeg", "uus Vans TH3 rula :)"),
    new Product(4, 7, "Vans TH5", "Vans", 370, "assets/images/artur.jpeg", "uus Vans TH5 rula = ("),
    new Product(5, 7, "BOLT T6UX", "Bolt", 690, "assets/images/artur.jpeg", "tänavalt varastatud bolti tõuks"),
    new Product(5, 7, "Razor 28T", "Razor", 370, "assets/images/artur.jpeg", "Razor 28T trikitõukeratas")
  ]

  constructor() { }

  getProducts(): Product[]{
    //TODO: Populate products from an API and return Observable
    return this.products
  }
  
}
