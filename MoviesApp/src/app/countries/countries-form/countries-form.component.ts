import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CountriesService } from 'src/app/services/countries.service';
import { Country } from 'src/app/services/models/country';

@Component({
  selector: 'app-countries-form',
  templateUrl: './countries-form.component.html',
  styleUrls: ['./countries-form.component.css']
})
export class CountriesFormComponent implements OnInit {

  constructor(public service: CountriesService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    if(this.service.formData.id == 0)
      this.insertCountry(form);
    else
      this.updateCountry(form);
  }

  insertCountry(form: NgForm){
    this.service.postCountries().subscribe(
      res => {
        this.resetForm(form);
        this.service.getCountries();
        alert("Successfully added a new country")
      },
      err => {
        console.log(err)
      }
    )
  }

  updateCountry(form: NgForm){
    this.service.putCountries().subscribe(
      res => {
        this.resetForm(form);
        this.service.getCountries();
        alert("Successfully updated a country")
      },
      err => {
        console.log(err)
      }
    )
  }

  resetForm(form: NgForm){
    form.form.reset;
    this.service.formData = new Country();
  }

}
