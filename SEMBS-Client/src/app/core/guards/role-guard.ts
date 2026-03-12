import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from "@angular/router"; // Fix: Import from @angular/router
import { AuthService } from "../services/auth-service";

@Injectable({ providedIn: 'root' })
export class RoleGuard implements CanActivate {

  constructor(private auth: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const allowedRoles = route.data['roles'] as Array<string>;
    const userRole = this.auth.getRole();

    // 1. Check if the user is logged in first
    if (!this.auth.isLoggedIn()) {
      this.router.navigate(['/login']);
      return false;
    }

    // 2. Check if the user's role is in the allowed list for this route
    // if (allowedRoles && allowedRoles.includes(userRole)) {
    //   return true;
    // }

    // 3. If not authorized, redirect to a 'forbidden' page or back to login
    // You might want to create an 'unauthorized' component for this
    this.router.navigate(['/login']); 
    return false;
  }
}