import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Role } from 'src/app/services/models/role';
import { RolesService } from 'src/app/services/roles.service';

@Component({
  selector: 'app-roles-form',
  templateUrl: './roles-form.component.html',
  styleUrls: ['./roles-form.component.css']
})
export class RolesFormComponent implements OnInit {

  constructor(public service: RolesService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    if(this.service.formData.id == 0)
      this.insertRole(form);
    else
      this.updateRole(form);
  }

  insertRole(form: NgForm){
    this.service.postRoles().subscribe(
      res => {
        this.resetForm(form);
        this.service.getRoles();
        alert("Successfully added a new role")
      },
      err => {
        console.log(err)
      }
    )
  }

  updateRole(form: NgForm){
    this.service.putRoles().subscribe(
      res => {
        this.resetForm(form);
        this.service.getRoles();
        alert("Successfully updated a role")
      },
      err => {
        console.log(err)
      }
    )
  }

  resetForm(form: NgForm){
    form.form.reset;
    this.service.formData = new Role();
  }

}
