import { Routes } from '@angular/router';
import { List } from './list/list';
import { Create } from './create/create';
import { UpdateStatus } from './update-status/update-status';
import { Schedule } from './schedule/schedule';
import { Get } from './get/get';

export const appointmentRoutes: Routes = [
  { path: 'list', component: List },
  { path: 'create', component: Create },
  { path: 'update-status', component: UpdateStatus },
  { path: 'schedule', component: Schedule },
  { path: 'get', component: Get },
  { path: '', redirectTo: 'list', pathMatch: 'full' },
];
