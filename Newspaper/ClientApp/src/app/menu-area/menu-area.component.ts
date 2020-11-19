import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-menu-area',
  templateUrl: './menu-area.component.html',
  styleUrls: ['./menu-area.component.css']
})
export class MenuAreaComponent implements OnInit {
  Categories : any;
  newCate : any;
  constructor(private categoryService : CategoryService) { }

  ngOnInit() {
    this.categoryService.getAllCategory().subscribe((res)=>{
      this.Categories = res;
      this.newCate =[];
      for(let i = 0; i < this.Categories.length; i++){
        if(this.Categories[i].parentCatID == null){
          let Child = [];
          for(let j = 0; j < this.Categories.length; j++){
            if(this.Categories[j].parentCategoryID == this.Categories[i].categoryID){
              Child.push(this.Categories[j]);
            }
          }
          this.Categories[i].Child = Child;
          this.newCate.push(this.Categories[i]);
        }
      }
    },(err)=> console.log(err));
  }

}
