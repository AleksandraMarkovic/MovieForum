import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from './models/country';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/countries"
  formData:Country = new Country();
  countries : Country[];

  postCountries(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putCountries(){
    return this.http.put(`${this.baseUrl}/${this.formData.id}`, this.formData);
  }

  deleteCountries(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getCountries(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.countries = res as Country[])
  }
}
