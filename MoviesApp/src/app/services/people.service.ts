import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Movies } from './models/movies';
import { People } from './models/people';
import { Role } from './models/role';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/people"
  readonly roleUrl = "http://localhost:5000/api/roles"
  readonly movieUrl = "http://localhost:5000/api/movies"
  movies: Movies[];
  roles: Role[];
  people: People[];
  formData:People = new People();


  getMovies(){
    this.http.get(this.movieUrl)
    .toPromise()
    .then(res => this.movies = res as Movies[])
  }

  getRoles(){
    this.http.get(this.roleUrl)
    .toPromise()
    .then(res => this.roles = res as Role[])
  }

  getPeople(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.people = res as People[])
  }

  postPeople(firstName: string, lastName: string, bio: string, placeOfBirth: string, image: File, personRoleMovies: any[]){
    const formData: FormData = new FormData();
    formData.append("firstName", firstName);
    formData.append("lastName", lastName);
    formData.append("bio", bio);
    formData.append("placeOfBirth", placeOfBirth);
    formData.append("image", image, image?.name);
    for(let i =0; i < personRoleMovies.length; i ++){
      formData.append(`personRoleMovies[${i}].roleId`, personRoleMovies[i].roleId.toString());
      formData.append(`personRoleMovies[${i}].movieId`, personRoleMovies[i].movieId.toString());
    }
    
    return this.http.post(this.baseUrl, formData);
  }

  putPeople(id:string, firstName: string, lastName: string, bio: string, placeOfBirth: string, image: File, personRoleMovies: any[]){
    const formData: FormData = new FormData();
    formData.append("firstName", firstName);
    formData.append("lastName", lastName);
    formData.append("bio", bio);
    formData.append("placeOfBirth", placeOfBirth);
    formData.append("image", image, image?.name);
    for(let i =0; i < personRoleMovies.length; i ++){
      formData.append(`personRoleMovies[${i}].roleId`, personRoleMovies[i].roleId.toString());
      formData.append(`personRoleMovies[${i}].movieId`, personRoleMovies[i].movieId.toString());
    }
    
    return this.http.put(`${this.baseUrl}/${id}`, formData);
  }

  deleteGenre(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
