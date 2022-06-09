import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  constructor(public service: MoviesService) { }

  ngOnInit(): void {
    this.service.getMovies();
  }

  addToWatchlist(id: number){
    this.service.watchlistPost(id).subscribe(
      res => {
        alert("Successfully added to watchlist")
        window.location.reload;
      },
      err => {
        console.log(err)
      }
    )
  }

}
