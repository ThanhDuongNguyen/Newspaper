import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl, Validators, } from "@angular/forms";
import { from } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  IsAllValid: boolean;
  errors: string[];


  constructor(private fb: FormBuilder, private http: HttpClient) {}

  ngOnInit() {
    this.registerForm = this.fb.group({
      name: [""],
      email: [""],
      address: [""],
      emailAddress: [""]
    });
    this.errors = [];
  }
}
