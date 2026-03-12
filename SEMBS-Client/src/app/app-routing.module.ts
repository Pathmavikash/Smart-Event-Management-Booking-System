import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth-guard';
import { RoleGuard } from './core/guards/role-guard';

const routes: Routes = [
  { path: 'login', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },

  {
    path: 'user',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['User'] },
    loadChildren: () => import('./user/user.module').then(m => m.UserModule)
  },
  {
    path: 'organizer',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Organizer'] },
    loadChildren: () => import('./organizer/organizer.module').then(m => m.OrganizerModule)
  },
  {
    path: 'admin',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Admin'] },
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  },

  { path: '**', redirectTo: 'login' }
];
