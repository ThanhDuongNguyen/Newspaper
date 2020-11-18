import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewspaperService {

  constructor(private http: HttpClient) { }

  getAllNewspaper(pageNumber, pageSize) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize);
      console.log(params);
    return this.http.get(environment.apiUrl + "newspaper", {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
      params: params
    });
  }

  addNewspaper(newspaperData: any) {
    var user = JSON.parse(localStorage.getItem('currentUser'));
    newspaperData.categoryID = parseInt(newspaperData.categoryID);
    newspaperData.userID = user.userID;
    console.log(newspaperData);
    return this.http.post(environment.apiUrl + "newspaper", JSON.stringify(newspaperData), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
}