import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { UploadEventComponent } from './upload-event/upload-event.component';
import { OrganizerRoutingModule } from './organizer-routing.module';
import { MaterialModule } from '../core/material/material.module';
import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { ManageEventsComponent } from './manage-event/manage-event.component';

@NgModule({
  declarations: [
    UploadEventComponent,
    ManageEventsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    OrganizerRoutingModule,
    MaterialModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    LayoutModule,
    MatCardModule
  ]
})
export class OrganizerModule {}
