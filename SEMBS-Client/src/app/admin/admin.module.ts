import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ManageEventsComponent } from './manage-events/manage-events.component';
import { AdminRoutingModule } from './admin-routing.module';

@NgModule({
  declarations: [
    ManageEventsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AdminRoutingModule
  ]
})
export class AdminModule {}
