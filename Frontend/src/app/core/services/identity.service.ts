import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ApiConfiguration } from '../api/api-configuration';
import { GenerateTokenCommand, RefreshTokenCommand } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class IdentityService {
  private http = inject(HttpClient);
  private config = inject(ApiConfiguration);

  // getIdentity() {
  //   return identityGet(this.http, this.config.rootUrl);
  // }

  // getIdentityById(id: string) {
  //   return identityIdGet(this.http, this.config.rootUrl, { id });
  // }

  // generateToken(command: GenerateTokenCommand) {
  //   return identityTokenGeneratePost(this.http, this.config.rootUrl, {
  //     body: command,
  //   });
  // }

  // refreshToken(command: RefreshTokenCommand) {
  //   return identityTokenRefreshPost(this.http, this.config.rootUrl, {
  //     body: command,
  //   });
  // }
}
