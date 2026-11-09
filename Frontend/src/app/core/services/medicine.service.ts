import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateMedicineCommand, UpdateMedicineCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class MedicineService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getMedicines(params?: MedicinesGet$Params) {
  //   return medicinesGet(this.http, this.config.rootUrl, params);
  // }

  // createMedicine(command: CreateMedicineCommand) {
  //   return medicinesPost(this.http, this.config.rootUrl, { body: command });
  // }

  // getMedicineById(id: string) {
  //   return medicinesIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updateMedicine(id: string, command: UpdateMedicineCommand) {
  //   return medicinesIdPut(this.http, this.config.rootUrl, { id, body: command });
  // }

  // deleteMedicine(id: string) {
  //   return medicinesIdDelete(this.http, this.config.rootUrl, { id });
  // }
}
