import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-single-movie',
  templateUrl: './single-movie.component.html',
  styleUrls: ['./single-movie.component.css']
})
export class SingleMovieComponent implements OnInit {

  fileToUploadPoster: File;
  fileToUploadCover: File;
  constructor(public service: MoviesService, public router: Router) { }

  ngOnInit(): void {
   this.service.getSingleMovie(parseInt(this.router.url.split("/")[2]));
   this.service.getCountries();
   this.service.getTypes();
   this.service.getGenres();
   $("#formUpdate").hide();
  }

  submitComment(form: NgForm){
    this.service.postComment().subscribe(
      res => {
        alert("Successfully added a new comment")
        window.location.reload;
      },
      err => {
        console.log(err)
      }
    )
  }

  submitRating(form: NgForm){
    this.service.postRating().subscribe(
      res => {
        alert("Successfully rated a movie")
        window.location.reload;
      },
      err => {
        console.log(err)
      }
    )
  }

  showForm(){
    $("#formUpdate").slideToggle();
  }

  delete(){
    this.service.deleteMovie(parseInt(this.router.url.split("/")[2])).subscribe(
      res => {
        this.service.getGenres();
        alert("Successfully deleted a movie");
        this.router.navigate(["/"]);
      },
      err => {
        console.log(err);
      }
    )
  }

  fileInputPoster(){
    // @ts-ignore: Object is possibly 'null'.
    this.fileToUploadPoster = (<HTMLInputElement>document.getElementById('poster')).files[0];
  }

  fileInputCover(){
    // @ts-ignore: Object is possibly 'null'.
    this.fileToUploadCover = (<HTMLInputElement>document.getElementById('cover')).files[0];
  }

  onSubmit(){
    let title = (<HTMLInputElement>document.getElementById('title')).value;
    let description = (<HTMLInputElement>document.getElementById('description')).value;
    let year = (<HTMLInputElement>document.getElementById('year')).value;
    let duration = (<HTMLInputElement>document.getElementById('duration')).value;
    let popularity = (<HTMLInputElement>document.getElementById('popularity')).value;
    let country = (<HTMLInputElement>document.getElementById('country')).value;
    let type = (<HTMLInputElement>document.getElementById('type')).value;

    var budgetArr = [];
    budgetArr.push(
      {
        "earning": 0,
        'budget': (<HTMLInputElement>document.getElementById('budget')).value
      }
    );


    let genres = $(".genres:checked");
    var genresArr = [];
    for(let i = 0; i < genres.length; i++){
      genresArr.push(
        {
          "movieId": 0,
          'genreId': (<HTMLInputElement>genres[i]).value,
        }
      );
    }

    this.service.putMovie(this.router.url.split("/")[2], title, description, year, duration, this.fileToUploadPoster, this.fileToUploadCover, popularity,
      country, type, genresArr, budgetArr).subscribe(
      res => {
        alert("Successfully updated a movie.");
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

}
