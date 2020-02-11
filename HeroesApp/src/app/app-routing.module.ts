import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { HomeComponent } from './components/home/home.component';
import { HeroCardComponent } from './components/hero-card/hero-card.component';
import { HeroDetailComponent } from './components/hero-detail/hero-detail.component';
import { AboutComponent } from './components/about/about.component';
import { HeroesComponent } from './components/heroes/heroes.component';
import { SearchComponent } from './components/search/search.component';
import { NewHeroComponent } from './components/newhero/newhero.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'heroes', component: HeroesComponent },
    { path: 'hero/:id', component: HeroDetailComponent },
    { path: 'search/:term', component: SearchComponent },
    { path: 'newhero', component: NewHeroComponent },
    { path: '**', pathMatch:'full', redirectTo:'home' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
