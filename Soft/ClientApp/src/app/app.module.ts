import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from 'src/app/app-routing.module'


import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
// import { HomeComponent } from './components/pages/home/home.component';
// import { CarsComponent } from './components/pages/cars/cars.component';
// import { MotorcyclesComponent } from './components/pages/motorcycles/motorcycles.component';
// import { BicyclesComponent } from './components/pages/bicycles/bicycles.component';
// import { SkateboardsComponent } from './components/pages/skateboards/skateboards.component';
// import { ScootersComponent } from './components/pages/scooters/scooters.component';
// import { ToolsComponent } from './components/pages/tools/tools.component';
//import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { FooterComponent } from './shared/footer/footer.component';
import { CartComponent } from './shopping-cart/cart/cart.component';
import { FiltersComponent } from './shopping-cart/filters/filters.component';
import { ProductListComponent } from './shopping-cart/product-list/product-list.component';
import { CartItemComponent } from './shopping-cart/cart/cart-item/cart-item.component';
import { ProductItemComponent } from './shopping-cart/product-list/product-item/product-item.component';
// import { LoginComponent } from './components/account/login/login.component';
// import { RegisterComponent } from './components/account/register/register.component';

import { fakeBackendProvider } from 'src/app/helpers/fake-backend';
import { AuthGuard } from 'src/app/helpers/auth.guard'


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    // HomeComponent,
    // CarsComponent,
    // MotorcyclesComponent,
    // BicyclesComponent,
    // SkateboardsComponent,
    // ScootersComponent,
    // ToolsComponent,
    //ShoppingCartComponent,
    // FooterComponent,
    // CartComponent,
    // FiltersComponent,
    // ProductListComponent,
    // CartItemComponent,
    // ProductItemComponent,
    // LoginComponent,
    // RegisterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    // RouterModule.forRoot([
    //   { path: '', component: HomeComponent, pathMatch: 'full' },
    //   //{ path: 'users', component: RegisterComponent },
    //   //{ path: 'users', component: LoginComponent },
    //   { path: 'cars', component: CarsComponent, canActivate: [AuthGuard] },
    //   { path: 'motorcycls', component: MotorcyclesComponent, canActivate: [AuthGuard] },
    //   { path: 'bicycles', component: BicyclesComponent, canActivate: [AuthGuard] },
    //   { path: 'skateboards', component: SkateboardsComponent, canActivate: [AuthGuard] },
    //   { path: 'scooters', component: ScootersComponent, canActivate: [AuthGuard] },
    //   { path: 'tools', component: ToolsComponent,canActivate: [AuthGuard]},

    // ])
  ],
  providers: [
    fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


