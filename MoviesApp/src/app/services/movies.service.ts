import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Movies } from './models/movies';
import { Watchlist } from './models/watchlist';
import { MovieLogic } from './models/movieLogic';
import { SingleMovie } from './models/single-movie';
import { MovieComment } from './models/comment';
import { Router } from '@angular/router';
import { Rating } from './models/rating';
import { Genres } from './models/genres';
import { Country } from './models/country';
import { Type } from './models/type';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor(private http: HttpClient, public router: Router) { }

  readonly baseUrl = "http://localhost:5000/api/movies"
  readonly commentUrl = "http://localhost:5000/api/comments"
  readonly ratingUrl = "http://localhost:5000/api/ratings"
  readonly watchlistUrl = "http://localhost:5000/api/watchlists"
  movies: Movies[];
  singleMovie: SingleMovie[];
  formData: MovieComment = new MovieComment();
  formDataRating: Rating = new Rating();
  formDataWatchlist: Watchlist = new Watchlist();
  id = parseInt(this.router.url.split("/")[2]);
  readonly genresUrl = "http://localhost:5000/api/genres"
  readonly countriesUrl = "http://localhost:5000/api/countries"
  readonly typesUrl = "http://localhost:5000/api/types"
  genres : Genres[];
  countries : Country[];
  types : Type[];


  getGenres(){
    this.http.get(this.genresUrl)
    .toPromise()
    .then(res => this.genres = res as Genres[])
  }

  getCountries(){
    this.http.get(this.countriesUrl)
    .toPromise()
    .then(res => this.countries = res as Country[])
  }

  getTypes(){
    this.http.get(this.typesUrl)
    .toPromise()
    .then(res => this.types = res as Type[])
  }

  getMovies(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.movies = res as Movies[])
  }

  getSingleMovie(id: number){
    this.http.get(`${this.baseUrl}/${id}`)
    .toPromise()
    .then(res => this.singleMovie = res as SingleMovie[])
  }

  postComment(){
    this.formData.movieId = this.id;
    return this.http.post(this.commentUrl, this.formData);
  }

  postRating(){
    this.formDataRating.movieId = this.id;
    return this.http.post(this.ratingUrl, this.formDataRating);
  }

  watchlistPost(id: number){
    this.formDataWatchlist.movieId = id;
    return this.http.post(this.watchlistUrl, this.formDataWatchlist);
  }

  putMovie(id:string, title: string, description: string, year: string, duration: string, poster: File, coverImg: File, popularity: string, 
    countryId: string, typeId: string, movieGenres: any[], finances: any[]){
    const formData: FormData = new FormData();
    formData.append("title", title);
    formData.append("description", description);
    formData.append("year", year);
    formData.append("duration", duration);
    formData.append("poster", poster, poster?.name);
    formData.append("coverImg", coverImg, coverImg?.name);
    formData.append("popularity", popularity);
    formData.append("countryId", countryId);
    formData.append("typeId", typeId);
    for(let i =0; i < movieGenres.length; i ++){
      formData.append(`movieGenres[${i}].genreId`, movieGenres[i].genreId.toString());
      formData.append(`movieGenres[${i}].movieId`, movieGenres[i].movieId.toString());
    }
    for(let i =0; i < finances.length; i ++){
      formData.append(`finances[${i}].earning`, finances[i].earning.toString());
      formData.append(`finances[${i}].budget`, finances[i].budget.toString());
    }
    
    return this.http.put(`${this.baseUrl}/${id}`, formData);
  }


  deleteMovie(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
