import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router"; // Change this line
import { AuthService } from "../services/auth-service";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

  // Dependency Injection uses the Angular Router now
  constructor(private auth: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.auth.isLoggedIn()) {
      return true;
    }
    
    // This will now work without errors
    this.router.navigate(['/login']);
    return false;
  }
}