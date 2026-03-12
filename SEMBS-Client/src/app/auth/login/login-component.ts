import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth-service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login-component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  hidePassword = true; 

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  login() {
    if (this.loginForm.invalid) {
      this.snackBar.open('Please enter valid email and password', 'Close', {
        duration: 2500
      });
      return;
    }

    this.authService.login(this.loginForm.value).subscribe({
      next: (res) => {
        this.authService.setSession(res);

        this.snackBar.open('Login successful ✅', 'Close', { duration: 2000 });

        if (res.role === 'Admin') {
          this.router.navigate(['/admin']);
        } else if (res.role === 'Organizer') {
          this.router.navigate(['/organizer']);
        } else {
          this.router.navigate(['/user']);
        }
      },
      error: (err) => {
        console.error('Login failed', err);
        this.snackBar.open('Invalid credentials ❌', 'Close', {
          duration: 2500
        });
      }
    });
  }
}
