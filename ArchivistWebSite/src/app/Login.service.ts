import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { User } from '../Models/User.model';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
 
  url: string = "http://localhost:3000/users/login";
  user: User;
  constructor(private http: Http) {  }

  login(user: string, password: string): boolean {

    this.user = new User(user, password, null);
    alert(this.user);
    this.http.post(this.url, this.user).subscribe(data => {
      if (data.status == 200) {
        alert("Successfully Logged in");
        localStorage.setItem('token', data.json().token);
        return true;
      } else if (data.status == 210) {
        alert("Wrong Username");
      } else if (data.status == 211) {
        alert("Wrong Password");
      }
      return false;
    }, error => { console.log(error) });
    return false;

  }

  logout(): any {
    localStorage.removeItem('token');
  }

  getUser(): any {
    const jwtHelper: JwtHelperService = new JwtHelperService();
    const token = localStorage.getItem('token');
    if (jwtHelper.isTokenExpired(token)) {

    } else {
      return jwtHelper.decodeToken(token);
    }
    return localStorage.getItem('token');

  }

  isLoggedIn(): boolean {
    return this.getUser() !== null;
  }

  User(): string {
    const jwtHelper: JwtHelperService = new JwtHelperService();
    const token = localStorage.getItem('token');
    return jwtHelper.decodeToken(token)['username'];
  }

  isAdmin(): boolean {
    const jwtHelper: JwtHelperService = new JwtHelperService();
    const token = localStorage.getItem('token');
    if (jwtHelper.decodeToken(token)['type'] == 0) {
      return true
    } else {
      return false;
    }
  }
}

export const AUTH_PROVIDERS: Array<any> = [
  { provide: LoginService, useClass: LoginService }
];
