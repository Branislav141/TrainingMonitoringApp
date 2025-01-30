import { Router, Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

export enum AppRoute {
  profile = 'dashboard',
  login = 'login',
  registration = 'register',
}

export const protectedRoutes: Routes = [
  {
    path: AppRoute.profile,
    component: DashboardComponent,
    canActivate: [authGuard],
  },
];

export const unprotectedRoutes: Routes = [
  { path: AppRoute.login, component: LoginComponent },
  { path: AppRoute.registration, component: RegisterComponent },
];

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  ...protectedRoutes,
  ...unprotectedRoutes,
];

export function getRoutePath(route: AppRoute): string {
  return `/${route}`;
}

export function navigateTo(route: AppRoute, router: Router): void {
  router.navigate([route]);
}
