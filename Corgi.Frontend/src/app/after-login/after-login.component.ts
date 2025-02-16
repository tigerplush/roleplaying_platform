import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AddUserDtoV1 } from '../add-user-dto-v1';

@Component({
  selector: 'app-after-login',
  imports: [],
  templateUrl: './after-login.component.html',
  styleUrl: './after-login.component.scss'
})
export class AfterLoginComponent {
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {
    console.log(this.route);
    this
      .userService
      .createNewUser(new AddUserDtoV1("ccca3dea-a2cd-4af8-ab86-f453ad4cee0a", "nickname"))
      .subscribe(_ => {
        this.router.navigate(['/dashboard']);
      });
  }
}
