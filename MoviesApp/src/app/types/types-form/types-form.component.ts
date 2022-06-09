import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Type } from 'src/app/services/models/type';
import { TypesService } from 'src/app/services/types.service';

@Component({
  selector: 'app-types-form',
  templateUrl: './types-form.component.html',
  styleUrls: ['./types-form.component.css']
})
export class TypesFormComponent implements OnInit {

  constructor(public service: TypesService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.insertType(form);
    else
      this.updateType(form);
  }

  insertType(form: NgForm){
    this.service.postTypes().subscribe(
      res => {
        this.resetForm(form);
        this.service.getTypes();
        alert("Successfully added a new type")
      },
      err => {
        console.log(err)
      }
    )
  }

  updateType(form: NgForm){
    this.service.putTypes().subscribe(
      res => {
        this.resetForm(form);
        this.service.getTypes();
        alert("Successfully updated a type")
      },
      err => {
        console.log(err)
      }
    )
  }

  resetForm(form: NgForm){
    form.form.reset;
    this.service.formData = new Type();
  }

 
}
