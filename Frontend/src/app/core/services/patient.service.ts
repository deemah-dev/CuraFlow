import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreatePatientCommand, UpdatePatientCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getPatients(params?: PatientsGet$Params) {
  //   return patientsGet(this.http, this.config.rootUrl, params);
  // }

  // createPatient(command: CreatePatientCommand) {
  //   return patientsPost(this.http, this.config.rootUrl, { body: command });
  // }

  // getPatientById(id: string) {
  //   return patientsIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updatePatient(id: string, command: UpdatePatientCommand) {
  //   return patientsIdPut(this.http, this.config.rootUrl, { id, body: command });
  // }

  // deletePatient(id: string) {
  //   return patientsIdDelete(this.http, this.config.rootUrl, { id });
  // }
}
