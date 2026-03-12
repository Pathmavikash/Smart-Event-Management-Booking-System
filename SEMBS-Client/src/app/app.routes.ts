import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { 
    path: 'login', 
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) 
  },
  { 
    path: 'user', 
    loadChildren: () => import('./user/user.module').then(m => m.UserModule) 
  },
   {
    path: 'organizer', 
    loadChildren: () =>
      import('./organizer/organizer.module').then(m => m.OrganizerModule)
  },

  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then(m => m.AdminModule)
  }
];