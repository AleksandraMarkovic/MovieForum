import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ShowWatchlist } from './models/showWatchlist';

@Injectable({
  providedIn: 'root'
})
export class WatchlistService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = "http://localhost:5000/api/watchlists";
  watchlists : ShowWatchlist[];

  getWatchlist(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.watchlists = res as ShowWatchlist[])
  }

  deleteWatchlist(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
