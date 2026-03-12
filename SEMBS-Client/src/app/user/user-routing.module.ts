import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { EventListComponent } from './event-list/event-list.component';

const routes: Routes = [
  {
    path: '',
    component: UserDashboardComponent
  },
  {
    path: 'events',
    component: EventListComponent
  }
  // Add more user-specific routes here
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule {}
