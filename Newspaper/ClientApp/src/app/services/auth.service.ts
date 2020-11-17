import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate {
  jwtHelper = new JwtHelperService;
  constructor(private http: HttpClient, public router: Router) { }
  Register(user: any) {
    return this.http.post(environment.apiUrl + "auth/register", JSON.stringify(user), {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }

  Login(loginData: any) {
    return this.http.post(environment.apiUrl + "auth/login", JSON.stringify(loginData), {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    })
      .pipe(
        map((res: any) => {
          console.log(res);
          localStorage.setItem('token', res.token);
          localStorage.setItem('refreshToken', JSON.stringify(res.refreshToken));
        })
      )
  }

  LogOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  canActivate(): boolean {
    const token = localStorage.getItem('token');
    if (token && this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(['login']);
    return false;
  }
}
