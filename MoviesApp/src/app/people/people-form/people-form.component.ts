import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { People } from 'src/app/services/models/people';
import { PeopleService } from 'src/app/services/people.service';

@Component({
  selector: 'app-people-form',
  templateUrl: './people-form.component.html',
  styleUrls: ['./people-form.component.css']
})
export class PeopleFormComponent implements OnInit {

  fileToUpload: File;
  constructor(public service: PeopleService) { }

  ngOnInit(): void {
    this.service.getMovies();
    this.service.getRoles();
  }

  fileInput(){
    // @ts-ignore: Object is possibly 'null'.
    this.fileToUpload = (<HTMLInputElement>document.getElementById('image')).files[0];
  }

  onSubmit(form: NgForm){
      if((<HTMLInputElement>document.getElementById('personId')).value == "undefined"){
        this.insert(form);
      }
      else {
        this.update(form);
      }
  }

  insert(form: NgForm){
    let firstName = (<HTMLInputElement>document.getElementById('firstName')).value;
    let lastName = (<HTMLInputElement>document.getElementById('lastName')).value;
    let bio = (<HTMLInputElement>document.getElementById('bio')).value;
    let placeOfBirth = (<HTMLInputElement>document.getElementById('birthPlace')).value;
    let role = (<HTMLInputElement>document.getElementById('role')).value;

    let movies = $(".movies:checked");
    var moviesRolesArr = [];
    for(let i = 0; i < movies.length; i++){
      moviesRolesArr.push(
        {
          "roleId": role,
          'movieId': (<HTMLInputElement>movies[i]).value,
        }
      );
    }


    this.service.postPeople(firstName, lastName, bio, placeOfBirth, this.fileToUpload, moviesRolesArr).subscribe(
      res => {
        alert("Successfully added a new person.");
        this.service.getPeople();
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    )
  }

  update(form: NgForm){
    let id = (<HTMLInputElement>document.getElementById('personId')).value;
    let firstName = (<HTMLInputElement>document.getElementById('firstName')).value;
    let lastName = (<HTMLInputElement>document.getElementById('lastName')).value;
    let bio = (<HTMLInputElement>document.getElementById('bio')).value;
    let placeOfBirth = (<HTMLInputElement>document.getElementById('birthPlace')).value;
    let role = (<HTMLInputElement>document.getElementById('role')).value;

    let movies = $(".movies:checked");
    var moviesRolesArr = [];
    for(let i = 0; i < movies.length; i++){
      moviesRolesArr.push(
        {
          "roleId": role,
          'movieId': (<HTMLInputElement>movies[i]).value,
        }
      );
    }

    this.service.putPeople(id, firstName, lastName, bio, placeOfBirth, this.fileToUpload, moviesRolesArr).subscribe(
      res => {
        alert("Successfully updated a person.");
        this.service.getPeople();
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form: NgForm){
    form.form.reset;
    this.service.formData = new People();
  }

}
