import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { User } from '../../Models/User.model';
import { Http } from '@angular/http';
@Component({
  selector: 'Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent implements OnInit {
  http: Http;
  username: string;
  constructor(public loginService: LoginService) {
    if (loginService.isLoggedIn()) {
      var user = loginService.User();
      this.username = user;
    }
  }
  login(username: string, password: string): boolean {
    this.username = username;
    if (!this.loginService.login(username, password)) {
      setTimeout(() => {
      }, 2500);
    }
    return false;
  }
  logout(): boolean {
    this.loginService.logout();
    return false;
  }

  ngOnInit() {
  }

}
