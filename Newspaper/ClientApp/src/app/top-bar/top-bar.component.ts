import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  constructor(private authService: AuthService, private route: Router) { }

  ngOnInit() {
  }

  IsAuthentication() : boolean {
    return localStorage.getItem('currentUser') !== null && localStorage.getItem('token') !== null
  }

  LogOut(){
    this.authService.LogOut();
    this.route.navigate(['home']);
  }
}
