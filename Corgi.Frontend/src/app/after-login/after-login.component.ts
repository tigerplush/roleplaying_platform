import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { AddUserDtoV1 } from '../add-user-dto-v1';
import Keycloak from 'keycloak-js';
import { catchError, finalize, of } from 'rxjs';
import { MatProgressSpinnerModule  } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-after-login',
  imports: [ MatProgressSpinnerModule ],
  templateUrl: './after-login.component.html',
  styleUrl: './after-login.component.scss'
})
export class AfterLoginComponent {
  constructor(private userService: UserService, private router: Router, private keycloak: Keycloak) {
    this.keycloak.loadUserProfile().then(async value => {
      await this
      .userService
      .createOrUpdateUser(new AddUserDtoV1(value.id ?? "id", value.username ?? "username")).subscribe();
      this.router.navigate(['/dashboard']);
    });
  }
}
