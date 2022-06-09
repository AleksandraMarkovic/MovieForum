import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { retry } from 'rxjs';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  isUserAuthenticated(){
    const token: string | null = localStorage.getItem("jwt");
    if(token){
      return true;
    }
    else {
      return false;
    }
  }

  logout($event: any){
    $event.preventDefault();
    localStorage.removeItem("jwt");
    alert("Successfully logged out!");
    this.router.navigate(["/"]);
  }

}
