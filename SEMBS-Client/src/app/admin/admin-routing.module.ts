import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageEventsComponent } from './manage-events/manage-events.component';

const routes: Routes = [
  {
    path: '',
    component: ManageEventsComponent
  }
  // later you can add:
  // { path: 'events', component: EventsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}
