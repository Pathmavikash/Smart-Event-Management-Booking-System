import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { EventListComponent } from './event-list/event-list.component';
import { UserRoutingModule } from './user-routing.module';

@NgModule({
  declarations: [
    UserDashboardComponent,
    EventListComponent
  ],
  imports: [
    CommonModule,        // Required for directives like *ngIf, *ngFor
    ReactiveFormsModule, // For forms
    UserRoutingModule    // ✅ THIS IS CRUCIAL
  ]
})
export class UserModule {}
