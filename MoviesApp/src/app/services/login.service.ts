import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from './models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/token"
  formData:Login = new Login();

  login(){
    return this.http.post(this.baseUrl, this.formData);
  }
}
