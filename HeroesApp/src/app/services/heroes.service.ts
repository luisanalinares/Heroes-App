import { Injectable } from '@angular/core';
import { Hero } from '../models/hero';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../models/pagination';
import { PageInfo } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class HeroesService {

  constructor(private httpClient: HttpClient) {
  }

  getHeroes(): Observable<Array<Hero>> {
    return this.httpClient.get<Array<Hero>>("https://localhost:44303/heroes/all");
  }

  getHeroesPaginated(pageInfo : PageInfo): Observable<PaginatedResult<Hero>> {
    const params = new HttpParams()
    .set('pagesize', pageInfo.pageSize.toString())
    .set('pagenumber', pageInfo.pageNumber.toString())
    .set('orderby', pageInfo.orderBy)
    .set('sortdirection', pageInfo.sortDirection.toString());

    return this.httpClient.get<PaginatedResult<Hero>>("https://localhost:44303/heroes/paginated/", { params : params });
  }

  getHero(id: number): Observable<Hero> {
    return this.httpClient.get<Hero>("https://localhost:44303/heroes/getone/" + id);
  }

  findHeroe(term: string): Observable<Array<Hero>> {
    return this.httpClient.get<Array<Hero>>("https://localhost:44303/heroes/search?term=" + term);
  }

  saveHero(hero: Hero): Observable<Hero> {
    console.log(hero);
    return this.httpClient.post<Hero>("https://localhost:44303/heroes/save", hero);
  }
}
