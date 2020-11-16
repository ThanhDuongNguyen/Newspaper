import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class RoleService implements CanActivate {
  jwtHelper = new JwtHelperService();

  constructor(public auth: AuthService, public router: Router) { }


  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;
    const token = localStorage.getItem('token');
    const tokenPayload = this.jwtHelper.decodeToken(token);
    console.log(tokenPayload);
    if (!this.auth.isAuthenticated() || tokenPayload.role !== expectedRole)
    {
      alert("Không có quyền truy cập vào trang này");
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
