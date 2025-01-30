import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { AppRoute, getRoutePath } from '../app.routes';
import { AuthService } from '../services/auth.service';

export const authGuard = (route: ActivatedRouteSnapshot) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const isAuthenticated = authService.isAuthenticated();
  const routePath = route.routeConfig?.path;

  const isProtectedRoute =
    routePath && Object.values(AppRoute).includes(routePath as AppRoute);

  if (isAuthenticated) {
    if (routePath === AppRoute.login || routePath === AppRoute.registration) {
      return router.parseUrl(getRoutePath(AppRoute.profile));
    }
    return true;
  }

  if (isProtectedRoute) {
    return router.parseUrl(getRoutePath(AppRoute.login));
  }

  return true;
};
