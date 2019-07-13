import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import  Hero  from './hero.model';

@Injectable({
  providedIn: 'root'
})
export default class HeroService {
  public API = 'http://localhost:8080/api';

  public VIAJARBARATO_API = `${this.API}/list`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Hero>> {
    return this.http.get<Array<Hero>>(this.VIAJARBARATO_API);
    
  } 
}