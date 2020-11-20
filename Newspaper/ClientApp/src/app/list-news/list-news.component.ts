import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { News } from '../hot-news/hot-news.component';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-list-news',
  templateUrl: './list-news.component.html',
  styleUrls: ['./list-news.component.css']
})
export class ListNewsComponent implements OnInit {
  CAT_ID = "";
  PAGE_NUM = 1;
  PAGE_SIZE = 2;
  startPage : number;
  endPage : number;

  viewPageNum = 2;
  listnews: News[];
  listPages: any;
  navigationSubscription;

  constructor(private route: ActivatedRoute, private newspaperService: NewspaperService, private router: Router,) {

    this.navigationSubscription = this.router.events.subscribe((e: any) => {
      if (e instanceof NavigationEnd) {
        this.initialiseInvites();
      }
    });
  }
  initialiseInvites() {
    console.log("init");
    this.CAT_ID = this.route.snapshot.paramMap.get('id');
    this.PAGE_NUM = parseInt(this.route.snapshot.paramMap.get('pageNumber'));
    this.LoadNewpapers();
  }

  ngOnInit() {
  }

  LoadNewpapers(){
    this.newspaperService.getAllNewspaper(this.PAGE_NUM, this.PAGE_SIZE ,this.CAT_ID).subscribe((res : any)=>{
      this.listnews = res.listNews;
      let totalPage = Math.floor(res.length / this.PAGE_SIZE);

      console.log("leng", res.length);
      console.log("size", this.PAGE_SIZE);
      if(res.length % this.PAGE_SIZE > 0){
        totalPage += 1;
      }
      console.log("total", totalPage);
      this.startPage = this.PAGE_NUM - this.viewPageNum;
      if(this.startPage <= 0)
        this.startPage = 1;
      console.log("start", this.startPage);

      this.endPage = this.PAGE_NUM + this.viewPageNum;
      if(this.endPage > totalPage)
        this.endPage = totalPage;
      console.log("end", this.endPage);

      this.listPages = new Array();
      for(let i = this.startPage; i <= this.endPage; i++){
        this.listPages.push(i);
      }
      console.log(this.listPages);
    }, err=>{
      console.log(err);
    })
  }

  ngOnDestroy() {
    if (this.navigationSubscription) {
       this.navigationSubscription.unsubscribe();
    }
  }
}
