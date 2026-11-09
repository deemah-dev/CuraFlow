import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { CreateInvoiceCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class InvoiceService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getInvoiceById(id: string) {
  //   return invoicesIdGet(this.http, this.config.rootUrl, { id });
  // }

  // createInvoice(command: CreateInvoiceCommand) {
  //   return invoicesPost(this.http, this.config.rootUrl, { body: command });
  // }

  // settleInvoice(id: string) {
  //   return invoicesIdSettlePost(this.http, this.config.rootUrl, { id });
  // }
}
