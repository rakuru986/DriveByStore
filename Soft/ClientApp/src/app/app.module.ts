import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
//import { AppRoutingModule } from './app-routing.module'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CarsComponent } from './pages/cars/cars.component';
import { MotorcyclesComponent } from './pages/motorcycles/motorcycles.component';
import { BicyclesComponent } from './pages/bicycles/bicycles.component';
import { SkateboardsComponent } from './pages/skateboards/skateboards.component';
import { ScootersComponent } from './pages/scooters/scooters.component';
import { ToolsComponent } from './pages/tools/tools.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { FooterComponent } from './shared/footer/footer.component';
import { CartComponent } from './shopping-cart/cart/cart.component';
import { FiltersComponent } from './shopping-cart/filters/filters.component';
import { ProductListComponent } from './shopping-cart/product-list/product-list.component';
import { CartItemComponent } from './shopping-cart/cart/cart-item/cart-item.component';
import { ProductItemComponent } from './shopping-cart/product-list/product-item/product-item.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';


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
    ProductItemComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'cars', component: CarsComponent },
      { path: 'motorcycles', component: MotorcyclesComponent },
      { path: 'bicycles', component: BicyclesComponent },
      { path: 'skateboards', component: SkateboardsComponent },
      { path: 'scooters', component: ScootersComponent },
      { path: 'tools', component: ToolsComponent},

    ])
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


