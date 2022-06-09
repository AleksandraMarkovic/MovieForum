import { Component, OnInit } from '@angular/core';
import { MovieGenres } from '../services/models/movieGenres';
import { MoviesFormService } from '../services/movies-form.service';

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.css']
})
export class MovieFormComponent implements OnInit {

  fileToUploadPoster: File;
  fileToUploadCover: File;
  moviegenres: MovieGenres = new MovieGenres();
  constructor(public service: MoviesFormService) { }

  ngOnInit(): void {
    this.service.getGenres();
    this.service.getCountries();
    this.service.getTypes();
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

    this.service.postMovies(title, description, year, duration, this.fileToUploadPoster, this.fileToUploadCover, popularity,
      country, type, genresArr, budgetArr).subscribe(
      res => {
        alert("Successfully added a new movie.");
      },
      err => {
        console.log(err);
      }
    )
  }
}
