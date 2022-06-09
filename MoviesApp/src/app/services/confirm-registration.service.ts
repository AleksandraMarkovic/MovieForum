import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfirmRegistrationService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/confirmRegistration"


  putMovie(id:string){
    return this.http.put(`${this.baseUrl}/${id}`, {});
  }
}
