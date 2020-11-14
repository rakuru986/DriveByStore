import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
//import { AuthGuard } from 'src/app/helpers/auth.guard';
import { BicyclesComponent } from './bicycles/bicycles.component';
import { CarsComponent } from './cars/cars.component';
import { HomeComponent } from './home/home.component';
import { MotorcyclesComponent } from './motorcycles';
import { ScootersComponent } from './scooters/scooters.component';
import { SkateboardsComponent } from './skateboards/skateboards.component';
import { ToolsComponent } from './tools/tools.component';
import { ShoppingCartComponent } from 'src/app/shopping-cart/shopping-cart.component';
import { FooterComponent } from 'src/app/shared/footer/footer.component';
import { CartComponent } from 'src/app/shopping-cart/cart/cart.component';
import { FiltersComponent } from 'src/app/shopping-cart/filters/filters.component';
import { ProductListComponent } from 'src/app/shopping-cart/product-list/product-list.component';
import { CartItemComponent } from 'src/app/shopping-cart/cart/cart-item/cart-item.component';
import { ProductItemComponent } from 'src/app/shopping-cart/product-list/product-item/product-item.component';


@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        PagesRoutingModule,
        
    ],
    declarations: [
        HomeComponent,
        CarsComponent,
        MotorcyclesComponent,
        BicyclesComponent,
        SkateboardsComponent,
        ScootersComponent,
        ToolsComponent,
        ShoppingCartComponent,
        FooterComponent,
        CartComponent,
        FiltersComponent,
        ProductListComponent,
        CartItemComponent,
        ProductItemComponent,
    ]
})
export class PagesModule { }