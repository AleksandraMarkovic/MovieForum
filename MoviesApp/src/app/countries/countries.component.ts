import { Component, OnInit } from '@angular/core';
import { CountriesService } from '../services/countries.service';
import { Country } from '../services/models/country';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})
export class CountriesComponent implements OnInit {

  constructor(public service: CountriesService) { }

  ngOnInit(): void {
    this.service.getCountries();
  }

  populateForm($event: any, selected: Country){
    $event.preventDefault();
    this.service.formData = Object.assign({}, selected);
  }

  onDelete($event: any, id: number){
    $event.preventDefault();
    this.service.deleteCountries(id).subscribe(
      res => {
        this.service.getCountries();
        alert("Successfully deleted a country");
      },
      err => {
        console.log(err);
      }
    )
  }

}
