import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { Login } from '../services/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean;
  constructor(public service: LoginService, private router: Router) { }

  ngOnInit(): void {
  }

  login(form: NgForm){
    this.service.login().subscribe(
      res => {
        const token = (<any>res).token;
        localStorage.setItem("jwt", token)
        alert("Successfully logged in")
        this.resetForm(form);
        this.router.navigate(["/"]);
        this.invalidLogin = false;
      },
      err => {
        console.log(err)
        this.invalidLogin = true;
      }
    )
  }

  resetForm(form: NgForm){
    form.form.reset;
    this.service.formData = new Login();
  }

}
