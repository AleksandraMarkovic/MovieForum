import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GenresService } from 'src/app/services/genres.service';
import { Genres } from 'src/app/services/models/genres';

@Component({
  selector: 'app-genres-form',
  templateUrl: './genres-form.component.html',
  styleUrls: ['./genres-form.component.css']
})
export class GenresFormComponent implements OnInit {

  constructor(public service: GenresService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.insertGenre(form);
    else
      this.updateGenre(form);
  }

  insertGenre(form: NgForm){
    this.service.postGenres().subscribe(
      res => {
        this.resetForm(form);
        this.service.getGenres();
        alert("Successfully added a new genre")
      },
      err => {
        console.log(err)
      }
    )
  }

  updateGenre(form: NgForm){
    this.service.putGenres().subscribe(
      res => {
        this.resetForm(form);
        this.service.getGenres();
        alert("Successfully updated a genre")
      },
      err => {
        console.log(err)
      }
    )
  }

  resetForm(form: NgForm){
    form.form.reset;
    this.service.formData = new Genres();
  }

}
