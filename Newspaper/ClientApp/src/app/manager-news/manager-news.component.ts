import { Component, OnInit } from '@angular/core';
import { News } from '../hot-news/hot-news.component';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-manager-news',
  templateUrl: './manager-news.component.html',
  styleUrls: ['./manager-news.component.css']
})
export class ManagerNewsComponent implements OnInit {
  listNew : News[];
  PAGE_NUM = 1;
  PAGE_SIZE = 10;
  constructor(private newspaperService: NewspaperService) { }

  ngOnInit() {
    this.LoadNewspapers();
  }

  LoadNewspapers(){
    this.newspaperService.getAllNewspaper(this.PAGE_NUM, this.PAGE_SIZE, "").subscribe((res : any)=>{
      this.listNew = res.listNews;
    }, err => console.log(err))
  }

  Delete(id){
    this.newspaperService.deleteNewspaper(id).subscribe((res=>{
      alert("Xóa thành công");
      this.LoadNewspapers();
    }), err=>console.log(err));
  }
}
