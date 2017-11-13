import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {User} from './user.model';

import {AuthenticationService} from './authentication.service';
import {RequestOptions, Headers} from '@angular/http';

@Injectable()
export class LoginService {

  constructor(private http: HttpClient,  private authenticationService: AuthenticationService) { }

  getUsers(): Observable <User> {
    const headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
    const options = new RequestOptions({ headers: headers });
    return this.http
      .get<User>(environment.ApiEndPoint + '/login');
  }

}
