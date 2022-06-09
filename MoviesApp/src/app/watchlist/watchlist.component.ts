import { Component, OnInit } from '@angular/core';
import { WatchlistService } from '../services/watchlist.service';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {

  constructor(public service: WatchlistService) { }

  ngOnInit(): void {
    this.service.getWatchlist();
  }

  delete(id: number){
    this.service.deleteWatchlist(id).subscribe(
      res => {
        alert("Successfully removed from watchlist");
        this.service.getWatchlist();
      },
      err => {
        console.log(err);
      }
    )
  }

}
