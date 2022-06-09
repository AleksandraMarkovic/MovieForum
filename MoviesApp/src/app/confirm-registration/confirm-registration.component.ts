import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmRegistrationService } from '../services/confirm-registration.service';

@Component({
  selector: 'app-confirm-registration',
  templateUrl: './confirm-registration.component.html',
  styleUrls: ['./confirm-registration.component.css']
})
export class ConfirmRegistrationComponent implements OnInit {

  constructor(public service: ConfirmRegistrationService, public router: Router) { }

  ngOnInit(): void {
    this.service.putMovie(this.router.url.split("/")[2]).subscribe(
      res => {
        $("#titleConfirm").html("Success!");
        $("#textConfirm").html("You can login now: <a class='text-primary' routerLink='/login'>Login</a>");
      },
      err => {
        console.log(err)
      }
    )
  }

}
