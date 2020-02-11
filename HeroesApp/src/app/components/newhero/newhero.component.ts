import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HomeService } from 'src/app/services/home.service';
import { HeroHome, Hero } from 'src/app/models/hero';
import { HeroesService } from 'src/app/services/heroes.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newhero',
  templateUrl: './newhero.component.html',
  styleUrls: ['./newhero.component.css']
})
export class NewHeroComponent implements OnInit {

  form : FormGroup;
  homes : Array<HeroHome>;

  constructor(public formBuilder : FormBuilder, private homeService : HomeService, 
    private heroService:HeroesService, private router : Router) { }

  ngOnInit() {

    this.homeService.getHomes().subscribe(response => this.homes = response);

    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      bio: [''],
      image: [''],
      firstAppearance: [''],
      homeId: ['']
    });
  }

  controlHasError(controlName:string, validationName:string):boolean{
    
    let formControl = this.form.get(controlName);

    return formControl.errors && formControl.dirty && formControl.hasError(validationName);
  }

  submit(){
    
    if(this.form.valid){

      let hero : Hero = {
        id : 0,
        name: this.form.value.name,
        bio: this.form.value.bio,
        image: this.form.value.image,
        firstAppearance: new Date(this.form.value.firstAppearance.year, this.form.value.firstAppearance.month-1, this.form.value.firstAppearance.day),
        homeId: this.form.value.homeId,
        home : null
      };

      this.heroService.saveHero(hero).subscribe(() => this.router.navigate(['./heroes']));      
    }    
  }

}
