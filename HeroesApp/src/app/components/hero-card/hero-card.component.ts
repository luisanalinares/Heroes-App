import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Hero } from 'src/app/models/hero';

@Component({
  selector: 'app-hero-card',
  templateUrl: './hero-card.component.html'
})
export class HeroCardComponent implements OnInit {

  @Input() hero:Hero;
  @Output() selectedHero:EventEmitter<number>;

  constructor() { 
    this.selectedHero = new EventEmitter();
  }

  ngOnInit() {
  }

  seeHero(){
    this.selectedHero.emit(this.hero.id);
  }

}
