import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { Router } from '@angular/router';
import Keycloak from 'keycloak-js';

@Component({
  selector: 'app-navigation',
  imports: [ CommonModule, MatButtonModule, MatTabsModule ],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  private routings: string[] = ['/dashboard', '/characters', '/templates']
  constructor(protected keycloak: Keycloak, private router: Router) {
  }

  ngOnInit() {
  }

  login() {
    this.keycloak.login();
  }

  logout() {
    this.keycloak.logout({
      redirectUri: window.location.origin
    });
  }

  set test(value: number) {
    this.router.navigate([this.routings[value]], {
      onSameUrlNavigation: 'reload'
    });
  }
}
