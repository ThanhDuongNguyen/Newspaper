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


  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | boolean {
    const expectedRole = route.data.expectedRole;
    const token = localStorage.getItem('token');
    const tokenPayload = this.jwtHelper.decodeToken(token);
    if(tokenPayload.role != expectedRole){
      alert("Không có quyền truy cập vào trang này");
        this.router.navigate(['login']);
        return false;
    } else if (this.auth.isAuthenticated()) {
      return true;
    }
    return this.tryRefreshingTokens(token).pipe(
      map((res: any) => {
        console.log(res);
        if(res){
          localStorage.setItem("token", res.token);
          localStorage.setItem("refreshToken", res.refreshToken);
          return true;
        }
        alert("Phiên làm việc đã hết hạn");
        this.router.navigate(['login']);
        return false;
      }));
  }

  tryRefreshingTokens(token: string) {
    var refreshToken =  localStorage.getItem('refreshToken');
    var credentials = JSON.stringify({ AccessToken: token, RefreshToken: refreshToken });
    console.log(refreshToken);
    console.log(token);
    return this.http.post(environment.apiUrl + "token/refresh", credentials, {headers: new HttpHeaders({ "Content-Type": "application/json" })});
  }
}
