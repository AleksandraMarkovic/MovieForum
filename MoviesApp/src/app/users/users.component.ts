import { HttpClient } from '@angular/common/http';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { MoviesService } from '../services/movies.service';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  fileToUpload: File;
  genres:any = []
  constructor(public service: UsersService) { }

  ngOnInit(): void {
    
  }

  fileInput(){
    // @ts-ignore: Object is possibly 'null'.
    this.fileToUpload = (<HTMLInputElement>document.getElementById('image')).files[0];
  }

  onSubmit(){
    let firstName = (<HTMLInputElement>document.getElementById('firstName')).value;
    let lastName = (<HTMLInputElement>document.getElementById('lastName')).value;
    let email = (<HTMLInputElement>document.getElementById('email')).value;
    let username = (<HTMLInputElement>document.getElementById('username')).value;
    let password = (<HTMLInputElement>document.getElementById('password')).value;
    let birthday = (<HTMLInputElement>document.getElementById('birthday')).value;
    this.service.postUsers(firstName, lastName, email, username, password, birthday, this.fileToUpload).subscribe(
      res => {
        alert("Successfully registered");
      },
      err => {
        console.log(err);
      }
    )
  }
}
