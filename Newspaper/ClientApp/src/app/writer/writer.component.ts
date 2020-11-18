import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryService } from '../services/category.service';
import { NewspaperService } from '../services/newspaper.service';

@Component({
  selector: 'app-writer',
  templateUrl: './writer.component.html',
  styleUrls: ['./writer.component.css'],

})
export class WriterComponent implements OnInit {
  Categories : any;
  writerForm : FormGroup;
  constructor(private categoryService: CategoryService, private fb: FormBuilder, private newpaperService: NewspaperService, private route : Router) { }

  ngOnInit() {
    this.writerForm = this.fb.group(
      {
        title: ["", Validators.required],
        tinyContent: ["", Validators.required],
        categoryID: ["", Validators.required],
        imageAvatar: ["", Validators.required],
        content: ["", Validators.required],
      }
    );

    this.categoryService.getAllCategory().subscribe((res)=>{
      this.Categories = res;
      console.log(this.Categories);
    },(err)=> console.log(err));
  }

  submitForm(data){
    this.newpaperService.addNewspaper(data).subscribe(res=>{
      alert("Đăng bài thành công");
      this.route.navigate(['writer']);
    }, err=>{
      alert("Lỗi");
      console.log(err);
    });
  }
}
