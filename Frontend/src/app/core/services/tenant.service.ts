import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateTenantCommand, UpdatedTenantCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class TenantService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // createTenant(command: CreateTenantCommand) {
  //   return tenantsPost(this.http, this.config.rootUrl, { body: command });
  // }

  // deleteTenant(command: DeleteTenantCommand) {
  //   return tenantsDelete(this.http, this.config.rootUrl, { body: command });
  // }

  // getTenantById(id: string) {
  //   return tenantsIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updateTenant(id: string, command: UpdatedTenantCommand) {
  //   return tenantsIdPut(this.http, this.config.rootUrl, { id, body: command });
  // }
}
