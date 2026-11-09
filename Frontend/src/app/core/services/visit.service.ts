import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateVisitCommand, UpdateVisitCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class VisitService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getVisits(params?: VisitsGet$Params) {
  //   return visitsGet(this.http, this.config.rootUrl, params);
  // }

  // createVisit(command: CreateVisitCommand) {
  //   return visitsPost(this.http, this.config.rootUrl, { body: command });
  // }

  // getVisitById(id: string) {
  //   return visitsIdGet(this.http, this.config.rootUrl, { id });
  // }

  // updateVisit(id: string, command: UpdateVisitCommand) {
  //   return visitsIdPut(this.http, this.config.rootUrl, { id, body: command });
  // }

  // deleteVisit(id: string) {
  //   return visitsIdDelete(this.http, this.config.rootUrl, { id });
  // }
}
