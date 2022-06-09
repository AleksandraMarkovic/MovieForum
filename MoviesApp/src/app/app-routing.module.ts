import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';
import { GenresComponent } from './genres/genres.component';
import { TypesComponent } from './types/types.component';
import { CountriesComponent } from './countries/countries.component';
import { RolesComponent } from './roles/roles.component';
import { SingleMovieComponent } from './single-movie/single-movie.component';
import { UsersComponent } from './users/users.component';
import { MovieFormComponent } from './movie-form/movie-form.component';
import { WatchlistComponent } from './watchlist/watchlist.component';
import { LoginComponent } from './login/login.component';
import { PeopleComponent } from './people/people.component';
import { AuthGuard } from './guards/auth-guard.service';
import { ConfirmRegistrationComponent } from './confirm-registration/confirm-registration.component';


const routes: Routes = [
  {path: '', component: MoviesComponent},
  {path: 'movies/:id', component: SingleMovieComponent},
  {path: 'genres', component: GenresComponent},
  {path: 'types', component: TypesComponent},
  {path: 'countries', component: CountriesComponent},
  {path: 'roles', component: RolesComponent},
  {path: 'users', component: UsersComponent},
  {path: 'moviesAdmin', component: MovieFormComponent},
  {path: 'watchlist', component: WatchlistComponent},
  {path: 'login', component: LoginComponent},
  {path: 'people', component: PeopleComponent},
  {path: 'confirmRegistration/:id', component: ConfirmRegistrationComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
