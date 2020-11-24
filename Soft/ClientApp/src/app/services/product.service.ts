import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetProducts, Product } from 'src/app/models/product.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  //TODO: Products from API
  products: Product[] = [];

  url: string = "https://localhost:44352/product/GetAllProducts";

  constructor(private http: HttpClient) {}

  async fetchProducts() {
    return await this.http.get<GetProducts>(this.url, {observe: "response"})
      .toPromise()
      .then((response) => {
        this.saveProductData(response.body.value);
      })
      .catch((err) => console.log("Error: " + err));
  }

  saveProductData(httpValue) {
    this.products = [];
    httpValue.forEach(item => {
      this.products.push(item.data);
    });
  }

  getProducts() {
    return this.products;
  }
}
