import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { UploadEventComponent } from './upload-event/upload-event.component';
import { ManageEventsComponent } from './manage-event/manage-event.component';

const routes: Routes = [
  { path: '', redirectTo: 'manage-event', pathMatch: 'full' }, 
  { path: 'manage-event', component: ManageEventsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizerRoutingModule {}
