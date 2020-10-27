import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CarsComponent } from './cars/cars.component';
import { MotorcyclesComponent } from './motorcycles/motorcycles.component';
import { BicyclesComponent } from './bicycles/bicycles.component';
import { SkateboardsComponent } from './skateboards/skateboards.component';
import { ScootersComponent } from './scooters/scooters.component';
import { ToolsComponent } from './tools/tools.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { FooterComponent } from './shared/footer/footer.component';
import { CartComponent } from './shopping-cart/cart/cart.component';
import { FiltersComponent } from './shopping-cart/filters/filters.component';
import { ProductListComponent } from './shopping-cart/product-list/product-list.component';
import { CartItemComponent } from './shopping-cart/cart/cart-item/cart-item.component';
import { ProductItemComponent } from './shopping-cart/product-list/product-item/product-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
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
    ProductItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'cars', component: CarsComponent },
      { path: 'motorcycles', component: MotorcyclesComponent },
      { path: 'bicycles', component: BicyclesComponent },
      { path: 'skateboards', component: SkateboardsComponent },
      { path: 'scooters', component: ScootersComponent },
      { path: 'tools', component: ToolsComponent}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


