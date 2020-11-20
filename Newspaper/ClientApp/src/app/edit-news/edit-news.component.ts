import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from '../hot-news/hot-news.component';
import { CategoryService } from '../services/category.service';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-edit-news',
  templateUrl: '../writer/writer.component.html',
  styleUrls: ['../writer/writer.component.css']
})
export class EditNewsComponent implements OnInit {
  newspaper : News;
  Categories : any;
  writerForm : FormGroup;
  idPage: any;
  constructor( private routeActivated: ActivatedRoute ,private categoryService: CategoryService, private fb: FormBuilder, private newpaperService: NewspaperService, private route : Router)
  {
    this.writerForm = this.fb.group(
      {
        title: ['', Validators.required],
        tinyContent: ['', Validators.required],
        categoryID: ['', Validators.required],
        imageAvatar: ['', Validators.required],
        content: ['', Validators.required],
      }
    );
  }

  async ngOnInit() {
    await this.categoryService.getAllCategory().subscribe((res)=>{
      this.Categories = res;
      console.log(this.Categories);
    },(err)=> console.log(err));



    await this.routeActivated.params.subscribe((params)=>{
      this.idPage = params.id;
    })

    this.newpaperService.getNewspaper(this.idPage).subscribe((res:any)=>{
      this.newspaper = res;
      console.log(res);
      this.writerForm.controls['title'].setValue(this.newspaper.title);
      this.writerForm.controls['tinyContent'].setValue(this.newspaper.tinyContent);
      this.writerForm.controls['categoryID'].setValue(this.newspaper.category.categoryID);
      this.writerForm.controls['imageAvatar'].setValue(this.newspaper.imageAvatar);
      this.writerForm.controls['content'].setValue(this.newspaper.content);
    }, err=> console.log(err));
  }

  submitForm(data){
    data.userID = this.newspaper.userID;
    data.date = this.newspaper.date;
    data.pageID = this.newspaper.pageID;
    data.view = this.newspaper.view;
    this.newpaperService.updateNewspaper(data).subscribe(res=>{
      alert("Cập nhật thành công");
      this.route.navigate(['manager']);
    }, err=>{
      alert("Lỗi");
      console.log(err);
    });
  }
}
