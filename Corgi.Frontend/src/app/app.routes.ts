import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { canActivateAuthRole } from './guards/auth.guard';
import { TemplateComponent } from './components/template/template.component';
import { TemplateOverviewComponent } from './components/template-overview/template-overview.component';
import { AfterLoginComponent } from './components/after-login/after-login.component';
import { CharacterOverviewComponent } from './components/character-overview/character-overview.component';
import { CharacterComponent } from './components/character/character.component';

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
        path: 'after-login',
        component: AfterLoginComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [canActivateAuthRole],
        data: { role: 'default-roles-corgi' }
    },
    {
        path: 'characters',
        component: CharacterOverviewComponent,
        canActivate: [canActivateAuthRole],
        data: { role: 'default-roles-corgi' }
    },
    {
        path: 'characters/:id',
        component: CharacterComponent,
        canActivate: [canActivateAuthRole],
        data: { role: 'default-roles-corgi' }
    },
    {
        path: 'templates',
        component: TemplateOverviewComponent,
        canActivate: [canActivateAuthRole],
        data: { role: 'default-roles-corgi' }
    },
    {
        path: 'templates/:id',
        component: TemplateComponent,
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
