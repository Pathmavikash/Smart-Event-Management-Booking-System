import { Component } from '@angular/core';
import { AuthService } from '../../core/services/auth-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-dashboard',
  standalone: false,
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent {
  constructor(private authService: AuthService, private router: Router) {}

  logout() {
    this.authService.logout(); // Make sure this clears localstorage
    this.router.navigate(['/login']);
  }
}