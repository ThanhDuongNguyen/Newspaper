import { Component, OnInit } from '@angular/core';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-hot-news',
  templateUrl: './hot-news.component.html',
  styleUrls: ['./hot-news.component.css']
})
export class HotNewsComponent implements OnInit {
  listNews : any;
  constructor(private newspaperService: NewspaperService) { }

  ngOnInit() {
    this.newspaperService.getAllNewspaper(1,2).subscribe(res=>{
      this.listNews = res;
    },err=>console.log(err));
  }

}
