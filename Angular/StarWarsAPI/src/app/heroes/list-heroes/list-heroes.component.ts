import { Component, OnInit } from '@angular/core';
import Hero from '../shared/hero.model';
import HeroService from '../shared/hero.service';
import {Observable} from 'rxjs';
import {debounceTime, distinctUntilChanged, map} from 'rxjs/operators';

@Component({
  selector: 'app-list-heroes',
  templateUrl: './list-heroes.component.html',
  styleUrls: ['./list-heroes.component.css']
})
export class ListHeroesComponent implements OnInit {
  hero: Array<Hero>;  
  

  public model: Hero;
//  formatMatches = (value: any) => value.name || 'heroName';
 formatter = (x: {nomeSpecie: string}) => x.nomeSpecie;

  search = (text$: Observable<string>) =>
  text$.pipe(
    debounceTime(400),
    distinctUntilChanged(), 
    map(term => term.length < 2 ? []
      : this.hero.filter(v => v.nomeSpecie.toLowerCase().indexOf(term.toLowerCase()) > -1).slice(0, 10))
  )
  clickedItem:string;

  selectedItem(item){
    this.clickedItem=item.item;
    console.log(item);
  }
  constructor(private heroservice: HeroService ) { }

  ngOnInit() {

    
    this.heroservice.getAll().subscribe(data => {
      this.hero = data;
      console.log(this.hero);

      return this.hero;
    })
  }

}
