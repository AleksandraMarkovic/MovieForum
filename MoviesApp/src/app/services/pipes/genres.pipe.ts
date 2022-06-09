import { Pipe, PipeTransform } from '@angular/core';
import { SingleMovieGenres } from '../models/single-movie-genre';

@Pipe({
  name: 'genres'
})
export class GenresPipe implements PipeTransform {

  transform(value: Array<SingleMovieGenres>): any {
    let ispis = "";
    value.forEach((element, i) => {
      if(typeof element == "object"){
        i == 0 ? ispis += element.genre : ispis += ", " + element.genre
      }
      else {
        i == 0 ? ispis += element : ispis += ", " + element
      }
    })
  }

}
