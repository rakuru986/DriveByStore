import { Component, OnInit } from "@angular/core";
import { ProductService } from "src/app/services/product.service";
import { Product } from "src/app/models/product.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-product-list",
  templateUrl: "./product-list.component.html",
  styleUrls: ["./product-list.component.css"],
})
export class ProductListComponent implements OnInit {
  productList: Product[] = [];

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.productService.fetchProducts();
    this.productList = this.productService.getProducts();
    this.productList = this.filterListByRoute();
    console.log(this.productList);
  }

  filterListByRoute() {
    if (this.router.url === "/cars") {
      return this.productList.filter((f) => f.productCategory.name === "Cars");
    } else if (this.router.url === "/motorcycles") {
      return this.productList.filter((f) => f.productCategory.name === "Motorcycles");
    } else if (this.router.url === "/bicycles") {
      return this.productList.filter((f) => f.productCategory.name === "Bicycles");
    } else if (this.router.url === "/skateboards") {
      return this.productList.filter((f) => f.productCategory.name === "Skateboards");
    } else if (this.router.url === "/scooters") {
      return this.productList.filter((f) => f.productCategory.name === "Scooters");
    } else {
      return this.productList.filter((f) => f.productCategory.name === "Tools");
    }
  }
}
