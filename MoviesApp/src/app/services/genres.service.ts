import { Injectable } from '@angular/core';
import { Genres } from './models/genres';
import {HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/genres"
  formData:Genres = new Genres();
  genres : Genres[];

  postGenres(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putGenres(){
    return this.http.put(`${this.baseUrl}/${this.formData.id}`, this.formData);
  }

  deleteGenre(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getGenres(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.genres = res as Genres[])
  }


}
