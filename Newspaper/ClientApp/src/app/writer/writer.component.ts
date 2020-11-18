import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-writer',
  templateUrl: './writer.component.html',
  styleUrls: ['./writer.component.css'],

})
export class WriterComponent implements OnInit {
  Categories : any;
  writerForm : FormGroup;
  constructor(private categoryService: CategoryService, private fb: FormBuilder) { }

  ngOnInit() {
    this.categoryService.getAllCategory().subscribe((res)=>{
      this.Categories = res;
      console.log(this.Categories);
    },(err)=> console.log(err));


  }

  submitForm(data){

  }
}
