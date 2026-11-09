import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateMedicalDepartmentCommand, UpdateMedicalDepartmentCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class MedicalDepartmentService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getMedicalDepartments(params?: MedicalDepartmentsGet$Params) {
  //   return medicalDepartmentsGet(this.http, this.config.rootUrl, params);
  // }

  // createMedicalDepartment(command: CreateMedicalDepartmentCommand) {
  //   return medicalDepartmentsPost(this.http, this.config.rootUrl, {
  //     body: command,
  //   });
  // }

  // getMedicalDepartmentById(id: string) {
  //   return medicalDepartmentsIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updateMedicalDepartment(id: string, command: UpdateMedicalDepartmentCommand) {
  //   return medicalDepartmentsIdPut(this.http, this.config.rootUrl, {
  //     id,
  //     body: command,
  //   });
  // }

  // deleteMedicalDepartment(id: string) {
  //   return medicalDepartmentsIdDelete(this.http, this.config.rootUrl, { id });
  // }
}
