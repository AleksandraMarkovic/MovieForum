import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from './models/country';
import { Genres } from './models/genres';
import { MovieGenres } from './models/movieGenres';
import { Type } from './models/type';

@Injectable({
  providedIn: 'root'
})
export class MoviesFormService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/movies"
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

  postMovies(title: string, description: string, year: string, duration: string, poster: File, coverImg: File, popularity: string, 
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
    
    return this.http.post(this.baseUrl, formData);
  }
}
