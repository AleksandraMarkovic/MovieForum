import { Component, OnInit } from '@angular/core';
import { People } from '../services/models/people';
import { PeopleService } from '../services/people.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {

  constructor(public service: PeopleService) { }

  ngOnInit(): void {
    this.service.getPeople();
  }

  populateForm($event: any, selected: People){
    $event.preventDefault();
    this.service.formData = Object.assign({}, selected);
  }

  onDelete($event: any, id: number){
    $event.preventDefault();
    this.service.deleteGenre(id).subscribe(
      res => {
        this.service.getPeople();
        alert("Successfully deleted a person");
      },
      err => {
        console.log(err);
      }
    )
  }


}
