import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeroesComponent } from './heroes/heroes.component';
import { HeroComponent } from './heroes/hero/hero.component';
import { ListHeroesComponent } from './heroes/list-heroes/list-heroes.component';
import { HomeComponent } from './heroes/home/home.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MenuComponent } from './heroes/menu/menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule, MatInputModule } from '@angular/material';
import { NgxTypeaheadModule } from 'ngx-typeahead';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    HeroesComponent,
    HeroComponent,
    ListHeroesComponent,
    HomeComponent,
    MenuComponent
  ],
  imports: [
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatInputModule,
    BrowserAnimationsModule,
    BrowserModule,
    NgxTypeaheadModule,
    HttpClientModule,
    MatAutocompleteModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'hero', component: HeroComponent },
      { path: 'list-heroes', component: ListHeroesComponent }
    ]),
    TypeaheadModule.forRoot()

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
