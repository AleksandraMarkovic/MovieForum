import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/users"

  postUsers(firstName: string, lastName: string, email: string, username: string, password: string, birthday: string, fileToUpload: File){
    const formData: FormData = new FormData();
    formData.append("firstName", firstName);
    formData.append("lastName", lastName);
    formData.append("email", email);
    formData.append("username", username);
    formData.append("password", password);
    formData.append("birthday", birthday);
    formData.append("image", fileToUpload, fileToUpload?.name);
    return this.http.post(this.baseUrl, formData);
  }
}
