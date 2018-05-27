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
  jwtHelper: JwtHelperService = new JwtHelperService();
  constructor(private http: Http) {  }

  public isAuthenticated(): boolean {

    const token = localStorage.getItem('token');

    // Check whether the token is expired and return
    // true or false
    return !this.jwtHelper.isTokenExpired(token);
  }

  login(user: string, password: string): boolean {

    this.user = new User(user, password, null);
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
    }, error => { console.log(error);
      alert("Can't login contact admin"); });
    return false;

  }

  logout(): any {
    localStorage.removeItem('token');
  }

  getUser(): any {
    
    const token = localStorage.getItem('token');
    if (this.jwtHelper.isTokenExpired(token)) {

    } else {
      return this.jwtHelper.decodeToken(token);
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
