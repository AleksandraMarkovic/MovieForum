import { BuiltinMethod } from "@angular/compiler";
import { People } from "./people";
import { SingleMovieGenres } from "./single-movie-genre";


export class SingleMovie {
    id:number;
    title:string;
    description:string;
    duration:number;
    year:number;
    poster:string;
    coverImg:string;
    country:string;
    countryId:number;
    type:string;
    typeId:number;
    movieGenres: Array<SingleMovieGenres>;
    people: Array<People>;
    rating:number;
    popularity:number;
    finances: Array<Finances>;
}

class Finances {
    id:number;
    movieId:number;
    budget:number;
    earning:number;
}