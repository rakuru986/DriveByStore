import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { ErrorInterceptor } from 'src/app/helpers/error.interceptor';
import { JwtInterceptor } from 'src/app/helpers/jwt.interceptor';

//import { fakeBackendProvider } from 'src/app/helpers/fake-backend';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { HomeComponent } from './components/pages/home/home.component';
import { CarsComponent } from './components/pages/cars/cars.component';
import { MotorcyclesComponent } from './components/pages/motorcycles/motorcycles.component';
import { BicyclesComponent } from './components/pages/bicycles/bicycles.component';
import { SkateboardsComponent } from './components/pages/skateboards/skateboards.component';
import { ScootersComponent } from './components/pages/scooters/scooters.component';
import { ToolsComponent } from './components/pages/tools/tools.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { FooterComponent } from './shared/footer/footer.component';
import { CartComponent } from './components/shopping-cart/cart/cart.component';
import { FiltersComponent } from './components/shopping-cart/filters/filters.component';
import { ProductListComponent } from './components/shopping-cart/product-list/product-list.component';
import { CartItemComponent } from './components/shopping-cart/cart/cart-item/cart-item.component';
import { ProductItemComponent } from './components/shopping-cart/product-list/product-item/product-item.component';
//import { LoginComponent } from './account/login/login.component';
//import { RegisterComponent } from './account/register/register.component';
import { AlertComponent } from './components/alert/alert.component';

import { AddEditComponent } from './users/add-edit/add-edit.component';
import { ListComponent } from './users/list/list.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
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
    //LoginComponent,
    //RegisterComponent,
    AlertComponent,    
    // AddEditComponent,
    // ListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'register', component: RegisterComponent },
      //{ path: 'login', component: LoginComponent },
      { path: 'cars', component: CarsComponent },
      { path: 'motorcycles', component: MotorcyclesComponent },
      { path: 'bicycles', component: BicyclesComponent },
      { path: 'skateboards', component: SkateboardsComponent },
      { path: 'scooters', component: ScootersComponent },
      { path: 'tools', component: ToolsComponent},

    ])
  ],
  providers: [
      { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

      // provider used to create fake backend
      // fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


