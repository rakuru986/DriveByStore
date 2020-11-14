import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/helpers/auth.guard';

import { BicyclesComponent } from './bicycles/bicycles.component';
import { CarsComponent } from './cars/cars.component';
import { HomeComponent } from './home/home.component';
import { MotorcyclesComponent } from './motorcycles';
import { ScootersComponent } from './scooters/scooters.component';
import { SkateboardsComponent } from './skateboards/skateboards.component';
import { ToolsComponent } from './tools/tools.component';

const routes: Routes = [
    {
        path: '', component: HomeComponent,        
        children: [                  
            { path: 'cars', component: CarsComponent, canActivate:[AuthGuard] },
            { path: 'motorcycles', component: MotorcyclesComponent, canActivate:[AuthGuard]},
            { path: 'bicycles', component: BicyclesComponent, canActivate:[AuthGuard]},
            { path: 'skateboards', component: SkateboardsComponent, canActivate:[AuthGuard]},
            { path: 'scooters', component: ScootersComponent, canActivate:[AuthGuard]},
            { path: 'tools', component: ToolsComponent, canActivate:[AuthGuard]},
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule { }