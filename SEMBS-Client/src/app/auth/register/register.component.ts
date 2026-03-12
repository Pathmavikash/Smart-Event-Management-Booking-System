import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '../../core/services/auth-service';
import { RegisterRequest } from '../../shared/models/auth/register-request.model';

@Component({
    selector: 'app-register',
    standalone: false,
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    registerForm!: FormGroup;
    hidePassword = true;
    hideConfirmPassword = true;
    roles = [
        { value: 'User', label: 'User (Book events)' },
        { value: 'Organizer', label: 'Organizer (Host events)' }
    ];
    constructor(
        private authService: AuthService,
        private fb: FormBuilder,
        private router: Router,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit(): void {
        this.registerForm = this.fb.group({
            firstName: ['', [Validators.required, Validators.minLength(3)]],
            lastName: ['', [Validators.required, Validators.minLength(3)]],
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            confirmPassword: ['', [Validators.required]],
            role: ['User', [Validators.required]]
        });
    }

    register(): void {
        if (this.registerForm.invalid) {
            this.snackBar.open('Please fill all details correctly', 'Close', { duration: 2500 });
            return;
        }

        const { password, confirmPassword } = this.registerForm.value;

        if (password !== confirmPassword) {
            this.snackBar.open('Passwords do not match ❌', 'Close', { duration: 2500 });
            return;
        }
        const registerData : RegisterRequest = {
            firstName: this.registerForm.value.firstName,
            lastName: this.registerForm.value.lastName,
            email: this.registerForm.value.email,
            password: this.registerForm.value.password,
            rolename: this.registerForm.value.role
        };
        this.authService.register(registerData).subscribe({
            next: (res) => {
                this.snackBar.open('Registration successful ✅', 'Close', { duration: 2000 });
                this.router.navigate(['/login']);
            },
            error: (err) => {
                console.error('Registration failed', err);
                this.snackBar.open('Registration failed ❌', 'Close', { duration: 2500 });
            }
        });
    }
}
