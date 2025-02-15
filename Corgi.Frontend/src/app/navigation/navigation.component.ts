import { CommonModule } from '@angular/common';
import { Component, effect } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import Keycloak from 'keycloak-js';

@Component({
  selector: 'app-navigation',
  imports: [ CommonModule, MatButtonModule ],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  constructor(public keycloak: Keycloak) {
  }

  login() {
    this.keycloak.login();
  }
  logout() {
    this.keycloak.logout({
      redirectUri: window.location.origin
    });
  }

}
