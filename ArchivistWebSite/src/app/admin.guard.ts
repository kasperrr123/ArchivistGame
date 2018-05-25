import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';

@Injectable()
export class AdminGuard implements CanActivate {
  constructor(private loginService: LoginService, public router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.loginService.isAuthenticated()) {
      this.router.navigate(['home']);
      this.loginService.logout();
      return false;
    }
    return true;
  }
}
