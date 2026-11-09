import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateMedicalRecordCommand, UpdateMedicalRecordCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class MedicalRecordService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getMedicalRecords(params?: MedicalRecordsGet$Params) {
  //   return medicalRecordsGet(this.http, this.config.rootUrl, params);
  // }

  // createMedicalRecord(command: CreateMedicalRecordCommand) {
  //   return medicalRecordsPost(this.http, this.config.rootUrl, {
  //     body: command,
  //   });
  // }

  // getMedicalRecordById(id: string) {
  //   return medicalRecordsIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updateMedicalRecord(id: string, command: UpdateMedicalRecordCommand) {
  //   return medicalRecordsIdPut(this.http, this.config.rootUrl, {
  //     id,
  //     body: command,
  //   });
  // }

  // deleteMedicalRecord(id: string) {
  //   return medicalRecordsIdDelete(this.http, this.config.rootUrl, { id });
  // }
}
