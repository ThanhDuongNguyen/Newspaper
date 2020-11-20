import { Component, OnInit } from '@angular/core';
import { News } from '../hot-news/hot-news.component';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-most-view-news',
  templateUrl: '../list-news/list-news.component.html',
  styleUrls: ['../list-news/list-news.component.css']
})
export class MostViewNewsComponent implements OnInit {
  PAGE_NUM = 1;
  PAGE_SIZE = 5;
  listnews: News[];

  constructor(private newspaperService : NewspaperService) {
  }

  ngOnInit() {
    this.newspaperService.getAllNewspaper(this.PAGE_NUM, this.PAGE_SIZE, "").subscribe((res : any)=>{
      this.listnews = res.listNews;
    }, err=>{
      console.log(err);
    })
  }
}
