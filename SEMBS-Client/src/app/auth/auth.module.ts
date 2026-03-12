import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login-component';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { MaterialModule } from '../core/material/material.module';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AuthRoutingModule,
    MaterialModule
  ]
})
export class AuthModule {}