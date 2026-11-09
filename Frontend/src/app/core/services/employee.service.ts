import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateEmployeeCommand, UpdateEmployeeCommand } from '../api/models';
import { createEmployee$Json, deleteEmployee$Json, updateEmployee$Json } from '../api/functions';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  createEmployee(command: CreateEmployeeCommand) {
    return createEmployee$Json(this.http, this.config.rootUrl, { body: command });
  }

  // getEmployeeById(id: string) {
  //   return (this.http, this.config.rootUrl, { id });
  // }

  updateEmployee(id: string, command: UpdateEmployeeCommand) {
    return updateEmployee$Json(this.http, this.config.rootUrl, {
      id,
      body: command,
    });
  }

  deleteEmployee(id: string) {
    return deleteEmployee$Json(this.http, this.config.rootUrl, { employeeId: id });
  }
}
