import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from 'src/app/components/pages/home/home.component';
import { AuthGuard } from 'src/app/helpers/auth.guard';
//import { PagesModule } from './components/pages/pages.module';

const accountModule = () => import('src/app/components/account/account.module').then(x => x.AccountModule);
//const usersModule = () => import('./users/users.module').then(x => x.UsersModule);
const pagesModule = () => import('./components/pages/pages.module').then(x=>x.PagesModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate:[AuthGuard] },
    //{ path: 'users', loadChildren: usersModule, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },
    { path: 'pages', loadChildren: pagesModule },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }