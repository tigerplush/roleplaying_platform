import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddUserDtoV1 } from './add-user-dto-v1';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly resource = '/users';

  constructor(private http: HttpClient) { }

  createNewUser(user: AddUserDtoV1) {
    return this.http.post(environment.baseUrl + this.resource, user);
  }
}
