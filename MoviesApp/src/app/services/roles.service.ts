import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Role } from './models/role';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/roles"
  formData:Role = new Role();
  roles : Role[];

  postRoles(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putRoles(){
    return this.http.put(`${this.baseUrl}/${this.formData.id}`, this.formData);
  }

  deleteRoles(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getRoles(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.roles = res as Role[])
  }
}
