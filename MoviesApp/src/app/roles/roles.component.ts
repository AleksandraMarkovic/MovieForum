import { Component, OnInit } from '@angular/core';
import { Role } from '../services/models/role';
import { RolesService } from '../services/roles.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {

  constructor(public service: RolesService) { }

  ngOnInit(): void {
    this.service.getRoles();
  }

  populateForm($event: any, selected: Role){
    $event.preventDefault();
    this.service.formData = Object.assign({}, selected);
  }

  onDelete($event: any, id: number){
    $event.preventDefault();
    this.service.deleteRoles(id).subscribe(
      res => {
        this.service.getRoles();
        alert("Successfully deleted a role");
      },
      err => {
        console.log(err);
      }
    )
  }

}
