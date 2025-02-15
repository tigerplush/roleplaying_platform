import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { canActivateAuthRole } from './auth.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [canActivateAuthRole],
        data: { role: 'default-roles-corgi' }
    },
    {
        path: 'forbidden',
        component: ForbiddenComponent
    },
    {
        path: '**',
        component: NotFoundComponent
    }
];
