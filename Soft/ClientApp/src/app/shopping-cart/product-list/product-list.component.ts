import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service'
import { Product } from 'src/app/models/product.model'
import { Router } from '@angular/router';

@Component({
    selector:'app-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{

    productList: Product[] = []    

    
    constructor(private productService: ProductService, private router: Router) { }

    ngOnInit(){        
        this.productList = this.productService.getProducts()
        this.productList = this.filterListByRoute();
    }    

    filterListByRoute(){
        if (this.router.url === '/cars'){        
            return this.productList.filter(f=>f.productCategoryId === 1)
        }
        else if (this.router.url === '/motorcycles'){        
            return this.productList.filter(f=>f.productCategoryId === 2)
        }
        else if (this.router.url === '/bicycles'){        
            return this.productList.filter(f=>f.productCategoryId === 3)
        }
        else if (this.router.url === '/skateboards'){        
            return this.productList.filter(f=>f.productCategoryId === 4)
        }
        else if (this.router.url === '/scooters'){        
            return this.productList.filter(f=>f.productCategoryId === 5)
        }
        else{
            return this.productList.filter(f=>f.productCategoryId === 6)
        }
    }
}