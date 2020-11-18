import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {
  name: any;
  isAdmin: boolean;
  constructor(private authService: AuthService, private route: Router) { }

  ngOnInit() {
    if(this.IsAuthentication()){
      var user = JSON.parse(localStorage.getItem('currentUser'));
      this.name = user.name;
      if (user.role == "Admin")
        this.isAdmin = true;
      else
        this.isAdmin = false;

      //not refresh page
      this.authService.currentUser.subscribe(curretnUser => {
        user = curretnUser;
        this.name = user.name;
        if (user.role == "Admin")
          this.isAdmin = true;
        else
          this.isAdmin = false;
      }, err => console.log(err))
    }
  }

  IsAuthentication(): boolean {
    return localStorage.getItem('currentUser') !== null && localStorage.getItem('token') !== null
  }



  LogOut() {
    this.authService.LogOut();
    this.route.navigate(['home']);
  }
}
