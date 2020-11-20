import { Component, OnInit } from '@angular/core';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-hot-news',
  templateUrl: './hot-news.component.html',
  styleUrls: ['./hot-news.component.css']
})
export class HotNewsComponent implements OnInit {
  listNews : News[];
  NewsFirst : News;
  constructor(private newspaperService: NewspaperService) {
    this.NewsFirst = new News();
  }

  ngOnInit() {
    this.newspaperService.getAllNewspaper(1,3,"").subscribe((res:any)=>{
      this.listNews = res.listNews;
      this.NewsFirst = this.listNews[0];
      console.log(this.listNews);
    },err=>console.log(err));
  }
}

export class News{
  category: Category = new Category();
  content: string;
  date: Date;
  imageAvatar: string;
  pageID: number;
  status: boolean;
  tinyContent: string;
  title: string;
  userID: number;
  view: number;
}

export class Category{
  categoryID : number;
  categoryName: string;
}

