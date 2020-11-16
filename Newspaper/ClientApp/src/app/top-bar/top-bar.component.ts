import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  IsAuthentication() : boolean {
    return localStorage.getItem('currentUser') !== null && localStorage.getItem('token') !== null
  }
}
