import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { GenresComponent } from './genres/genres.component';
import { GenresFormComponent } from './genres/genres-form/genres-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersComponent } from './users/users.component';
import { AppRoutingModule } from './app-routing.module';
import { MenuComponent } from './menu/menu.component';
import { TypesComponent } from './types/types.component';
import { TypesFormComponent } from './types/types-form/types-form.component';
import { CountriesComponent } from './countries/countries.component';
import { CountriesFormComponent } from './countries/countries-form/countries-form.component';
import { RolesComponent } from './roles/roles.component';
import { RolesFormComponent } from './roles/roles-form/roles-form.component';
import { SingleMovieComponent } from './single-movie/single-movie.component';
import { GenresPipe } from './services/pipes/genres.pipe';
import { ImageComponent } from './image/image.component';
import { MovieFormComponent } from './movie-form/movie-form.component';
import { WatchlistComponent } from './watchlist/watchlist.component';
import { LoginComponent } from './login/login.component';
import { PeopleComponent } from './people/people.component';
import { PeopleFormComponent } from './people/people-form/people-form.component';
import { ConfirmRegistrationComponent } from './confirm-registration/confirm-registration.component';

export function tokenGetter(){
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    GenresComponent,
    GenresFormComponent,
    UsersComponent,
    MenuComponent,
    TypesComponent,
    TypesFormComponent,
    CountriesComponent,
    CountriesFormComponent,
    RolesComponent,
    RolesFormComponent,
    SingleMovieComponent,
    GenresPipe,
    ImageComponent,
    MovieFormComponent,
    WatchlistComponent,
    LoginComponent,
    PeopleComponent,
    PeopleFormComponent,
    ConfirmRegistrationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5000"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
