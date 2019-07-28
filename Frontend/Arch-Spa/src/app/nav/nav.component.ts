import { AlertifyService } from './../shared/alertify.service';
import { AuthService } from './../shared/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(
    public authService: AuthService,
    public alertify: AlertifyService,
    private router: Router
    ) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model)
      .subscribe(
          next => this.alertify.success('logged in successfully'),
          error => this.alertify.error(error),
          () => this.router.navigate(['customers'])
        );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/']);
  }

}
