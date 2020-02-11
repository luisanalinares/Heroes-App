import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeroesService } from 'src/app/services/heroes.service';
import { Hero } from 'src/app/models/hero';


@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html'
})
export class HeroDetailComponent implements OnInit {  

  hero : Hero;
  
  constructor(private router:ActivatedRoute, private heroesService: HeroesService) {    
  }

  ngOnInit() {
    this.router.params.subscribe((data) => {
       this.heroesService.getHero(data.id).subscribe((hero) => this.hero = hero);
    })
  }

}
