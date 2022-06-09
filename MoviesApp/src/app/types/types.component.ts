import { Component, OnInit } from '@angular/core';
import { Type } from '../services/models/type';
import { TypesService } from '../services/types.service';

@Component({
  selector: 'app-types',
  templateUrl: './types.component.html',
  styleUrls: ['./types.component.css']
})
export class TypesComponent implements OnInit {

  constructor(public service: TypesService) { }

  ngOnInit(): void {
    this.service.getTypes();
  }

  populateForm($event: any, selected: Type){
    $event.preventDefault();
    this.service.formData = Object.assign({}, selected);
  }

  onDelete($event: any, id: number){
    $event.preventDefault();
    this.service.deleteType(id).subscribe(
      res => {
        this.service.getTypes();
        alert("Successfully deleted a type");
      },
      err => {
        console.log(err);
      }
    )
  }

}
