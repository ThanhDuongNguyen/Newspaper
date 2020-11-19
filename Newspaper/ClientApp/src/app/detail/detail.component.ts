import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { News } from '../hot-news/hot-news.component';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class DetailComponent implements OnInit {
  newspaper: News;
  id:number;
  constructor(private route: ActivatedRoute, private newspaperService: NewspaperService) {
    route.params.subscribe((params)=>{
      this.id = params.id;
    })
    this.newspaper = new News();
   }

  ngOnInit() {
    this.newspaperService.getNewspaper(this.id).subscribe((res : any)=>{
      this.newspaper = res;
      console.log(this.newspaper);
    }, err=>{
      console.log(err);
    })
  }

}
