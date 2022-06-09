export class People {
    id:number;
    firstName:string;
    lastName:string;
    bio:string;
    placeOfBirth:string;
    roleId: number;
    personRoleMovies: Array<PersonRoleMovies>;
}

class PersonRoleMovies {
    id:number;
    personId:number;
    roleId:number;
    movieId:number;
    role:string;
}