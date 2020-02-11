import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeroesService } from 'src/app/services/heroes.service';
import { Hero } from 'src/app/models/hero';
import { PageInfo, SortDirection } from 'src/app/models/pagination';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html'
})
export class HeroesComponent implements OnInit {

  /*heroes : Hero[];*/
  paginatedHeroes: Hero[];
  pageSize: number = 3;
  pageNumber: number = 0;
  pages: number[] = [];

  constructor(private heroesService: HeroesService, private router: Router) {
  }

  ngOnInit() {
    this.getPage(0);
  }


  seeHero(id: number) {
    this.router.navigate(['/hero', id]);
  }

  getPage(pageNumber: number) {
    let pageInfo = {
      pageSize: this.pageSize,
      pageNumber: pageNumber + 1,
      orderBy: 'Name',
      sortDirection: SortDirection.Ascending
    };

    this.heroesService.getHeroesPaginated(pageInfo).subscribe((data) => {
      this.paginatedHeroes = data.entities;
      this.pageNumber = pageNumber;

      this.pages = [];
      let pageCount = Math.ceil(data.count / this.pageSize);

      for (let i = 0; i < pageCount; i++) {
        this.pages.push(i);
      }
    });
  }

}
