import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Type } from './models/type';

@Injectable({
  providedIn: 'root'
})
export class TypesService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/types"
  formData:Type = new Type();
  types : Type[];

  postTypes(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putTypes(){
    return this.http.put(`${this.baseUrl}/${this.formData.id}`, this.formData);
  }


  deleteType(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getTypes(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.types = res as Type[])
  }
}
