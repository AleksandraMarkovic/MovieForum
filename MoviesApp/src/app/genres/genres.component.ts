import { Component, OnInit } from '@angular/core';
import { GenresService } from '../services/genres.service';
import { Genres } from '../services/models/genres';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  constructor(public service: GenresService) { }

  ngOnInit(): void {
    this.service.getGenres();
  }

  populateForm($event: any, selected: Genres){
    $event.preventDefault();
    this.service.formData = Object.assign({}, selected);
  }

  onDelete($event: any, id: number){
    $event.preventDefault();
    this.service.deleteGenre(id).subscribe(
      res => {
        this.service.getGenres();
        alert("Successfully deleted a genre");
      },
      err => {
        console.log(err);
      }
    )
  }

}
