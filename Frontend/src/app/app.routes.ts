import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'appointments',
        loadChildren: () =>
          import('./features/appointments/appointment.routes').then((r) => r.appointmentRoutes),
      },
    ],
  },
];
