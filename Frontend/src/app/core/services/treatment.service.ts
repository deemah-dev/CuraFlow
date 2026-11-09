import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateTreatmentCommand, UpdateTreatmentCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class TreatmentService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getTreatments(params?: TreatmentsGet$Params) {
  //   return treatmentsGet(this.http, this.config.rootUrl, params);
  // }

  // createTreatment(command: CreateTreatmentCommand) {
  //   return treatmentsPost(this.http, this.config.rootUrl, { body: command });
  // }

  // getTreatmentById(id: string) {
  //   return treatmentsIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updateTreatment(id: string, command: UpdateTreatmentCommand) {
  //   return treatmentsIdPut(this.http, this.config.rootUrl, {
  //     id,
  //     body: command,
  //   });
  // }

  // deleteTreatment(id: string) {
  //   return treatmentsIdDelete(this.http, this.config.rootUrl, { id });
  // }
}
