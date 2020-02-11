import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HeroHome } from '../models/hero';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private httpClient:HttpClient) {
  }

  getHomes(): Observable<Array<HeroHome>> {
    return this.httpClient.get<Array<HeroHome>>("https://localhost:44303/heroshomes/all");
  }
}
