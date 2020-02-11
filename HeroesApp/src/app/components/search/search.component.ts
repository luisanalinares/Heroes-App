import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HeroesService } from 'src/app/services/heroes.service';
import { Hero } from 'src/app/models/hero';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

  heroes:Hero[];
  term:string;

  constructor(private activatedRoute:ActivatedRoute, private heroesService:HeroesService,
  private router:Router) {     
  }
  
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.term = params['term'];
      this.heroesService.findHeroe(this.term).subscribe((heroes) => this.heroes = heroes);
    })
  }

  seeHero(id:number){
    this.router.navigate(['/hero', id]);
  }
}
