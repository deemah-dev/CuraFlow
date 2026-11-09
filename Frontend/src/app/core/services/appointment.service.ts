import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import {
  AppointmentDto,
  CreateAppointmentCommand,
  Deleted,
  PagenatedListOfAppointmentDto,
  ScheduleAppointmentCommand,
  Success,
  UpdateAppointmentStatusCommand,
  Updated,
} from '../api/models';
import { map, Observable } from 'rxjs';
import {
  createAppointment$Json,
  deleteAppointment$Json,
  getAppointment$Json,
  getAppointments$Json,
  GetAppointments$Json$Params,
  scheduleAppointment$Json,
  updateAppointmentStatus$Json,
} from '../api/functions';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  getAppointments(params?: GetAppointments$Json$Params): Observable<PagenatedListOfAppointmentDto> {
    return getAppointments$Json(this.http, this.config.rootUrl, params).pipe(
      map((response) => response.body as PagenatedListOfAppointmentDto),
    );
  }

  createNewAppointment(command: CreateAppointmentCommand): Observable<AppointmentDto> {
    return createAppointment$Json(this.http, this.config.rootUrl, { body: command });
  }

  getAppointmentById(id: string): Observable<AppointmentDto> {
    return getAppointment$Json(this.http, this.config.rootUrl, { appointmentId: id });
  }

  deleteAppointment(id: string): Observable<Deleted> {
    return deleteAppointment$Json(this.http, this.config.rootUrl, { appointmentId: id });
  }

  scheduleAppointment(id: string, command: ScheduleAppointmentCommand): Observable<Updated> {
    return scheduleAppointment$Json(this.http, this.config.rootUrl, {
      id,
      body: command,
    });
  }

  updateAppointmentStatus(
    id: string,
    command: UpdateAppointmentStatusCommand,
  ): Observable<Updated> {
    return updateAppointmentStatus$Json(this.http, this.config.rootUrl, {
      id,
      body: command,
    });
  }
}
