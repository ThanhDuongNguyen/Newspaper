import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authService: AuthService) { }

  IsAuthentication() : boolean {
    return localStorage.getItem('currentUser') !== null && localStorage.getItem('token') !== null
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  LogOut(){
    this.authService.LogOut();
    console.log("Logout");
  }
}
