import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { News } from '../hot-news/hot-news.component';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-list-news',
  templateUrl: './list-news.component.html',
  styleUrls: ['./list-news.component.css']
})
export class ListNewsComponent implements OnInit {
  catID:number;
  pageNum:number;
  listnews: News[];
  constructor(private route: ActivatedRoute, private newspaperService: NewspaperService) {
    route.params.subscribe((params)=>{
      this.catID = params.id;
      this.pageNum = params.pageNumber;
      console.log("catid", this.catID);
      console.log("num", this.pageNum);
    })
  }

  ngOnInit() {
    this.newspaperService.getAllNewspaper(this.pageNum, 1,this.catID).subscribe((res : any)=>{
      this.listnews = res;
      console.log(this.listnews);
    }, err=>{
      console.log(err);
    })
  }

}
