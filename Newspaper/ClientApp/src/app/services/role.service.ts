import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RoleService implements CanActivate {
  jwtHelper = new JwtHelperService();

  constructor(public auth: AuthService, public router: Router, private http: HttpClient) { }


  async canActivate(route: ActivatedRouteSnapshot): Promise<boolean> {
    const expectedRole = route.data.expectedRole;
    const token = localStorage.getItem('token');
    const tokenPayload = this.jwtHelper.decodeToken(token);
    console.log(tokenPayload);
    if (this.auth.isAuthenticated() && tokenPayload.role == expectedRole) {
      return true;
    }
    this.tryRefreshingTokens(token)
      .subscribe((res: any) => {
        localStorage.setItem("token", res.token);
        localStorage.setItem("refreshToken", res.refreshToken);
      },
        err => {
          alert("Không có quyền truy cập vào trang này");
          this.router.navigate(['login']);
          return false;
        });
  }

  tryRefreshingTokens(token: string) {
    const refreshToken: string = localStorage.getItem("refreshToken");
    const credentials = JSON.stringify({ accessToken: token, refreshToken: refreshToken });

    return this.http.post(environment.apiUrl + "refresh", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }
}
