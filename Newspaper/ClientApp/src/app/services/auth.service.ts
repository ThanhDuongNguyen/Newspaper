import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  Register(user: any) {
    return this.http.post(environment.apiUrl + "auth/register", JSON.stringify(user), {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }

  Login(loginData: any){
    return this.http.post(environment.apiUrl + "auth/login", JSON.stringify(loginData), {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
}
